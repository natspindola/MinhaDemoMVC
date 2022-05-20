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
        [Route("pagina-inicial")] //rota da action
        public IActionResult Index(string id, string categoria)
        {
            return View();
        }

        [Route("privacidade")] //rota da action
        [Route("politica-de-privacidade")] //as duas funcionam, mas a última vai ser usada como padrão
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [Route("erro-encontrado")] //se não criar uma rota aqui, gera colisão de rotas com o index, pois os dois estão vazios
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
