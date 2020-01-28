using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coopera.Data; 

namespace CooperaApi.Models
{
    public class ReviewsModel
    {
        public int UsersId { get; set; }
        public int ProduitsId { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }

        public ReviewsModel(reviews obj)
        {
            this.UsersId = obj.UsersId;
            this.ProduitsId = obj.ProduitsId;
            this.Content = obj.Content;
            this.Rating = obj.Rating;

        }
    }
}