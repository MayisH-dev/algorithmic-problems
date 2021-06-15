namespace InterleavingStrings.Recursive
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

        public bool IsInterleaved() =>
            _first.Length + _second.Length == _total.Length
            && IsInterleaved(0, 0);

        private bool IsInterleaved(int firstIndex, int secondIndex)
        {
            if (firstIndex == _first.Length && secondIndex == _second.Length)
                return true;
            else if (_reached[firstIndex, secondIndex])
                return false;

            var totalIndex = firstIndex + secondIndex;
            _reached[firstIndex, secondIndex] = true;

            return
                ( TryFirst: firstIndex < _first.Length
                    && _first[firstIndex] == _total[totalIndex]
                , TrySecond: secondIndex < _second.Length
                    && _second[secondIndex] == _total[totalIndex]) switch
                {
                    (true, true) => IsInterleaved(firstIndex + 1, secondIndex)
                        || IsInterleaved(firstIndex, secondIndex + 1),
                    (true, false) => IsInterleaved(firstIndex + 1, secondIndex),
                    (false, true) => IsInterleaved(firstIndex, secondIndex + 1),
                    (false, false) => false,
                };
        }
    }
}