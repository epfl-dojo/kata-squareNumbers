using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarreDeChiffres
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programme = false;
            do
            {
                Console.WriteLine("Bienvenue! Veuillez saisir un nombre.");
                string stringNombre = Console.ReadLine();
                int nombre = 0;
                bool testParse = true;
                try
                {
                    nombre = int.Parse(stringNombre);
                }
                catch (Exception e)
                {
                    testParse = false;
                    Console.WriteLine("Veuillez saisir un nombre entier positif");
                }
                if (testParse == true)
                {
                    if(nombre >= 0)
                    {
                        kataSquare(nombre);
                    }
                    else
                    {
                        Console.WriteLine("Veuillez saisir un nombre entier positif");
                    }
                }
            }
            while (programme == false);
        }
        private static void kataSquare(int nombre)
        {
            tableSuivante();
            carréEnLigne(nombre);
            tableSuivante();
            carréColonne(nombre);
            tableSuivante();
            if(nombre != 1)
            {
                carréSpirale(nombre);
            }
            else
            {
                Console.WriteLine(1);
            }
            tableSuivante();
        }
        private static void carréSpirale(int nombre)
        {
            int nombreDeLaCase = nombre * nombre;
            int?[,] array = new int?[nombre, nombre];
            int x = nombre - 1;
            int y = nombre - 1;
            while (nombreDeLaCase > 0)
            {
                bool fin = true;
                while (fin == true)
                {
                    if (x == 0)
                    {
                        if (array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            fin = false;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            x++;
                        }
                    }
                    else
                    {
                        if(array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            x--;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            x++;
                        }
                    }
                }
                y--;
                fin = true;
                while (fin == true)
                {
                    if (y == 0)
                    {
                        if (array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            fin = false;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            y++;
                        }
                    }
                    else
                    {
                        if (array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            y--;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            y++;
                        }
                    }
                }
                x++;
                fin = true;
                while (fin == true)
                {
                    if (x == nombre - 1)
                    {
                        if (array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            fin = false;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            x--;
                        }
                    }
                    else
                    {
                        if (array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            x++;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            x--;
                        }
                    }
                }
                y++;
                fin = true;
                while (fin == true)
                {
                    if (y == nombre - 1)
                    {
                        if (array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            fin = false;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            y--;
                        }

                    }
                    else
                    {
                        if (array[x, y] == null)
                        {
                            array[x, y] = nombreDeLaCase;
                            y++;
                            nombreDeLaCase--;
                        }
                        else
                        {
                            fin = false;
                            y--;
                        }
                    }
                }
                x--;
            }
            dessinerTableau(nombre, array);
        }
        private static void dessinerTableau(int nombre, int?[,] array)
        {
            for (int i = nombre - 1; i >= 0; i--)
            {
                for (int h = 0; h < nombre; h++)
                {
                    dessineCase(array[h, i].GetValueOrDefault(), nombre);
                }
                ligneSuivante();
            }
        }
        private static void carréColonne(int nombre)
        {
            int compteurLigne = 0;
            int nombreDeLaCase = 0;
            for (int e = 0; e < nombre; e++)
            {
                compteurLigne++;
                for (int i = 0; i < nombre; i++)
                {
                    nombreDeLaCase = i * nombre + compteurLigne;
                    dessineCase(nombreDeLaCase, nombre);
                }
                ligneSuivante();
            }
        }
        private static void carréEnLigne(int nombre)
        {
            int nombreDeLaCase = 0;
            for (int e = 0; e < nombre; e++)
            {
                for (int i = 0; i < nombre; i++)
                {
                    nombreDeLaCase++;
                    dessineCase(nombreDeLaCase, nombre);
                }
                ligneSuivante();
            }
        }
        private static int longueurCarré(int nombre)
        {
            int carreNombre = nombre * nombre;
            int longueurCarre = carreNombre.ToString().Length;
            return longueurCarre;
        }
        private static void tableSuivante()
        {
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
        private static void ligneSuivante()
        {
            Console.Write(Environment.NewLine);
        }
        /// <summary>
        /// Dessine une case
        /// </summary>
        /// <param name="nombre">Nombre à afficher</param>
        /// <param name="longueurCarre">Longueur du plus grand nombre dans le carré</param>
        private static void dessineCase(int nombre, int nombreSaisi)
        {
            for (int h = 0; h < longueurCarré(nombreSaisi) - nombre.ToString().Length; h++)
            {
                Console.Write(0);
            }
            Console.Write(nombre + " ");
        }
    }
}
