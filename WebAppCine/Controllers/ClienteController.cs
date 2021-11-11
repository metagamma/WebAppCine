using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebAppCine.Models;

namespace WebAppCine.Controllers
{
    public class ClienteController : Controller
    {
        private String urlBase = "http://localhost:8080/jaxrs-cinema/";
        // GET: Cliente
        public async System.Threading.Tasks.Task<ActionResult> Listar_Cliente()
        {
            List<Cliente> lista = new List<Cliente>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/customers");
                if (response.IsSuccessStatusCode)
                {
                    var resp = response.Content.ReadAsStringAsync().Result;

                    lista = JsonConvert.DeserializeObject<List<Cliente>>(resp);
                }
            }
            return View(lista);
        }

        // GET: Cliente/Detalle/5
        public async System.Threading.Tasks.Task<ActionResult> Detalle_Cliente(int id)
        {
            Cliente cliente = new Cliente();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/customers/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    cliente = JsonConvert.DeserializeObject<Cliente>(res);
                }
            }
            return View(cliente);
        }

        // GET: Cliente/Agregar
        public ActionResult Agregar_Cliente()
        {
            return View(new Cliente());
        }

        // POST: Cliente/Agregar
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Agregar_Cliente(FormCollection collection, Cliente cliente)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/customers", cliente);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listar_Cliente");
                    }
                    ViewBag.Error = "Ha ocurrido un error " + response.Content.ReadAsStringAsync().Result;
                    return View(cliente);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error " + ex.ToString();
                return View(cliente);
            }
        }



        // GET: Cliente/Editar/5
        public async System.Threading.Tasks.Task<ActionResult> Editar_Cliente(int id)
        {
            Cliente cliente = new Cliente();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/customers/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    cliente = JsonConvert.DeserializeObject<Cliente>(res);
                }
            }
            return View(cliente);
        }

        // POST: Cliente/Editar/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Editar_Cliente(int id, FormCollection collection, Cliente cliente)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/customers/", cliente);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listar_Cliente");

                    }
                    ViewBag.Error = "Ha ourrido un error inesperado " + response.StatusCode;
                    return View(cliente);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error " + ex.ToString();
                return View(cliente);
            }
        }

        // GET: Cliente/Eliminar/5
        public async System.Threading.Tasks.Task<ActionResult> Eliminar_Cliente(int id)
        {
            Cliente cliente = new Cliente();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/customers/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    cliente = JsonConvert.DeserializeObject<Cliente>(res);
                }
            }
            return View(cliente);
        }

        // POST: Cliente/Eliminar/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Eliminar_Cliente(int id, FormCollection collection)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync("api/customers/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listar_Cliente");
                    }
                    ViewBag.Error = "Ha ocurrido un error al eliminar el cliente " + response.StatusCode;
                    return View(id);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error al eliminar el cliente " + ex.ToString();
                return View();
            }
        }
    }
}