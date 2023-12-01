using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QuizzConsole
{
    public partial class QuizzConsole
    {
        public class QuestionLoader
        {

            public List<Questions> LoadCSV(string filePath)
            {
                List<string[]> lignes = File.ReadAllLines(filePath)
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
                    string categorie = colonnes[3];

                    Questions newQuestion = new Questions(questionText, reponses, bonneRep, categorie);

                    listeQuestions.Add(newQuestion);
                }

                return listeQuestions;

            }

            public string getFilePath()
            {
                string executablePath = AppContext.BaseDirectory;
                string folderName = "QuizzConsole";
                string fileName = "QuestionsExample.csv";

                int index = executablePath.IndexOf(folderName);

                if (index != -1)
                {
                    string filePath = executablePath.Substring(0, index + folderName.Length + 1) + fileName;
                    Console.WriteLine($"Executable path = {executablePath} \n File Path = {filePath}");

                    return filePath;
                }


                else
                {
                    Console.WriteLine("Path not found");
                    return string.Empty;
                }

            }
        }
    }
}


