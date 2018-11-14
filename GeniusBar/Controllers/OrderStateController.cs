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
    public class OrderStatusController : ApiController
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
        public class stateData
        {
            public int State;
        }
        [Route("api/admin/recycleOrderState/{id}")]
        [HttpPut]
        public IHttpActionResult EditRecycleOrderState(int id, stateData state)
        {

            var order = db.RecycleOrders.Find(id);
            if(order == null)
            {
                return NotFound();
            }
            if(!Enum.IsDefined(typeof(RecycleOrderState),state.State))
            {
                return NotFound();
            }
            order.State = (RecycleOrderState)state.State;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }

        
        [Route("api/admin/repairOrderState/{id}")]
        [HttpPut]
        public IHttpActionResult EditRepairOrderState(int id, stateData state)
        {

            var order = db.RepairOrders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            if (!Enum.IsDefined(typeof(RepairOrderState), state.State))
            {
                return NotFound();
            }
            order.State = (RepairOrderState)state.State;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/engineer/recycleOrderState/{id}")]
        [HttpPut]
        public IHttpActionResult EditEngineerRecycleOrderState(int id, stateData state)
        {
            var user = getCooikedUser();
            var order = db.RecycleOrders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            if (!Enum.IsDefined(typeof(RecycleOrderState), state.State))
            {
                return NotFound();
            }
            if(user.ID!=order.Engineer_ID)
            {
                return NotFound();
            }
            order.State = (RecycleOrderState)state.State;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }

        [Route("api/engineer/repairOrderState/{id}")]
        [HttpPut]
        public IHttpActionResult EditEngineerRepairOrderState(int id, stateData state)
        {
            var user = getCooikedUser();
            var order = db.RepairOrders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            if (!Enum.IsDefined(typeof(RepairOrderState), state.State))
            {
                return NotFound();
            }
            if (user.ID != order.Engineer_ID)
            {
                return NotFound();
            }
            order.State = (RepairOrderState)state.State;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }
    }

 
    
}
