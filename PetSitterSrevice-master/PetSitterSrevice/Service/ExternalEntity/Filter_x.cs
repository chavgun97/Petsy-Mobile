using System.Runtime.Serialization;

namespace PetSitterSrevice.Service.ExternalEntity
{
    [DataContract]
    //Пока не реализован
    public class Filter_x
    {
        [DataMember]
        public KindOfPet_x KindOfPet { get; set; }
        [DataMember]
        public TypeSitter_x TypeSitter { get; set; }

    }
}