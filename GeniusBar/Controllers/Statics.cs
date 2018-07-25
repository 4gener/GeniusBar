
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.WebPages;
using GeniusBar.Models;

namespace GeniusBar.Controllers
{
    public class StaticsController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

   
        // GET: /api/data/repair_amount/
        [Route("api/data/repair_amount/")]
        [HttpGet]
        public IHttpActionResult GetUserRepairAmount()
        {
            var re = db.RepairOrders
                .GroupBy(e => new {e.Customer_ID, e.Price})
                .Select(g => new
                {
                    ID = g.Key.Customer_ID,
                    count = g.Count(),
                    tot_price = g.Sum(e => e.Price)
                })
                .Join(db.Users, a=>a.ID, b=>b.ID, (a,b)=>new {a.ID, b.Name, a.count, a.tot_price});
            return Ok(re.ToList());
        }
        
        // GET: /api/data/recycle_amount/
        [Route("api/data/recycle_amount/")]
        [HttpGet]
        public IHttpActionResult GetUserRecycleAmount()
        {
            var re = db.RecycleOrders
                .GroupBy(e => new {e.Customer_ID, e.Price})
                .Select(g => new
                {
                    ID = g.Key.Customer_ID,
                    count = g.Count(),
                    tot_price = g.Sum(e => e.Price)
                })
                .Join(db.Users, a=>a.ID, b=>b.ID, (a,b)=>new {a.ID, b.Name, a.count, a.tot_price});
            return Ok(re.ToList());
        }
        
        // GET: /api/data/recycle_engineer_amount/
        [Route("api/data/recycle_engineer_amount/")]
        [HttpGet]
        public IHttpActionResult GetEngineerRecycleAmount()
        {
            var re = db.RecycleOrders
                .GroupBy(e => new {e.Engineer_ID, e.Price})
                .Select(g => new
                {
                    ID = g.Key.Engineer_ID,
                    count = g.Count(),
                    tot_price = g.Sum(e => e.Price)
                })
                .Join(db.Users, a=>a.ID, b=>b.ID, (a,b)=>new {a.ID, b.Name, a.count, a.tot_price});
            return Ok(re.ToList());
        }
        
        // GET: /api/data/repair_engineer_amount/
        [Route("api/data/repair_engineer_amount/")]
        [HttpGet]
        public IHttpActionResult GetEngineerRepairAmount()
        {
            var re = db.RepairOrders
                .GroupBy(e => new {e.Engineer_ID, e.Price})
                .Select(g => new
                {
                    ID = g.Key.Engineer_ID,
                    count = g.Count(),
                    tot_price = g.Sum(e => e.Price)
                })
                .Join(db.Users, a=>a.ID, b=>b.ID, (a,b)=>new {a.ID, b.Name, a.count, a.tot_price});
            return Ok(re.ToList());
        }
        
        // GET: /api/data/repair_daily_amount/
        [Route("api/data/repair_daily_amount/")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRepairDailyAmount()
        {
            var datas = await db.RepairOrders.ToListAsync();
            var re = datas
                .Select(n => new
                {
                    o_ID = n.ID,
                    Date = n.Create_time.ToString("yyyy-MM-dd"),
                    o_Price = n.Price
                })
                .GroupBy(n => new {n.Date})
                .Select(n => new
                {
                    Date = n.Key.Date, 
                    count = n.Count(),
                    tot_sales = n.Sum(e=>e.o_Price)
                });
            
            return Ok(re.ToList());
        }
        
        // GET: /api/data/recycle_daily_amount/
        [Route("api/data/recycle_daily_amount/")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRecycleDailyAmount()
        {
            var datas = await db.RecycleOrders.ToListAsync();
            var re = datas
                .Select(n => new
                {
                    o_ID = n.ID,
                    Date = n.Create_time.ToString("yyyy-MM-dd"),
                    o_Price = n.Price
                })
                .GroupBy(n => new {n.Date})
                .Select(n => new
                {
                    Date = n.Key.Date, 
                    count = n.Count(),
                    tot_sales = n.Sum(e=>e.o_Price)
                });
            
            return Ok(re.ToList());
        }
        
        // GET: /api/data/hot_models/
        [Route("api/data/hot_models/")]
        [HttpGet]
        public IHttpActionResult  GetHotModels()
        {
            var re = db.RepairOrder_RepairChoice
                .GroupBy(n => new {n.Rep_order_ID})
                .Select(x => new
                {
                    o_id = x.Key.Rep_order_ID, 
                    c_id = x.Max(t => t.Rep_choice_ID)
                    
                })
                .Join(db.RepairChoices, 
                    a => a.c_id, 
                    b => b.ID,
                    (a, b) => new
                    {
                        a.o_id, b.Model_ID
                        
                    })
                .GroupBy(e => e.Model_ID)
                .Select(e => new
                {
                    Model = e.Key,
                    count = e.Count()
                });
                
  
            
            return Ok(re.ToList());
        }

        
    }
}