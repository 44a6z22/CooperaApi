//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Coopera.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Details_commande
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public int ProduitsId { get; set; }
        public int CommandesId { get; set; }
        public Nullable<float> Sub_total { get; set; }
    
        public virtual Commandes Commandes { get; set; }
        public virtual Produits Produits { get; set; }
    }
}
