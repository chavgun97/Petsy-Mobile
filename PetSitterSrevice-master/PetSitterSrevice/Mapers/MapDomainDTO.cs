using AutoMapper;
using PetSitterSrevice.ORM.Model;
using PetSitterSrevice.Service.ExternalEntity;
using System.Linq;

namespace PetSitterSrevice.Mapers
{
    public static class MapDomainDTO
    {
        public static Mapper CustomMapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, User_x>();
            cfg.CreateMap<Order, Order_x>();
            cfg.CreateMap<Sitter, Sitter_x>().ForMember("Types", source => source.MapFrom(v =>
            v.Types.Select(x => (TypeSitter_x)x.Type).ToArray()
            ));
            cfg.CreateMap<Pet, Pet_x>();
            cfg.CreateMap<User_x, User>();
            cfg.CreateMap<Order_x, Order>();
            cfg.CreateMap<Sitter_x, Sitter>().ForMember("Types", source => source.MapFrom(v =>
            v.Types.Select(x => new TypeSitterModel() { Type = (TypeSitter)x })));
            cfg.CreateMap<Pet_x, Pet>();
            cfg.CreateMap<Order, Order>();
            cfg.CreateMap<Pet, Pet>();

        }));
        public static User_x MapToDto(User user)
        {
            return CustomMapper.Map<User, User_x>(user);
        }

        public static Order_x MapToDto(Order order)
        {
            return CustomMapper.Map<Order, Order_x>(order);

        }

        public static Sitter_x MapToDto(Sitter sitter)
        {
            var v = CustomMapper.Map<Sitter, Sitter_x>(sitter);
            return v;
        }
        public static Pet_x MapToDto(Pet pet)
        {

            return CustomMapper.Map<Pet, Pet_x>(pet);
        }

        public static User MapToDamain(User_x user_x)
        {

            return CustomMapper.Map<User_x, User>(user_x);
        }

        public static Order MapToDamain(Order_x order_x)
        {
            var freshOrder = CustomMapper.Map<Order_x, Order>(order_x);
            freshOrder.PetId = order_x.Pet.Id;
            freshOrder.SitterId = order_x.Sitter.Id;
            freshOrder.Pet = null;
            freshOrder.Sitter = null;
            return freshOrder;
        }

        public static Sitter MapToDamain(Sitter_x sitter_x)
        {
            return CustomMapper.Map<Sitter_x, Sitter>(sitter_x);

        }

        public static Pet MapToDamain(Pet_x pet_x)
        {
            var fresh = CustomMapper.Map<Pet_x, Pet>(pet_x);
            return fresh;

        }


    }
}
