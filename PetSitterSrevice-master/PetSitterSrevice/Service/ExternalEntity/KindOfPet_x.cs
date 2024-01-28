using System.Runtime.Serialization;

namespace PetSitterSrevice.Service.ExternalEntity
{
    [DataContract]
    public enum KindOfPet_x
    {
        [EnumMember]
        NONE,
        [EnumMember]
        DOG,
        [EnumMember]
        CAT,
        [EnumMember]
        FROG
    }
}