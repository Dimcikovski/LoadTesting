namespace LoadTesting.Helpers
{
    public class SortingService : ISortingService
    {
        private readonly IRandomizer _randomizer;

        public SortingService(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public int[] SortArray(SortingAlgorithm sortingAlgorithm)
        {
            const int limit = 100_000;
            var unsortedArray = new int[limit];

            for (var i = 0; i < limit; i++)
            {
                unsortedArray[i] = _randomizer.GetNextRandomNumber(limit);
            }

            if (sortingAlgorithm == SortingAlgorithm.QuickSort)
            {
                return SortingAlgorithms.QuickSort(unsortedArray, 0, unsortedArray.Length - 1);
            }

            return SortingAlgorithms.BubbleSort(unsortedArray);

        }
    }

    public interface ISortingService
    {
        int[] SortArray( SortingAlgorithm sortingAlgorithm);
    }

    public enum SortingAlgorithm
    {
        BubbleSort,
        QuickSort,
    }
}
