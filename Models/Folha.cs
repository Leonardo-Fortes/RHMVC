using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RHMVC.Models
{
    [Table("Folha")]
    public class Folha
    {
        [Key]
        public int idfolha { get; set; }

        [Column("mes_ano")]
        public string MesAno{ get; set; }
        [Column("hora_extra")]
        public decimal HoraExtra { get; set; }
        [Column("qtd_hora")]
        public decimal QtdHora { get; set; } 
        [Column("salario_base")]
        public decimal SalarioBase { get; set; }
        [Column("salario_liquido")]
        public decimal SalarioLiquido { get; set; }
        [Column("id_funcionario")]

        public int idFuncionario { get; set; }

    }
}
