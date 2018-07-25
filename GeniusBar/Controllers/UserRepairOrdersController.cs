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
    public class UserRepairOrdersController : ApiController
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
            public string Staff_note;
            public decimal Price;
            public byte State;
            public string Loc_name;
            public string Loc_detail;
            public List<int> Choices;
            
        }
        
        // GET: api/user/repair_orders
        [Route("api/user/repair_orders")]
        [HttpGet]
        [ResponseType(typeof(RepairOrder))]
        public IHttpActionResult GetUserRepairOrders()
        {
            User cookiedUser = getCooikedUser();
            
            Console.WriteLine(cookiedUser.ID);

            return Ok(db.RepairOrders.Where(e => e.Customer_ID == cookiedUser.ID).ToList<RepairOrder>());
        }
        
        // GET: api/user/repair_order/5
        [Route("api/user/repair_order/{id}", Name="GetUserRepairOrder")]
        [ResponseType(typeof(RepairOrder))]
        public IHttpActionResult GetUserRepairOrder(int id)
        {
            User cookiedUser = getCooikedUser();
            var repairOrder = db.RepairOrders.FirstOrDefault(u => (u.Customer_ID == cookiedUser.ID) && (u.ID == id));
            if (repairOrder == null)
            {
                return NotFound();
            }

            return Ok(repairOrder);
        }
        
        

        
        public class OrderUpdateData 
        {
            public string Customer_note;
            public string Staff_note;
            public decimal Price;
            public byte State;
            public string Loc_name;
            public string Loc_detail;
        }

        
        // PUT: api/user/repair_order/{id}
        [Route("api/user/repair_order/{id}")]
        [HttpPut]
        [ResponseType(typeof(RepairOrder))]
        public IHttpActionResult PutUserRepairOrder(int id, OrderUpdateData repairOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = db.RepairOrders.Find(id);
            
            if (order.Customer_ID != getCooikedUser().ID)
            {
                return Unauthorized();
            }

            order.Customer_note = repairOrder.Customer_note;
            order.Staff_note = repairOrder.Staff_note;
            order.Price = repairOrder.Price;
            order.State = repairOrder.State;
            order.Loc_detail = repairOrder.Loc_detail;
            order.Loc_name = repairOrder.Loc_name;
            
            

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrderExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);            

        }
        
        
        // POST: api/user/repair_order/
        [Route("api/user/repair_order/")]
        [HttpPost]
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult PostUserAddress(OrderData repairOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (getCooikedUser() == null)
            {
                return Unauthorized();
            }
            
            RepairOrder order = new RepairOrder();
            order.Create_time = System.DateTime.Now;
            order.Service_time = System.DateTime.Now;
            order.Customer_note = repairOrder.Customer_note;
            order.Staff_note = repairOrder.Staff_note;
            order.Price = repairOrder.Price;
            order.State = repairOrder.State;
            order.Loc_name = repairOrder.Loc_name;
            order.Loc_detail = repairOrder.Loc_detail;
            order.Customer_ID = getCooikedUser().ID;
            order.Engineer_ID = null;
            
            
            

            var entry = db.RepairOrders.Add(order);
            db.SaveChanges();

            db.Entry(order).GetDatabaseValues();
            
            Console.WriteLine(order.ID);
            
            foreach (var choice in repairOrder.Choices)
                       {
                           var repairOrderRepairChoice =
                               new RepairOrder_RepairChoice
                               {
                                   Rep_choice_ID = choice,
                                   Rep_order_ID = order.ID
                               };
           
                           db.RepairOrder_RepairChoice.Add(repairOrderRepairChoice);
                           db.SaveChanges();
                       }
           
                       
                      
            

            return CreatedAtRoute("GetUserRepairOrder", new { id = order.ID }, order);
        }


        // GET: api/user/repair_choice
        [Route("api/user/repair_choice/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserRepairChoice(int id)
        {
            var re = db.RepairOrder_RepairChoice.Where(e => e.Rep_order_ID == id).Include("RepairChoice");
            return Ok(re.ToList());
        }
        
        public class StateUpdate
        {
            public byte State;
        }
        
        // PUT: api/user/repair_status_update
        [Route("api/user/repair_status_update/{id}")]
        [HttpPut]
        public IHttpActionResult RepairStatusUpdate(int id, StateUpdate s)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = db.RepairOrders.Find(id);
            
            if (order.Customer_ID != getCooikedUser().ID)
            {
                return Unauthorized();
            }

            order.State = s.State;

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrderExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return StatusCode(HttpStatusCode.OK);
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepairOrderExists(int id)
        {
            return db.RepairOrders.Count(e => e.ID == id) > 0;
        }


    }
}