using Alvarez_ExamenProgreso3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alvarez_ExamenProgreso3.Services
{
    public class ApiService
    {
        private const string ApiBaseUrl = "https://api.api-ninjas.com/v1/facts";
        private const string ApiKey = "GRol827ayhIzRiSFdV2Hkg==D1boKDrjplJoFPdu"; // Reemplaza con tu clave de API

        public async Task<List<FactModel>> GetFactsAsync(int limit)
        {
            try
            {
                Console.WriteLine($"Iniciando solicitud a la API con límite: {limit}");

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{ApiBaseUrl}?limit={limit}";
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                    request.Headers.Add("X-Api-Key", ApiKey);

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        List<FactModel> facts = JsonConvert.DeserializeObject<List<FactModel>>(jsonResult);

                        Console.WriteLine($"Recibidos {facts.Count} Fun Facts de la API:");

                        foreach (var fact in facts)
                        {
                            Console.WriteLine($"- {fact.JA_FactText}"); // Muestra la propiedad 'FactText' de FactModel
                        }

                        return facts;
                    }
                    else
                    {
                        // Manejar el caso en que la solicitud no sea exitosa
                        Console.WriteLine($"Error en la solicitud a la API: {response.ReasonPhrase}");
                        return null; // Devolvemos null para indicar que no se pudo obtener datos
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada
                Console.WriteLine($"Error en la solicitud a la API: {ex.Message}");
                return null; // Devolvemos null para indicar que no se pudo obtener datos
            }
        }
    }
}



