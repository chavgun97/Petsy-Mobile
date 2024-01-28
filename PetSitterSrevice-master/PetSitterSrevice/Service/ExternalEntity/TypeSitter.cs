using System.Runtime.Serialization;

namespace PetSitterSrevice.Service.ExternalEntity
{
    [DataContract]
    public enum TypeSitter_x
    {
        [EnumMember]
        None,
        [EnumMember]
        PetSitting,
        [EnumMember]
        Сritter,
        [EnumMember]
        Walking
    }
}