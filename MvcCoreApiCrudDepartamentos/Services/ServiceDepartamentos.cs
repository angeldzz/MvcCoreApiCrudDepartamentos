using MvcCoreApiCrudDepartamentos.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreApiCrudDepartamentos.Services
{
    public class ServiceDepartamentos
    {
        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceDepartamentos(IConfiguration configuration)
        {
            ApiUrl = configuration.GetValue<string>("ApiUrls:ApiCrudDepartamentos");
            header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);  
                }
            }
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            string request = "api/departamento";
            List<Departamento> departamentos = await CallApiAsync<List<Departamento>>(request);
            return departamentos;
        }
        public async Task<Departamento> GetDepartamentoAsync(int id)
        {
            string request = $"api/departamento/{id}";
            Departamento departamento = await CallApiAsync<Departamento>(request);
            return departamento;
        }
        public async Task CreateDepartamentoAsync(int id, string nombre, string localidad)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/departamento";
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //Creamos nuestro model
                Departamento departamento = new Departamento
                {
                    IdDepartamento = id,
                    Nombre = nombre,
                    Localidad = localidad
                };
                string json = JsonConvert.SerializeObject(departamento);
                //PARA enviar la informacion usamos la clase stringcontent
                StringContent content = new StringContent
                    (json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
            }
        }
        public async Task DeleteDepartamentoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = $"api/departamento/{id}";
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.DeleteAsync(request);
            }
        }
        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/departamento";
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //Creamos nuestro model
                Departamento departamento = new Departamento
                {
                    IdDepartamento = id,
                    Nombre = nombre,
                    Localidad = localidad
                };
                string json = JsonConvert.SerializeObject(departamento);
                //PARA enviar la informacion usamos la clase stringcontent
                StringContent content = new StringContent
                    (json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
            }
        }
    }
}
