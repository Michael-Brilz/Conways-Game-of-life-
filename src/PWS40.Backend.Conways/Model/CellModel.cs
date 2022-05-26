﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PWS40.Backend.Conways.Model
{
    public record CellModel
    {
        [JsonPropertyName("row")]
        public int Row { get; set; }
        
        [JsonPropertyName("column")]
        public int Column { get; set; }      
    }
}
