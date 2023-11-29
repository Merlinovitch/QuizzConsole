namespace QuizzConsole
{
    public partial class QuizzConsole
    {
        public class Questions
        {
            public string Question { get; private set; }
            public string[] Reponses { get; private set; }

            public int BonneRep { get; private set; }
            public string Categorie { get; private set; }

            public Questions(string question, string[] reponses, int bonneRep, string categorie)
            {
                Question = question;
                Reponses = reponses;
                BonneRep = bonneRep;
                Categorie = categorie;
            }
        }
    }

}
