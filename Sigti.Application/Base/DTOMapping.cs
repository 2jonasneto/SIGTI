using AutoMapper;
using Sigti.Application.DTO;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;

namespace Sigti.Application.Base
{
    public class DTOMapping:Profile
    {
        public DTOMapping()
        {
          CreateMap<Computador,ComputadorDTO>();  
          CreateMap<AdicionarComputadorCommand,Computador>();  
          CreateMap<AtualizarComputadorCommand,Computador>();  
          
        }
       
    }
}
