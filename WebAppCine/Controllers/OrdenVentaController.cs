using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using WebAppCine.Models;

namespace WebAppCine.Controllers
{
    public class OrdenVentaController : Controller
    {
        private string urlBase = "http://localhost:8080/jaxrs-cinema/";
        // GET: OrdenVenta
        public async System.Threading.Tasks.Task<ActionResult> Listar_Venta()
        {
            List<OrdenVenta> lista = new List<OrdenVenta>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/salesorders");
                if (response.IsSuccessStatusCode)
                {
                    var resp = response.Content.ReadAsStringAsync().Result;

                    lista = JsonConvert.DeserializeObject<List<OrdenVenta>>(resp);
                }
            }
            return View(lista);
        }

        // GET: OrdenVenta/Detalle/5
        public async System.Threading.Tasks.Task<ActionResult> Detalle_Venta(int id)
        {
            OrdenVenta ordenVenta = new OrdenVenta();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/salesorders/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    ordenVenta = JsonConvert.DeserializeObject<OrdenVenta>(res);
                }
            }
            return View(ordenVenta);
        }

        // GET: OrdenVenta/Agregar
        public ActionResult Agregar_Venta()
        {
            return View(new OrdenVenta());
        }

        // POST: OrdenVenta/Agregar
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Agregar_Venta(FormCollection collection, OrdenVenta ordenVenta)
        {
            try
            {
                //Empleado objE = new Empleado();
                //objE.empleado_id = 1;
                //ordenVenta.codigo_reserva = ordenVenta.fila + ordenVenta.asiento + ordenVenta.cantidad + "-" + DateTime.Now.Day + DateTime.Now.Minute;
                //ordenVenta.EmpleadoOrdenVenta=objE;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/salesorders", ordenVenta);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listar_Venta");
                    }
                    ViewBag.Error = "Ha ocurrido un error " + response.Content.ReadAsStringAsync().Result;
                    return View(ordenVenta);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error " + ex.ToString();
                return View(ordenVenta);
            }
        }

        // GET: OrdenVenta/Editar/5
        public async System.Threading.Tasks.Task<ActionResult> Editar_Venta(int id)
        {
            OrdenVenta ordenVenta = new OrdenVenta();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/salesorders/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    ordenVenta = JsonConvert.DeserializeObject<OrdenVenta>(res);
                }
            }
            return View(ordenVenta);
        }

        // POST: OrdenVenta/Editar/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Editar_Venta(int id, FormCollection collection, OrdenVenta ordenVenta)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/salesorders", ordenVenta);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listar_Venta");

                    }
                    ViewBag.Error = "Ha ourrido un error... " + response.StatusCode;
                    return View(ordenVenta);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error... " + ex.ToString();
                return View(ordenVenta);
            }
        }

        // GET: OrdenVenta/Eliminar/5
        public async System.Threading.Tasks.Task<ActionResult> Eliminar_Venta(int id)
        {
            OrdenVenta ordenVenta = new OrdenVenta();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/salesorders/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    ordenVenta = JsonConvert.DeserializeObject<OrdenVenta>(res);
                }
            }
            return View(ordenVenta);
        }

        // POST: OrdenVenta/Eliminar/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Eliminar_Venta(int id, FormCollection collection)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlBase);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.DeleteAsync("api/salesorders/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listar_Venta");
                    }
                    ViewBag.Error = "Ha ocurrido un error... " + response.StatusCode;
                    return View(id);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error... " + ex.ToString();
                return View();
            }
        }

        private Funcion buscarFuncion(int idFuncion)
        {
            Funcion objF = new Funcion();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlBase);
                var responseTask = client.GetAsync("api/showtimes/" + idFuncion);
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

    }
}
