using System.Diagnostics;

namespace AdventUtils;

public abstract class DayBase
{
    protected abstract string _sample1 { get; }
    protected virtual string _sample2 { get { return _sample1; } }
    protected abstract string _part1 { get; }
    protected virtual string _part2 { get { return _part1; } }

    public void Run()
    {
        Part1(_sample1, true);
        Part1(_part1, false);
        Part2(_sample2, true);
        Part2(_part2, false);
    }

    private void Part1(string input, bool isTest)
    {
        var stopwatch = Stopwatch.StartNew();
        var answer = Part1Internal(input);
        stopwatch.Stop();

        PrintAnswer(1, isTest, answer, stopwatch.ElapsedMilliseconds);
    }

    private void Part2(string input, bool isTest)
    {
        var stopwatch = Stopwatch.StartNew();
        var answer = Part2Internal(input);
        stopwatch.Stop();

        PrintAnswer(2, isTest, answer, stopwatch.ElapsedMilliseconds);
    }

    private void PrintAnswer(int partNumber, bool isTest, string answer, long elapsedMilliseconds)
    {
        var label = isTest ? "test" : "final";
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write($"The {label} answer for part {partNumber} is ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(answer);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($" - duration {elapsedMilliseconds}ms");
    }

    protected abstract string Part1Internal(string input);
    protected virtual string Part2Internal(string input) { return Part1Internal(input); }
}
