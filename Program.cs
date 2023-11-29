﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace QuizzConsole
{
    public partial class QuizzConsole
    {
        public static void Main(string[] args)

        {
            Welcome accueil = new Welcome();
            LaunchGame game = new LaunchGame();
            ScoreBoard score = new ScoreBoard();
            QuestionLoader questionLoader = new QuestionLoader();
            Categories categories = new Categories();


            string filePath = "QuestionsExample.csv";
            List<Questions> listeQuestions = questionLoader.LoadCSV(filePath);
            List<string> categoriesList = listeQuestions.Select(q => q.Categorie).Distinct().ToList();
            int nbQuestions = File.ReadLines(filePath).Count();


            accueil.WelcomePlayer();
            string selectedCategory = categories.ChoixCategories(listeQuestions);

            Console.WriteLine($"Choix de la catégorie : {selectedCategory}");




            foreach (Questions question in listeQuestions)
            {
                Console.WriteLine(question.Question);
                Console.WriteLine("1. " + question.Reponses[0]);
                Console.WriteLine("2. " + question.Reponses[1]);
                Console.WriteLine("3. " + question.Reponses[2]);
                Console.Write("Réponse : ");
                game.LaunchQuizz(question, score, listeQuestions);
            }

            Console.WriteLine($"Score final : {score.score}/{nbQuestions} points");
            if (score.score < nbQuestions / 4)
            {
                Console.WriteLine("Dommage, tu n'as pas reussi");
            }
            else if (score.score >= nbQuestions / 4 && score.score < nbQuestions / 2)
            {
                Console.WriteLine("Bof bof !");
            }
            else if (score.score >= nbQuestions / 2 && score.score < nbQuestions * 0.75)
            {
                Console.WriteLine("Pas trop mal !");

            }
            else
            {
                Console.WriteLine("Bravo !");
            }

            Console.ReadLine();


        }
    }
}
