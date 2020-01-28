using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coopera.Data;

namespace CooperaApi.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int statusId { get; set; }
        public int UsersId { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public Nullable<System.DateTime> DateLivraison { get; set; }

        public OrderModel(Commandes obj)
        {
            this.Id = obj.Id;
            this.statusId = obj.statusId;
            this.UsersId = obj.UsersId;
            this.DateCreation = obj.DateCreation;
            this.DateLivraison = obj.DateLivraison; 
        }
    }
}