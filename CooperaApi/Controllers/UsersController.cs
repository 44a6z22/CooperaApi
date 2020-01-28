using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

using Coopera.Data;
using CooperaApi.Models;

namespace CooperaApi.Controllers
{
    public class UsersController : ApiController
    {
        private CoopEntities db = new CoopEntities();

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            List<Users> users = db.Users.Where( u => u.IsDeleted == false ).ToList();
            
            var usersValue = from u in users select new UserModel(u,
                                from p in u.Produits  select new ProductModel(p,
                                    from i in p.Images select new ImagesModel(i),
                                    from r in p.reviews select new ReviewsModel(r)
                                 )
                             );

            return Ok(usersValue);
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);

            if (users == null)
            {
                return NotFound();
            }

            List<ProductModel> list = new List<ProductModel>();

            foreach (var product in users.Produits)
            {
                List<ImagesModel> imagesList = new List<ImagesModel>();
                foreach (var image in product.Images)
                {
                    imagesList.Add(new ImagesModel(image));
                }
                List<ReviewsModel> Reviews = new List<ReviewsModel>();
                foreach (var i in product.reviews)
                {
                    Reviews.Add(new ReviewsModel(i));
                }
                list.Add(new ProductModel(product, imagesList, Reviews));
            }

            return Ok(new UserModel(users, list));
            //return Ok();
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        // GET : Api/Users/Deleted
        [HttpGet]
        [Route("api/users/deleted")]
        public IHttpActionResult DeletedUsers()
        {
            IEnumerable<Users> DeletedUsers = db.Users.Where( u => u.IsDeleted == true ).ToList();

            var something = from a in DeletedUsers select new UserModel(a,
                                from p in a.Produits select new ProductModel(p,
                                    from i in p.Images select new ImagesModel(i),
                                    from r in p.reviews select new ReviewsModel(r)
                                )
                            );

            return Ok(something);
        }

        // GET : Api/Users/Deleted
        [HttpGet]
        [Route("api/users/UnActive")]
        public IHttpActionResult UnActiveUsers()
        {
            IEnumerable<Users> DeletedUsers = db.Users.Where(u => u.IsActivated == false).ToList();

            var something = from a in DeletedUsers
                            select new UserModel(a,
                                 from p in a.Produits
                                 select new ProductModel(p,
                                       from i in p.Images select new ImagesModel(i),
                                    from r in p.reviews select new ReviewsModel(r)
                                   )
                             );
            return Ok(something);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}