using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PWS40.Backend.Conways.Model
{
    public record GameFieldModel
    {
        [JsonPropertyName("rows")]
        public int Row { get; set; }

        [JsonPropertyName("columns")]
        public int Column { get; set; }

        [JsonPropertyName("active-cells")]
        public CellModel[] AliveCells { get; set; }
    }
}
