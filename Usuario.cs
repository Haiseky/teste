namespace Dominio.Entidades
{
    public class Usuario
    {
        public string Nome { get; }
        private string Senha { get; }

        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        public virtual bool VerificarSenha(string senha)
        {
            return Senha == senha;
        }
    }
}