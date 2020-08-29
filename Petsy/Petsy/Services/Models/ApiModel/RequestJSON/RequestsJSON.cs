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
            public User user { get; set; }
            public UserRequest(User user)
            {
                this.user = user;
            }
        }
        public class PetRequest
        {
            [JsonProperty("pet")]
            public Pet pet { get; set; }
            public PetRequest(Pet pet)
            {
                this.pet = pet;
            }
        }

        public class OrderRequest
        {

            [JsonProperty("order")]
            public Order order { get; set; }

            public OrderRequest(Order order)
            {
                this.order = order;
            }
        }

      

        public class SitterRequest
        {

            [JsonProperty("sitter")]
            public Sitter sitter { get; set; }

            public SitterRequest(Sitter sitter)
            {
                this.sitter = sitter;
            }
        }
        public class FilterRequest
        {

            [JsonProperty("filter")]
            public Filter filter { get; set; }

            public FilterRequest(Filter filter)
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

        public class SitterIdRequest
        {
           
            public SitterIdRequest(int sitterId) { 
                SitterId = sitterId;
            }

            [JsonProperty("SitterId")]
            public int SitterId { get; set; }
        }

        public class UserIdRequest
        {
            public UserIdRequest(int userId)
            {
                UserId = userId;
            }

            [JsonProperty("UserId")]
            public int UserId { get; set; }
        }
    }
}
