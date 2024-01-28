namespace PetSitterSrevice.ORM.Model
{
    public class Order
    {
        public int Id { get; set; }


        public string Name { get; set; }
        public int PriseInCoin { get; set; }
        public TypeSitter Type { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public bool IsActive { get; set; }
        public int SitterId { get; set; }
        public int PetId { get; set; }

        virtual public Sitter Sitter { get; set; }
        virtual public Pet Pet { get; set; }


    }
}