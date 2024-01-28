using System.Collections.Generic;

namespace PetSitterSrevice.ORM.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UID { get; set; }
        public string UrlPhotoLable { get; set; }
        public int TestAmountInCoins { get; set; }

        virtual public ICollection<Order> Orders { get; set; }
        virtual public ICollection<Pet> Pets { get; set; }

    }
}