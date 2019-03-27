﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace _04_Netflix
{
    class Program
    {
        /*En el archivo “ratings.txt” se encuentran las puntuaciones realizadas por los usuarios de Netflix para cada película. 
         El formato del archivo es el siguiente:
         <identificador de película>,<identificador de usuario>,<puntaje asignado>,<fecha del puntaje>
         Se solicita realizar un top 10 de los usuarios que más puntuaciones hicieron en Netflix.*/

        private static Dictionary<int, int> dic = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            StreamReader objReader = new StreamReader("c:\\ratings.txt");//Me da error cuando pongo este archivo en la solucion y lo quiero subir a GitHub
            string sLine = "";
            List<string> arrText = new List<string>();

            //Lectura
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    arrText.Add(sLine);

                    string[] cadenaFinal = sLine.Split(',');

                    int peli = Convert.ToInt32(cadenaFinal[1]);

                    if (dic.ContainsKey(peli))
                    {
                        int valor = Convert.ToInt32(cadenaFinal[2]);

                        if (dic.TryGetValue(peli, out valor))
                        {
                            valor += valor;
                            dic.Remove(peli);
                            dic.Add(peli, valor);
                        }
                    }
                    else
                    {
                        dic.Add(peli, Convert.ToInt32(cadenaFinal[2]));
                    }
                }

            }
            objReader.Close();

            mostrarDiccionario(dic);

            //Muestro el array
            /*foreach (string line in arrText)
            {
                Console.WriteLine(line);
            }*/

            //Muestro determinada posicion del array
            /* Console.Write("{0}" , arrText[5]);                
             Console.ReadKey();*/


        }

        private static void mostrarDiccionario(Dictionary<int, int> diccionario)
        {
            foreach (var entrada in diccionario)
            {
                Console.WriteLine("{0} - {1}", entrada.Key, entrada.Value);
            }
            Console.ReadKey();
        }
    }
}
/*
 * Otra forma de leer un txt y mostrarlo por pantalla
string text = System.IO.File.ReadAllText(@"C:\ratings.txt");
System.Console.WriteLine("Contenido del archivo = {0}", text);
Console.WriteLine("Presione cualquier tecla para salir.");
System.Console.ReadKey();
*/
