using GestaoEstoque.Domain.Validacao;

namespace GestaoEstoque.Domain.Entidades
{
    public sealed class Produto : Entity
    {
        public string? Nome { get; private set; }
        public string? Descricao { get; private set;}
        public decimal? Preco { get; private set; }
        public int Estoque { get; private set; }
        public string? Imagem { get; private set; }
        // Propriedades de navegação entre as classe
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        //public Produto()
        //{
                
        //}
        //public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
        //{
        //    ValidaDomain(nome, descricao, preco, estoque, imagem);
        //}
        //public Produto(int id, string nome, string descricao, decimal preco, int estoque, string imagem)
        //{
        //    DomainExceptionValidacao.ValidaErro(id < 0, "Valor do id invalido");
        //    Id = id;
        //    ValidaDomain(nome, descricao, preco, estoque, imagem);
        //}
        //public void Update(string nome, string descricao, decimal preco, int estoque, string imagem, int categoriaId)
        //{
        //    ValidaDomain(nome, descricao, preco, estoque, imagem);
        //    CategoriaId = categoriaId;
        //}

        //private void ValidaDomain(string nome, string descricao, decimal preco, int estoque, string imagem)
        //{
        //    DomainExceptionValidacao.ValidaErro(string.IsNullOrEmpty(nome), "Nome invalido. Nome é obrigatorio");
        //    DomainExceptionValidacao.ValidaErro(nome.Length < 8, "Nome invalido, nome precisa ter no minimo 3 caracteres");
        //    DomainExceptionValidacao.ValidaErro(string.IsNullOrEmpty(descricao), "Nome invalido. Nome é obrigatorio");
        //    DomainExceptionValidacao.ValidaErro(descricao.Length < 8, "Nome invalido, nome precisa ter no minimo 3 caracteres");
        //    DomainExceptionValidacao.ValidaErro(preco <= 0, "Valor de preço invalido. Preço não pode ser menor ou igual a 0");
        //    DomainExceptionValidacao.ValidaErro(estoque < 0, "Estoque não pode ser menor que 0");
        //    DomainExceptionValidacao.ValidaErro(imagem?.Length > 250, "Nome da imagem invalido. Imagem pode ter no maximo 250 caracteres");
        //    Nome = nome;
        //    Descricao = descricao;
        //    Preco = preco;
        //    Estoque = estoque;
        //    Imagem = imagem;
        //}
    }
}
