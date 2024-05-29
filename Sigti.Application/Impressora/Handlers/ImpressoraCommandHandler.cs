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
    public class ImpressoraCommandHandler : Notifiable<Notification>, ICommandHandler<AdicionarImpressoraCommand>, 
        ICommandHandler<AtualizarImpressoraCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public ImpressoraCommandHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<ICommandResult> Execute(AdicionarImpressoraCommand command)
        {
           

                /*c.Validate();
                if (c.IsValid == false)
                {
                    return new GenericCommandResult(false, CommandMessages.InsertError, c.Notifications);
                }*/
                if (!_data.Impressoras.Create(_mapper.Map<Impressora>(command)))
                {
                    AddNotifications(_data.Impressoras.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Save())
                {
                    AddNotifications(_data.Impressoras.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);

        }

        public async Task<ICommandResult> Execute(AtualizarImpressoraCommand command)
        {

            if (!_data.Impressoras.Create(_mapper.Map<Impressora>(command)))
            {
                AddNotifications(_data.Impressoras.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            if (!await _data.Save())
            {
                AddNotifications(_data.Impressoras.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);
        }
        public async Task<ICommandResult> Execute(RemoverImpressoraCommand command)
        {

            if (!_data.Impressoras.Delete(command.Id))
            {
                AddNotifications(_data.Impressoras.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            if (!await _data.Save())
            {
                AddNotifications(_data.Impressoras.GetNotifications());
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
