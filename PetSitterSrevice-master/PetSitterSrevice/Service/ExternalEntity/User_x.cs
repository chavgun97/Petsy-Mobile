using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PetSitterSrevice.Service.ExternalEntity
{
    [DataContract]
    public class User_x
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string UID { get; set; }
        [DataMember]
        public string UrlPhotoLable { get; set; }
        [DataMember]
        public int TestAmountInCoins { get; set; }
        [IgnoreDataMember]
        public ICollection<Order_x> Orders { get; set; }
        [IgnoreDataMember]
        public ICollection<Pet_x> Pets { get; set; }

        public User_x()
        {
            Orders = new List<Order_x>();
            Pets = new List<Pet_x>();
        }

    }
}