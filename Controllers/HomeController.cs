using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC.Controllers
{
    [Route("")] //rota vazia funciona, porém só pode ser usada em um controller e pode dar conflito, principalmente com o Error
    [Route("gestao")] //toda a aplicação usa esse atributo - colocar antes da class evita a repetição 
    public class HomeController : Controller
    {
        [Route("")]
        [Route("pagina-inicial")] //rota da action - não é obrigado ter um ID
        [Route("pagina-inicial/{id:int}/{categoria?}")] //rota da action por atributo - é obrigado ter um ID mas não uma categoria
        public IActionResult Index(int id, string categoria)
        {
            var filme = new Filme()
            {
                Titulo = "Teste",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 3,
                Valor = 100000
            };

            //return RedirectToAction("Privacy", filme);
            return View();
        }

        [Route("privacidade")] //rota da action
        [Route("politica-de-privacidade")] //as duas funcionam, mas a última vai ser usada como padrão
        public IActionResult Privacy(Filme filme)
        {
            if(ModelState.IsValid)
            {

            }

            foreach(var error in ModelState.Values.SelectMany(M => M.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View();

            //var fileBytes = System.IO.File.ReadAllBytes(@"C:\arquivo.txt");
            //var fileName = "ola.txt";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            // aqui ele faz o download e lê o arquivo

            //return Content("qualquer coisa");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [Route("erro-encontrado")] //se não criar uma rota aqui, gera colisão de rotas com o index, pois os dois estão vazios
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
