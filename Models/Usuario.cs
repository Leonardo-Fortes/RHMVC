using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RHMVC.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int idusuario
        {
            get; set;
        }
        public string login
        {
            get; set;
        }
        public string senha
        {
            get; set;
        }

        public int id_funcionario
        {
            get; set;
        }

        [ForeignKey("id_funcionario")]
        public int IdFuncionario
        {
            get; set;
        }

        // Propriedade de navegação
        public Funcionario Funcionario
        {
            get; set;
        }
    }



}

