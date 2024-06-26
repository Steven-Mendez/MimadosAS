﻿using System.Web.Mvc;
using Business = BusinessLayer;
using Entity = EntityLayer;

namespace AdminPresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Entity.Product product)
        {
            var result = new Business.Product().Create(product, out string message);
            var json = new { result, message };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Read()
        {
            var json = new
            {
                data = new Business.Product().Read()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ReadById(int id)
        {
            var json = new
            {
                data = new Business.Product().ReadById(id)
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ReadByCode(int code)
        {
            var json = new
            {
                data = new Business.Product().ReadById(code)
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Entity.Product product)
        {
            var result = new Business.Product().Update(product, out string message);
            var json = new { result, message };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(Entity.Product product)
        {
            var result = new Business.Product().Delete(product, out string message);
            var json = new { result, message };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost] 
        public JsonResult StockControl(int idProduct, int quantity)
        {
            var result = new Business.Product().StockControl(idProduct, quantity);
            var json = new { result };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}