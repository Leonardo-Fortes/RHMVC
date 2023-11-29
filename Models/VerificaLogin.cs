using System.Linq;
namespace RHMVC.Models
{
    public class VerificaLogin
    {
        private readonly Contexto _contexto;

        public string Usuario 
        {
            get; set;
        }
        public string Senha
        {
            get; set;
        }
        public static int IDTESTE { get; set; }
        public static string NomeFuncionario
        {
            get; set;
        }

        public VerificaLogin(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Acesso()
        {
           
                             var usuarioFuncionario = _contexto.Usuario
                            .Where(u => u.login == this.Usuario && u.senha == this.Senha)
                            .Select(u => new
                            {
                                u.idusuario,
                                u.id_funcionario
                            })
                            .FirstOrDefault();

            // Se encontrou o usuário, armazena o IdFuncionario e retorna true
            if (usuarioFuncionario != null)
            {
                IDTESTE = usuarioFuncionario.id_funcionario;
                return true;
            }

            // Se não encontrou o usuário, reinicia o IdFuncionario e retorna false
            IDTESTE = 0;
            return false;
        }


    }
}
