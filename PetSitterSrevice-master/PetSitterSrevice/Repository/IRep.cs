using PetSitterSrevice.Service.ExternalEntity;
using System;
using System.Collections.Generic;

namespace PetSitterSrevice.Repository
{
    interface IRep
    {
        User_x GetUserByUID(String UID);
        IEnumerable<Sitter_x> GetAllSitters();
        IEnumerable<Pet_x> GetPetsByUserId(int UserId);
        IEnumerable<Order_x> GetOrdersByUserId(int UserId);
        IEnumerable<Order_x> GetOrdersBySitterId(int SitterId);
        IEnumerable<Sitter_x> GetSittersByLocation(String location);
        IEnumerable<Sitter_x> GetSitterByFilter(Filter_x filter);

        int CreateUser(User_x user_x);
        int CreateUser(string Uid);
        int CreateSitter(Sitter_x sitter_x);
        int CreateOrder(Order_x order);
        int CreatePet(Pet_x pet);
        int UpdateUser(User_x user);
        int UpdateSitter(Sitter_x sitter);
        int UpdateOrder(Order_x order);
        int UpdatePet(Pet_x pet);
        string[] GetAllBreeds();

    }
}
