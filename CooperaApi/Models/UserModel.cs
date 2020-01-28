using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coopera.Data;

namespace CooperaApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActivated { get; set; }
        public string Matricule { get; set; }
        public IEnumerable<ProductModel> produits { get; set; }

        public UserModel()
        {

        }

        public UserModel(Users user, IEnumerable<ProductModel> products)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.UserName = user.UserName;
            this.PassWord = user.PassWord;
            this.Email = user.Email;
            this.Adress = user.Adress;
            this.PhoneNumber = user.PhoneNumber;
            this.IsActivated = user.IsActivated;
            this.IsDeleted = user.IsDeleted;
            this.Matricule = user.Matricule;
            this.produits = products;

        }
        public UserModel(Users user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.UserName = user.UserName;
            this.PassWord = user.PassWord;
            this.Email = user.Email;
            this.Adress = user.Adress;
            this.PhoneNumber = user.PhoneNumber;
            this.IsActivated = user.IsActivated;
            this.IsDeleted = user.IsDeleted;
            this.Matricule = user.Matricule;
            //this.produits = obj;

        }
    }
}
