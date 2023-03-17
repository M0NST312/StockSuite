using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockSuite.Controllers
{
    public class Proposals : Controller
    {
        // GET: Proposals
        public ActionResult Index()
        {
            return View();
        }

        // GET: Proposals/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proposals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proposals/Create
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

        // GET: Proposals/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proposals/Edit/5
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

        // GET: Proposals/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proposals/Delete/5
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
