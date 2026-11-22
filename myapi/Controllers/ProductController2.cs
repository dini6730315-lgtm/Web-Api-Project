using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers
{
    public class ProductController2 : Controller
    {
        // GET: ProductController2
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController2/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
