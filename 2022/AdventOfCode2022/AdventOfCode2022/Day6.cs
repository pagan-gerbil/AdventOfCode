using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day6
    {
        public static void Run(int puzzlePart)
        {
            if (puzzlePart == 1) Puzzle1();
            if (puzzlePart == 2) Puzzle2();
        }

        private static void Puzzle1()
        {
            Scan(4);
        }

        private static void Scan(int scanLength)
        {
            var i = 0;
            var answer = string.Empty;
            while (string.IsNullOrEmpty(answer))
            {
                var chars = _input.Skip(i).Take(scanLength).ToArray();
                if (chars.Distinct().Count() == scanLength)
                {
                    answer = new string(chars, 0, scanLength);
                    break;
                }

                i++;
            }

            Console.WriteLine($"The answer is {i + scanLength} ({answer})");
        }

        private static void Puzzle2()
        {
            Scan(14);
        }

        private static string _testInput = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";

        private static string _input = @"sgrrrrwcrrlqqgppfgfnngsgcgngrrllnqnndzzjgzzzjdjqdjdhhjshjhwwqnnwjnwnjwjttvgvddjrrtvtsvtvqtqhhbchcdhhnwwvqvvsbsqswqqdwdjwwjvvrddgpdpdlpljjwffqnffbllplmmwzwtzzvfzvvjbbmnmppzgzszllsqqpvqvmmzzlccjhchdhlddchdchcddnwdwhhhczzldlsdlssdmmswswzwtwzwjzwzfwwdhwdwjdjldjldlqddhttfbfnbfnfgnfnvnffsszjjsqqdzdsdrsswddggstgsgqgzqgqcqdccqcvcpcspccdgccfflppddqfdfmdffmlflplnppfvvgsgbgtgccmfccfwwthhcjcbbhbwbjbhjjtddrldlrddzjdzdttbfbmmtjmjtjzjvjvgvttthwhhgqhggcbbtqbbqgbqqvccdttfgfwfnwffbfqbfbbnlnzlzbbwnwntwtjwjnjwwsdwwcbbwhwzwhwvhhpwwnvvtvnttgtrrnjjzppmbmfmjffdddvfvjjpfpgpzzwqwpwllwjjzmjmdmdwwdrdttpmmdhdndvvpbpqbbzqzmmtdmmtddlccjvjsjrsscqqzvvbsstccvffcttwrwjjsgsttmgmvvzbbcjbjrbrddvjjnhjhphvhsszqqfrfzfssgfssgddcbbplbbsfsmfmpphssmvvcvrrcgrcgcvggrzggzjjfhjjtpphzppqtptllssbmbrrgrvvhjjnznlnggrnrsnrrphhbqhhhsthsthhhnssmsjjwjppqfqlqqgnnhnmmfsfslfllvnnsdnssgngbbjmjccsrrmjjnljlwlttpffddgbdggmbgbtbzzwgwppczcffvccnssbmmjrrfwwhcwhwqwnqqzsqqjsqqnndqdgqdqgggzjjcvvzdddhnhjnnzlnlwlzlqqvjjpprqrjrfjjrpjjnfntffqtttnjjdbjbdjbbrsrbbmrmccpllmccqrqwqnnsjjmjgjqjpqjqgjjtwwqdqmqtqqmsqmmvlldtllbcctfcccdcddcggmmmsggjddcqddbqqdgqgffststgtftbbdrbrlllnvllcflfpfdffjvvvmdmvvtfvfcvvfgghzzlgzgszzhmzzhfhllgblggfpfzfvzvdzzhsspmmjtjhjggfhggnggbtggqqtztqtmqtqddmzmrmdrmdmqqcbqcqzzvczvzfvvsggcgssjnnjqnntwtmwwhzzzhllqvlljsljjfnnjwjnwnffpggqwwvbwwdbbmbvmvlvnnnppqvqqghqgqppnllhjllvlflfpfhfjjhgjgpjpbjjdpdqdpqdpdwpwffqlffrbrjrtrvtvrtvrtrvtvltlrrvjjlttmtffhvfhfnhnlnfnvvltvlvlbbfllfnllndndcdrrnznssvpvhhhmrmlmhhrnhhpggtftddghhqrqddjttbdbqddpsdppwrwhhhgwhhqrhqrqhhqdhqddjpjqqsdsmddnqncqnqwqdwwhghbhffnsffnsszlssntnbbbfhbhwhzhdzhzbhblbzzzbqzbbgtbbcjbjtjptpwwhlwwhhmshhmbbfjbfflnnlmnnzvnnbtnbbvwvvgcggrzrffwmwhmwhwjwpwwzbbvtbtssdhdlhhdppmmcnmcmffnpfffvbfvfhvhjhffzfbzzfdfpdpzzhbzblbbmffvvcmmttdntnmtmztzbbncbctcqtcqqcvcfcwcdcchphfhjhhjbjnjtjnjwwzsstpprnnhtntvtpthpttpdpzzwcczsscqscsbbmpbbdsdlsslzszjszsczntrqjmmmfqsdwtqqflgsttwfqqvvspnlfvqlrvvbjmmpmttcdnhncmmdfhwwqdrqjqwggrbtgbrdmmrhhvqfvvhsmtfbnthrbltgvdrsbqglgjqtssbvmbjjjbbcgfftgbjmfqzggdtcfzddqlrvwqjjvnmjzjwqrwsqbjgnswpnlbdzdlcvcbqplzgqwmsntzzjhqwfjdprglcccnldfqftgttqbrmclsqtncrjbttcglcvspsgvdjqgrdzzlnhbfqbwnfqcjrrqpprjbqpzhthgsgcflqldsnwsvzgcmfrdvfmqhbcfczhschpwnmdjnjlvrwqllnnhjvjtzhcrqcwlmrqfdhvzcbnvwrgngttwlhcmmgtzwjztscjnmslbvtdrvgdprlfrhggcwtwjhblppfbpljbmwrlwqrfwjwfsftmflsdfrhlvgcbzcvhlhgclvnmtfcqttvcphgvflhdclbmtgsrldgfvtpjcphtzdctrcchwdbdbtpptdnbjnqwdrllmnbcgfltmggpqfbfpmnhcmpgsgptflglzswtmrjfzmwmwphfjngnfmmtqlrsltlvlfmwmjvvtgngllszwzdjjmbnwwgzpqltlrzfdwchgttvlhgjjhjqmlrrwsqlhsgzsgmmsgbgvrlmbprrhlgsjnsdwcbrwvqjqmfcqcwllsvggcznwpzvgpszrqwngcnchvdlrdrgtbsjdqfpsfvwdtdlqwbfjlwrmqbrhwqmfgppwvfbgthnbqnmqqhmpfwbgljcmqqbpnwvztrcrlbvtcnncwwjcbqsmbqnqtrmpwmhlvwtfmsmtpfnmphqdvqfzvmjjhnwdfjnwvmbbwvthhwzjtzzrsmqlqtnnrqjrnchqttgsptfpdcpgfmzvqhwffqmfhwqqbdhmgcrfqtwrcgtgmglmmwhvqwvglfsvwbpvhmnbqhgfgqwwnhdhvnwggsmhjfsjmsrlcvlnhrhrlhbvhdrhbplrzspdmbcnzbwlvcmztwvghlsnzmbnrpssrngpdtmgzfcbqmfdgthcscjspspmcgdmwwwfspgjwzccrfzdpbwrfpgpgzrchffmhvwwppbjwqmdzgtpfmcblzqrghzdbzqzvbnmqbdlzjrwbbhqgtdzntgdbndmndhlnhcvqtlfcrfprfrlfglwvdnszrwjdcmtstcsnvnpcldctvqpcfhjnpvscscrtfqfjcrjlrmcqjfthptbqprbvchjlqzmfcmlhmfmdhhpcqbncmcqjsdmzflwtzfdcgmrbwbcdgjmfhlshsbwmbdcbfbvmqcgwlqpprjfrhzvsjmcjdfnwhcffhtnqpznfzpttsqqwcsvpdhdfbggzpngvbvdlpmvfjjlcfmbvmfqsczprtlnwvqnnlcrdnvpmcbrzvlfgscbcwtrbcpdnpshhmrqmhnwcndptljhwpvtcflqgmzjsfmfdzwwwhnbpzjwzgqmdcdbtfhwtgvcscbdqlcmppwjgghvrmqpwfbnjfhfcrccfzjvtjsjcsmhncdjlclvhfsvlcjcnpbqqqdjmjdbggmfwswvdjscvgrdbpcrcqtndswgdnznzpwtcdgvcrrqpdcpbmbdjrsgnfvgwpgpzttfmsczcmjvhmdpbpmjjcjsvbvbwjpwtwpsdddlsnvrshqvmwsjwwvqnczzljjfptcszgpndgczprbvjbnqpwgzmnlhvbsfbtjnwbtlzqgnmzbmqgqvwzltvqczfpdzfzsfhqlmtfcbfdqtnwzbvqblqmzvmnspntqtqdglrdmdntrghwvpfrbjgpzvrnppvnvfgwdzlvhtcscclbtftlvsprwhjvjlhrhfdgzbfbfphzbhtfdlpzcshhfzhtdvggnnbqvnrwvnhvgjgjpcrztqjmtzlzlrlmndfvctzjdpnmlgmsppqdrzmptvrsptvmmbvbwvhwptrtlfdqdqwfgldtbhqdhszcmwqnhswrdhgmgvbvbhwhlpcflsrwlvsvhvctmwwhtlgmshdqflwsdjbbzgbvbwpfncgqjzfjvmzzhgdzjvghtrtsmwgzpdrngwdbtfzrqsgdmwtdhsftfqcnmjtrqqwthcbgtmqnjvjzzplrzllnjqddvbwnglhtzljwjvscdfdnsvmrgwhjrhlrqpqgmzstnwwjpddhdbsnnsqvtsdhtmfdmbcpzwqmbhhjhcfzbvvglhfdltrmbstjhsqrbs";
    }
}
