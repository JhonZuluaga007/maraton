using Newtonsoft.Json;
using Servidor.Models;
using SERVIDOR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Servidor.Controllers
{
    public class SapController : Controller
    {
        public ActionResult sap(string json)
        {
            ///Sap/sap?Json={'numero':3,'vector':[[1,2,3],[2,3,-1]]}
            SapFuerzaBruta solucion = new SapFuerzaBruta();
            JsonSap dato = JsonConvert.DeserializeObject<JsonSap>(json);
            int a = (dato.vector[0])[2];
            // james@example.com
            return Content(solucion.Consulta(dato.numero, dato.vector));
        }
    }
}
