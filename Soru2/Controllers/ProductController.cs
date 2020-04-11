using Soru2.Models;
using Soru2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soru2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductDal pd = new ProductDal();
            var product = pd.ProductsList();

            ViewBag.CatList = pd.CategoryList();

            return View(product);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductDal pd = new ProductDal();
            var product = pd.ProductDetail(id);

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductDal pd = new ProductDal();
            //pd.CategoryList();

            ViewBag.CatList = pd.CategoryList();

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(products pro) //FormCollection collection
        {
            try
            {
                ProductDal pd = new ProductDal();
                pd.AddProduct(pro);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductDal pd = new ProductDal();
            var product = pd.ProductDetail(id);

            ViewBag.CatList = pd.CategoryList();

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(products pro) // int id, FormCollection collection
        {
            try
            {
                ProductDal pd = new ProductDal();
                pd.UpdateProduct(pro);

                ViewBag.CatList = pd.CategoryList();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            ProductDal pd = new ProductDal();
            var product = pd.ProductDetail(id);

            ViewBag.CatList = pd.CategoryList();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(products pro)
        {
            try
            {
                ProductDal pd = new ProductDal();
                pd.DeleteProduct(pro.ProductID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
