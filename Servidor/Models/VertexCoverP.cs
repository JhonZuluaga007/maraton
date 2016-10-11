using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servidor.Models
{
    public class VertexCoverP
    {
        public const int N = 100;
        public int nodos;
        public int[,] grafo = new int[N, N];
        int conexiones, unos = 0, posicioni = -1, posicionj = -1;
        int[] asignacion = new int[N];

        public int iniciar(int nodos, int[,] grafo)
        {
            for (int i = 0; i < nodos; ++i)
            {
                asignacion[i] = -1;
            }
            this.nodos = nodos;
            this.grafo = grafo;
            preprocesamiento();
            int respuesta = backtracking();
            return respuesta;
        }
        public int sumatoria(int[] asignacion)
        {
            int suma = 0;
            for (int i = 0; i < asignacion.Length; ++i)
            {
                if (asignacion[i] == 1)
                {
                    suma += asignacion[i];
                }
            }
            return suma;
        }

        public bool validar(int[] asignacion)
        {

            for (int i = 0; i < nodos; ++i)
            {
                if (asignacion[i] == 1)
                {
                    continue;
                }
                for (int j = i + 1; j < nodos; ++j)
                {
                    if (asignacion[j] != 1 && grafo[i, j] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void preprocesamiento()
        {
            Dictionary<int, int> posiciones = new Dictionary<int, int>();
            for (int i = 0; i < nodos; ++i)
            {
                for (int j = 0; j < nodos; ++j)
                {
                    conexiones = grafo[i, j];
                    if (conexiones == 1)
                    {
                        unos += conexiones;
                        if (unos == 1)
                        {
                            posicioni = i;
                            posicionj = j;
                        }
                        else
                            posicioni = -1;
                    }
                }
                if (posicioni >= 0)
                {
                    asignacion[posicionj] = 1;
                    posiciones.Add(posicioni, posicionj);
                }
                unos = 0;
            }
            foreach (var item in posiciones)
            {
                grafo[item.Key, item.Value] = 0;
                grafo[item.Value, item.Key] = 0;
            }
        }

        public int backtracking()
        {
            int u = -1, v = -1, w = -1;
            for (int i = 0; i < nodos; ++i)
            {
                for (int j = i + 1; j < nodos; ++j)
                {
                    for (int k = i + 2; k < nodos; ++k)
                    {
                        if (asignacion[i] == -1 && asignacion[j] == -1 && asignacion[k] == -1)
                        {
                            if ((grafo[i, j] == 1 && grafo[j, k] == 1) || (grafo[j, i] == 1 && grafo[i, k] == 1) || (grafo[i, k] == 1 && grafo[k, j] == 1))
                            {
                                u = i;
                                v = j;
                                w = k;

                                break;
                            }
                        }
                    }
                    if (u != -1)
                        break;
                }
                if (u != -1)
                    break;
            }
            if (u == -1)
            {

                if (validar(asignacion))
                    return sumatoria(asignacion);
                else
                    return N;
            }
            asignacion[u] = 1;
            asignacion[v] = 0;
            asignacion[w] = 0;
            int r1 = backtracking();

            asignacion[u] = 0;
            asignacion[v] = 1;
            asignacion[w] = 0;
            int r2 = backtracking();

            asignacion[u] = 0;
            asignacion[v] = 0;
            asignacion[w] = 1;
            int r3 = backtracking();

            asignacion[u] = 1;
            asignacion[v] = 1;
            asignacion[w] = 0;
            int r4 = backtracking();

            asignacion[u] = 1;
            asignacion[v] = 0;
            asignacion[w] = 1;
            int r5 = backtracking();

            asignacion[u] = 0;
            asignacion[v] = 1;
            asignacion[w] = 1;
            int r6 = backtracking();

            asignacion[u] = 1;
            asignacion[v] = 1;
            asignacion[w] = 1;
            int r7 = backtracking();

            return Math.Min(r1, Math.Min(r2, Math.Min(r3, Math.Min(r4, Math.Min(r5, Math.Min(r6, r7))))));
        }
      
        
    }
    
}