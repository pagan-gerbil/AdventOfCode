using System.Text.RegularExpressions;

namespace AdventUtils.Solvers;

public class Wordsearch
{
    private string[] _forwardDiagonals;
    private string[] _backDiagonals;
    private IEnumerable<string> _verticalLines;
    private List<string> _horizontalLines;

    public Wordsearch(string input)
    {
        _horizontalLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        var indices = Enumerable.Range(0, _horizontalLines[0].Length);
        var maxLength = indices.Count();

        _forwardDiagonals = Enumerable.Range(-maxLength, maxLength * 2).Select(a =>
        {
            var c = a;
            return new string(_horizontalLines.Select(b =>
            {
                c++;
                var result = c < maxLength && c >= 0 ? b[c] : '\0';
                return result;
            }).ToArray());
        }).ToArray();
        _backDiagonals = Enumerable.Range(0, (maxLength * 2)).Select(a =>
        {
            var c = a;
            return new string(_horizontalLines.Select(b =>
            {
                c--;
                var result = c >= 0 && c < maxLength ? b[c] : '\0';
                return result;
            }
            ).ToArray());
        }).ToArray();

        _verticalLines = indices.Select(a => new string(_horizontalLines.Select(b => b[a]).ToArray()));
    }

    public int CountWords(params string[] wordList)
    {
        var wordListRegex = new Regex(string.Join('|', wordList.Select(word => $"(?<={word})|(?<={new string(word.Reverse().ToArray())})")));

        Console.WriteLine($"Horizontal matches: {_horizontalLines.Sum(wordListRegex.Count)}");
        Console.WriteLine($"Vertical matches: {_verticalLines.Sum(wordListRegex.Count)}");
        Console.WriteLine($"forward diagonal matches: {_forwardDiagonals.Sum(wordListRegex.Count)}");
        Console.WriteLine($"back diagonal matches: {_backDiagonals.Sum(wordListRegex.Count)}");

        var result = _horizontalLines.Sum(wordListRegex.Count) +
            _verticalLines.Sum(wordListRegex.Count) +
            _forwardDiagonals.Sum(wordListRegex.Count) +
            _backDiagonals.Sum(wordListRegex.Count);

        return result;
    }
}
