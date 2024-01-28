using PetSitterSrevice.Service.ExternalEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;

namespace PetSitterSrevice.Repository
{
    public class MockRep : Pet_x, IRep
    {
        ICollection<User_x> users = new List<User_x>();
        ICollection<Order_x> orders = new List<Order_x>();
        ICollection<Sitter_x> sitters = new List<Sitter_x>();

        private static MockRep instance = new MockRep();
        private MockRep()
        {
            Init();
        }

        public Pet_x Pet_x
        {
            get => default;
            set
            {
            }
        }

        private void Init()
        {
            sitters.Add(new Sitter_x
            {
                Id = 1,
                Name = "Mikol",
                Surname = "DogMan",
                Description = "Ваша собака попадет в вольшебные руки",
                UID = null,
                UrlPhotoLable = "https://scontent-waw1-1.xx.fbcdn.net/v/t1.0-9/p960x960/117815403_3182091861866814_3309768340166989336_o.jpg?_nc_cat=111&_nc_sid=85a577&_nc_ohc=oZ5yJ707GhQAX82pl3s&_nc_ht=scontent-waw1-1.xx&_nc_tp=6&oh=120dc604f049a10e97e62c6739982764&oe=5F5D307B",
                Types = new TypeSitter_x[] { TypeSitter_x.PetSitting },
                PricePerHourInCoins = 555,
                PricePerDayInCoins = 205,
                Reiting = 48,
                TestAmountInCoins = 2000,
                OnlineStatus = false,
                Level = "IronMan"
            });

            sitters.Add(new Sitter_x
            {
                Id = 2,
                Name = "Nikola",
                Surname = "BossOfMops",
                Description = "Спортсмен с десятилетним сажем, возмьу вашу собкау на пробежку.",
                UID = null,
                UrlPhotoLable = "https://scontent-waw1-1.xx.fbcdn.net/v/t1.0-9/117645202_2683829375269118_8317780132219506817_n.jpg?_nc_cat=105&_nc_sid=dd7718&_nc_ohc=F9GE6zMDKwAAX8t_F5k&_nc_ht=scontent-waw1-1.xx&oh=581b7bb948366bc347e136b685dcd117&oe=5F60039B",
                Types = new TypeSitter_x[] { TypeSitter_x.Walking },
                PricePerHourInCoins = 10050000,
                PricePerDayInCoins = 100050000,
                Reiting = 45,
                TestAmountInCoins = 5000,
                OnlineStatus = true,
                Level = "SuperMen"
            }); ;


        }

        public static MockRep GetInstance()
        {
            return instance;
        }

        public int CreateOrder(Order_x order)
        {
            order.Id = new Random().Next();
            orders.Add(order);
            users.First(x => x.Id == order.Pet.UserId).Orders.Add(order);
            sitters.First(x => x.Id == order.Sitter.Id).Orders.Add(order);

            return 0;
        }

        public int CreatePet(Pet_x pet, int UserId)
        {
            throw new NotImplementedException();
        }

        public int CreatePet(Pet_x pet)
        {
            pet.Id = new Random().Next();
            users.First(x => x.Id == pet.UserId).Pets.Add(pet);

            return 0;
        }

        public int CreateSitter(Sitter_x sitter_x)
        {
            throw new NotImplementedException();
        }

        public int CreateUser(User_x user_x)
        {
            user_x.Id = new Random().Next();
            users.Add(user_x);

            return 0;
        }

        public string[] GetAllBreeds()
        {
            return new string[] {
                "Labrador Retrievers",
                "German Shepherd Dogs",
                "Golden Retrievers",
                "French Bulldogs",
                "Bulldogs",
                "Beagles",
                "Poodles",
                "Yorkshire Terriers	" };
        }

        public IEnumerable<Sitter_x> GetAllSitters()
        {
            return sitters;
        }

        public IEnumerable<Order_x> GetOrdersBySitterId(int SitterId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order_x> GetOrdersByUserId(int UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet_x> GetPetsByUserId(int UserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sitter_x> GetSitterByFilter(Filter_x filter)
        {
            return sitters.Where(x =>
            {
                return (x.KindofPet == filter.KindOfPet || x.KindofPet == KindOfPet_x.NONE)
            && (x.Types.Contains(filter.TypeSitter) || filter.TypeSitter == TypeSitter_x.None);
            });

        }

        public IEnumerable<Sitter_x> GetSittersByLocation(string location)
        {
            var l = DbGeography.FromText(location);

            return sitters.Where(x => DbGeography.FromText(x.Location).Distance(l) < 1000);
        }

        public User_x GetUserByUID(string UID)
        {
            return users.FirstOrDefault(x => x.UID == UID);
        }

        public int UpdateOrder(Order_x order)
        {
            orders.Remove(orders.First(x => x.Id == order.Id));
            orders.Add(order);

            var userOrders = users.First(x => x.Id == order.Pet.UserId).Orders;
            userOrders.Remove(userOrders.First(x => x.Id == order.Id));
            userOrders.Add(order);

            var sitterOrders = sitters.First(x => x.Id == order.Pet.UserId).Orders;
            sitterOrders.Remove(userOrders.First(x => x.Id == order.Id));
            sitterOrders.Add(order);

            return 0;
        }

        public int UpdatePet(Pet_x pet)
        {
            var userPets = users.First(x => pet.UserId == x.Id).Pets;
            userPets.Remove(userPets.First(x => x.Id == pet.Id));
            userPets.Add(pet);

            return 0;
        }

        public int UpdateSitter(Sitter_x sitter)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(User_x user)
        {
            users.Remove(user);
            users.Add(user);
            return 0;
        }

        public int CreateUser(string Uid)
        {
            throw new NotImplementedException();
        }
    }
}