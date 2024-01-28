using PetSitterSrevice.ORM;
using PetSitterSrevice.ORM.Model;
using PetSitterSrevice.Service.ExternalEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;

using static PetSitterSrevice.Mapers.MapDomainDTO;

namespace PetSitterSrevice.Repository
{
    /**
     * На данный момент я хочу сделать репозиторий синглтоном, это значит что все потоки будут использовать один обьект
     * для подключения к базе данных. В будущем это может быть узким горлышком, если
     * в Entyti Framework не реализована автоматическая оптимизация работы в многопоточной системе. То есть 
     * по моей логике если у нас один класс для управления бд, то и одно подключение к бд на одном потоке, 
     * что звучит как плохая оптимизация работы с бд. Но я работаю только с интерфейсом фреймфорка орм, и надесь,
     * что в внутриностях оптимизация реализована автоматически.
     */
    public class Rep : IRep
    {
        private static readonly Rep instance = new Rep();

        private Rep()
        {
            using (var context = new PetSitterDbContext())
            {
                var breads = context.Breads;
                if (breads.Count() == 0)
                {
                    breads.Add(new Bread() { Name = "Labrador Retriever" });
                    breads.Add(new Bread() { Name = "German Shepherd Dog" });
                    breads.Add(new Bread() { Name = "French Bulldog" });
                    breads.Add(new Bread() { Name = "Golden Retriever" });
                    breads.Add(new Bread() { Name = "Bulldogs" });
                    breads.Add(new Bread() { Name = "Poodles" });
                    breads.Add(new Bread() { Name = "Beagles" });
                    breads.Add(new Bread() { Name = "Rottweilers" });
                    breads.Add(new Bread() { Name = "Pointers (German Shorthaired)" });
                    breads.Add(new Bread() { Name = "Pembroke Welsh Corgis" });
                    breads.Add(new Bread() { Name = "Dachshunds" });
                    breads.Add(new Bread() { Name = "Yorkshire Terriers" });
                    breads.Add(new Bread() { Name = "Australian Shepherds" });

                }
                var sitters = context.Sitters;
                if (sitters.Count() == 0)
                {
                    sitters.Add(new Sitter
                    {
                        Id = 1,
                        Name = "Mikol",
                        Surname = "DogMan",
                        Description = "Twój pies dostanie się w magiczne ręce",
                        UID = null,
                        UrlPhotoLable = "https://scontent-waw1-1.xx.fbcdn.net/v/t1.0-9/p960x960/117815403_3182091861866814_3309768340166989336_o.jpg?_nc_cat=111&_nc_sid=85a577&_nc_ohc=oZ5yJ707GhQAX82pl3s&_nc_ht=scontent-waw1-1.xx&_nc_tp=6&oh=120dc604f049a10e97e62c6739982764&oe=5F5D307B",
                        Types = new List<TypeSitterModel> { new TypeSitterModel() { Type = TypeSitter.PetSitting } },
                        PricePerHourInCoins = 555,
                        PricePerDayInCoins = 205,
                        Reiting = 48,
                        TestAmountInCoins = 2000,
                        OnlineStatus = false,
                        Level = "IronMan"
                    });

                    sitters.Add(new Sitter
                    {
                        Id = 2,
                        Name = "Nikola",
                        Surname = "BossOfMops",
                        Description = "Спортсмен с десятилетним сажем, возмьу вашу собкау на пробежку.",
                        UID = null,
                        UrlPhotoLable = "https://scontent-waw1-1.xx.fbcdn.net/v/t1.0-9/117645202_2683829375269118_8317780132219506817_n.jpg?_nc_cat=105&_nc_sid=dd7718&_nc_ohc=F9GE6zMDKwAAX8t_F5k&_nc_ht=scontent-waw1-1.xx&oh=581b7bb948366bc347e136b685dcd117&oe=5F60039B",
                        Types = new List<TypeSitterModel> { new TypeSitterModel() { Type = TypeSitter.Walking } },
                        PricePerHourInCoins = 10050000,
                        PricePerDayInCoins = 100050000,
                        Reiting = 45,
                        TestAmountInCoins = 5000,
                        OnlineStatus = true,
                        Level = "SuperMen",
                    }); ;

                }
                context.SaveChanges();
            }
        }

        public static Rep GetInstance()
        {
            return instance;
        }

        public int CreateOrder(Order_x order)
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                var model = MapToDamain(order);
                context.Orders.Add(model);
                context.SaveChanges();

                result = 0;

            }

            return result;
        }

        public int CreatePet(Pet_x pet)
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                var model = MapToDamain(pet);
                context.Pets.Add(model);
                context.SaveChanges();

                result = 0;
            }

            return result;
        }

        public int CreateSitter(Sitter_x sitter)
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                context.Sitters.Add(MapToDamain(sitter));
                context.SaveChanges();
                result = 0;
            }

            return result;
        }

        public int CreateUser(string Uid)
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                var users = context.Users;
                bool isAlreadyExist = users.Any(x => x.UID == Uid);
                if ((isAlreadyExist || Uid == null || Uid.Equals("")) != true)
                {
                    context.Users.Add(new ORM.Model.User() { UID = Uid });
                    context.SaveChanges();
                    result = 0;
                }
                else
                {
                    result = -1;
                }
            }

            return result;
        }

        public int CreateUser(User_x user_x)
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                context.Users.Add(MapToDamain(user_x));
                context.SaveChanges();
                result = 0;
            }

            return result;
        }

        public string[] GetAllBreeds()
        {
            using (var context = new PetSitterDbContext())
            {
                return context.Breads.Select(x => x.Name).ToArray();
            }
        }

        public IEnumerable<Sitter_x> GetAllSitters()
        {
            ICollection<Sitter_x> result = new List<Sitter_x>();
            using (var context = new PetSitterDbContext())
            {
                var res = context.Sitters.ToList();
                foreach (var r in res)
                {
                    result.Add(MapToDto(r));
                }
            }
            return result;

        }

        public IEnumerable<Order_x> GetOrdersBySitterId(int SitterId)
        {
            ICollection<Order_x> orders = new List<Order_x>();
            using (var context = new PetSitterDbContext())
            {
                var dbOrders = context.Orders.Where(x => x.SitterId == SitterId);
                foreach (var modelOrder in dbOrders)
                {
                    orders.Add(MapToDto(modelOrder));
                }
            }
            return orders;
        }

        public IEnumerable<Order_x> GetOrdersByUserId(int UserId)
        {
            ICollection<Order_x> orders = new List<Order_x>();
            using (var context = new PetSitterDbContext())
            {
                var dbOrders = context.Orders.Where(x => x.Pet.UserId == UserId);
                foreach (var modelOrder in dbOrders)
                {
                    orders.Add(MapToDto(modelOrder));
                }
            }
            return orders;
        }

        public IEnumerable<Pet_x> GetPetsByUserId(int UserId)
        {
            ICollection<Pet_x> pets = new List<Pet_x>();
            using (var context = new PetSitterDbContext())
            {
                var dbPets = context.Pets.Where(x => x.UserId == UserId).ToList();
                foreach (var modelPet in dbPets)
                {
                    pets.Add(MapToDto(modelPet));
                }
            }
            return pets;

        }

        public IEnumerable<Sitter_x> GetSitterByFilter(Filter_x filter)
        {
            var allSitters = GetAllSitters();
            var filteredSitters = allSitters.Where(x =>
            (x.KindofPet == filter.KindOfPet || x.KindofPet == KindOfPet_x.NONE)
               && (x.Types.Contains(filter.TypeSitter) || filter.TypeSitter == TypeSitter_x.None));

            return filteredSitters;
        }

        public IEnumerable<Sitter_x> GetSittersByLocation(string location)
        {
            var l = DbGeography.FromText(location);

            return GetAllSitters().Where(x => DbGeography.FromText(x.Location).Distance(l) < 1000);
        }

        public User_x GetUserByUID(string Uid)
        {
            User_x user = null;
            if ((Uid == null || Uid.Equals("")) == true)
            {
                return null;
            }
            using (var context = new PetSitterDbContext())
            {
                try
                {
                    var DbUser = context.Users.First(x => x.UID == Uid);
                    user = MapToDto(DbUser);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return user;

        }

        public int UpdateOrder(Order_x order)//-----------------------------------------------propaply not working 
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                var freshOrder = MapToDamain(order);
                var curOrder = context.Orders.Where(x => x.Id == order.Id).FirstOrDefault();
                CustomMapper.Map<Order, Order>(freshOrder, curOrder);
                //context.Sitters.Where(x=> x.Id == order.Sitter.Id).First().Orders.

                //update order in users and sitters!!!

                context.SaveChanges();
                result = 0;
            }

            return result;
        }

        public int UpdatePet(Pet_x pet)//-----------------------------------------------
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                var freshPet = MapToDamain(pet);
                var curPet = context.Pets.Where(x => x.Id == pet.Id).FirstOrDefault();
                CustomMapper.Map<Pet, Pet>(freshPet, curPet);
                context.SaveChanges();
                result = 0;
            }

            return result;
        }

        public int UpdateSitter(Sitter_x sitter)
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                throw new NotImplementedException();
            }

            return result;
        }

        public int UpdateUser(User_x user)
        {
            int result = -1;
            using (var context = new PetSitterDbContext())
            {
                var updatingUser = context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                if (updatingUser != null)
                {
                    CustomMapper.Map<User_x, User>(user, updatingUser);
                    context.SaveChanges();
                    result = 0;
                }
            }

            return result;
        }
    }
}