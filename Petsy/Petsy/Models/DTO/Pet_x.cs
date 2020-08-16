using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class Pet_x
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        
        [JsonProperty("Name")]
        public string Name { get; set; }
        
        [JsonProperty("Sex")]
        public bool Sex { get; set; }
        
        [JsonProperty("DateOfBirthday")]
        public DateTime DateOfBirthday { get; set; }
        
        [JsonProperty("UrlPhotoLable")]
        public string UrlPhotoLable { get; set; }
       
        [JsonProperty("Kind")]
        public KindOfPet_x Kind { get; set; }  
        
        [JsonProperty("Breed")]
        public string Breed { get; set; } 
        
        [JsonProperty("Recommendation")]
        public string Recommendation { get; set; }
        
        [JsonProperty("User_x")]
        virtual public User_x User { get; set; }
    }
}
