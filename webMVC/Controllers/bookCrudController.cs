using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using webMVC.Models;

namespace webMVC.Controllers
{
    public class bookCrudController : Controller
    {

        HttpClient client = new HttpClient();

        // GET: /bookCrud
        [HttpGet]
        public ActionResult Index()
        {
            List<book> b = new List<book>();
            client.BaseAddress = new Uri(" https://localhost:44301/api/booksAPI");
            var response = client.GetAsync("booksAPI");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<book>>();
                display.Wait();
                b = display.Result;
            }
            return View(b);
        }

        // POST: /bookCrud/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            client.BaseAddress = new Uri(" https://localhost:44301/api/booksAPI");
            client.DeleteAsync("booksAPI/" + id.ToString());
            return RedirectToAction("Index");
        }

        // GET: /bookCrud/create
        [HttpGet]
        public ActionResult create()
        {
            return View("create");
        }

        // GET: /bookCrud/update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            book b = null;
            client.BaseAddress = new Uri(" https://localhost:44301/api/booksAPI");
            var response = client.GetAsync("booksAPI/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<book>();
                display.Wait();
                b = display.Result;
            }
            return View(b);
        }


        // GET: /bookCrud/update/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            book b = null;
            client.BaseAddress = new Uri("https://localhost:44301/api/booksAPI");
            var response = client.GetAsync("booksAPI/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<book>();
                display.Wait();
                b = display.Result;
            }
            return View(b);
        }


        // PUT: /bookCrud/update/[body]
        [HttpPost]
        public ActionResult Edit(book b)
        {
          
            client.BaseAddress = new Uri("https://localhost:44301/api/booksAPI");
            var response = client.PutAsJsonAsync($"booksAPI",b);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }


        // POST: /bookCrud/create/
        [HttpPost]
        public ActionResult create(book b)
        {
            client.BaseAddress = new Uri(" https://localhost:44301/api/booksAPI");
            var response = client.PostAsJsonAsync("booksAPI",b);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("create");
        }

        
    }
}