﻿using InventoryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.MobileControls;

namespace InventoryManagment.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managmentEntities db = new Inventory_managmentEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List < Product> list = db.Products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }


        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
                db.Products.Add(pro);
                db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult UpdateProduct( int id)
        {
            Product pr= db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]

        public ActionResult UpdateProduct(int id, Product pro)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            pr.product_name = pro.product_name;
            pr.Product_qnty = pro.Product_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id, Product pro)
        {
            db.Products.Remove(db.Products.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}