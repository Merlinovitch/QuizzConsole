using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QuizzConsole
{
    public partial class QuizzConsole
    {
        public class DeleteQuestion
        {
            QuestionLoader questionLoader = new QuestionLoader();


            public void SuppQuestion()
            {
                Console.WriteLine("Voulez vous supprimer une question ? (o/n)");
                string? choixUser = Console.ReadLine();
                if (choixUser != "o" || choixUser != "O" || choixUser != "n" || choixUser != "N")
                {
                    Console.WriteLine("Le choix doit etre o ou n");
                    SuppQuestion();
                    if (choixUser == "o" || choixUser == "O")
                    {
                        string filePath = questionLoader.getFilePath();
                        string[] lignes = File.ReadAllLines(filePath);
                        List<string[]> questions = lignes.Select(l => l.Split(";")).ToList();

                        for (int i = 0; i < questions.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + questions[i][0]);
                        }
                        Console.WriteLine("Entrez le numéro de la question à supprimer :");
                        int questionASupp = int.Parse(Console.ReadLine());
                        lignes = lignes.Where((line, index) => (index + 1) != questionASupp).ToArray();
                        File.WriteAllLines(filePath, lignes);
                        Console.WriteLine($"La question " + questionASupp + " a bien été supprimée");

                        Console.WriteLine("Voulez vous en supprimer une autre ? (o/n)");
                        string? suppAgain = Console.ReadLine();

                        if (suppAgain == "o" || suppAgain == "O")
                        {
                            SuppQuestion();
                        }
                        else if (choixUser == "n" || choixUser == "N")
                        {

                        }

                    }
                    else
                    {

                    }
                }
            }
        }

    }
}
