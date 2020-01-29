using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coopera.Data;

namespace CooperaApi.Models
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public int ProduitsId { get; set; }
        public int CommandesId { get; set; }
        public Nullable<float> Sub_total { get; set; }

        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }

        public OrderDetailsModel(Details_commande obj , Commandes order, Produits product)
        {
            this.Id = obj.Id;
            this.Quantity = obj.Quantity;
            this.TotalPrice = obj.TotalPrice;
            this.ProduitsId = obj.ProduitsId;
            this.CommandesId = obj.CommandesId;
            this.Sub_total = obj.Sub_total;
            this.Order = new OrderModel(order, order.status);

            this.Product = new ProductModel(product, 
                            from i in product.Images select new ImagesModel(i), 
                            from r in product.reviews select new ReviewsModel(r)
                            );
        }
    }
}