namespace Sigti.Core.Entities
{
    public sealed class Localizacao:Entity {
        public Localizacao(string nome, string descricao, Guid localizacaoId, string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
        }
        public void Atualizar(string nome, string descricao, Guid localizacaoId, string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }


        public ICollection<Computador> Computadores { get; }
        public ICollection<Setor> Setores { get; }
    }
}
