using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GeniusBar.Models;

namespace GeniusBar.Controllers
{
    public class DispatchTakeController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        private User getCooikedUser()
        {
            // To be implemented 
            // throw new System.NotImplementedException();

            var cookie = System.Web.HttpContext.Current.Request.Cookies["GB"];
            var user = db.Users.Where(e => e.COOKIE == cookie.Value).FirstOrDefault();
            return user;
        }
        public class dispatchInfo
        {
            public int orderID;
            public int engineerID;
        }

        [HttpPut]
        [Route("api/dispatcher/repair")]

        public IHttpActionResult DispatchRepairOrder(dispatchInfo info)
        {
            var order = db.RepairOrders.Find(info.orderID);
            var engineer = db.Users.Find(info.engineerID);
            if(order==null || engineer== null || engineer.Role_ID != 2)
            {
                return NotFound();
            }
            order.Engineer_ID = info.engineerID;
            order.State = RepairOrderState.ASSIGNED;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/dispatcher/recycle")]

        public IHttpActionResult DispatchRecycleOrder(dispatchInfo info)
        {
            var order = db.RecycleOrders.Find(info.orderID);
            var engineer = db.Users.Find(info.engineerID);
            if (order == null || engineer == null ||engineer.Role_ID!=2)
            {
                return NotFound();
            }
            order.Engineer_ID = info.engineerID;
            order.State = RecycleOrderState.ASSIGNED;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/engineer/undispatchedRecycle")]
        public IHttpActionResult GetUnassignedRecycleOrder()
        {
            var orders = db.RecycleOrders.Where(s => s.State == RecycleOrderState.ORDERED).ToList<RecycleOrder>();
            return Ok(orders);
        }

        [HttpGet]
        [Route("api/engineer/undispatchedRepair")]
        public IHttpActionResult GetUnassignedRepairOrder()
        {
            var orders = db.RepairOrders.Where(s => s.State > RepairOrderState.PAID).ToList<RepairOrder>();
            return Ok(orders);
        }

        [HttpGet]
        [Route("api/engineer/repair")]

        public IHttpActionResult getPersonalRepairOrder()
        {
            var user = getCooikedUser();
            var orders = db.RepairOrders.Where(s => s.Engineer_ID == user.ID).ToList<RepairOrder>() ;
            return Ok(orders);
        }

        [HttpGet]
        [Route("api/engineer/recycle")]

        public IHttpActionResult GetPersonalRecycleOrder()
        {
            var user = getCooikedUser();
            var orders = db.RecycleOrders.Where(s => s.Engineer_ID == user.ID).ToList<RecycleOrder>();
            return Ok(orders);
        }


        [HttpPut]
        [Route("api/engineer/recycle/{id}")]
        public IHttpActionResult TakeRecycleOrder(int id)
        {
            var engineer = getCooikedUser();


            var order = db.RecycleOrders.Find(id);

            if (order == null || order.State != RecycleOrderState.ORDERED)
            {
                return NotFound();
            }
            order.State = RecycleOrderState.ASSIGNED;
            order.Engineer_ID = engineer.ID;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/engineer/repair/{id}")]
        public IHttpActionResult TakeRepairOrder(int id)
        {
            var engineer = getCooikedUser();

            var order = db.RepairOrders.Find(id);

            if (order ==null || order.State > RepairOrderState.PAID)
            {
                return NotFound();
            }
            order.State = RepairOrderState.ASSIGNED;
            order.Engineer_ID = engineer.ID;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
