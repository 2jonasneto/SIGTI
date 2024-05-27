using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Base
{
    public static class CommandMessages
    {
        //CommandResults
        public const string InsertSuccess = "Registro incluído com sucesso!";
        public const string InsertError = "Ocorreu um erro ao incluir o registro!";
        public const string UpdateSuccess = "Registro atualizado com sucesso!";
        public const string UpdateError = "Ocorreu um erro ao atualizar o registro!";
        public const string DeleteSuccess = "Registro excluído com sucesso!";
        public const string DeleteError = "Ocorreu um erro ao excluir o registro!";

        public const string GetByIdError = "Registro não encontrado!";
        public const string GetByQueryError = "um ou mais Registros não foram encontrados!";

        //Validações
        public const string NullOrEmpty = "Valor informado não pode ser vazio!";
        public const string GreaterThan = "Valor informado deve possuir ao menos 3 caracteres!";
        public const string validId = "Id informado não é válido!";
    }
}
