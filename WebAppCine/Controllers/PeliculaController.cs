using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using WebAppCine.Models;

namespace WebAppCine.Controllers
{
    public class PeliculaController : Controller
    {
        private String urlBase = "http://localhost:8080/jaxrs-cinema/";

        // GET: Pelicula
        public async System.Threading.Tasks.Task<ActionResult> Listar_Pelicula()
        {
            List<Pelicula> lista = new List<Pelicula>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/films");
                if (response.IsSuccessStatusCode)
                {
                    var resp = response.Content.ReadAsStringAsync().Result;

                    lista = JsonConvert.DeserializeObject<List<Pelicula>>(resp);
                }
            }
            return View(lista);
        }

        // GET: Pelicula/Detalle/5
        public async System.Threading.Tasks.Task<ActionResult> Detalle_Pelicula(int id)
        {
            Pelicula pelicula = new Pelicula();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/films/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    pelicula = JsonConvert.DeserializeObject<Pelicula>(res);
                }
            }
            return View(pelicula);
        }

        // GET: Pelicula/Agregar
        public ActionResult Agregar_Pelicula()
        {
            return View(new Pelicula());
        }

        // POST: Pelicula/Agregar
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Agregar_Pelicula(FormCollection collection, Pelicula pelicula)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/films", pelicula);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listar_Pelicula");
                    }
                    ViewBag.Error = "Ha ocurrido un error " + response.Content.ReadAsStringAsync().Result;
                    return View(pelicula);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error " + ex.ToString();
                return View(pelicula);
            }
        }
















       

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pelicula/Edit/5
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

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pelicula/Delete/5
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
    }
}
