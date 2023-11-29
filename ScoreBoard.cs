namespace QuizzConsole
{
    public class ScoreBoard
    {
        public int score { get; private set; } = 0;

        public void IncrementScore()
        {
            score++;
        }
    }

}
