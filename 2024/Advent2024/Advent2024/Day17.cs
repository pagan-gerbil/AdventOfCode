using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024;

internal class Day17 : DayBase
{
    protected override string _sample1 => "Register A: 729\r\nRegister B: 0\r\nRegister C: 0\r\n\r\nProgram: 0,1,5,4,3,0";

    protected override string _part1 => "Register A: 27334280\r\nRegister B: 0\r\nRegister C: 0\r\n\r\nProgram: 2,4,1,2,7,5,0,3,1,7,4,1,5,5,3,0";

    protected override string Part1Internal(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var registerA = long.Parse(lines[0].Substring(lines[0].IndexOf(':') + 1));
        var registerB = long.Parse(lines[1].Substring(lines[1].IndexOf(':') + 1));
        var registerC = long.Parse(lines[2].Substring(lines[2].IndexOf(':') + 1));

        var program = new List<int>(lines[3].Substring(lines[3].IndexOf(':') + 1).Split(',').Select(int.Parse));

        var output = new StringBuilder();

        var i = 0;

        while (i < program.Count)
        {
            var instruction = program[i];
            var operand = program[i + 1];

            long oValue = 0;
            switch (operand)
            {
                case 0:
                case 1:
                case 2:
                case 3: oValue = operand; break;
                case 4: oValue = registerA; break;
                case 5: oValue = registerB; break;
                case 6: oValue = registerC; break;
            }

            switch (instruction)
            {
                case 0: registerA = Convert.ToInt32(Math.Round(registerA / Math.Pow(2.0, oValue), 0, MidpointRounding.ToZero)); break;
                case 1: registerB = registerB ^ operand; break;
                case 2: registerB = oValue % 8; break;
                case 3: if (registerA != 0) i = operand; break;
                case 4: registerB = registerC ^ registerB; break;
                case 5: output.Append(oValue % 8).Append(','); break;
                case 6: registerB = Convert.ToInt32(Math.Round(registerA / Math.Pow(2.0, oValue), 0, MidpointRounding.ToZero)); break;
                case 7: registerC = Convert.ToInt32(Math.Round(registerA / Math.Pow(2.0, oValue), 0, MidpointRounding.ToZero)); break;
            }

            if (instruction != 3 || registerA == 0) i += 2;
        }

        return output.ToString();
    }
}
