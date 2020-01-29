using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coopera.Data;

namespace CooperaApi.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusModel(status s)
        {
            this.Id = s.Id;
            this.Name = s.Name; 
        }
    }
}