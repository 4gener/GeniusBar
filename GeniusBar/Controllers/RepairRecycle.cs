using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Text;
using GeniusBar.Models;

namespace GeniusBar.Controllers
{
    public class RecycleRepairController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        [HttpGet]
        [Route("api/RepairChoices/route")]
        public IHttpActionResult GetRepairChoicesByInfo(int repairID, int laptopID)
        {
            var repairChoice = db.RepairChoices.Where(s => s.Category_ID == repairID).Where(s => s.Model_ID == laptopID).ToList<RepairChoice>();
            if (repairChoice == null)
            {
                return NotFound();
            }
            return Ok(repairChoice);
        }

        [HttpGet]
        [Route("api/RecycleEvaluationCategories/route")]

        public IHttpActionResult GetRecycleCategoryByInfo(int laptopID)
        {
            var recycleCategory = db.RecycleEvaluationCategories.Where(s => s.Model_ID == laptopID).ToList<RecycleEvaluationCategory>();
            if (recycleCategory == null)
            {
                return NotFound();
            }
            return Ok(recycleCategory);
        }

        [HttpGet]
        [Route("api/RecycleEvaluationChoices/route")]
        public IHttpActionResult GetRecycleChoiceByInfo(int recycleID)
        {
            var recycleChoice = db.RecycleEvaluationChoices.Where(s => s.Category_ID == recycleID).ToList<RecycleEvaluationChoice>();
            if (recycleChoice == null)
            {
                return NotFound();
            }
            return Ok(recycleChoice);
        }
    }
}