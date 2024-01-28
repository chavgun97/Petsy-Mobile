namespace PetSitterSrevice.ORM.Model
{
    public class TypeSitterModel
    {
        public int Id { get; set; }
        public int SitterId { get; set; }
        public TypeSitter Type { get; set; }
        virtual public Sitter Sitter { get; set; }
    }
}