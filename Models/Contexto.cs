using Microsoft.EntityFrameworkCore;

namespace RHMVC.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario
        {
            get; set;
        }
        public DbSet<Folha> Folhas
        {
            get; set;
        }
        public DbSet<Desconto> Descontos
        {
            get; set;
        }
        public DbSet<Funcionario> Funcionarios
        {
            get; set;
        }


      

      
    }

 
}

