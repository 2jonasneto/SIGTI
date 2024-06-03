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
    public class LocalizacaoCommandHandler : Notifiable<Notification>, ICommandHandler<AdicionarLocalizacaoCommand>,
        ICommandHandler<AtualizarLocalizacaoCommand>,
        ICommandHandler<RemoverLocalizacaoCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public LocalizacaoCommandHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<ICommandResult> Execute(AdicionarLocalizacaoCommand command)
        {
            try
            {

                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!_data.Localizacoes.Create(_mapper.Map<Localizacao>(command)))
                {
                    await _data.Rollback();
                    AddNotifications(_data.Localizacoes.GetNotifications());
                    _data.Localizacoes.NotificationsClear();
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Save())
                {
                    await _data.Rollback();
                    AddNotifications(_data.GetNotifications());
                    _data.NotificationsClear();
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Commit())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);
            }
            catch (Exception ex)
            {

                AddNotification("Erro", ex.Message);
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }


        }

        public async Task<ICommandResult> Execute(AtualizarLocalizacaoCommand command)
        {
            try
            {
                var loc = await _data.Localizacoes.GetByIdAsync(command.Id);
                if (loc == null)
                {
                    return new GenericCommandResult(false, "Registro não existe na base", Notifications);

                }
                loc.Atualizar(command.Nome, command.Descricao, command.ModificadoPor);
                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                if (!_data.Localizacoes.Update(loc))
                {
                    await _data.Rollback();
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
                return new GenericCommandResult(true, CommandMessages.UpdateSuccess, Notifications);
            }
            catch (Exception ex)
            {

                AddNotification("Erro", ex.Message);
                return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
            }

        }
        public async Task<ICommandResult> Execute(RemoverLocalizacaoCommand command)
        {

            if (!_data.Localizacoes.Delete(command.Id))
            {
                AddNotifications(_data.Localizacoes.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            if (!await _data.Save())
            {
                AddNotifications(_data.GetNotifications());
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
