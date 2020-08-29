using Petsy.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Services.Interfaces
{
    interface IApi
    {
        User GetUserByToken();

        IEnumerable<Sitter> GetAllSitters();

        IEnumerable<Sitter> GetSitterByLocation(string location);

        IEnumerable<Sitter> GetSittersByFilter(Filter filter);

        int CreateUser(User user);

        int CreateSitter(Sitter sitter);

        int CreateOrder(Order order);

        int CreatePet(Pet pet);

        int UpdateUser(User user);

        int UpdateSitter(Sitter sitter);

        int UpdatePet(Pet pet);

        int UpdateOrder(Order order);

        string[] GetAllBreeds();

        IEnumerable<Pet> GetPetsByUserId(int userId);

        IEnumerable<Order> GetOrdersByUserId(int userId);

        IEnumerable<Order> GetOrdersBySitterId(int sitterId);
    }
}
