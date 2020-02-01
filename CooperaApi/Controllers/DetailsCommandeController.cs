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
using Coopera.Logic.managers;
using CooperaApi.Models;
//using Coopera.Logic;

namespace CooperaApi.Controllers
{
    public class DetailsCommandeController : ApiController
    {
        private CoopEntities db = new CoopEntities();

        // GET: api/DetailsCommande
        public IHttpActionResult GetDetails_commande()
        {
            var ok = db.Details_commande.ToList();
            IEnumerable<OrderDetailsModel> listOrderDetail = from od in ok select new OrderDetailsModel(od,od.Commandes, od.Produits);
        
            return Ok(listOrderDetail);
        }

        // GET: api/DetailsCommande/5
        [ResponseType(typeof(Details_commande))]
        public IHttpActionResult GetDetails_commande(int id)
        {
            Details_commande details_commande = db.Details_commande.Find(id);
            if (details_commande == null)
            {
                return NotFound();
            }

            return Ok(details_commande);
        }

        // GET: api/DetailsCommande/User/2
        [Route("Api/DetailsCommande/User/{id}")]
        public IHttpActionResult getDetailCommandes(int id)
        {
            var ok = db.Details_commande.ToList();
            IEnumerable<OrderDetailsModel> listOrderDetail = from od in ok
                                                             where od.Commandes.UsersId == id
                                                             select new OrderDetailsModel(
                                                                 od,
                                                                 od.Commandes,
                                                                 od.Produits
                                                                );
            return Ok(listOrderDetail);
        }

        // GET: api/DetailsCommande/User/2
        [Route("Api/DetailsCommande/{StatusId}/User/{id}")]
        public IHttpActionResult getDetailCommandes(int StatusId, int id)
        {
            var ok = db.Details_commande.ToList();
            IEnumerable<OrderDetailsModel> listOrderDetail = from od in ok
                                                             where od.Commandes.UsersId == id
                                                             where od.Commandes.statusId == StatusId
                                                             select new OrderDetailsModel(
                                                                 od,
                                                                 od.Commandes ,
                                                                 od.Produits
                                                                );
            //var numbers = from lod in listOrderDetail select lod.TotalPrice; 
            return Ok(listOrderDetail);
        }

        // GET: Api/DetailsCommande/User/CountOrders/5
        [Route("Api/DetailsCommande/User/CountOrders/{userId}")]
        public IHttpActionResult getCommandesCount(int userId)
        {
            var detailCommandList = db.Details_commande.ToList();
            IEnumerable<OrderDetailsModel> listOrderDetail = from od in detailCommandList
                                                             where od.Commandes.UsersId == userId
                                                             select new OrderDetailsModel(
                                                                 od,
                                                                 od.Commandes,
                                                                 od.Produits
                                                                );
            return Ok(listOrderDetail.Count());
        }

        // PUT: api/DetailsCommande/5/
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetails_commande(int id, Details_commande details_commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != details_commande.Id)
            {
                return BadRequest();
            }

            db.Entry(details_commande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Details_commandeExists(id))
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

        // PUT: api/DetailsCommande/5/2
        [Route("api/DetailsCommande/{id}/{userId}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetails_commande(int id, int userId, Details_commande details_commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != details_commande.Id && userId != details_commande.Commandes.UsersId)
            {
                return BadRequest();
            }

            db.Entry(details_commande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Details_commandeExists(id))
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

        // POST: api/DetailsCommande
        [ResponseType(typeof(Details_commande))]
        public IHttpActionResult PostDetails_commande(Details_commande details_commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Details_commande.Add(details_commande);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = details_commande.Id }, details_commande);
        }

        // DELETE: api/DetailsCommande/5
        [ResponseType(typeof(Details_commande))]
        public IHttpActionResult DeleteDetails_commande(int id)
        {
            Details_commande details_commande = db.Details_commande.Find(id);
            if (details_commande == null)
            {
                return NotFound();
            }

            db.Details_commande.Remove(details_commande);
            db.SaveChanges();

            return Ok(details_commande);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Details_commandeExists(int id)
        {
            return db.Details_commande.Count(e => e.Id == id) > 0;
        }
    }
}