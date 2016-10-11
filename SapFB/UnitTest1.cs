using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SERVIDOR;
using System.Collections.Generic;

namespace SapFB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const int nodos = 3;
            int[] a = { 1, 2, 3 };
            int[] b = { 2, 3, -1 };
            List<int[]> vector = new List<int[]> ();
            vector.Add(a);
            vector.Add(b);
            const string respuesta = "true, false, true";

            SapFuerzaBruta sap = new SapFuerzaBruta();

            var actual = sap.Consulta(nodos, vector);

            Assert.AreEqual(respuesta, actual);
        }
    }
}
