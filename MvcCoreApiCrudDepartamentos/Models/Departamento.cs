using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreApiCrudDepartamentos.Models
{
    public class Departamento
    {
        [JsonProperty("DEPT_NO")]
        public int IdDepartamento { get; set; }

        [JsonProperty("DNOMBRE")]
        public string Nombre { get; set; }
        [JsonProperty("LOC")]
        public string Localidad { get; set; }
    }
}
