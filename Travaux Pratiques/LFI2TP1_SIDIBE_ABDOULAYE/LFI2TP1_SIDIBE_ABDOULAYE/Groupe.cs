using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFI2TP1_SIDIBE_ABDOULAYE
{
    class Groupe
    {
        Etudiant[] Tab;
        int Nombre_Etudiant;

        // les constructeurs
        public Groupe()
        {

        }
        public Groupe(int Nombre)
        {
            Nombre_Etudiant = Nombre;
            Tab = new Etudiant[Nombre_Etudiant];

        }

        //Methode de saisir
        public void Saisir()
        {
            string c;
            int i;

            Console.Write(" Nombre d'etudiant du groupe : ");
            c = Console.ReadLine();
            Nombre_Etudiant = Convert.ToInt32(c);

            Tab = new Etudiant[Nombre_Etudiant];
            for (i = 0; i < Nombre_Etudiant; i++)
            {
                Console.Write(" \n\t  ETUDIANT " + (i + 1) + "\n");
                Tab[i] = new Etudiant();
                Tab[i].Saisir();
            }
        }

        public override string ToString()
        {
            string ChaineTotal = " Nbr Etudiant " + Tab.Length + "\n";
            for (int i = 0; i < Tab.Length; i++)
            {
                ChaineTotal += Tab[i];
            }
            return ChaineTotal;
        }


        public void Trier()
        {
            Etudiant AUX = new Etudiant();
            for (int i = 0; i < this.Nombre_Etudiant - 1; i++)
                for (int j = i + 1; j < Nombre_Etudiant; j++)
                    if (Tab[i].Date_de_naissance.Annee > Tab[j].Date_de_naissance.Annee)
                    {
                        AUX = Tab[i];
                        Tab[i] = Tab[j];
                        Tab[j] = AUX;
                    }
        }

        // Methode afficher
        public void Affichage()
        {
            for (int i = 0; i < Nombre_Etudiant; i++)
                Tab[i].Afficher();
        }


        private Etudiant[] champ = new Etudiant[3];

        public Etudiant this[int index]
        {
            get { return champ[index]; }
            set { champ[index] = value; }
        }
    }
}
