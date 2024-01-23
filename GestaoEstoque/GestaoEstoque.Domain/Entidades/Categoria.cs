using GestaoEstoque.Domain.Validacao;

namespace GestaoEstoque.Domain.Entidades
{
    public sealed class Categoria : Entity
    {
        public string? Nome { get; private set; }

        public Categoria(string nome)
        {
            ValidacaoDomain(nome);
        }
        public Categoria(int id, string nome)
        {
            DomainExceptionValidacao.ValidaErro(id < 0, "Valor do id invalido");
            Id = id;
            ValidacaoDomain(nome);
        }
        // Criando metodo para alterar o nome da categoria
        public void Update(string  nome)
        {
            ValidacaoDomain(nome);
        }
        // Criado metodo de validar minha class dentro dos construtores
        private void ValidacaoDomain(string nome)
        {
            DomainExceptionValidacao.ValidaErro(string.IsNullOrEmpty(nome), "Nome invalido. Nome é obrigatorio");
            DomainExceptionValidacao.ValidaErro(nome.Length < 3, "Nome invalido, nome precisa ter no minimo 3 letras");
            Nome = nome;
        }
        // Usando ICollection, para ter uma lista de produtos
        public ICollection<Produto>? Produtos { get; set; }
    }
}
