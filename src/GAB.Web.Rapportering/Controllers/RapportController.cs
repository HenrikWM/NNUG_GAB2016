namespace GAB.Web.Rapportering.Controllers
{
    using System.Web.Mvc;

    public class RapporterController : Controller
    {
        public ActionResult Vis()
        {
            ViewBag.Title = "Vis rapport";

            return View();
        }
    }
}