using Sigti.Application.DTO;
using System.Net.Http.Json;

namespace Sigti.Web.Services
{
    public class ComputadorService(IHttpClientFactory httpClientFactory) : IComputadorService
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient("Api");
        public async Task<List<ListaComputadorGridDTO>> GetComputadores() => await _client.GetFromJsonAsync<List<ListaComputadorGridDTO>?>("v2/Computadores")
           ?? new List<ListaComputadorGridDTO>();
    }
}
