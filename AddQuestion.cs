using System;
using System.IO;

namespace QuizzConsole
{
    public partial class QuizzConsole
    {
        public class AddQuestion
        {
            string filePath = "QuestionsExample.csv";
            public string? AjoutQuestion()
            {
                Console.WriteLine("Ecrire a pour ajouter une nouvelle question, n'importe quelle autre commande pour continuer");
                string? choixUser = Console.ReadLine();
                if (choixUser == "a")
                {
                    try
                    {



                        Console.WriteLine("Ajout d'une nouvelle question");
                        Console.Write("Question : ");
                        string? nouvelleQuestion = Console.ReadLine();
                        Console.Write("Réponse 1 : ");
                        string? nouvelleReponse1 = Console.ReadLine();
                        Console.Write("Réponse 2 : ");
                        string? nouvelleReponse2 = Console.ReadLine();
                        Console.Write("Réponse 3 : ");

                        string? nouvelleReponse3 = Console.ReadLine();
                        Console.Write("Quelle est la bonne réponse (nombre entier) : ");

                        int? nouvelleBonneReponse = int.TryParse(Console.ReadLine(), out int nouvelleBonneReponseInt) ? nouvelleBonneReponseInt : null;
                        Console.Write("Catégorie : ");

                        string? nouvelleCategorie = Console.ReadLine();

                        using (StreamWriter sw = File.AppendText(filePath))
                        {

                            {
                                string nouvelleLigne = $"{nouvelleQuestion};{nouvelleReponse1}/{nouvelleReponse2}/{nouvelleReponse3};{nouvelleBonneReponse};{nouvelleCategorie}";
                                sw.WriteLine(nouvelleLigne);

                                Console.WriteLine($"Votre question : {nouvelleQuestion} a bien été ajoutée dans la catégorie {nouvelleCategorie}\n");
                                return nouvelleLigne;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {

                }
                return null;
            }
        }
    }
}