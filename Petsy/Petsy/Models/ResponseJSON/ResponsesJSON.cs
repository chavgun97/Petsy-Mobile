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
            public User_x UserExternal { get; set; }
        }

        public class GetAllSittersResponse
        {
            [JsonProperty("GetAllSittersResult")]
            public IEnumerable<Sitter_x> AllSitters { get; set; }
        }
        public class GetSittersByLocationResponse
        {
            [JsonProperty("GetSittersByLocationResult")]
            public IEnumerable<Sitter_x> SittersByLocation { get; set; }
        }
        public class GetSitterByFilterResponse
        {
            [JsonProperty("GetSitterByFilterResult")]
            public IEnumerable<Sitter_x> SittersByFilter { get; set; }
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
       


    }
}
