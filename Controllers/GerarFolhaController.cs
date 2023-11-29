using Microsoft.AspNetCore.Mvc;
using RHMVC.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RHMVC.Controllers
{
    public class GerarFolhaController : Controller
    {
        private readonly FolhaService _folhaService;
        private readonly DescontoService _descontoService;

        public GerarFolhaController(FolhaService folhaService, DescontoService descontoService)
        {
            _folhaService = folhaService;
            _descontoService = descontoService;
        }

        [HttpPost]
        public IActionResult Index(string data)
        {
           
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    // Chama o método ConsultarFolha do FolhaService
                    List<ExibirFolha> resultadosFolha = _folhaService.ConsultarFolha(data);
                    List<ExibirDesconto> resultadosDesconto = _descontoService.ConsultarDesconto(data);

                    // Crie um modelo de exibição
                    var viewModel = new ExibirFolhaDescontoViewModel
                    {
                        Folhas = resultadosFolha,
                        Descontos = resultadosDesconto
                    };

                    // Passe o modelo para a view
                    return View(viewModel);
                }

                // Se a data não for fornecida, pode retornar uma mensagem ou redirecionar para uma página de erro.
                return RedirectToAction("Privacy"); // ou redirecione para uma página de erro
            }
            catch (Exception ex)
            {
                // Registre a exceção ou imprima no console para ajudar na depuração
                Console.WriteLine($"Erro ao processar ação Index: {ex.Message}");

                // Redirecione para uma página de erro ou faça algo apropriado com a exceção
                return RedirectToAction("Error");
            }
        }
    }


}
