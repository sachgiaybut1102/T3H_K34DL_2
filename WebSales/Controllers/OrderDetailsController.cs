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
    public class OrderDetailsController : BaseController
    {
        private OrderDetailDAO dao = new OrderDetailDAO();

        // GET: OrderDetails
        public async Task<ActionResult> Index()
        {
            return View(await dao.Getall());
        }

        // GET: OrderDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = await dao.GetSingleByID((int)id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.OrderID = new SelectList(await new OrderDAO().Getall(), "ID", "CustomerID");
            ViewBag.ProductID = new SelectList(await new ProductDAO().Getall(), "ID", "Name");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,OrderID,ProductID,UnitPrice,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                await dao.Add(orderDetail);
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(await new OrderDAO().Getall(), "ID", "CustomerID",orderDetail.OrderID);
            ViewBag.ProductID = new SelectList(await new ProductDAO().Getall(), "ID", "Name",orderDetail.ProductID);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = await dao.GetSingleByID((int)id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(await new OrderDAO().Getall(), "ID", "CustomerID", orderDetail.OrderID);
            ViewBag.ProductID = new SelectList(await new ProductDAO().Getall(), "ID", "Name", orderDetail.ProductID);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,OrderID,ProductID,UnitPrice,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                await dao.Update(orderDetail);
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(await new OrderDAO().Getall(), "ID", "CustomerID", orderDetail.OrderID);
            ViewBag.ProductID = new SelectList(await new ProductDAO().Getall(), "ID", "Name", orderDetail.ProductID);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = await dao.GetSingleByID((int)id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
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
