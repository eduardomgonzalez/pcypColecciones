﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;

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

            Stopwatch tiempo = new Stopwatch();

            tiempo.Start(); //inicia reloj

            //Lectura
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    arrText.Add(sLine);

                    string[] cadenaFinal = sLine.Split(',');

                    int usuario = Convert.ToInt32(cadenaFinal[1]);

                    validadYCargarUsuario(usuario, cadenaFinal);
                }

            }
            objReader.Close();

            tiempo.Stop(); //finaliza reloj

            mostrarDiccionario(dic);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tardó: {0} segundos", tiempo.ElapsedMilliseconds / 1000.0);
            Console.ReadKey();

        }

        private static void mostrarDiccionario(Dictionary<int, int> diccionario)
        {
            foreach (var entrada in diccionario.OrderByDescending(pair => pair.Value).Take(10))//imprime los 10 primeros
            {
                Console.WriteLine("{0} - {1}", entrada.Key, entrada.Value);
            }
        }
        
       private static void validadYCargarUsuario(int us, string[] cadena)
        {
            if (dic.ContainsKey(us))
            {                
                int puntajeDiccionario;

                if (dic.TryGetValue(us, out puntajeDiccionario))
                {
                    puntajeDiccionario++;
                    dic.Remove(us);
                    dic.Add(us, puntajeDiccionario);
                }
            }
            else
            {
                dic.Add(us, 1);
            }

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
