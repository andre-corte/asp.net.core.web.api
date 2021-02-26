using Aula.Painel.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula.Painel.Controllers
{
    public class UsuarioController : Controller
    {
        private const string UrlBase = "https://localhost:44341/api/v1/public";

        public IActionResult Index()
        {
            RestClient client = new RestClient($"{UrlBase}/usuario/todos");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            IList<UsuarioModel> usuarioModel = JsonConvert.DeserializeObject<IList<UsuarioModel>>(response.Content);
            return View(usuarioModel);
        }

        public IActionResult Cadastrar()
        {
            return View(new UsuarioModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Cadastrar(UsuarioModel obj)
        {
            obj.ResponsavelCadastro = "painel";
            obj.DataCadastro = DateTime.Now;

            RestClient client = new RestClient($"{UrlBase}/usuario/cadastrar");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(obj), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                obj = new UsuarioModel();
                ViewData["sucesso"] = response.Content;
            }
            else
            {
                ViewData["erro"] = response.Content;
            }

            return View(obj);
        }

        public IActionResult Atualizar(long id)
        {
            RestClient client = new RestClient($"{UrlBase}/usuario/obter-por/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            UsuarioModel usuarioModel = JsonConvert.DeserializeObject<UsuarioModel>(response.Content);
            return View(usuarioModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Atualizar(UsuarioModel obj)
        {
            RestClient client = new RestClient($"{UrlBase}/usuario/atualizar");
            RestRequest request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(obj), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                obj = new UsuarioModel();
                ViewData["sucesso"] = response.Content;
            }
            else
            {
                ViewData["erro"] = response.Content;
            }

            return View(obj);
        }

        public IActionResult Detalhe(long id)
        {
            RestClient client = new RestClient($"{UrlBase}/usuario/obter-por/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            UsuarioModel usuarioModel = JsonConvert.DeserializeObject<UsuarioModel>(response.Content);
            return View(usuarioModel);
        }

        public IActionResult Delete(long id)
        {
            RestClient client = new RestClient($"{UrlBase}/usuario/remover/{id}");
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViewData["sucesso"] = response.Content;
            }
            else
            {
                ViewData["erro"] = response.Content;
            }

            return RedirectToAction("index", "usuario");
        }
    }
}
