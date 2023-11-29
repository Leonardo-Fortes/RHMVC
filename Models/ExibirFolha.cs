using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RHMVC.Models
{
    public class ExibirFolha
    {
        public decimal QtdHora
        {
            get; set;
        }
        public decimal HoraExtra
        {
            get; set;
        }
        public decimal SalarioBase
        {
            get; set;
        }
        public decimal SalarioLiquido
        {
            get; set;
        }
        public string NomeFuncionario
        {
            get; set;
        }
    }

    public class FolhaService
    {
        private readonly Contexto _contexto;
        private readonly VerificaLogin _verificaLogin;

        public FolhaService(Contexto contexto, VerificaLogin verificaLogin)
        {
            _contexto = contexto;
            _verificaLogin = verificaLogin;
        }


        public List<ExibirFolha> ConsultarFolha(string data)
        {

            int idFuncionario = VerificaLogin.IDTESTE;

            if (idFuncionario != 0 && data != null)
            {
                var resultadoFolha = _contexto.Folhas
                     .Where(folha => folha.idFuncionario == idFuncionario && folha.MesAno == data)
                     .Join(_contexto.Funcionarios,
                           folha => folha.idFuncionario,
                           funcionario => funcionario.idfuncionario,
                           (folha, funcionario) => new
                           {
                               folha.QtdHora,
                               folha.HoraExtra,
                               folha.SalarioBase,
                               folha.SalarioLiquido,
                               funcionario.Nome
                           })
                     .Select(result => new ExibirFolha
                     {
                         QtdHora = result.QtdHora,
                         HoraExtra = result.HoraExtra,
                         SalarioBase = result.SalarioBase,
                         SalarioLiquido = result.SalarioLiquido,
                         NomeFuncionario = result.Nome // Adicione uma propriedade NomeFuncionario em ExibirFolha para armazenar o nome do funcionário
                     })
                     .ToList();

                return resultadoFolha;
            }
            else
            {
                return null;
            }
        }
    }

}

