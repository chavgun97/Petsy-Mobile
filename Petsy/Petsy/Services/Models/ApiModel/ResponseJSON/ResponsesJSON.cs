using Newtonsoft.Json;
using Petsy.Models.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Petsy.Models.ResponseJSON
{
    public static class ResponsesJSON
    {
       public class GetUserByTokenResponse
        {
            [JsonProperty("GetUserByTokenResult")]
            public User UserExternal { get; set; }
        }

        public class GetAllSittersResponse
        {
            [JsonProperty("GetAllSittersResult")]
            public IEnumerable<Sitter> AllSitters { get; set; }
        }
        public class GetSittersByLocationResponse
        {
            [JsonProperty("GetSittersByLocationResult")]
            public IEnumerable<Sitter> SittersByLocation { get; set; }
        }
        public class GetSitterByFilterResponse
        {
            [JsonProperty("GetSitterByFilterResult")]
            public IEnumerable<Sitter> SittersByFilter { get; set; }
        }
        public class CreateUserResponse
        {
            [JsonProperty("CreateUserResult")]
            public int ResultExecution { get; set; }

        }
        public class CreateSitterResponse
        {
            [JsonProperty("CreateSitterResult")]
            public int ResultExecution { get; set; }
        }
        public class CreateOrderResponse
        {
            [JsonProperty("CreateOrderResult")]
            public int ResultExecution { get; set; }
        }
        public class CreatePetResponse
        {
            [JsonProperty("CreatePetResult")]
            public int ResultExecution { get; set; }
        }
        public class UpdateUserResponse
        {
            [JsonProperty("UpdateUserResult")]
            public int ResultExecution { get; set; }

        }
        public class UpdateSitterResponse
        {
            [JsonProperty("UpdateSitterResult")]
            public int ResultExecution { get; set; }
        }
        public class UpdatePetResponse
        {
            [JsonProperty("UpdatePetResult")]
            public int ResultExecution { get; set; }
        }
        public class UpdateOrderResponse
        {
            [JsonProperty("UpdateOrderResult")]
            public int ResultExecution { get; set; }
        }

        public class GetAllBreedsResponse
        {
            [JsonProperty("GetAllBreedsResult")]
            public string[] AllBreeds { get; set; }
        }

        public class GetOrdersBySitterIdResponse
        {
            [JsonProperty("GetOrdersBySitterIdResult")]
            public IEnumerable<Order> OrdersBySitterId { get; set; }
        }

        public class GetOrdersByUserIdResponse
        {
            [JsonProperty("GetOrdersByUserIdResult")]
            public IEnumerable<Order> OrdersByUserId { get; set; }
        }

        public class GetPetsByUserIdResponse
        {
            [JsonProperty("GetPetsByUserIdResult")]
            public IEnumerable<Pet> PetsByUserId { get; set; }
        }



    }
}
