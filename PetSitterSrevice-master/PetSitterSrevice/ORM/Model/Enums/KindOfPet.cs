using System.Runtime.Serialization;

namespace PetSitterSrevice.ORM.Model
{
    [DataContract]
    public enum KindOfPet
    {
        NONE,
        DOG,
        CAT,
        FROG
    }
}