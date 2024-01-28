using System.Runtime.Serialization;

namespace PetSitterSrevice.Service.ExternalEntity
{
    [DataContract]
    public class Pet_x
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Sex { get; set; }
        [DataMember]
        public string DateOfBirthday { get; set; } //если понадобиться логика нужно переопределять JSON converter анотацию
        [DataMember]
        public string UrlPhotoLable { get; set; }
        [DataMember]
        public KindOfPet_x Kind { get; set; }  //заменить на медель
        [DataMember]
        public string Breed { get; set; } //заменить на медель
        [DataMember]
        public string Recommendation { get; set; }

        [DataMember]
        public int UserId { get; set; }

    }
}