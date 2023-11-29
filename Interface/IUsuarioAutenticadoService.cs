namespace RHMVC.Interface
{
    public interface IUsuarioAutenticadoService
    {
        string CPF
        {
            get;
        }
        public class UsuarioAutenticadoService : IUsuarioAutenticadoService
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public UsuarioAutenticadoService(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string CPF => _httpContextAccessor.HttpContext?.User.FindFirst("CPF")?.Value;
            // Adicione outras propriedades conforme necessário
        }
    }
}
