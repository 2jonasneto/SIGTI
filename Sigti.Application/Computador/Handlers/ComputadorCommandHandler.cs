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
    public class ComputadorCommandHandler : Notifiable<Notification>, ICommandHandler<AdicionarComputadorCommand>, 
        ICommandHandler<AtualizarComputadorCommand>, ICommandHandler<RemoverComputadorCommand>
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
            try
            {
                    
                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                if (!_data.Computadores.Create(_mapper.Map<Computador>(command)))
                {
                    await _data.Rollback();
                    AddNotifications(_data.Computadores.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.InsertError, Notifications);
                }
                if (!await _data.Save())
                {
                   await _data.Rollback();
                    AddNotifications(_data.Computadores.GetNotifications());
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

        public async Task<ICommandResult> Execute(AtualizarComputadorCommand command)
        {

            try
            {
                var computador = await _data.Computadores.GetByIdAsync(command.Id);
                if (computador == null)
                {
                    return new GenericCommandResult(false, "Registro não existe na base", Notifications);

                }
                    computador.Atualizar(
                    hostName: command.HostName,
                    patrimonio: command.Patrimonio,
                    processador: command.Processador,
                    memoria: command.Memoria,
                    disco: command.Disco,
                    ip: command.Ip,
                    anydesk: command.Anydesk,
                    grupos: command.Grupos,
                    observacao: command.Observacao,
                    ultimoUsuarioLogado: command.UltimoUsuarioLogado,
                    sistemaOperacional: command.SistemaOperacional,
                    modificadoPor: command.ModificadoPor,
                    setorId: command.SetorId,
                    localizacaoId: command.LocalizacaoId

                    );
                if (!await _data.Init())
                {
                    AddNotifications(_data.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }
                if (!_data.Computadores.Update(computador))
                {
                    await _data.Rollback();
                    AddNotifications(_data.Computadores.GetNotifications());
                    return new GenericCommandResult(false, CommandMessages.UpdateError, Notifications);
                }



                if (!await _data.Save())
                {
                    await _data.Rollback();
                    AddNotifications(_data.Computadores.GetNotifications());
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
        public async Task<ICommandResult> Execute(RemoverComputadorCommand command)
        {

            if (!_data.Computadores.Delete(command.Id))
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
