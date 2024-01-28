using System;
using System.Collections.Generic;

namespace PetSitterSrevice.ORM.Model
{
    public class Sitter
    {
        public int Id { get; set; }
        public string UID { get; set; }
        public string UrlPhotoLable { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Location { get; set; }
        public int Reiting { get; set; } // max 50
        public KindOfPet KindofPet { get; set; } //заменить на списко медлей
        public int PricePerHourInCoins { get; set; }
        public int PricePerDayInCoins { get; set; }
        public int TestAmountInCoins { get; set; }
        public String Description { get; set; }
        public bool OnlineStatus { get; set; }
        public string Level { get; set; }//Заменить на енам

        virtual public ICollection<TypeSitterModel> Types { get; set; }

        virtual public ICollection<Order> Orders { get; set; }



    }
}