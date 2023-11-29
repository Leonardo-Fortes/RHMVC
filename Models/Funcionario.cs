using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RHMVC.Models
{
    [Table("Funcionario")]
    public class Funcionario
    {
        [Key] public int idfuncionario { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("cpf")]
        public string CPF { get; set; }
    }
}
