using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.projeto.Models;

namespace Senai.projeto.Controllers {
    public class UsuarioController : Controller {
        [HttpGet]

        public ActionResult Cadastrar () {

            return View ();
        }

        [HttpPost]

        public ActionResult Cadastrar (IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel ();
            int contador = 0;

            // falando ID
            usuario.Id = contador + 1;
            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];
            usuario.Tipo = form["tipo"];
            usuario.Data = DateTime.Now;

            using (StreamWriter sw = new StreamWriter ("usuarios.csv", true)) {
                sw.WriteLine ($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Tipo};{usuario.Data}");
            }
            // faltando return
            return RedirectToAction ("Login");

        }

        [HttpGet]

        public IActionResult Login () {

            return View ();
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form) {

            UsuarioModel usuario = new UsuarioModel ();
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];

            using (StreamReader sr = new StreamReader ("usuario.csv")) {
                while (!sr.EndOfStream) {

                    string[] dados = sr.ReadLine ().Split (";");

                    if (dados[2] == usuario.Email && dados[3] == usuario.Senha) {

                        //HttpContext.Session.SetString ("emailUsuario", usuario.Email);

                        //Rever faltando retur
                        return RedirectToAction ("Cadastrar", "Tarefa");

                    }
                }
                // rever return
                return View ();

            }

        }
    }
}