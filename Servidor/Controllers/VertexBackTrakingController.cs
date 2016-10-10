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
        public ActionResult VertexF(string json)
        {
            ///VertexBackTraking/VertexF?json={'nodos':2,'matriz':[[1,0],[0,1]]}
            VertexCoverFuerzaBruta s = new VertexCoverFuerzaBruta();
            
            //se descerializa el json en una instancia de la clase datos
            JsonVertex dato = JsonConvert.DeserializeObject<JsonVertex>(json);
            string respuesta = JsonConvert.SerializeObject(s.Vertex(dato.nodos, dato.matriz));
            return Content("el nodo que forma el vertex cover es :[" + respuesta + "]");  
        }
        
        public ActionResult VertexB(string json)
        {
            ///VertexBackTraking/VertexB?json={'nodos':2,'matriz':[[1,0],[0,1]]}
            VertexCoverBackTraking s = new VertexCoverBackTraking();

            //se descerializa el json en una instancia de la clase datos
            JsonVertex dato = JsonConvert.DeserializeObject<JsonVertex>(json);
            int consulta = s.Solucion(dato.nodos, dato.matriz);
            string respuesta = JsonConvert.SerializeObject(consulta);
            return Content("el nodo que forma el vertex cover es :[" + respuesta + "]");
        }
    }
}

