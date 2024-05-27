using AutoMapper;
using Flunt.Notifications;
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
    public class ComputadorCommandHandler : Notifiable<Notification>, ICommandHandler<AdicionarComputadorCommand>, ICommandHandler<AtualizarComputadorCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public ComputadorCommandHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<ICommandResult> Execute(AdicionarComputadorCommand command)
        {
           

                /*c.Validate();
                if (c.IsValid == false)
                {
                    return new GenericCommandResult(false, CommandMessages.InsertError, c.Notifications);
                }*/
                if (_data.Computadores.Create(_mapper.Map<Computador>(command)))
                {
                    AddNotifications(_data.Computadores.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Save())
                {
                    AddNotifications(_data.Computadores.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);

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
        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }
    }
}
