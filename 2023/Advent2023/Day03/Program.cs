﻿using System.Data;
using System.Text;

namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = _input1;
            Puzzle1(input);
        }

        private static void Puzzle1(string input)
        {
            var rows = input.Split(Environment.NewLine);

            var gearRatios = 0;
            var coords = new List<Tuple<int, int>> ();
            var adjacentNumbers = new List<int>();
            var allSymbols = rows.SelectMany(y => y.Where(x => !char.IsDigit(x) && x != '.'));
            var rowNumber = 0;
            foreach (var row in rows) 
            {
                var colNumber = 0;
                foreach (var c in row)
                {
                    if (allSymbols.Contains(c))
                    {
                        coords.Add(new Tuple<int, int>(rowNumber, colNumber));
                        var thisSymbolAdjacentNumbers = SearchAdjacent(rowNumber, colNumber, rows, allSymbols).ToArray();
                        adjacentNumbers.AddRange(thisSymbolAdjacentNumbers);
                        var isGear = thisSymbolAdjacentNumbers.Count() == 2 && c == '*';
                        if (isGear)
                        {
                            gearRatios += (thisSymbolAdjacentNumbers[0] * thisSymbolAdjacentNumbers[1]);
                        }
                    }
                    colNumber++;
                }
                rowNumber++;
            }

            Console.WriteLine($"Found {coords.Count} symbols");
            Console.WriteLine($"Sum of part numbers: {adjacentNumbers.Sum()}"); // 501695 is too low
            Console.WriteLine($"Sum of gear ratios: {gearRatios}");
            
        }

        private static IEnumerable<int> SearchAdjacent(int rowNumber, int colNumber, string[] rows, IEnumerable<char> allSymbols)
        {
            var results = new List<int>();
            for (var rowMod = -1; rowMod < 2; rowMod++)
            {
                if (rowNumber + rowMod >= 0)
                {
                    var topRow = colNumber > 0
                        ? rows[rowNumber + rowMod].Substring(colNumber - 1, 3)
                        : rows[rowNumber + rowMod].Substring(colNumber, 2);

                    var colMod = 1;

                    while (char.IsDigit(topRow[0]) && colNumber - colMod > 0)
                    {
                        colMod++;
                        topRow = topRow.Insert(0, rows[rowNumber + rowMod][colNumber - colMod].ToString());
                    }

                    colMod = 1;
                    while (char.IsDigit(topRow.Last()) && colNumber + colMod < rows[rowNumber].Length - 1)
                    {
                        colMod++;
                        topRow += rows[rowNumber + rowMod][colNumber + colMod].ToString();
                    }

                    var numbers = topRow.Split(allSymbols.Concat(new[] { '.' }).ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach (var number in numbers)
                    {
                        if (int.TryParse(number, out var parsedNumber))
                        {
                            results.Add(parsedNumber);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
            
            return results;
        }

        private static string _test = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..";
        private static string _input1 = "...................15....904...........850.................329...................13....................................871....816....697....\r\n...........53.497........................%....906...610.......*.............735#..&...*......558...68...............68..*......&....*.......\r\n..........*....$....................132.........*..........844....875................350............*...............*..336.364...649........\r\n.......726.......341..................*...186...358..................*244........57.......@.........738......*.....663.................584..\r\n.............952.*......33......660..704............949......................518*....234.967....551........971..&.......................*...\r\n.......738...*....222......................706.......*..825.............474%...........*...........*.405.........779..............542...405.\r\n.74.........366....................192..........542.737....*760...................623/..730.....718.../.....................$17......%......\r\n...*126.....................%........*.504...=..*.........................................................974...............................\r\n........331/..901.........337..........*...461.698...............*461.....814............................*............975...............165.\r\n..../.........*.....................262.......................313........*........530.56.....567.......897.....*.........*.9................\r\n....953....355...@703..................................609..............462.......%........./...............108.557...501.../...724.........\r\n..............................................=.........%.......46......................533....670...............................*..%630....\r\n.........................91...382*204.........154..%.............+.524.995..............=.....*...........7..........692.92*56...73.........\r\n.685....*....70.189.......*.........................773...830/....../....*........=.........565.............464................$....738..130\r\n.........938..*........993..............*.................................243...340...753...........*...882...............108.647....*......\r\n..............762..........348.......280...............364*526...........................*........552.....=....25..682....*.........164.....\r\n.....948..............813../....644......62........................................#.....657......................*.........................\r\n......*...........................*.................$745.......739.....*...399...30............&..@...........924.117..........309..........\r\n...883....544.....33.........585=.428.146................288.....*..853....*...........*891.409....429..460...*..........997....*........187\r\n.............*818........829..........*....846..............................248.....574..................*....789.......*.....965....-..*...\r\n......=.....................*..........370.......850+.............313...........................573....621...............268.......58..800..\r\n....67....287.............481..709...............................*.......#74...................*.................965........................\r\n............@.291.............*.........607*....950.475..309...66..932........395..374..........155.891....472..*......774.............&....\r\n....207..........%..262......543..887/......711....*.......+......*............*...*........823............*...93...........377.....764.....\r\n.....*...968.951.......#................................$.........453...366..736.972........*.............697........*618...&...............\r\n....984..*...............-.......................884..23......492.....*..*................70..523.....25........$.....................370...\r\n..................870...187.......548#.522..458.....*..........*....956......535....../.........*.525*........197....@..*266...123.....*....\r\n.........501.....*..........................&.....323........257........956..*........80..946.592.................211.........*.........311.\r\n.....380*.....867...653..347....................*........93=...........*......515..........-...................................678..........\r\n..........876......&....*.......&631.950.647...631...@...........=...705..914................739..............319......713.........*97.#918.\r\n.....805...*..........118................-.........790....559..51........../........*.........*......550......*........./.......647.........\r\n......-..428.....599......813................413..................280............840.654.......91.....*...........236.......$...............\r\n.............=...%.......*.....77...................#.492............................................96..........@.......175....%...........\r\n......*427..569..........47......................999......314.....636*253.................764.................27......-..........415..386...\r\n...142................$................@..320........969...................882*311...............#..751...........=....649...........*......\r\n.........*723..993.976....638........475................=..800.......................*764.710...574....*964....831..........473......531....\r\n...%..486...................*....#..................................831...........375........*........................=824......21..........\r\n559.........................441...316................................./....................618.407.......83.......972...............91......\r\n......*.....25..741...................%...............*63.546$..905......27........861.756........*.......*..........*...28...57............\r\n.......794....*./........782...236....47...........937...........*..755....*505..............23.948.......560.532...421....*..#.........405.\r\n............566.................*........-850..872.......90....229...+..........978..684............225..................675.....591...*....\r\n.............................296..243...........+....691...................311.........$......321......@......827....$13.......$....&..530..\r\n.....664..422$....613.....@.........%.401/.$974.....-.........%.145....729......*........./.......106............%.......=.....611..........\r\n.......$.........*.......857...147*.............591........+.46..*.....=........306.67*...818.............................261....../........\r\n............823...785..............340.........-....564..777......456.......%....................891.................560...........642..181.\r\n.....394.....*................226..........423..............................539.................*............640&.............535...........\r\n.......@.....626..317..329....*...92........+..................374....827............*.683+....771....529.........303..........*............\r\n.........172.....-........*......*.....332...........288..229..+.........*.786=....468.............*....*...........*....461...249..=.......\r\n....974...*............901..@....130..*..............$...*..........4.573................163......429....808.464*47..231....@......964......\r\n........183.................582........11...............310.....774.*.....567.............*....36...........................................\r\n.......................939.....................*826............@.....892..........481......266.*...-253.........106.830....235......*..841..\r\n727.........177#.........&.......507........301..........................550..242*.....+./.....686.......@.446.*.....*.......*....894..*....\r\n....67...............468.....&......&..596......................817.600...............85.5.............973...$.805...513......378.......388.\r\n...........*247.........*.....974.........*263....329....476....*............721............723.....................................358.....\r\n........784.....434.....667.......................*............615.195.612...............................540#........347...........*........\r\n...............*.................76......121...659........@555..........-.............201......................866............628.505.509...\r\n.............515........../.................#....................281..%...656............*670.419.......799.......*...510.786...*.......&...\r\n....993.................540.373....709.............705............*...132..#........298$......*...232....*..@..878.......*....528...#.......\r\n....$.........615.............*..........948..........*........565................%..........465..#.....497.67....................631.......\r\n.........138....#....417......123...........*.......546...821...................114..=............................258.859=.380-.............\r\n.....734*.............../.............833..399..........................+............780...288..............117..@...................925....\r\n................*860..........228........*...............................956....390*........=..........%...*..........839...373......*......\r\n..802........369........641.............763.....154.24...............302............620..............150.403.......*.........*....647.......\r\n...................................&........466*.....@..................*827....530.............................129.628.....923.........=866\r\n..........&......&.............824.573.................669.........................$.....374..627...........698.....................759.....\r\n.......499....%.812.857*653...................668..........879.......974................../......*926...852.........................-....832\r\n...646......284..............708...369...........*808................-.......705.......@...............%.............492.462............*...\r\n....................959......#.......*....872..........................102....*.........80..839....996..............*.....%........83...49..\r\n.785............363..*.............49.......*.......667.....797....224.......586..............&....*...34..673.......650....................\r\n....*..*132....*.....225...................631..350..*.........*....*.............941....=.......52....*.................406...546..........\r\n.543............760.........305..325...330.......+.................621...........*.......63..#.......268..239...................#...........\r\n........658..................*............*...........735......820.....145....419...........91..489.........*......404.......*....#.........\r\n..........=....415+.....38$....844...+..366.............*.......*......*..............................43....945.....#.....563.205..211..183.\r\n......267.......................*...519.....730........836..........277...........808...........504...&................................#....\r\n.....*..................705/....575..........*....../..........$866.........=.......*...975......#.......183.931........%.......611.........\r\n.......135.......284........................246.653.972..............365..191.....376...*.....&.........*......*.........994...@.....11.....\r\n...440../.........*.............................*..............415.....................985..838......677.......109...................*......\r\n...@............224....399.727$......68#..........................$......432.....214$.....................#.................591....686......\r\n..........&.......................................658........143....779.+....942......$.............885....567..........$...................\r\n.461.......33....277.407......108..............47.*.............*...........*.......$.811............................390....................\r\n..........................907*.....#397..307...*....197.12.....3...738....254.85..393...............713..700..741...........176.....883.....\r\n..316........180...........................*.758...................-...........................................*............*...............\r\n....*..../........871...338..165.........683............455...701*......................540....255.......$....858........277....28....+.....\r\n...660.469..912...#..........%......743.........439.....-.........206......363..........*.......*.......640............................144..\r\n..............*.........443...............610.............803.............*.............879...658............$................189...........\r\n...........172......794........98..............646......................662..............................*....49.-210.523.257....*..........\r\n...87..662.....#.......*667....%..408..........*............220...524............=.....742..39..160....64.636..........*..*....974..378.....\r\n...*.....*.....42..&.............=....371*.....804.................*..#....../.240.....*........................395%..461..818.....*........\r\n....706.398........452....500.............406..........57*380....365.42...635.......131...........18.....538.....................403........\r\n..............143........*.........80............740..........................*245......784........-...........708...................&.297..\r\n.230...........*.......373..341...........................$438.......*.................=.............874&..959*...........192......829.#....\r\n...#..........476..647.....*......................................431.728..........................................50.....$.................\r\n........334...........*731.930......=........966........*323...................301.....%....404...............879....*372.....208.134.......\r\n...........*.....................163..........*......509......................%.....&..785.......................*...............*..........\r\n...768..329....199........................................797......*368..........873..........26.565....651.....664......111..........217...\r\n................*.....26.......705*76....415.............*................................749..........*..................#......545-..%....\r\n....-....473..517......*...............5*....449..........68........................751.......*399......401.................................\r\n.730......#.........240...&..65.718.87......*.....532..............-....567............*....................675.......67..463...............\r\n.....289#....509........200......*...*....852....................885...+....663..72..507......998.&954..213....$.....*.........672..........\r\n..............................403.....129........377-....................../....&.................................473...........*...........\r\n.........855=.........250...................961........860*916.......981..........326.........633..404................676.%566..120.........\r\n892...........532.............754.......866*....790..................#........819*..............*.........%.44..=......*............29......\r\n....@527.......*..................600............../...$568.....800.....................179..528........613.....358...949...................\r\n................302...807............*..895.................+.....@.....-...........................980...........................736.......\r\n........217...=......*............879.....+.-..........%.....793.......442.......422............209*.......&.......969....240.378...*.......\r\n....340*.....145...%.596....................23....703...217................372..........610.................129.......*........../.....=....\r\n.................790.....&............904............=............795......*.......385=...+.....88*143...............891....406.......79....\r\n............*749.........31..............*....318.................+.......317.................................%419.............*392.........\r\n....854..797......*..500...............614.1...*..............803.....451............330.159.143.598.......+......./827...............717...\r\n...@............924.*........................245............-.&..........*...606................*...........461............604....#....*....\r\n....................73....160..406.150...............933.957...................%.......419.........665..*.........-.......*.....721..573....\r\n....*915.........40................*...%.............*........584.......929......377....*..404.935....&..870.....93........395..............\r\n.781.............@...........632.......710....769.323............$.........*.........904.....*...*.....................859..................\r\n.....=.......................*...646............-.........................52................149...414....................*........%.........\r\n...51....524.625..........328...*.................................295.734......@..........................856.291.695....367..218..787..8...\r\n.........../.*................339........................576/.417*...........445...@........................%....................-..........\r\n....869.85...316.....308...............345.......749.............................264.............775..777...............................89..\r\n.......*...............#.........$....*..........*....../.....786.713*52.................357.......&./.........#......971....74.305....-....\r\n............................325..770..167..@.....265..+..883................................+...57..........312.......*........*............\r\n......+.....266.....788.111....*..........342........588.......939..393*717.............488....*....................401....249...255........\r\n.......308..*............#.....816....465..........*.....492..@.............581.........-.......397..709*.................$.....*...........\r\n.............511.....881...+.........+..........178..524*..............150..../..720.......843...........964....129.../......908............\r\n.......749.............*.526.$............800............................*.........*...500....*.../.................487..........200........\r\n..668......*639......932......139.726................#...51..436$..................775...*...834..874.......%..............859+......439....\r\n........810........................*.......805.......100..*...........999.....743......169............477...961......973............$.......\r\n.574...........6*262........398....204......*.....%.......525...........*.........................412..*.........376...*.@43....=......=....\r\n....*836....................................25...619............658.....172.......................*...408...........*........%...776..802...\r\n.............307.......&........537..988..............128..-.....*..........................118...327......296.......967..991...............\r\n.....899...$...*....788.....829......=....................559.722.......519.........385$...+..................*.323*..............*123......\r\n........*.930...674...........*..........447.......801..............957....................................111......767..34....556..........\r\n..565.644..............18.....472.........*...8........................*........258........901.................296.......*..........*.......\r\n....*............995=....*................649.*...151.........437%...445.747......-.........&......#......%.....*.........800....357.240....\r\n....476.491/.931.......121..732*940..682......975..$.....*..................+.358.............../.363....152.264........$...................\r\n.............=....730*..................*584...........234.........996.................*.....701........................499............649..\r\n......................672......@.............................958.....&.+...........983.673........233.@981........760.......................\r\n..942.993@......293...........939..&....@.........867..92.....*........679.........................*.............*.......27...998...........\r\n....#.......230.$...................36.24....809..#....*...660.....$.......748..199.-.............717...@......................../..........\r\n......*95..............647...$..............-.........461..........757...........*...68...............728..210*680..708......$.....246......\r\n...355.........*..........*.538...%..............................-...............977....209*.......................*.........141.....*......\r\n...............680.....670.........784........171..799.........317..........................844........166........289.................463...\r\n";
    }
}