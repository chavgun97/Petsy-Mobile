using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class Filter_x
    {   [JsonProperty("KindOfPet")]
        public KindOfPet_x KindOfPet { get; set; }

        [JsonProperty("TypeSitter")]
        public TypeSitter_x TypeSitter { get; set; }
    }
}
