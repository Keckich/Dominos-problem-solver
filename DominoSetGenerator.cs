namespace Dominos
{
    internal class DominoSetGenerator
    {
        private const int MaxDominoValue = 6;

        private static Random random = new Random();

        public static List<(int, int)> Generate(int dominosCount)
        {
            var dominos = new List<(int, int)>();

            for (int i = 0; i < dominosCount; i++)
            {
                var left = random.Next(1, MaxDominoValue + 1);
                var right = random.Next(1, MaxDominoValue + 1);

                dominos.Add((left, right));
            }

            return dominos;
        }
    }
}
