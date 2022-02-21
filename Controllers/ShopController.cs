using MvcBoutique.Models;
using System;
using System.Web.Mvc;

namespace MvcBoutique.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var Shop = new Database();
            var Get=Shop.GetBoutique();
            return View(Get);
        }

        public ActionResult Create()
        {
            var con = new Database();
            return View(new Boutique());
        }
        [HttpPost]
        public ActionResult Create(Boutique add)
        {
            var Addnew = new Database();
            try
            {
                Addnew.AddBoutique(add);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public ActionResult Onclick(string id)
        {
            int compo = Convert.ToInt32(id);
            var updt = new Database();
            try
            {
                var back = updt.FindBoutique(compo);
                return View(back);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult Onclick(Boutique bout)
        {
            var click = new Database();
            try
            {
                click.UpdateBoutique(bout);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public ActionResult Delete(int id)
        {
            var con = new Database();
            con.Delete(id);
            return RedirectToAction("Index");
        }


        public ActionResult Showcase()
        {
            return View();
        }
    }
}