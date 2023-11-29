using System;
using System.Collections.Generic;

namespace QuizzConsole
{
    public class LaunchGame
    {

        public void LaunchQuizz(QuizzConsole.Questions question, ScoreBoard score, List<QuizzConsole.Questions> listeQuestions)
        {

            int choixUser;
            if (int.TryParse(Console.ReadLine(), out choixUser) && choixUser >= 1 && choixUser <= 3)
            {

                int bonneRepIndex = question.BonneRep;

                if (choixUser == bonneRepIndex)
                {
                    Console.WriteLine("\n--- Bonne réponse ---");
                    score.IncrementScore();
                    Console.WriteLine("Score : " + score.score + " points \n");
                    Console.WriteLine("Appuyez sur entrée pour continuer \n");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\n--- Mauvaise réponse ---");
                    Console.WriteLine("La bonne réponse était " + question.Reponses[bonneRepIndex - 1] + "\n");
                    Console.WriteLine("Appuyez sur entrée pour continuer \n");
                    Console.ReadLine();


                }

            }
            else
            {
                Console.WriteLine("La réponse doit être 1, 2 ou 3");
                Console.Write("Réponse : ");
                LaunchQuizz(question, score, listeQuestions);
            }
        }

    }

}
