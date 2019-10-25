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
            seprateurDeTables();
            carréEnLigne(nombre);
            seprateurDeTables();
            carréColonne(nombre);
            seprateurDeTables();
            carréSpirale(nombre);
            seprateurDeTables();
        }
        class MarcheSpirale
        {
            public int nombreDeLaCase;
            public int x;
            public int y;
            public Vecteur déplacement;

            public MarcheSpirale(int nombre)
            {
                x = nombre - 1;
                y = nombre - 1;
                déplacement = Vecteur.versLaGauche;
                nombreDeLaCase = nombre * nombre;
            }
        }
        private static void carréSpirale(int nombre)
        {
            int?[,] array = new int?[nombre, nombre];
            MarcheSpirale état = new MarcheSpirale(nombre);

            while (état.nombreDeLaCase > 0)
            {
                ligneDroite(état, nombre, array);
            }
            dessinerTableau(nombre, array);
        }
        private static void ligneDroite(MarcheSpirale état, int nombre, int?[,] array)
        {
            while (true)
            {
                array[état.x, état.y] = état.nombreDeLaCase;
                if (-- état.nombreDeLaCase == 0) return;

                if ((!état.déplacement.sortiraitDuCadre(état.x, état.y, nombre)) &&
                    array[état.déplacement.deplaceX(état.x), état.déplacement.deplaceY(état.y)] == null)
                {
                    état.x = état.déplacement.deplaceX(état.x);
                    état.y = état.déplacement.deplaceY(état.y);
                }
                else
                {
                    break;
                }
            }
            état.déplacement = état.déplacement.tourne();
            état.x = état.déplacement.deplaceX(état.x);
            état.y = état.déplacement.deplaceY(état.y);
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
        private static void seprateurDeTables()
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
    class Vecteur
    {
        int dx;  /// La quantité dont on avance en x; peut être 1, 0 ou -1
        int dy;  /// La quantité dont on avance en y; peut être  1, 0 ou -1 (mais dx et dy ne peuvent pas être tous deux nuls)
        public static Vecteur versLeHaut = new Vecteur(0, 1);
        public static Vecteur versLeBas = new Vecteur(0, -1);
        public static Vecteur versLaDroite = new Vecteur(1, 0);
        public static Vecteur versLaGauche = new Vecteur(-1, 0);
        public Vecteur(int dx_, int dy_) {
            dx = dx_;
            dy = dy_;
        }
        public int deplaceX(int ancienX)
        {
            return ancienX + dx;
        }
        public int deplaceY(int ancienY)
        {
            return ancienY + dy;
        }
        public bool sortiraitDuCadre(int ancienX, int ancienY, int cadreMax)
        {
            if (deplaceX(ancienX) < 0) return true;
            if (deplaceX(ancienX) >= cadreMax) return true;
            if (deplaceY(ancienY) < 0) return true;
            if (deplaceY(ancienY) >= cadreMax) return true;
            return false;
        }
        public Vecteur tourne()
        {
            if (this == Vecteur.versLaGauche)
            {
                return Vecteur.versLeBas;
            }
            else if(this == Vecteur.versLeBas)
            {
                return Vecteur.versLaDroite;
            }
            else if(this == Vecteur.versLaDroite)
            {
                return Vecteur.versLeHaut;
            }
            else
            {
                return Vecteur.versLaGauche;
            }
        }
    }
}
