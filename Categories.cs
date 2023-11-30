using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QuizzConsole
{
    public partial class QuizzConsole
    {
        public class Categories
        {
            QuestionLoader questionLoader = new QuestionLoader();

            public string ChoixCategories(List<Questions> listeQuestion)
            {
                string filePath = questionLoader.getFilePath();

                Console.WriteLine("Choix de la catégorie :");
                List<string> categories = questionLoader.LoadCSV(filePath).Select(q => q.Categorie).Distinct().ToList();

                foreach (int i in Enumerable.Range(0, categories.Count))
                {
                    Console.WriteLine($"{i + 1} : {categories[i]}");
                }
                Console.WriteLine("Tapez un nombre entre 1 et " + categories.Count + " ou 9 pour une categorie aleatoire\n");

                int choixUserCategory;

                if (int.TryParse(Console.ReadLine(), out choixUserCategory) && choixUserCategory >= 1 && choixUserCategory <= categories.Count)
                {

                    return categories[choixUserCategory - 1];
                }
                if (choixUserCategory == 9)
                {
                    return categories[Random.Shared.Next(0, categories.Count)];
                }
                else
                {
                    Console.WriteLine("Choix invalide, sélectionnez à nouveau.");
                    return ChoixCategories(listeQuestion);
                }

            }
        }
    }
}