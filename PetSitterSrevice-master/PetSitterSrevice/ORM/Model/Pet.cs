using System.ComponentModel.DataAnnotations.Schema;

namespace PetSitterSrevice.ORM.Model
{
    public class Pet
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string DateOfBirthday { get; set; }
        public string UrlPhotoLable { get; set; }
        public KindOfPet Kind { get; set; }  //заменить на медель
        public string Breed { get; set; } //заменить на медель
        public string Recommendation { get; set; }

        virtual public User User { get; set; }

    }
}