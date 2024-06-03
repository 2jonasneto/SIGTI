using AutoMapper;
using Flunt.Notifications;
using Sigti.Application.Base;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Handlers
{
    public class ControladoraCommandHandler : Notifiable<Notification>, ICommandHandler<AdicionarControladoraCommand>,
        ICommandHandler<AtualizarControladoraCommand>, ICommandHandler<RemoverControladoraCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public ControladoraCommandHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<ICommandResult> Execute(AdicionarControladoraCommand command)
        {
            try
            {

                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                var d = _mapper.Map<Controladora>(command);
                if (!_data.Controladoras.Create(d))
                {
                    await _data.Rollback();
                    AddNotifications(_data.Controladoras.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Save())
                {
                    await _data.Rollback();
                    AddNotifications(_data.Controladoras.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Commit())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                return new GenericCommandResult(true, CommandMessages.InsertSuccess, Notifications);
            }
            catch (Exception ex)
            {

                AddNotification("Erro", ex.Message);
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }



        }

        public async Task<ICommandResult> Execute(AtualizarControladoraCommand command)
        {
            try
            {
                var control = await _data.Controladoras.GetByIdAsync(command.Id);
                if (control == null)
                {
                    return new GenericCommandResult(false, "Registro não existe na base", Notifications);

                }
                control.Atualizar(command.Nome, command.Descricao, command.LocalizacaoId, command.ModificadoPor,command.SetorId);
                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                if (!_data.Controladoras.Update(control))
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
        public async Task<ICommandResult> Execute(RemoverControladoraCommand command)
        {

            if (!_data.Controladoras.Delete(command.Id))
            {
                AddNotifications(_data.Controladoras.GetNotifications());
                return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
            }
            if (!await _data.Save())
            {
                AddNotifications(_data.Controladoras.GetNotifications());
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
