using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servidor.Models
{
    public class VertexCoverBackTraking
    {
        public int Solucion(int nodo, int[,] Matriz)
        {
            BacktrackingTrios backtracking = new BacktrackingTrios();
            int[,] grafo = new int[100, 100];
            int nodos = nodo;
            for (int i = 0; i < nodos; ++i)
            {
                for (int j = 0; j < nodos; ++j)
                {
                    grafo[i, j] = Matriz[i,j];
                }
            }
            int x = backtracking.iniciar(nodos, grafo);
            return(x);
            
        }
    }
}