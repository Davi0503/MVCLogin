using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.projeto.Models;

namespace Senai.projeto.Controllers {
    public class TarefaController : Controller {

            [HttpGet]
        public ActionResult Cadastrar(){

            return View();
        }


        [HttpPost]
        public ActionResult Cadasrtrar(IFormCollection Form){
            
            TarefaModel tarefa = new TarefaModel();

            tarefa.Id = 1;
            tarefa.Nome = Form["nome"];
            tarefa.Descricao = Form["descricao"];
            tarefa.Tipo = Form["tipo"];
            



            return View();
        }
    

    }
}