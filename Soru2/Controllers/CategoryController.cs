using Soru2.Models;
using Soru2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soru2.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryDal pd = new CategoryDal();
            var categories = pd.CategoryList();

            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            CategoryDal pd = new CategoryDal();
            var category = pd.CategoryDetail(id);

            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(category cat)
        {
            try
            {
                CategoryDal ct = new CategoryDal();
                ct.AddCategory(cat);

                return RedirectToAction("Index");
            }
            catch(Exception ex) 
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryDal ct = new CategoryDal();
            var category = ct.CategoryDetail(id);

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(category cat)
        {
            try
            {
                CategoryDal ct = new CategoryDal();
                ct.UpdateProduct(cat);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryDal ct = new CategoryDal();
            var category = ct.CategoryDetail(id);

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(category cat)
        {
            try
            {
                CategoryDal ct = new CategoryDal();
                ct.DeleteProduct(cat.CategoryID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
