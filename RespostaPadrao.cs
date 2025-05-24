namespace Aplicação.RespostaPadrao
{
    public class RespostaPadrao<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Dados { get; set; }

        public static RespostaPadrao<T> Falha(bool sucesso, string mensagem, T dados)
        {
            return new RespostaPadrao<T> { Sucesso = sucesso, Mensagem = mensagem, Dados = dados };
        }

        public static RespostaPadrao<T> Sucesso(bool sucesso, string mensagem, T dados)
        {
            return new RespostaPadrao<T> { Sucesso = sucesso, Mensagem = mensagem, Dados = dados };
        }
    }
}