using Microsoft.AspNetCore.Components;
using Sigti.Application.DTO;
using Sigti.Application.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static MudBlazor.Colors;

namespace Sigti.Web.Pages.Computadores
{
    public partial class ComputadorListaPage:ComponentBase
    {
        public IEnumerable<ListaComputadorGridDTO> _computadores = new List<ListaComputadorGridDTO>();

        [Inject]
        public IComputadorService Query { get; set; } = null;
        protected override async Task OnInitializedAsync()
        {
                      _computadores = await Query.GetAllAsync();


        }
      
        
        
    }
}
