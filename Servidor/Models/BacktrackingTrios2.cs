using System;
using System.Collections.Generic;

namespace SERVIDOR
{
    public class BacktrackingTrios2
    {
        public const int N = 100;
        public int nodos;
        public int[,] grafo = new int[N, N];
        List<int> asignacion = new List<int>();

        public int iniciar(int nodos, int[,] grafo)
        {
            for (int i = 0; i < nodos; ++i)
            {
                asignacion.Add(-1);
            }
            this.nodos = nodos;
            this.grafo = grafo;
            int respuesta = backtracking(asignacion);
            return respuesta;
        }

        public int sumatoria(List<int> asignacion)
        {
            int suma = 0;
            for (int i = 0; i < asignacion.Count; ++i)
            {
                if (asignacion[i] == 1)
                {
                    suma += asignacion[i];
                }
            }
            return suma;
        }

        public bool validar(List<int> asignacion)
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

        int backtracking(List<int> asignacionactual)
        {
            int u = -1, v = -1, w = -1, k2 = 0;
            for (int i = 0; i < nodos; ++i)
            {
                k2 = i + 2;
                for (int j = k2 - 1; j < nodos; ++j)
                {
                    if (i + 3 > nodos)
                    {
                        k2 = 0;
                    }
                    for (int k = k2; k < nodos; ++k)
                    {
                        if (asignacionactual[i] == -1 && asignacionactual[j] == -1 && asignacionactual[k] == -1)
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
                if (validar(asignacionactual))
                    return sumatoria(asignacionactual);
                else
                    return N;
            }
            asignacionactual[u] = 1;
            asignacionactual[v] = 1;
            asignacionactual[w] = 1;
            int r1 = backtracking(asignacionactual);

            asignacionactual[u] = 1;
            asignacionactual[v] = 1;
            asignacionactual[w] = 0;
            int r2 = backtracking(asignacionactual);

            asignacionactual[u] = 1;
            asignacionactual[v] = 0;
            asignacionactual[w] = 1;
            int r3 = backtracking(asignacionactual);

            asignacionactual[u] = 0;
            asignacionactual[v] = 1;
            asignacionactual[w] = 1;
            int r4 = backtracking(asignacionactual);

            asignacionactual[u] = 1;
            asignacionactual[v] = 0;
            asignacionactual[w] = 0;
            int r5 = backtracking(asignacionactual);

            asignacionactual[u] = 0;
            asignacionactual[v] = 0;
            asignacionactual[w] = 1;
            int r6 = backtracking(asignacionactual);

            asignacionactual[u] = 0;
            asignacionactual[v] = 1;
            asignacionactual[w] = 0;
            int r7 = backtracking(asignacionactual);

            return Math.Min(r1, Math.Min(r2, Math.Min(r3, Math.Min(r4, Math.Min(r5, Math.Min(r6, r7))))));
        }
    }
}