using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petsy.Models.DTO
{
    public class Filter
    {   [JsonProperty("KindOfPet")]
        public KindOfPet KindOfPet { get; set; }

        [JsonProperty("TypeSitter")]
        public TypeSitter TypeSitter { get; set; }
    }
}
