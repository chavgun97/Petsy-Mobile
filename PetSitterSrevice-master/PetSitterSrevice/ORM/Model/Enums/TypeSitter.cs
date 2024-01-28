using System.Runtime.Serialization;

namespace PetSitterSrevice.ORM.Model
{
    [DataContract]
    public enum TypeSitter
    {
        None,
        PetSitting,
        Сritter,
        Walking
    }
}