namespace LoadTesting.Helpers
{
    public class Randomizer :IRandomizer
    {
        private Random random;
        public Randomizer()
        {
            random = new Random(new DateTime().Millisecond);
        }
        public int GetNextRandomNumber(int maxValue)
        {
            return random.Next(maxValue);
        }
    }

    public interface IRandomizer
    {
        int GetNextRandomNumber(int maxValue);
    }
}
