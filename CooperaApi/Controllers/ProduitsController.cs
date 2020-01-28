using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Coopera.Data;
using CooperaApi.Models;

namespace CooperaApi.Controllers
{
    public class ProduitsController : ApiController
    {
        private CoopEntities db = new CoopEntities();

        // GET: api/Produits
        public IHttpActionResult GetProduits()
        {
            List<Produits> produitsList = db.Produits.ToList();
            var something = from p in produitsList
                            select new ProductModel(
                                p, 
                                from i in p.Images select new ImagesModel(i), 
                                from r in p.reviews select new ReviewsModel(r)
                            );
                                
            return Ok(something);
        }

        // GET: api/Produits/5
        [ResponseType(typeof(Produits))]
        public IHttpActionResult GetProduits(int id)
        {
            Produits produits = db.Produits.Find(id);
           
            if (produits == null)
            {
                return NotFound();
            }

            List<ImagesModel> images = new List<ImagesModel>();
            foreach (var i in produits.Images)
            {
                images.Add(new ImagesModel(i));
            }
            List<ReviewsModel> Reviews = new List<ReviewsModel>();
            foreach (var i in produits.reviews)
            {
                Reviews.Add(new ReviewsModel(i));
            }

            ProductModel listOdProducts = new ProductModel(produits, images, Reviews);

            return Ok(listOdProducts);
        }

        // PUT: api/Produits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduits(int id, Produits produits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produits.Id)
            {
                return BadRequest();
            }

            db.Entry(produits).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitsExists(id))
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

        // POST: api/Produits
        [ResponseType(typeof(Produits))]
        public IHttpActionResult PostProduits(Produits produits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            produits.Users = db.Users.Find(produits.UsersId);
            produits.Filliers = db.Filliers.Find(produits.FilliersId);
            produits.reviews = new List<reviews>();
            produits.Details_commande = new List<Details_commande>();

            db.Produits.Add(produits);
            db.SaveChanges();

            List<ImagesModel> list = new List<ImagesModel>();
            foreach (var i in produits.Images)
            {
                list.Add(new ImagesModel(i) );
            }
            List<ReviewsModel> Reviews = new List<ReviewsModel>();
            foreach (var i in produits.reviews)
            {
                Reviews.Add(new ReviewsModel(i));
            }
            return CreatedAtRoute("DefaultApi", new { id = produits.Id }, new ProductModel(produits, list, Reviews));
        }

        // DELETE: api/Produits/5
        [ResponseType(typeof(Produits))]
        public IHttpActionResult DeleteProduits(int id)
        {
            Produits produits = db.Produits.Find(id);
            if (produits == null)
            {
                return NotFound();
            }

            db.Produits.Remove(produits);
            db.SaveChanges();

            return Ok(produits);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProduitsExists(int id)
        {
            return db.Produits.Count(e => e.Id == id) > 0;
        }
    }
}