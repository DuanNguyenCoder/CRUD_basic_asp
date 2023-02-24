
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using webMVC.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace webMVC.Controllers
{ 
        public class booksAPIController : ApiController
        {
            private bookEntities db = new bookEntities();

            // GET: api/booksAPI
            [HttpGet]
            public IEnumerable<book> getList()
            {
                return db.books.ToList();
            }

            // GET: api/booksAPI/{id}
            [HttpGet]
            public IHttpActionResult getBook(int id)
            {
                book b = db.books.Find(id);
                if (b == null)
                {
                    return NotFound();
                }
                return Ok(b);
            }

            // POST: api/booksAPI
            [HttpPost]
            public IHttpActionResult createBook([FromBody] book b)
            {
            book bo = db.books.Find(b.book_id);
            if (bo != null)
            {
                return NotFound();
            }
                db.books.Add(b);
                db.SaveChanges();

                return Ok(b);
            }

            // PUT: api/booksAPI/[body]
            [HttpPut]
            public IHttpActionResult update([FromBody] book b)
            {
                book bo = db.books.Find(b.book_id);
                if (bo == null)
                {
                    return NotFound();
                }
                //update
                bo.book_id = b.book_id;
                bo.title = b.title;
                bo.price = b.price;
                bo.author = b.author;
                bo.publish_date = b.publish_date;
                db.SaveChanges();

                return Ok(bo);

            }

            // DELETE: api/booksAPI/{id}
            [HttpDelete]
            public IHttpActionResult delete(int id)
            {
                book bo = db.books.Find(id);
                if (bo == null)
                {
                    return NotFound();
                }
                db.books.Remove(bo);
                db.SaveChanges();
                return Ok();
            }
        }
    }

