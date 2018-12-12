using MvcApplication.DAL;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcApplication.Controllers
{
    public class EventsController : Controller
    {
        private EventContext _db = new EventContext();

        public ActionResult Index() => View();

        [HttpGet]
        [OutputCache(CacheProfile = "CacheEvents", VaryByParam = "iDisplayStart;iDisplayLength;sSearch")]
        public JsonResult GetEvents(int iDisplayStart, int iDisplayLength, string sSearch)
        {
            try
            {

                int totalRecords = _db.Events.Count();
                int totalDisplayRecords;

                if (!string.IsNullOrEmpty(sSearch))
                {
                    IOrderedQueryable<Event> initialSearch = _db.Events.Where(x => x.RegistrationLink.ToLower().Contains(sSearch) || x.StartingDate.ToLower().Contains(sSearch) ||
                        x.Technology.ToLower().Contains(sSearch) || x.Title.ToLower().Contains(sSearch)).OrderBy(x=>x.Id);

                    var result = initialSearch.Skip(iDisplayStart).Take(iDisplayLength).ToList();

                    totalDisplayRecords = initialSearch.Count();

                    return Json(new { aaData = result, iTotalRecords = totalRecords, iTotalDisplayRecords = totalDisplayRecords }, JsonRequestBehavior.AllowGet);
                }

                totalDisplayRecords = totalRecords;

                var eventList = _db.Events.OrderBy(x => x.Id).Skip(iDisplayStart).Take(iDisplayLength).ToList();

                return Json(new { aaData = eventList, iTotalRecords = totalRecords, iTotalDisplayRecords = totalDisplayRecords }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(new { error = e.Message.ToString() });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
