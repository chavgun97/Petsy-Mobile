using System.Runtime.Serialization;

namespace PetSitterSrevice.Service.ExternalEntity
{
    [DataContract]
    public class Order_x
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int PriseInCoin { get; set; }
        [DataMember]
        public TypeSitter_x Type { get; set; }
        [DataMember]
        public string DateFrom { get; set; }
        [DataMember]
        public string DateTo { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public Sitter_x Sitter { get; set; }
        [DataMember]
        public Pet_x Pet { get; set; }



    }
}