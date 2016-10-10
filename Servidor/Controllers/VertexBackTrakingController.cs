using Newtonsoft.Json;
using Servidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Servidor.Controllers
{
    public class VertexBackTrakingController : Controller
    {
        public void getLeer(int Nodos, int Matriz, int tipo)
        {
            //JsonVertex Leer = new JsonVertex();
            //aca validamos y mandamos los datos al algoritmo que necesite 
            
        }
        public ActionResult getFuerzaBruta(int nodo, int[,] matriz, int tipo)
        {
            VertexCoverFuerzaBruta vertex = new VertexCoverFuerzaBruta();
            //string respuesta = vertex.Vertex(nodo, matriz);

            return Json(nodo, JsonRequestBehavior.AllowGet);
        }
        public ActionResult sap(string json)
        {
            //se descerializa el json en una instancia de la clase datos
            JsonVertex dato = JsonConvert.DeserializeObject<JsonVertex>(json);
            //estoy retornando la matriz 
            //return Content(dato.matriz.ToString());
            return Json(dato.matriz[0,1], JsonRequestBehavior.AllowGet);
        }
    }
}