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
    public class SetorCommandHandler : Notifiable<Notification>, ICommandHandler<AdicionarSetorCommand>, 
        ICommandHandler<AtualizarSetorCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public SetorCommandHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<ICommandResult> Execute(AdicionarSetorCommand command)
        {
           

                /*c.Validate();
                if (c.IsValid == false)
                {
                    return new GenericCommandResult(false, CommandMessages.InsertError, c.Notifications);
                }*/
                if (!_data.Setores.Create(_mapper.Map<Setor>(command)))
                {
                    AddNotifications(_data.Setores.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Save())
                {
                    AddNotifications(_data.Setores.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);

        }

        public async Task<ICommandResult> Execute(AtualizarSetorCommand command)
        {

            if (!_data.Setores.Create(_mapper.Map<Setor>(command)))
            {
                AddNotifications(_data.Setores.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            if (!await _data.Save())
            {
                AddNotifications(_data.Setores.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);
        }
        public async Task<ICommandResult> Execute(RemoverSetorCommand command)
        {

            if (!_data.Setores.Delete(command.Id))
            {
                AddNotifications(_data.Setores.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            if (!await _data.Save())
            {
                AddNotifications(_data.Setores.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);
        }
        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }
        
    }
  
}
