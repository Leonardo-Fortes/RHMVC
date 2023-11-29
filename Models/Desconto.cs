using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RHMVC.Models
{
    [Table("Desconto")]
    public class Desconto
    {
        
        [Key] public int idDesconto { get; set; }
        [Column("inss")]
        public decimal Inss  { get; set; }
        [Column("fgts")]
        public decimal Fgts { get; set; }
        [Column("irrf")]
        public decimal Irrf { get; set; }
        [Column("mes_ano")]
        public string MesAno { get; set; }
        [Column("id_funcionario")]
        public int idFuncionario { get; set; }
    }
}
