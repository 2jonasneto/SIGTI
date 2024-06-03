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
        ICommandHandler<AtualizarImpressoraCommand>, ICommandHandler<RemoverImpressoraCommand>
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

            try
            {

                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                if (!_data.Impressoras.Create(_mapper.Map<Impressora>(command)))
                {
                    await _data.Rollback();
                    AddNotifications(_data.Impressoras.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Save())
                {
                    await _data.Rollback();
                    AddNotifications(_data.Impressoras.GetNotifications());
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

        public async Task<ICommandResult> Execute(AtualizarImpressoraCommand command)
        {


            try
            {
                var impressora = await _data.Impressoras.GetByIdAsync(command.Id);
                if (impressora == null)
                {
                    return new GenericCommandResult(false, "Registro não existe na base", Notifications);

                }
                impressora.Atualizar(
                modelo: command.Modelo,
                patrimonio: command.Patrimonio,
                alugado: command.Alugado,
                conexao: command.Conexao,
                tipo: command.Tipo,
                ip: command.Ip,
                observacao: command.Observacao,
                modificadoPor: command.ModificadoPor,
                setorId: command.SetorId,
                localizacaoId: command.LocalizacaoId

                );
                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                if (!_data.Impressoras.Update(impressora))
                {
                    await _data.Rollback();
                    AddNotifications(_data.Impressoras.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }



                if (!await _data.Save())
                {
                    await _data.Rollback();
                    AddNotifications(_data.Impressoras.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
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
        public void NotificationsClear()
        {
            Clear();
        }
    }
  
}
