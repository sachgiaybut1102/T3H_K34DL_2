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
    public class OrdersController : BaseController
    {
        private OrderDAO dao = new OrderDAO();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            return View(await dao.Getall());
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await dao.GetSingleByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CustomerID = new SelectList(await new CustomerDAO().Getall(), "ID", "ID");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CustomerID,OrderDate,Address,Amount,Description")] Order order)
        {
            if (ModelState.IsValid)
            {
                await dao.Add(order);
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(await new CustomerDAO().Getall(), "ID", "ID", order.CustomerID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await dao.GetSingleByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(await new CustomerDAO().Getall(), "ID", "ID", order.CustomerID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CustomerID,OrderDate,Address,Amount,Description")] Order order)
        {
            if (ModelState.IsValid)
            {
                await dao.Update(order);
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(await new CustomerDAO().Getall(), "ID", "ID", order.CustomerID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await dao.GetSingleByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await dao.Delete((int)id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
