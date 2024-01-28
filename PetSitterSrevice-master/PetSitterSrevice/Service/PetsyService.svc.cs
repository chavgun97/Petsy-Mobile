using PetSitterSrevice.Repository;
using PetSitterSrevice.Service.ExternalEntity;
using System;
using System.Collections.Generic;
using System.ServiceModel.Web;

namespace PetSitterSrevice.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PetsyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PetsyService.svc or PetsyService.svc.cs at the Solution Explorer and start debugging.
    public class PetsyService : IPetsyService
    {
        private IRep repository = Rep.GetInstance();//MockRep.GetInstance();


        public int CreateUser(User_x user)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            if (user.UID != UID) throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.CreateUser(user);

        }

        public User_x GetUserByToken()
        {
            string idUser = CheckJWT(WebOperationContext.Current);

            User_x user = repository.GetUserByUID(idUser);

            return user;
        }

        public string IsWorking()
        {
            return "i am working!";
        }

        public IEnumerable<Sitter_x> GetAllSitters()
        {
            CheckJWT(WebOperationContext.Current);

            return repository.GetAllSitters();
        }

        public IEnumerable<Sitter_x> GetSittersByLocation(string location)
        {
            CheckJWT(WebOperationContext.Current);

            return repository.GetSittersByLocation(location);
        }

        public IEnumerable<Sitter_x> GetSitterByFilter(Filter_x filter)
        {
            CheckJWT(WebOperationContext.Current);
            var t = repository.GetSitterByFilter(filter);
            return t;
        }

        public int CreateSitter(Sitter_x sitter)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            if (sitter.UID != UID) throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.CreateSitter(sitter);
        }

        //needs tests
        public int CreateOrder(Order_x order)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            var user = repository.GetUserByUID(UID);
            //var sitter = repository.GetSitterByUID(UID);
            if ((order.Pet.UserId != 0 & user.Id != order.Pet.UserId) && (order.Sitter != null & order.Sitter.UID != UID))
                throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.CreateOrder(order);
        }

        public int CreatePet(Pet_x pet)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            var user = repository.GetUserByUID(UID);
            if (user.UID != UID) throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.CreatePet(pet);
        }

        public int UpdateUser(User_x user)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            if (user.UID != UID) throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.UpdateUser(user);
        }

        public int UpdateSitter(Sitter_x sitter)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            if (sitter.UID != UID) throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.UpdateSitter(sitter);
        }

        public int UpdatePet(Pet_x pet)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            var user = repository.GetUserByUID(UID);
            if (user.Id != pet.UserId) throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.UpdatePet(pet);
        }

        public int UpdateOrder(Order_x order)
        {
            string UID = CheckJWT(WebOperationContext.Current);
            var user = repository.GetUserByUID(UID);
            if ((user == null & user.Id != order.Pet.UserId) && (order.Sitter == null & order.Sitter.UID != UID))
                throw new Exception("UidProvideUserDontMachWithAuthUid");

            return repository.UpdateOrder(order);
        }

        public string[] GetAllBreeds()
        {
            CheckJWT(WebOperationContext.Current);

            return repository.GetAllBreeds();
        }
        public string CheckJWT(WebOperationContext context)
        {
            var req = context.IncomingRequest.Headers.Get("Authorization");
            var stringValues = req.Split(' ');
            if (stringValues.Length != 2 || !stringValues[0].Equals("Bearer"))
                throw new Exception("Bed Authorithation Token in Header");
            var FireBaseAuthKey = stringValues[1];
            return FireBaseAuth.FireBaseAuth.CheckAndGetUidFromToken(FireBaseAuthKey).Result;
        }

        public IEnumerable<Pet_x> GetPetsByUserId(int UserId)
        {
            CheckJWT(WebOperationContext.Current);
            //check user id!!!!
            return repository.GetPetsByUserId(UserId);
        }

        public IEnumerable<Order_x> GetOrdersByUserId(int UserId)
        {
            CheckJWT(WebOperationContext.Current);
            //check user id!!!!

            return repository.GetOrdersByUserId(UserId);
        }

        public IEnumerable<Order_x> GetOrdersBySitterId(int SitterId)
        {
            CheckJWT(WebOperationContext.Current);
            //check user id!!!!

            return repository.GetOrdersBySitterId(SitterId);
        }
    }
}
