using Coopera.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CooperaApi.Models
{
    public class FillieresModel
    {
        public int Id { get; set; }
        public Nullable<int> FilliersId { get; set; }
        public int secteurDactiviteId { get; set; }
        public string Name { get; set; }

        public FillieresModel(Filliers fillier)
        {
            this.Id = fillier.Id;
            this.FilliersId = fillier.FilliersId;
            this.secteurDactiviteId = fillier.secteurDactiviteId;
            this.Name = fillier.Name;
        }
    }
}