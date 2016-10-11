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
            return Content("el minimo numero de nodos a tomar para cubrir todas las aristas es :" + respuesta );  
        }
      
        public ActionResult VertexB2(string json)
        {
            //VertexBackTraking/VertexF?json={%27nodos%27:6,%27matriz%27:[[0,1,1,0,1,0],[1,0,1,1,0,0],[1,1,0,1,1,0],[0,1,1,0,1,0] ,[1,0,1,1,0,1],[0,0,0,0,1,0]]}
            ///VertexBackTraking/VertexB2?json={'nodos':2,'matriz':[[1,0],[0,1]]}
            VertexCoverB2 s = new VertexCoverB2();

            //se descerializa el json en una instancia de la clase datos
            JsonVertex dato = JsonConvert.DeserializeObject<JsonVertex>(json);
            int consulta = s.Solucion(dato.nodos, dato.matriz);
            string respuesta = JsonConvert.SerializeObject(consulta);
            return Content("el minimo numero de nodos a tomar para cubrir todas las aristas es :" + respuesta);
        }


        public ActionResult Vertexp(string json)
        {
            //VertexBackTraking/VertexF?json={%27nodos%27:6,%27matriz%27:[[0,1,1,0,1,0],[1,0,1,1,0,0],[1,1,0,1,1,0],[0,1,1,0,1,0] ,[1,0,1,1,0,1],[0,0,0,0,1,0]]}
            ///VertexBackTraking/VertexB2?json={'nodos':2,'matriz':[[1,0],[0,1]]}
            VertexCoverP s = new VertexCoverP();

            //se descerializa el json en una instancia de la clase datos
            JsonVertex dato = JsonConvert.DeserializeObject<JsonVertex>(json);
            int consulta = s.iniciar(dato.nodos, dato.matriz);
            string respuesta = JsonConvert.SerializeObject(consulta);
            return Content("el minimo numero de nodos a tomar para cubrir todas las aristas es :" + respuesta);
        }
    }
}

