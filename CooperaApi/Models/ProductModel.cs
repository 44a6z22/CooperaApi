using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coopera.Data;

namespace CooperaApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int FilliersId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        //public UserModel User { get; set; }
        public IEnumerable<ImagesModel> images { get; set; }
        public IEnumerable<ReviewsModel> reviews { get; set;  }

        public ProductModel(Produits p, IEnumerable<ImagesModel> images, IEnumerable<ReviewsModel> reviews)
        {
            this.Id = p.Id;
            this.UsersId = p.UsersId;
            this.FilliersId = p.FilliersId;
            this.Name = p.Name;
            this.Price = p.Price;
            this.images = images;
            this.reviews = reviews;

        }
        
    }
}