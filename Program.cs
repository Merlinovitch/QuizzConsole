using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace QuizzConsole
{
    public class QuizzConsole
    {
        public static void Main(string[] args)

        {
            Welcome accueil = new Welcome();
            LaunchGame game = new LaunchGame();
            ScoreBoard score = new ScoreBoard();
            QuestionLoader questionLoader = new QuestionLoader();
            Music music = new Music();



            List<Questions> questionsList = questionLoader.LoadCSV(@"C:\Users\Utilisateur\Desktop\Simplon\QuizzConsole\QuestionsExample.csv");

            accueil.WelcomePlayer();
            Music.takeOnMe();

            foreach (Questions question in questionsList)
            {
                Console.WriteLine(question.Question);
                Console.WriteLine("1. " + question.Reponse1);
                Console.WriteLine("2. " + question.Reponse2);
                Console.WriteLine("3. " + question.Reponse3);
                Console.Write("Réponse : ");
                game.LaunchQuizz(question, score);
            }

            Console.WriteLine("Score final : " + score.score + " points");



        }

        public class Welcome
        {
            public void WelcomePlayer()
            {
                Console.WriteLine("Bonjour, bienvenue sur ce Quizz");
                Console.Write(@"                                                                                                                                
                                                                                                                                
LLLLLLLLLLL                                           QQQQQQQQQ                         iiii                                    
L:::::::::L                                         QQ:::::::::QQ                      i::::i                                   
L:::::::::L                                       QQ:::::::::::::QQ                     iiii                                    
LL:::::::LL                                      Q:::::::QQQ:::::::Q                                                            
  L:::::L                   eeeeeeeeeeee         Q::::::O   Q::::::Quuuuuu    uuuuuu  iiiiiii zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
  L:::::L                 ee::::::::::::ee       Q:::::O     Q:::::Qu::::u    u::::u  i:::::i z:::::::::::::::zz:::::::::::::::z
  L:::::L                e::::::eeeee:::::ee     Q:::::O     Q:::::Qu::::u    u::::u   i::::i z::::::::::::::z z::::::::::::::z 
  L:::::L               e::::::e     e:::::e     Q:::::O     Q:::::Qu::::u    u::::u   i::::i zzzzzzzz::::::z  zzzzzzzz::::::z  
  L:::::L               e:::::::eeeee::::::e     Q:::::O     Q:::::Qu::::u    u::::u   i::::i       z::::::z         z::::::z   
  L:::::L               e:::::::::::::::::e      Q:::::O     Q:::::Qu::::u    u::::u   i::::i      z::::::z         z::::::z    
  L:::::L               e::::::eeeeeeeeeee       Q:::::O  QQQQ:::::Qu::::u    u::::u   i::::i     z::::::z         z::::::z     
  L:::::L         LLLLLLe:::::::e                Q::::::O Q::::::::Qu:::::uuuu:::::u   i::::i    z::::::z         z::::::z      
LL:::::::LLLLLLLLL:::::Le::::::::e               Q:::::::QQ::::::::Qu:::::::::::::::uui::::::i  z::::::zzzzzzzz  z::::::zzzzzzzz
L::::::::::::::::::::::L e::::::::eeeeeeee        QQ::::::::::::::Q  u:::::::::::::::ui::::::i z::::::::::::::z z::::::::::::::z
L::::::::::::::::::::::L  ee:::::::::::::e          QQ:::::::::::Q    uu::::::::uu:::ui::::::iz:::::::::::::::zz:::::::::::::::z
LLLLLLLLLLLLLLLLLLLLLLLL    eeeeeeeeeeeeee            QQQQQQQQ::::QQ    uuuuuuuu  uuuuiiiiiiiizzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
                                                              Q:::::Q                                                           
                                                               QQQQQQ                                                           
                                                                                                                                
                                                                                                                                
                                                                                                                                
                                                                                                                                
                                                                                                                                ");
                Console.WriteLine("Appuyez sur entrée pour commencer");
                Console.ReadLine();
            }
        }

        public class Questions
        {
            public string Question { get; private set; }
            public string Reponse1 { get; private set; }
            public string Reponse2 { get; private set; }
            public string Reponse3 { get; private set; }

            public int BonneRep { get; private set; }

            public Questions(string question, string reponse1, string reponse2, string reponse3, int bonneRep)
            {
                Question = question;
                Reponse1 = reponse1;
                Reponse2 = reponse2;
                Reponse3 = reponse3;
                BonneRep = bonneRep;
            }
        }
        public class QuestionLoader
        {



            public List<Questions> LoadCSV(string cheminFichier)
            {
                List<string[]> lignes = File.ReadAllLines(cheminFichier)
                                        .Select(line => line.Split(";"))
                                        .ToList();

                List<Questions> listeQuestions = new List<Questions>();


                foreach (string[] colonnes in lignes)
                {
                    string questionText = colonnes[0];

                    string[] reponses = colonnes[1].Split('/');
                    string reponse1 = reponses[0];
                    string reponse2 = reponses[1];
                    string reponse3 = reponses[2];

                    int bonneRep = int.Parse(colonnes[2]);

                    Questions newQuestion = new Questions(questionText, reponse1, reponse2, reponse3, bonneRep);

                    listeQuestions.Add(newQuestion);
                }

                return listeQuestions;

            }
        }
    }
    public class LaunchGame
    {

        public void LaunchQuizz(QuizzConsole.Questions question, ScoreBoard score)
        {

            int choixUser;
            if (int.TryParse(Console.ReadLine(), out choixUser) && choixUser >= 1 && choixUser <= 3)
            {

                int bonneRepIndex = question.BonneRep;

                if (choixUser == bonneRepIndex)
                {
                    Console.WriteLine("Bonne réponse");
                    score.IncrementScore();
                    Console.WriteLine("Score : " + score.score + " points \n");
                    Console.WriteLine("Appuyez sur entrée pour continuer \n");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse");
                    Console.WriteLine("La bonne réponse était " + bonneRepIndex);
                    Console.WriteLine("Question suivante\n");

                }

            }
            else
            {
                Console.WriteLine("La réponse doit être 1, 2 ou 3");
                Console.Write("Réponse : ");
                LaunchQuizz(question, score);
            }
        }

    }

    public class ScoreBoard
    {
        public int score { get; private set; } = 0;

        public void IncrementScore()
        {
            score++;
        }
    }
    public class Music
    {
        public static void takeOnMe()
        {
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(293, 200);
            Console.Beep(246, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(415, 200);
            Console.Beep(415, 200);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(329, 200);
            Console.Beep(293, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(293, 200);
            Console.Beep(246, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(415, 200);
            Console.Beep(415, 200);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(440, 200);
            Console.Beep(329, 200);
            Console.Beep(293, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
            Console.Beep(329, 200);
            Console.Beep(369, 200);
            Console.Beep(329, 200);
        }
    }
}
