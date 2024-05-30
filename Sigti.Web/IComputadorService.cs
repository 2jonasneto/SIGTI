
using Sigti.Application.DTO;
using System.Net.Http.Json;

namespace Sigti.Web
{
    public interface IComputadorService
    {
        Task<List<ListaComputadorGridDTO>?> GetAllAsync();

    }
    public class ComputadorService(IHttpClientFactory httpClientFactory) : IComputadorService
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient("api");

        public async Task<List<ListaComputadorGridDTO>?> GetAllAsync()

     => await _client.GetFromJsonAsync<List<ListaComputadorGridDTO>?>("v2/Computadores")
           ?? new List<ListaComputadorGridDTO>();
    }


}

