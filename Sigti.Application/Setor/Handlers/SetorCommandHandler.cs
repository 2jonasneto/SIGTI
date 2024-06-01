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
        ICommandHandler<AtualizarSetorCommand>,ICommandHandler<RemoverSetorCommand>
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
            try
            {
                /*c.Validate();
                           if (c.IsValid == false)
                           {
                               return new GenericCommandResult(false, CommandMessages.InsertError, c.Notifications);
                           }*/
                var d = _mapper.Map<Setor>(command);
                if (!_data.Setores.Create(d))
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
            catch (Exception EX)
            {

                throw EX;
            }

           

        }

        public async Task<ICommandResult> Execute(AtualizarSetorCommand command)
        {
            var setor = await _data.Setores.GetByIdAsync(command.Id);
            if (setor == null)
            {
                return new GenericCommandResult(false, "Registro não existe na base", Notifications);

            }
            setor.Atualizar(command.Nome, command.Descricao,command.LocalizacaoId, command.ModificadoPor);
            if (!await _data.Init())
            {
                AddNotifications(_data.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
            }
            if (!_data.Setores.Update(setor))
            {
                AddNotifications(_data.Localizacoes.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
            }

            if (!await _data.Save())
            {
                await _data.Rollback();
                AddNotifications(_data.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
            }
            if (!await _data.Commit())
            {
                AddNotifications(_data.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
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
        public void NotificationsClear()
        {
            Clear();
        }
    }
  
}
