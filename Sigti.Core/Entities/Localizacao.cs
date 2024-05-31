namespace Sigti.Core.Entities
{
    public sealed class Localizacao:Entity {
        protected Localizacao()
        {
            
        }
        public Localizacao(string nome, string descricao, string modificadoPor, Guid id = default)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            if (id != default) { Id = id; }
        } public Localizacao(string nome, string descricao, string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
        }
        public void Atualizar(string nome, string descricao,  string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            DataModificacao=DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }


        public ICollection<Computador> Computadores { get; }
        public ICollection<Impressora> Impressoras { get; }
        public ICollection<Setor> Setores { get; }
    }
}
