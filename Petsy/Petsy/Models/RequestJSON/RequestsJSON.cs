using Newtonsoft.Json;
using Petsy.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.RequestJSON
{
    public static class RequestsJSON
    {
        public class UserRequest
        {

            [JsonProperty("user")]
            public User_x user { get; set; }

            public UserRequest(User_x user)
            {
                this.user = user;
            }
        }

        public class PetRequest
        {

            [JsonProperty("pet")]
            public Pet_x pet { get; set; }

            public PetRequest(Pet_x pet)
            {
                this.pet = pet;
            }
        }

        public class OrderRequest
        {

            [JsonProperty("order")]
            public Order_x order { get; set; }

            public OrderRequest(Order_x order)
            {
                this.order = order;
            }
        }

      

        public class SitterRequest
        {

            [JsonProperty("sitter")]
            public Sitter_x sitter { get; set; }

            public SitterRequest(Sitter_x sitter)
            {
                this.sitter = sitter;
            }
        }
        public class FilterRequest
        {

            [JsonProperty("filter")]
            public Filter_x filter { get; set; }

            public FilterRequest(Filter_x filter)
            {
                this.filter = filter;
            }
        }

        public class GetSitterByLocationRequest
        {
            public GetSitterByLocationRequest(string l)
            {
                Location = l;
            }

            [JsonProperty("location")]
            public string Location { get; set; }
        }
    }
}
