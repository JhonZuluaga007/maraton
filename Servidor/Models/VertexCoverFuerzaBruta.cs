using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servidor.Models
{
    public class VertexCoverFuerzaBruta
    {
        public string Vertex(int nodo,int[,]matriz)
        {
            int nodos = nodo;
            int contador = 1;
            bool cambiar = false;
            //matriz = new List<int>();
            List<int> losValidos = new List<int>();
            //nodos = int.Parse(Console.ReadLine());
            int[,] grafo = new int[nodos,nodos];
            for(int i = 0; i < nodos; i++)
            {
                for(int j = 0; j < nodos; j++)
                {
                    grafo[i, j] = matriz[i, j];

                }
            }
            //Acá se llena la matriz
            int fila = Convert.ToInt32(Math.Pow(2, nodos));
            int[,] posibilidades = new int[fila, nodos];

            //Acá se sacan todas las posibilidades
            for (int i = 0; i < nodos; ++i)
            {
                int paSaber = 0;
                for (int j = 0; j < fila; ++j)
                {
                    if (paSaber <= contador)
                    {
                        paSaber++;
                        if (cambiar == false)
                        {
                            posibilidades[j, i] = 0;
                            if (paSaber == contador)
                            {
                                cambiar = true;
                                paSaber = 0;
                            }
                        }
                        else
                        {
                            posibilidades[j, i] = 1;
                            if (paSaber == contador)
                            {
                                cambiar = false;
                                paSaber = 0;
                            }
                        }
                    }
                }
                contador *= 2;
            }

            int[,] grafoParaCambiar = new int[nodos, nodos];
            int paraBajar = -1;

            //Acá se sacan solo las posibilidades buenas del vertex cover
            while (true)
            {
                //es como decir --> grafoParaCambiar = grafo;
                //Me salia error con la asignación
                for (int i = 0; i < nodos; ++i)
                {
                    for (int j = 0; j < nodos; ++j)
                    {
                        grafoParaCambiar[i, j] = grafo[i, j];
                    }
                }

                //Está es la parte donde realmente se ensaya
                //si una posibilidad es valida o no
                paraBajar++;
                for (int j = 0; j < nodos; ++j)
                {
                    int recibir;
                    recibir = posibilidades[paraBajar, j];
                    if (recibir == 1)
                    {
                        for (int k = 0; k < nodos; ++k)
                        {
                            grafoParaCambiar[j, k] = 0;
                            grafoParaCambiar[k, j] = 0;
                        }
                    }

                    if (j == (nodos - 1))
                    {
                        int contador2 = 0;
                        for (int q = 0; q < nodos; ++q)
                        {
                            for (int m = 0; m < nodos; ++m)
                            {
                                contador2 += grafoParaCambiar[q, m];
                            }
                        }
                        if (contador2 == 0)
                        {
                            losValidos.Add(paraBajar);
                        }
                    }
                }
                //Esto es para que no recorra posiciones nulas
                //de la matriz clonada y modificada
                if (paraBajar == (fila - 1))
                {
                    break;
                }
            }

            int elMenor = 0;
            int resultado = 0;
            int suma = 0;

            //Acá solo se saca el que realmente ese el valido
            for (int i = 0; i < losValidos.Count; ++i)
            {
                for (int j = 0; j < nodos; ++j)
                {
                    suma += posibilidades[losValidos[i], j];
                }
                if (elMenor == 0)
                {
                    resultado = losValidos[i];
                    elMenor = suma;
                    suma = 0;
                }
                else
                {
                    if (suma < elMenor)
                    {
                        resultado = losValidos[i];
                        elMenor = suma;
                        suma = 0;
                    }
                }

            }
            
            //Fila en la matriz posibilidades donde está la respuesta
           List<int> a =new List<int>();
            for (int j = 0; j < nodos; ++j)
            {

               a.Add((posibilidades[resultado, j]));
              
               


            }
            string respuesta = string.Join(",", a.ToArray());
            return (respuesta.ToString());

        }
    }
}