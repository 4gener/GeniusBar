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
    public class UserRecycleOrdersController : ApiController
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
        
        public class OrderData
        {
            public string Customer_note;
            public DateTime Service_time;
            public string Staff_note;
            public decimal Price;
            public RecycleOrderState State;
            public string Loc_name;
            public string Loc_detail;
            public List<int> Choices;
            
        }
        
        // GET: api/user/recycle_orders
        [Route("api/user/recycle_orders")]
        [HttpGet]
        [ResponseType(typeof(RecycleOrder))]
        public IHttpActionResult GetUserRecycleOrders()
        {
            User cookiedUser = getCooikedUser();
            
            Console.WriteLine(cookiedUser.ID);

            return Ok(db.RecycleOrders.Where(e => e.Customer_ID == cookiedUser.ID).ToList<RecycleOrder>());
        }
        
        // GET: api/user/recycle_order/5
        [Route("api/user/recycle_order/{id}", Name="GetUserRecycleOrder")]
        [ResponseType(typeof(RecycleOrder))]
        public IHttpActionResult GetUserRecycleOrder(int id)
        {
            User cookiedUser = getCooikedUser();
            var recycleOrder = db.RecycleOrders.FirstOrDefault(u => (u.Customer_ID == cookiedUser.ID) && (u.ID == id));
            if (recycleOrder == null)
            {
                return NotFound();
            }

            return Ok(recycleOrder);
        }

        public class OrderUpdateData
        {
            public DateTime Service_time;
            public string Customer_note;
            public string Staff_note;
            public decimal Price;
            public RecycleOrderState State;
            public string Loc_name;
            public string Loc_detail;
        }

        public class timeData
        {
            public DateTime Service_time;
        }
        
        // PUT: api/user/recycle_order/{id}
        [Route("api/user/recycle_order_service_time/{id}")]
        [HttpPut]
        [ResponseType(typeof(RecycleOrder))]
        public IHttpActionResult PutRecycleOrderTIme(int id, timeData recycleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = db.RecycleOrders.Find(id);
            var cookieUser = getCooikedUser();

            if (order.Customer_ID != cookieUser.ID && cookieUser.Role_ID != 3 &&(order.Engineer_ID != cookieUser.ID))
            {
                return Unauthorized();
            }


            order.Service_time = recycleOrder.Service_time;

            
            

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecycleOrderExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return Ok(order);            

        }

        
        // PUT: api/user/recycle_order/{id}
        [Route("api/user/recycle_order/{id}")]
        [HttpPut]
        [ResponseType(typeof(RecycleOrder))]
        public IHttpActionResult PutUserRecycleOrder(int id, OrderUpdateData recycleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = db.RecycleOrders.Find(id);
            var cookieUser = getCooikedUser();

            if (order.Customer_ID != cookieUser.ID && cookieUser.Role_ID != 3 && (order.Engineer_ID != cookieUser.ID))
            {
                return Unauthorized();
            }

            order.Customer_note = recycleOrder.Customer_note;
            order.Service_time = recycleOrder.Service_time;
            order.Staff_note = recycleOrder.Staff_note;
            order.Price = recycleOrder.Price;
            order.State = recycleOrder.State;
            order.Loc_detail = recycleOrder.Loc_detail;
            order.Loc_name = recycleOrder.Loc_name;
            
            

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecycleOrderExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);            

        }
        
        
        // POST: api/user/recycle_order/
        [Route("api/user/recycle_order/")]
        [HttpPost]
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult PostUserAddress(OrderData recycleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (getCooikedUser() == null)
            {
                return Unauthorized();
            }
            
            RecycleOrder order = new RecycleOrder();
            order.Create_time = System.DateTime.Now;
            order.Service_time = recycleOrder.Service_time;
            order.Customer_note = recycleOrder.Customer_note;
            order.Staff_note = recycleOrder.Staff_note;
            order.Price = recycleOrder.Price;
            order.State = recycleOrder.State;
            order.Loc_name = recycleOrder.Loc_name;
            order.Loc_detail = recycleOrder.Loc_detail;
            order.Customer_ID = getCooikedUser().ID;
            order.Engineer_ID = null;
            
            
            

            var entry = db.RecycleOrders.Add(order);
            db.SaveChanges();

            db.Entry(order).GetDatabaseValues();
            
            Console.WriteLine(order.ID);
            
            foreach (var choice in recycleOrder.Choices)
            {
                var recycleOrderRecycleEvaluationChoice =
                    new RecycleOrder_RecycleEvaluatonChoice
                    {
                        Rec_eval_choice_ID = choice,
                        Rec_order_ID = order.ID
                    };

                db.RecycleOrder_RecycleEvaluatonChoice.Add(recycleOrderRecycleEvaluationChoice);
                db.SaveChanges();
            }
           
            

            return CreatedAtRoute("GetUserRecycleOrder", new { id = order.ID }, order);
        }
        
        
        

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecycleOrderExists(int id)
        {
            return db.RecycleOrders.Count(e => e.ID == id) > 0;
        }


    }
}