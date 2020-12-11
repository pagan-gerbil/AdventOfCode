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

            var newSeatArray = new char[seatArray.Length, seatArray[0].Length];
            seatArray.CopyTo(newSeatArray, 0);

            var changed = false;

            for(var row = 0; row < seatArray.Length; row++)
            {
                for (var col = 0; col < seatArray[row].Length; col++)
                {
                    switch(seatArray[row][col])
                    {
                        case '.':
                            continue;
                        case 'L':
                            //check all adjacent
                            break;
                        case '#':
                            //count till 4
                            break;
                    }
                }
            }

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
