using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Mvc;

using WebAppCine.Models;

namespace WebAppCine.Controllers
{
    public class FuncionController : Controller
    {
        private String urlBase = "http://localhost:8080/jaxrs-cinema/api/";
        // GET: Funcion
        public ActionResult listarFuncion(String fecha = "", int local = 0)
        {
            var lista = new List<Funcion>();
            if (!fecha.Equals(""))
                fecha = Convert.ToDateTime(fecha).ToString("yyyyMMdd");
            //IEnumerable<Funcion> lista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                //HTTP GET
                var responseTask = client.GetAsync("");
                if (fecha.Equals("") && local == 0)
                    responseTask = client.GetAsync("showtimes");
                else
                    responseTask = client.GetAsync("showtimes/" + fecha + "&" + local);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resp = result.Content.ReadAsStringAsync().Result;

                    lista = JsonConvert.DeserializeObject<List<Funcion>>(resp);
                    //var readTask = result.Content.ReadAsAsync<IList<Funcion>>();
                    //readTask.Wait();

                    //lista = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    lista = new List<Funcion>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            ViewBag.SEDE = new SelectList(listarSede(), "sede_id", "nombre");
            return View(lista);
        }

        // GET: Funcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Funcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcion/Edit/5
        public ActionResult reservar(int id)
        {
            return View(buscarFuncion(id));
        }

        // POST: Funcion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult buscarCliente(String dni)
        {
            Cliente cli = buscarClienteDni(dni);
            return Json(cli);
        }
        // GET: Funcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funcion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //Otros Métodos
        private List<Sede> listarSede()
        {
            List<Sede> lista = new List<Sede>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                //HTTP GET
                var responseTask = client.GetAsync("locations");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resp = result.Content.ReadAsStringAsync().Result;
                    lista = JsonConvert.DeserializeObject<List<Sede>>(resp);

                }

            }
            return lista;
        }
        private Funcion buscarFuncion(int idFuncion)
        {
            Funcion objF = new Funcion();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                //HTTP GET
                var responseTask = client.GetAsync("showtimes/" + idFuncion);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resp = result.Content.ReadAsStringAsync().Result;
                    objF = JsonConvert.DeserializeObject<Funcion>(resp);

                }
            }
            return objF;
        }

        private Cliente buscarClienteDni(String dni)
        {
            Cliente objC = new Cliente();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                //HTTP GET
                var responseTask = client.GetAsync("customers/dni/" + dni);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resp = result.Content.ReadAsStringAsync().Result;
                    objC = JsonConvert.DeserializeObject<Cliente>(resp);

                }
            }
            return objC;
        }



    }
}
