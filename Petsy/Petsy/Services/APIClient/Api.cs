using Petsy.Models.DTO;
using Petsy.Services.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using static Petsy.Models.RequestJSON.RequestsJSON;

namespace Petsy.Services.APIClient
{
    /*
     W implementacji API zastosowano odmianę Paterna vraper, dla wyższego poziomu dostępu do bekendu,
    i ukrywanie wewnętrznej realizacji. Pozwoliło to na zmniejszenie powiązań między projektami, a nie przyciągać do REFIT, w każdej chwili
    podłączyć i wdrożyć inną bibliotekę.
    Zrealizowano również patern Singleton.
     */
    public class Api : IApi
    {
        /*
         HttpClientHandler - удали эту надстройку когда будет нормальный сертефикат! Этот код отключает 
        проверку сертефиката SSL!!!!
         */
        private static Api Instance = new Api();
        private static IClientRestApiRefit Service;

        private static readonly HttpClient client = new HttpClient(new HttpClientHandler()
        { ServerCertificateCustomValidationCallback = ((sender, cert, chain, sslPolicyErrors) => { return true; }) }
       )
        {
            BaseAddress = new Uri(
                //"http://134.249.160.114/Service/PetsyService.svc" // globalVersion Http
                "https://134.249.160.114/Service/PetsyService.svc" // globalVersion Https
                //"http://192.168.0.129/Service/PetsyService.svc" // localVersion Http
                )

        };

        public static void SetJwtToken(String token)
        {
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            Service = RestService.For<IClientRestApiRefit>(client, new RefitSettings()
            {
                JsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    //Будь осторожен  это означает что ссылки на обьекты не будут иннициализироваться

                }
            });

        }

        public static Api GetInstance()
        {
            if (Service == null)
            {
                throw new Exception("Gettin instance without JWT token is not possible ");
            }
            return Instance;
        }
        private Api()
        {
        }

        public User GetUserByToken()
        {
            return Service.GetUserByToken().Result.UserExternal;
        }

        public IEnumerable<Sitter> GetAllSitters()
        {
            return Service.GetAllSitters().Result.AllSitters;
        }

        public IEnumerable<Sitter> GetSitterByLocation(string location)
        {
            return Service.GetSittersByLocation(new GetSitterByLocationRequest(location)).Result.SittersByLocation;
        }

        public IEnumerable<Sitter> GetSittersByFilter(Filter filter)
        {
            return Service.GetSittersByFilter(new FilterRequest(filter)).Result.SittersByFilter;
        }

        public int CreateUser(User user)
        {
            return Service.CreateUser(new UserRequest(user)).Result.ResultExecution;
        }

        public int CreateSitter(Sitter sitter)
        {
            return Service.CreateSitter(new SitterRequest(sitter)).Result.ResultExecution;
        }

        public int CreateOrder(Order order)
        {
            return Service.CreateOrder(new OrderRequest(order)).Result.ResultExecution;
        }

        public int CreatePet(Pet pet)
        {
            return Service.CreatePet(new PetRequest(pet)).Result.ResultExecution;
        }

        public int UpdateUser(User user)
        {
            return Service.UpdateUser(new UserRequest(user)).Result.ResultExecution;

        }

        public int UpdateSitter(Sitter sitter)
        {
            return Service.UpdateSitter(new SitterRequest(sitter)).Result.ResultExecution;
        }

        public int UpdatePet(Pet pet)
        {
            return Service.UpdatePet(new PetRequest(pet)).Result.ResultExecution;
        }

        public int UpdateOrder(Order order)
        {
            return Service.UpdateOrder(new OrderRequest(order)).Result.ResultExecution;
        }

        public string[] GetAllBreeds()
        {
            return Service.GetAllBreeds().Result.AllBreeds;
        }

        public IEnumerable<Pet> GetPetsByUserId(int userId)
        {
            return Service.GetPetsByUserId(new UserIdRequest(userId)).Result.PetsByUserId;
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return Service.GetOrdersByUserId(new UserIdRequest(userId)).Result.OrdersByUserId;
        }

        public IEnumerable<Order> GetOrdersBySitterId(int sitterId)
        {
            return Service.GetOrdersBySitterId(new SitterIdRequest(sitterId)).Result.OrdersBySitterId;
        }
    }
}
