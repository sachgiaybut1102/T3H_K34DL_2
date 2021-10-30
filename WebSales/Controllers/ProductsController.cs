using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSales.Models.EF;
using WebSales.Models.DAO;

namespace WebSales.Controllers
{
    public class ProductsController : BaseController
    {
        private ProductDAO dao = new ProductDAO();

        // GET: Products
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.Keyword = keyword;

            return View(await dao.GetPagedList(page, pageSize, keyword));
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await dao.GetSingleByID((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public async Task<ActionResult> Create()
        {
            Product model = new Product()
            {
                ProductDate = DateTime.Now,
            };

            ViewBag.CategoryID = new SelectList(await new CategoryDAO().Getall(), "ID", "Name");
            return View(model);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,UnitPrice,Image,ProductDate,Available,CategoryID,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                await dao.Add(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(await new CategoryDAO().Getall(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await dao.GetSingleByID((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(await new CategoryDAO().Getall(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,UnitPrice,Image,ProductDate,Available,CategoryID,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                await dao.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(await new CategoryDAO().Getall(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await dao.GetSingleByID((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await dao.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
