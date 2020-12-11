using System;
using System.Linq;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var seatArray = _example
                .Split(Environment.NewLine)
                .Select(x => x.ToCharArray())
                .ToArray();

            var changed = true;

            while (changed == true)
            {
                changed = false;
                var newSeatArray = seatArray.Select(x => string.Join(null, x).ToCharArray()).ToArray();
                
                for (var row = 0; row < seatArray.Length; row++)
                {
                    for (var col = 0; col < seatArray[row].Length; col++)
                    {
                        var count = CountAdjacent(4, seatArray, row, col);
                        switch (seatArray[row][col])
                        {
                            case '.':
                                continue;
                            case 'L':
                                if (count == 0)
                                {
                                    newSeatArray[row][col] = '#';
                                    changed = true;
                                }
                                break;
                            case '#':
                                if (count >= 4)
                                {
                                    newSeatArray[row][col] = 'L';
                                    changed = true;
                                }
                                break;
                        }
                    }
                }

                seatArray = newSeatArray;
            }

            Console.WriteLine("Loop exited");
            Console.WriteLine($"There are {seatArray.Sum(x => x.Count(y => y == '#'))} occupied seats");
        }

        private static int CountAdjacent(int cutoff, char[][] seatArray, int row, int col)
        {
            var rowStart = row == 0 ? 0 : -1;
            var rowEnd = row == seatArray.Length - 1 ? 1 : 2;
            var colStart = col == 0 ? 0 : -1;
            var colEnd =   col == seatArray[0].Length - 1 ? 1 : 2;
            var counter = 0;
            
            for (var rowMod = rowStart; rowMod < rowEnd; rowMod++)
            {
                for (var colMod = colStart; colMod < colEnd; colMod++)
                {
                    if (rowMod == 0 && colMod == 0)
                        continue;

                    if (seatArray[row + rowMod][col + colMod] == '#')
                        counter++;

                    if (counter == cutoff)
                        return counter;
                }
            }

            return counter;
        }

        private static string _example = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";
    }
}
