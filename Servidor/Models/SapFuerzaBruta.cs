using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVIDOR
{
    public class SapFuerzaBruta
    {
        public string Consulta(int rango, List<int[]> matriz)
        {
            
            int cantidadNumeros = rango;
            int contador = 1;
            bool cambiar = false;
            int fila = Convert.ToInt32(Math.Pow(2, cantidadNumeros));
            bool[,] posibilidades = new bool[fila, cantidadNumeros];
            for (int i = 0; i < cantidadNumeros; ++i)
            {
                int paSaber = 0;
                for (int j = 0; j < fila; ++j)
                {
                    if (paSaber <= contador)
                    {
                        paSaber++;
                        if (cambiar == false)
                        {
                            posibilidades[j, i] = false;
                            if (paSaber == contador)
                            {
                                cambiar = true;
                                paSaber = 0;
                            }
                        }
                        else
                        {
                            posibilidades[j, i] = true;
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

            int numeros, clausulas;

            clausulas = matriz.Count;
            List<List<int>> numero = new List<List<int>>();
            for (int i = 0; i < clausulas; ++i)
            {
                List<int> valores = new List<int>();

                numeros = (matriz[i]).Count();
                for (int j = 0; j < numeros; ++j)
                {

                    int valor = (matriz[i])[j];
                    valores.Add(valor);
                }
                numero.Add(valores);
            }

            int ombe = -1;
            List<int> losOmbes = new List<int>();
            while (true)
            {
                ++ombe;
                bool[] posibilidad = new bool[1000];
                for (int i = 0; i < cantidadNumeros; ++i)
                {
                    posibilidad[i] = posibilidades[ombe, i];
                }
                int contadorClausulas = 0;
                for (int i = 0; i < clausulas; ++i)
                {
                    int contadorNumeros = 0;
                    int tamano = numero[i].Count;
                    for (int j = 0; j < tamano; ++j)
                    {
                        int numerito = numero[i][j];
                        if (numerito < 0)
                        {
                            numerito *= -1;
                            if (posibilidad[numerito - 1] == false)
                            {
                                ++contadorNumeros;
                            }
                        }
                        else
                        {
                            if (posibilidad[numerito - 1] == true)
                            {
                                ++contadorNumeros;
                            }
                        }
                    }
                    if (contadorNumeros > 0)
                    {
                        ++contadorClausulas;
                    }
                }
                if (contadorClausulas == clausulas)
                {
                    losOmbes.Add(ombe);
                    contadorClausulas = 0;
                }
                if (ombe == (fila - 1))
                {
                    break;
                }
            }
            List<string> a = new List<string>();
            for (int i = 0; i < cantidadNumeros; ++i)
            {
                a.Add(posibilidades[losOmbes[0], i].ToString() + " ");
            }
            string respuesta = string.Join(",", a.ToArray());
            return (respuesta.ToString());
        }
    }
}