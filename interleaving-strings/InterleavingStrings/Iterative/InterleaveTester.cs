namespace InterleavingStrings.Iterative
{
    public sealed class InterleaveTester
    {
        private readonly bool[,] _reached;
        private readonly string _first;
        private readonly string _second;
        private readonly string _total;

        public InterleaveTester(string first, string second, string total)
        {
            _first = first;
            _second = second;
            _total = total;
            _reached = new bool[_first.Length + 1, _second.Length + 1];
        }

        public bool IsInterleaved()
        {
            if (_first.Length + _second.Length != _total.Length)
                return false;

            var retry = new System.Collections.Generic.Stack<(int FirstIndex, int SecondIndex)>();

            for (int firstIndex = 0, secondIndex = 0; firstIndex < _first.Length || secondIndex < _second.Length;)
            {
                int totalIndex = firstIndex + secondIndex;

                if (_reached[firstIndex, secondIndex])
                {
                    if (!retry.TryPop(out var indices))
                            return false;
                    (firstIndex, secondIndex) = indices;
                    continue;
                }

                _reached[firstIndex, secondIndex] = true;

                switch
                    ( TryFirst: firstIndex < _first.Length && _first[firstIndex] == _total[totalIndex]
                    , TrySecond: secondIndex < _second.Length && _second[secondIndex] == _total[totalIndex] )
                {
                    case(true, true):
                        retry.Push((firstIndex++, secondIndex + 1));
                        break;
                    case(true, false):
                        firstIndex++;
                        break;
                    case(false, true):
                        secondIndex++;
                        break;
                    case(false, false):
                        if (!retry.TryPop(out var indices))
                            return false;
                        (firstIndex, secondIndex) = indices;
                        break;
                }
            }

            return true;
        }
    }
}