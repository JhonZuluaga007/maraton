using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SERVIDOR;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const int nodos = 2;
            int[,] matriz = { { 0, 1 }, { 1, 0 } };
            const int respuesta = 1;

            VertexCoverFuerzaBruta VC = new VertexCoverFuerzaBruta();

            var actual = VC.Vertex(nodos, matriz);

            Assert.AreEqual(respuesta, actual);
        }
    }
}
