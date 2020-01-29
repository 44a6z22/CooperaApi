using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coopera.Data; 

namespace CooperaApi.Models
{
    public class ImagesModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }

        public ImagesModel(){}

        public ImagesModel(Images obj)
        {
            this.Id = obj.Id;
            this.ProductId= obj.ProduitsId;
            this.Path = obj.Path;

        }
    }
}