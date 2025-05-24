namespace Dominio.Interface_Repositorios
{
    public interface IUsuarioRepositorio
    {
        bool NomeUsuarioExiste(string nomeUsuario);
        Usuario RecuperarPorNome(string nomeUsuario);
    }
}