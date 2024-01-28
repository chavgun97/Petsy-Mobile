using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PetSitterSrevice.Service.ExternalEntity
{
    [DataContract]
    public class Sitter_x
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UID { get; set; }
        [DataMember]
        public string UrlPhotoLable { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public int Reiting { get; set; } // max 50
        [DataMember]
        public TypeSitter_x[] Types { get; set; }  //заменить на списко медлей
        [DataMember]
        public KindOfPet_x KindofPet { get; set; } //заменить на списко медлей
        [DataMember]
        public int PricePerHourInCoins { get; set; }
        [DataMember]
        public int PricePerDayInCoins { get; set; }
        [DataMember]
        public int TestAmountInCoins { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public bool OnlineStatus { get; set; }
        [DataMember]
        public string Level { get; set; }//Заменить на енам
        [IgnoreDataMember]
        public ICollection<Order_x> Orders { get; set; }

        public Sitter_x()
        {
            Orders = new List<Order_x>();
        }



    }
}