
namespace GestaoEstoque.Domain.Validacao
{
    public class DomainExceptionValidacao : Exception
    {
        public DomainExceptionValidacao(string erro) : base(erro) { }

        public static void ValidaErro(bool temErro, string erro)
        {
            if (temErro)
                throw new DomainExceptionValidacao(erro);
        }
    }
}
