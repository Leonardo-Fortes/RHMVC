namespace RHMVC.Models
{
    public class ExibirDesconto
    {
        public decimal INSS
        {
            get; set;
        }
        public decimal IRRF
        {
            get; set;
        }
        public decimal FGTS
        {
            get; set;
        }
    }
    public class DescontoService
    {
        private readonly Contexto _contexto;
        private readonly VerificaLogin _verificaLogin;

        public DescontoService(Contexto contexto, VerificaLogin verificaLogin)
        {
            _contexto = contexto;
            _verificaLogin = verificaLogin;
        }

        // Método para consultar informações de Desconto com base no idFuncionario e na data
        public List<ExibirDesconto> ConsultarDesconto(string data)
        {
            int idFuncionario = VerificaLogin.IDTESTE;
            var resultadoDesconto = _contexto.Descontos
                .Where(desconto => desconto.idFuncionario == idFuncionario && desconto.MesAno == data)
                .Select(desconto => new ExibirDesconto
                {
                    INSS = desconto.Inss,
                    IRRF = desconto.Irrf,
                    FGTS = desconto.Fgts
                })
                .ToList();

            return resultadoDesconto;
        }
    }
}
