using AutoMapper;
using Sigti.Application.Base;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Handlers
{
    public class ComputadorCommandHandler : ICommandHandler<AdicionarComputadorCommand>, ICommandHandler<AtualizarComputadorCommand>
    {
        private readonly IMapper mapper;
        private readonly IUnitForWork data;

        public ComputadorCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<ICommandResult> Execute(AdicionarComputadorCommand command)
        {
            try
            {
                var results = new List<(bool, string)>();
                results.Add(await data.CreateTransaction());

                var pc = mapper.Map<Computador>(command);
                await data.Computadores.AdicionarAsync(pc);
                results.Add(await data.Save());
                results.Add(await data.Commit());

                return new CommandResult(results);
            }
            catch (Exception ex)
            {
              await  data.Rollback();
                return new CommandResult(false, "Ocorreu um ao executar esta operação\n\n"+ex.Message);
               
            }


        }

        public async Task<ICommandResult> Execute(AtualizarComputadorCommand command)
        {
            try
            {
                var results = new List<(bool, string)>();
                results.Add(await data.CreateTransaction());

                var pc = mapper.Map<Computador>(command);
                await data.Computadores.AtualizarAsync(pc);
                results.Add(await data.Save());
                results.Add(await data.Commit());

                return new CommandResult(results);
            }
            catch (Exception ex)
            {
                await data.Rollback();
                return new CommandResult(false, "Ocorreu um ao executar esta operação\n\n" + ex.Message);

            }
        }
    }
}
