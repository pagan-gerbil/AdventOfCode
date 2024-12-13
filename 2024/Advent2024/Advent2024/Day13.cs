﻿using AdventUtils;
using AdventUtils.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2024;

internal class Day13 : DayBase
{
    protected override string _sample1 => "Button A: X+94, Y+34\r\nButton B: X+22, Y+67\r\nPrize: X=8400, Y=5400\r\n\r\nButton A: X+26, Y+66\r\nButton B: X+67, Y+21\r\nPrize: X=12748, Y=12176\r\n\r\nButton A: X+17, Y+86\r\nButton B: X+84, Y+37\r\nPrize: X=7870, Y=6450\r\n\r\nButton A: X+69, Y+23\r\nButton B: X+27, Y+71\r\nPrize: X=18641, Y=10279";

    protected override string _part1 => "Button A: X+31, Y+85\r\nButton B: X+30, Y+24\r\nPrize: X=3096, Y=8256\r\n\r\nButton A: X+59, Y+62\r\nButton B: X+11, Y+57\r\nPrize: X=4193, Y=6860\r\n\r\nButton A: X+39, Y+12\r\nButton B: X+26, Y+72\r\nPrize: X=19360, Y=8576\r\n\r\nButton A: X+34, Y+60\r\nButton B: X+32, Y+14\r\nPrize: X=512, Y=13392\r\n\r\nButton A: X+28, Y+12\r\nButton B: X+33, Y+71\r\nPrize: X=2039, Y=4001\r\n\r\nButton A: X+26, Y+54\r\nButton B: X+66, Y+32\r\nPrize: X=6556, Y=12006\r\n\r\nButton A: X+68, Y+36\r\nButton B: X+22, Y+46\r\nPrize: X=6894, Y=8086\r\n\r\nButton A: X+37, Y+62\r\nButton B: X+35, Y+19\r\nPrize: X=18851, Y=2351\r\n\r\nButton A: X+11, Y+72\r\nButton B: X+80, Y+54\r\nPrize: X=1178, Y=5832\r\n\r\nButton A: X+14, Y+45\r\nButton B: X+67, Y+15\r\nPrize: X=11622, Y=6170\r\n\r\nButton A: X+72, Y+88\r\nButton B: X+73, Y+22\r\nPrize: X=10610, Y=6380\r\n\r\nButton A: X+21, Y+86\r\nButton B: X+79, Y+15\r\nPrize: X=4955, Y=2089\r\n\r\nButton A: X+53, Y+12\r\nButton B: X+37, Y+70\r\nPrize: X=17268, Y=2956\r\n\r\nButton A: X+44, Y+93\r\nButton B: X+74, Y+27\r\nPrize: X=7244, Y=7029\r\n\r\nButton A: X+16, Y+65\r\nButton B: X+98, Y+63\r\nPrize: X=6230, Y=8218\r\n\r\nButton A: X+28, Y+57\r\nButton B: X+59, Y+29\r\nPrize: X=2501, Y=14956\r\n\r\nButton A: X+56, Y+22\r\nButton B: X+59, Y+99\r\nPrize: X=7907, Y=10461\r\n\r\nButton A: X+93, Y+29\r\nButton B: X+24, Y+44\r\nPrize: X=9333, Y=5649\r\n\r\nButton A: X+50, Y+77\r\nButton B: X+47, Y+19\r\nPrize: X=18445, Y=2610\r\n\r\nButton A: X+83, Y+23\r\nButton B: X+26, Y+59\r\nPrize: X=4068, Y=1956\r\n\r\nButton A: X+41, Y+80\r\nButton B: X+59, Y+32\r\nPrize: X=5288, Y=4832\r\n\r\nButton A: X+12, Y+21\r\nButton B: X+47, Y+22\r\nPrize: X=7045, Y=7860\r\n\r\nButton A: X+74, Y+83\r\nButton B: X+17, Y+85\r\nPrize: X=2423, Y=4366\r\n\r\nButton A: X+85, Y+42\r\nButton B: X+45, Y+95\r\nPrize: X=8310, Y=10946\r\n\r\nButton A: X+16, Y+34\r\nButton B: X+53, Y+36\r\nPrize: X=1753, Y=9464\r\n\r\nButton A: X+70, Y+19\r\nButton B: X+18, Y+58\r\nPrize: X=16504, Y=18135\r\n\r\nButton A: X+73, Y+20\r\nButton B: X+68, Y+84\r\nPrize: X=4742, Y=5156\r\n\r\nButton A: X+67, Y+15\r\nButton B: X+74, Y+77\r\nPrize: X=7922, Y=7696\r\n\r\nButton A: X+76, Y+41\r\nButton B: X+18, Y+50\r\nPrize: X=15882, Y=5599\r\n\r\nButton A: X+63, Y+29\r\nButton B: X+18, Y+42\r\nPrize: X=11195, Y=10957\r\n\r\nButton A: X+19, Y+55\r\nButton B: X+55, Y+26\r\nPrize: X=4334, Y=4142\r\n\r\nButton A: X+55, Y+21\r\nButton B: X+31, Y+68\r\nPrize: X=3889, Y=526\r\n\r\nButton A: X+15, Y+31\r\nButton B: X+58, Y+35\r\nPrize: X=3296, Y=4956\r\n\r\nButton A: X+46, Y+30\r\nButton B: X+20, Y+44\r\nPrize: X=12904, Y=15480\r\n\r\nButton A: X+14, Y+31\r\nButton B: X+64, Y+34\r\nPrize: X=5750, Y=14425\r\n\r\nButton A: X+61, Y+69\r\nButton B: X+99, Y+32\r\nPrize: X=9981, Y=6331\r\n\r\nButton A: X+26, Y+49\r\nButton B: X+35, Y+21\r\nPrize: X=16844, Y=11512\r\n\r\nButton A: X+13, Y+47\r\nButton B: X+89, Y+66\r\nPrize: X=7439, Y=5666\r\n\r\nButton A: X+25, Y+13\r\nButton B: X+35, Y+55\r\nPrize: X=8920, Y=896\r\n\r\nButton A: X+34, Y+13\r\nButton B: X+17, Y+30\r\nPrize: X=9645, Y=6071\r\n\r\nButton A: X+55, Y+18\r\nButton B: X+13, Y+45\r\nPrize: X=15692, Y=611\r\n\r\nButton A: X+15, Y+47\r\nButton B: X+64, Y+17\r\nPrize: X=14398, Y=19293\r\n\r\nButton A: X+27, Y+86\r\nButton B: X+83, Y+61\r\nPrize: X=6769, Y=5901\r\n\r\nButton A: X+14, Y+73\r\nButton B: X+58, Y+11\r\nPrize: X=2464, Y=3888\r\n\r\nButton A: X+24, Y+91\r\nButton B: X+64, Y+16\r\nPrize: X=4488, Y=5457\r\n\r\nButton A: X+22, Y+42\r\nButton B: X+62, Y+38\r\nPrize: X=5982, Y=8262\r\n\r\nButton A: X+26, Y+83\r\nButton B: X+98, Y+25\r\nPrize: X=2838, Y=3015\r\n\r\nButton A: X+23, Y+11\r\nButton B: X+12, Y+23\r\nPrize: X=16176, Y=247\r\n\r\nButton A: X+16, Y+81\r\nButton B: X+68, Y+13\r\nPrize: X=2320, Y=3120\r\n\r\nButton A: X+56, Y+22\r\nButton B: X+39, Y+72\r\nPrize: X=9611, Y=10688\r\n\r\nButton A: X+15, Y+49\r\nButton B: X+70, Y+14\r\nPrize: X=12990, Y=16846\r\n\r\nButton A: X+20, Y+42\r\nButton B: X+69, Y+43\r\nPrize: X=17421, Y=11009\r\n\r\nButton A: X+44, Y+17\r\nButton B: X+36, Y+67\r\nPrize: X=6204, Y=9733\r\n\r\nButton A: X+69, Y+58\r\nButton B: X+19, Y+56\r\nPrize: X=7605, Y=8314\r\n\r\nButton A: X+42, Y+26\r\nButton B: X+13, Y+43\r\nPrize: X=14897, Y=19635\r\n\r\nButton A: X+95, Y+12\r\nButton B: X+49, Y+39\r\nPrize: X=5462, Y=2757\r\n\r\nButton A: X+91, Y+47\r\nButton B: X+11, Y+69\r\nPrize: X=5799, Y=9137\r\n\r\nButton A: X+32, Y+63\r\nButton B: X+40, Y+16\r\nPrize: X=4488, Y=3753\r\n\r\nButton A: X+24, Y+26\r\nButton B: X+67, Y+13\r\nPrize: X=4057, Y=1833\r\n\r\nButton A: X+56, Y+28\r\nButton B: X+41, Y+72\r\nPrize: X=2960, Y=4776\r\n\r\nButton A: X+17, Y+37\r\nButton B: X+22, Y+14\r\nPrize: X=2352, Y=3696\r\n\r\nButton A: X+61, Y+15\r\nButton B: X+25, Y+39\r\nPrize: X=4483, Y=2745\r\n\r\nButton A: X+31, Y+89\r\nButton B: X+92, Y+74\r\nPrize: X=4558, Y=7382\r\n\r\nButton A: X+92, Y+90\r\nButton B: X+88, Y+16\r\nPrize: X=12928, Y=8652\r\n\r\nButton A: X+23, Y+54\r\nButton B: X+75, Y+44\r\nPrize: X=13273, Y=2702\r\n\r\nButton A: X+92, Y+35\r\nButton B: X+69, Y+87\r\nPrize: X=6486, Y=4776\r\n\r\nButton A: X+11, Y+42\r\nButton B: X+57, Y+22\r\nPrize: X=10231, Y=15522\r\n\r\nButton A: X+32, Y+77\r\nButton B: X+39, Y+13\r\nPrize: X=1008, Y=19784\r\n\r\nButton A: X+58, Y+33\r\nButton B: X+23, Y+85\r\nPrize: X=4499, Y=7378\r\n\r\nButton A: X+52, Y+94\r\nButton B: X+44, Y+23\r\nPrize: X=3920, Y=6860\r\n\r\nButton A: X+55, Y+53\r\nButton B: X+16, Y+81\r\nPrize: X=5253, Y=11489\r\n\r\nButton A: X+93, Y+17\r\nButton B: X+13, Y+20\r\nPrize: X=9229, Y=1969\r\n\r\nButton A: X+14, Y+72\r\nButton B: X+93, Y+49\r\nPrize: X=3526, Y=3538\r\n\r\nButton A: X+31, Y+75\r\nButton B: X+58, Y+16\r\nPrize: X=9764, Y=4452\r\n\r\nButton A: X+59, Y+11\r\nButton B: X+15, Y+59\r\nPrize: X=18486, Y=2694\r\n\r\nButton A: X+55, Y+23\r\nButton B: X+14, Y+43\r\nPrize: X=9234, Y=19372\r\n\r\nButton A: X+58, Y+15\r\nButton B: X+13, Y+50\r\nPrize: X=7834, Y=15825\r\n\r\nButton A: X+18, Y+52\r\nButton B: X+76, Y+37\r\nPrize: X=19406, Y=19423\r\n\r\nButton A: X+80, Y+31\r\nButton B: X+35, Y+56\r\nPrize: X=3185, Y=4417\r\n\r\nButton A: X+37, Y+71\r\nButton B: X+49, Y+12\r\nPrize: X=7053, Y=10444\r\n\r\nButton A: X+24, Y+51\r\nButton B: X+50, Y+30\r\nPrize: X=3854, Y=16391\r\n\r\nButton A: X+47, Y+15\r\nButton B: X+11, Y+99\r\nPrize: X=1783, Y=5439\r\n\r\nButton A: X+50, Y+13\r\nButton B: X+39, Y+61\r\nPrize: X=4118, Y=4224\r\n\r\nButton A: X+37, Y+21\r\nButton B: X+21, Y+54\r\nPrize: X=4810, Y=7871\r\n\r\nButton A: X+32, Y+78\r\nButton B: X+95, Y+48\r\nPrize: X=5756, Y=7422\r\n\r\nButton A: X+62, Y+68\r\nButton B: X+18, Y+99\r\nPrize: X=3684, Y=6339\r\n\r\nButton A: X+48, Y+18\r\nButton B: X+30, Y+72\r\nPrize: X=7766, Y=11222\r\n\r\nButton A: X+14, Y+30\r\nButton B: X+74, Y+47\r\nPrize: X=8212, Y=1767\r\n\r\nButton A: X+12, Y+30\r\nButton B: X+73, Y+39\r\nPrize: X=2459, Y=2847\r\n\r\nButton A: X+42, Y+46\r\nButton B: X+88, Y+25\r\nPrize: X=10008, Y=4751\r\n\r\nButton A: X+16, Y+99\r\nButton B: X+97, Y+88\r\nPrize: X=10202, Y=17028\r\n\r\nButton A: X+29, Y+75\r\nButton B: X+91, Y+30\r\nPrize: X=7720, Y=4770\r\n\r\nButton A: X+42, Y+53\r\nButton B: X+87, Y+19\r\nPrize: X=9531, Y=3221\r\n\r\nButton A: X+18, Y+55\r\nButton B: X+70, Y+35\r\nPrize: X=10724, Y=18660\r\n\r\nButton A: X+25, Y+71\r\nButton B: X+47, Y+37\r\nPrize: X=2412, Y=2412\r\n\r\nButton A: X+16, Y+28\r\nButton B: X+54, Y+24\r\nPrize: X=8254, Y=12076\r\n\r\nButton A: X+72, Y+21\r\nButton B: X+16, Y+60\r\nPrize: X=2808, Y=3875\r\n\r\nButton A: X+30, Y+70\r\nButton B: X+53, Y+20\r\nPrize: X=12179, Y=11940\r\n\r\nButton A: X+97, Y+47\r\nButton B: X+20, Y+49\r\nPrize: X=7442, Y=5650\r\n\r\nButton A: X+26, Y+81\r\nButton B: X+66, Y+42\r\nPrize: X=5260, Y=8697\r\n\r\nButton A: X+20, Y+57\r\nButton B: X+74, Y+23\r\nPrize: X=1916, Y=4709\r\n\r\nButton A: X+29, Y+62\r\nButton B: X+52, Y+13\r\nPrize: X=9832, Y=6736\r\n\r\nButton A: X+56, Y+40\r\nButton B: X+28, Y+98\r\nPrize: X=4900, Y=11222\r\n\r\nButton A: X+18, Y+70\r\nButton B: X+91, Y+59\r\nPrize: X=8890, Y=8622\r\n\r\nButton A: X+39, Y+63\r\nButton B: X+31, Y+16\r\nPrize: X=4286, Y=13712\r\n\r\nButton A: X+53, Y+60\r\nButton B: X+94, Y+13\r\nPrize: X=9291, Y=2391\r\n\r\nButton A: X+75, Y+77\r\nButton B: X+18, Y+81\r\nPrize: X=5658, Y=7747\r\n\r\nButton A: X+70, Y+35\r\nButton B: X+64, Y+98\r\nPrize: X=2294, Y=2863\r\n\r\nButton A: X+88, Y+16\r\nButton B: X+22, Y+45\r\nPrize: X=4884, Y=1298\r\n\r\nButton A: X+78, Y+27\r\nButton B: X+13, Y+65\r\nPrize: X=16396, Y=17208\r\n\r\nButton A: X+35, Y+15\r\nButton B: X+43, Y+67\r\nPrize: X=6514, Y=12966\r\n\r\nButton A: X+12, Y+50\r\nButton B: X+34, Y+14\r\nPrize: X=11440, Y=4888\r\n\r\nButton A: X+56, Y+28\r\nButton B: X+21, Y+65\r\nPrize: X=6013, Y=5241\r\n\r\nButton A: X+48, Y+16\r\nButton B: X+37, Y+63\r\nPrize: X=6942, Y=7866\r\n\r\nButton A: X+59, Y+15\r\nButton B: X+14, Y+31\r\nPrize: X=9266, Y=7349\r\n\r\nButton A: X+44, Y+64\r\nButton B: X+48, Y+15\r\nPrize: X=4360, Y=3272\r\n\r\nButton A: X+31, Y+96\r\nButton B: X+82, Y+40\r\nPrize: X=7611, Y=8808\r\n\r\nButton A: X+76, Y+28\r\nButton B: X+14, Y+54\r\nPrize: X=17116, Y=5740\r\n\r\nButton A: X+42, Y+23\r\nButton B: X+15, Y+45\r\nPrize: X=5741, Y=6774\r\n\r\nButton A: X+54, Y+90\r\nButton B: X+81, Y+38\r\nPrize: X=8910, Y=6314\r\n\r\nButton A: X+11, Y+65\r\nButton B: X+60, Y+11\r\nPrize: X=17751, Y=18609\r\n\r\nButton A: X+35, Y+11\r\nButton B: X+38, Y+73\r\nPrize: X=9697, Y=14514\r\n\r\nButton A: X+29, Y+89\r\nButton B: X+86, Y+59\r\nPrize: X=2972, Y=6047\r\n\r\nButton A: X+28, Y+75\r\nButton B: X+63, Y+14\r\nPrize: X=16622, Y=14291\r\n\r\nButton A: X+12, Y+51\r\nButton B: X+78, Y+31\r\nPrize: X=14348, Y=11996\r\n\r\nButton A: X+58, Y+25\r\nButton B: X+21, Y+60\r\nPrize: X=4510, Y=6835\r\n\r\nButton A: X+58, Y+13\r\nButton B: X+15, Y+56\r\nPrize: X=18050, Y=6227\r\n\r\nButton A: X+73, Y+13\r\nButton B: X+18, Y+64\r\nPrize: X=15496, Y=12872\r\n\r\nButton A: X+92, Y+12\r\nButton B: X+62, Y+57\r\nPrize: X=11486, Y=4971\r\n\r\nButton A: X+28, Y+73\r\nButton B: X+83, Y+62\r\nPrize: X=4125, Y=3498\r\n\r\nButton A: X+25, Y+61\r\nButton B: X+80, Y+59\r\nPrize: X=4300, Y=3682\r\n\r\nButton A: X+13, Y+89\r\nButton B: X+85, Y+63\r\nPrize: X=6446, Y=5730\r\n\r\nButton A: X+70, Y+31\r\nButton B: X+36, Y+57\r\nPrize: X=4956, Y=4494\r\n\r\nButton A: X+57, Y+18\r\nButton B: X+38, Y+75\r\nPrize: X=16707, Y=7106\r\n\r\nButton A: X+46, Y+12\r\nButton B: X+22, Y+64\r\nPrize: X=2646, Y=9092\r\n\r\nButton A: X+39, Y+19\r\nButton B: X+15, Y+46\r\nPrize: X=5456, Y=9580\r\n\r\nButton A: X+18, Y+92\r\nButton B: X+20, Y+12\r\nPrize: X=2682, Y=5588\r\n\r\nButton A: X+83, Y+87\r\nButton B: X+87, Y+22\r\nPrize: X=8592, Y=3955\r\n\r\nButton A: X+22, Y+44\r\nButton B: X+44, Y+23\r\nPrize: X=13938, Y=13586\r\n\r\nButton A: X+88, Y+85\r\nButton B: X+11, Y+97\r\nPrize: X=8437, Y=12209\r\n\r\nButton A: X+21, Y+45\r\nButton B: X+58, Y+25\r\nPrize: X=2918, Y=4565\r\n\r\nButton A: X+52, Y+32\r\nButton B: X+20, Y+49\r\nPrize: X=15176, Y=1670\r\n\r\nButton A: X+95, Y+59\r\nButton B: X+44, Y+95\r\nPrize: X=2309, Y=4547\r\n\r\nButton A: X+15, Y+45\r\nButton B: X+67, Y+34\r\nPrize: X=12188, Y=15341\r\n\r\nButton A: X+79, Y+23\r\nButton B: X+14, Y+61\r\nPrize: X=18404, Y=3995\r\n\r\nButton A: X+33, Y+13\r\nButton B: X+44, Y+73\r\nPrize: X=5787, Y=14728\r\n\r\nButton A: X+67, Y+31\r\nButton B: X+25, Y+57\r\nPrize: X=10265, Y=1785\r\n\r\nButton A: X+30, Y+11\r\nButton B: X+23, Y+59\r\nPrize: X=16691, Y=10624\r\n\r\nButton A: X+61, Y+30\r\nButton B: X+35, Y+65\r\nPrize: X=1705, Y=19620\r\n\r\nButton A: X+52, Y+12\r\nButton B: X+29, Y+80\r\nPrize: X=18572, Y=11200\r\n\r\nButton A: X+44, Y+12\r\nButton B: X+29, Y+77\r\nPrize: X=2974, Y=5182\r\n\r\nButton A: X+36, Y+62\r\nButton B: X+49, Y+21\r\nPrize: X=10460, Y=1406\r\n\r\nButton A: X+77, Y+43\r\nButton B: X+27, Y+84\r\nPrize: X=7799, Y=8146\r\n\r\nButton A: X+28, Y+48\r\nButton B: X+39, Y+18\r\nPrize: X=12722, Y=3212\r\n\r\nButton A: X+51, Y+21\r\nButton B: X+26, Y+55\r\nPrize: X=6510, Y=10255\r\n\r\nButton A: X+36, Y+11\r\nButton B: X+26, Y+59\r\nPrize: X=5402, Y=5684\r\n\r\nButton A: X+34, Y+79\r\nButton B: X+65, Y+22\r\nPrize: X=7764, Y=5395\r\n\r\nButton A: X+28, Y+52\r\nButton B: X+50, Y+17\r\nPrize: X=18074, Y=5915\r\n\r\nButton A: X+32, Y+11\r\nButton B: X+21, Y+40\r\nPrize: X=6955, Y=12543\r\n\r\nButton A: X+63, Y+28\r\nButton B: X+11, Y+46\r\nPrize: X=4208, Y=5118\r\n\r\nButton A: X+35, Y+62\r\nButton B: X+55, Y+27\r\nPrize: X=6030, Y=1585\r\n\r\nButton A: X+68, Y+31\r\nButton B: X+14, Y+43\r\nPrize: X=9228, Y=9991\r\n\r\nButton A: X+33, Y+93\r\nButton B: X+75, Y+35\r\nPrize: X=3273, Y=7813\r\n\r\nButton A: X+60, Y+32\r\nButton B: X+34, Y+61\r\nPrize: X=7250, Y=6479\r\n\r\nButton A: X+63, Y+20\r\nButton B: X+17, Y+34\r\nPrize: X=2996, Y=3554\r\n\r\nButton A: X+20, Y+43\r\nButton B: X+53, Y+36\r\nPrize: X=5590, Y=16608\r\n\r\nButton A: X+24, Y+56\r\nButton B: X+50, Y+21\r\nPrize: X=15338, Y=11169\r\n\r\nButton A: X+43, Y+11\r\nButton B: X+43, Y+79\r\nPrize: X=6928, Y=3880\r\n\r\nButton A: X+98, Y+26\r\nButton B: X+28, Y+30\r\nPrize: X=9478, Y=3756\r\n\r\nButton A: X+26, Y+30\r\nButton B: X+56, Y+15\r\nPrize: X=4470, Y=2925\r\n\r\nButton A: X+39, Y+60\r\nButton B: X+51, Y+25\r\nPrize: X=17102, Y=10135\r\n\r\nButton A: X+96, Y+38\r\nButton B: X+38, Y+50\r\nPrize: X=6820, Y=5706\r\n\r\nButton A: X+15, Y+45\r\nButton B: X+65, Y+20\r\nPrize: X=12825, Y=19350\r\n\r\nButton A: X+50, Y+14\r\nButton B: X+55, Y+81\r\nPrize: X=5905, Y=4343\r\n\r\nButton A: X+11, Y+75\r\nButton B: X+68, Y+16\r\nPrize: X=10709, Y=17713\r\n\r\nButton A: X+64, Y+12\r\nButton B: X+11, Y+58\r\nPrize: X=3722, Y=18036\r\n\r\nButton A: X+19, Y+87\r\nButton B: X+51, Y+13\r\nPrize: X=1912, Y=816\r\n\r\nButton A: X+76, Y+21\r\nButton B: X+38, Y+80\r\nPrize: X=4826, Y=6963\r\n\r\nButton A: X+13, Y+65\r\nButton B: X+78, Y+26\r\nPrize: X=1898, Y=5850\r\n\r\nButton A: X+78, Y+14\r\nButton B: X+22, Y+38\r\nPrize: X=3040, Y=784\r\n\r\nButton A: X+72, Y+36\r\nButton B: X+33, Y+80\r\nPrize: X=7893, Y=8328\r\n\r\nButton A: X+89, Y+19\r\nButton B: X+19, Y+39\r\nPrize: X=6117, Y=3717\r\n\r\nButton A: X+58, Y+20\r\nButton B: X+25, Y+71\r\nPrize: X=15562, Y=1008\r\n\r\nButton A: X+83, Y+56\r\nButton B: X+24, Y+50\r\nPrize: X=8392, Y=8130\r\n\r\nButton A: X+50, Y+47\r\nButton B: X+96, Y+12\r\nPrize: X=11662, Y=5329\r\n\r\nButton A: X+59, Y+32\r\nButton B: X+23, Y+44\r\nPrize: X=4088, Y=2564\r\n\r\nButton A: X+56, Y+51\r\nButton B: X+18, Y+66\r\nPrize: X=5410, Y=6564\r\n\r\nButton A: X+71, Y+82\r\nButton B: X+84, Y+12\r\nPrize: X=10998, Y=7176\r\n\r\nButton A: X+32, Y+13\r\nButton B: X+13, Y+19\r\nPrize: X=1284, Y=1235\r\n\r\nButton A: X+13, Y+60\r\nButton B: X+66, Y+16\r\nPrize: X=3424, Y=9816\r\n\r\nButton A: X+18, Y+34\r\nButton B: X+27, Y+12\r\nPrize: X=3024, Y=3840\r\n\r\nButton A: X+71, Y+12\r\nButton B: X+12, Y+45\r\nPrize: X=6270, Y=3681\r\n\r\nButton A: X+62, Y+87\r\nButton B: X+82, Y+17\r\nPrize: X=3450, Y=1605\r\n\r\nButton A: X+36, Y+94\r\nButton B: X+99, Y+16\r\nPrize: X=7668, Y=2562\r\n\r\nButton A: X+92, Y+62\r\nButton B: X+19, Y+56\r\nPrize: X=6111, Y=6926\r\n\r\nButton A: X+22, Y+69\r\nButton B: X+74, Y+25\r\nPrize: X=11560, Y=15128\r\n\r\nButton A: X+51, Y+31\r\nButton B: X+11, Y+29\r\nPrize: X=8486, Y=13262\r\n\r\nButton A: X+50, Y+19\r\nButton B: X+16, Y+30\r\nPrize: X=18834, Y=9771\r\n\r\nButton A: X+66, Y+15\r\nButton B: X+53, Y+99\r\nPrize: X=2105, Y=3174\r\n\r\nButton A: X+33, Y+11\r\nButton B: X+21, Y+50\r\nPrize: X=18119, Y=3119\r\n\r\nButton A: X+60, Y+17\r\nButton B: X+12, Y+45\r\nPrize: X=2292, Y=1731\r\n\r\nButton A: X+44, Y+42\r\nButton B: X+92, Y+19\r\nPrize: X=12016, Y=5345\r\n\r\nButton A: X+57, Y+27\r\nButton B: X+11, Y+41\r\nPrize: X=3153, Y=3483\r\n\r\nButton A: X+19, Y+62\r\nButton B: X+92, Y+28\r\nPrize: X=7951, Y=6074\r\n\r\nButton A: X+25, Y+78\r\nButton B: X+53, Y+13\r\nPrize: X=9787, Y=13653\r\n\r\nButton A: X+28, Y+55\r\nButton B: X+58, Y+18\r\nPrize: X=742, Y=11404\r\n\r\nButton A: X+36, Y+46\r\nButton B: X+96, Y+34\r\nPrize: X=8964, Y=5868\r\n\r\nButton A: X+18, Y+40\r\nButton B: X+68, Y+48\r\nPrize: X=16366, Y=1272\r\n\r\nButton A: X+70, Y+92\r\nButton B: X+85, Y+19\r\nPrize: X=6130, Y=3050\r\n\r\nButton A: X+78, Y+40\r\nButton B: X+11, Y+76\r\nPrize: X=6375, Y=8124\r\n\r\nButton A: X+74, Y+21\r\nButton B: X+14, Y+53\r\nPrize: X=12394, Y=4011\r\n\r\nButton A: X+57, Y+29\r\nButton B: X+18, Y+51\r\nPrize: X=2372, Y=17349\r\n\r\nButton A: X+15, Y+64\r\nButton B: X+74, Y+17\r\nPrize: X=14831, Y=10060\r\n\r\nButton A: X+57, Y+96\r\nButton B: X+40, Y+13\r\nPrize: X=4537, Y=4651\r\n\r\nButton A: X+36, Y+81\r\nButton B: X+93, Y+40\r\nPrize: X=9309, Y=4528\r\n\r\nButton A: X+39, Y+65\r\nButton B: X+44, Y+17\r\nPrize: X=807, Y=7219\r\n\r\nButton A: X+15, Y+22\r\nButton B: X+51, Y+21\r\nPrize: X=1824, Y=1653\r\n\r\nButton A: X+41, Y+26\r\nButton B: X+28, Y+54\r\nPrize: X=7326, Y=3010\r\n\r\nButton A: X+26, Y+68\r\nButton B: X+51, Y+14\r\nPrize: X=6235, Y=12190\r\n\r\nButton A: X+24, Y+45\r\nButton B: X+59, Y+29\r\nPrize: X=9878, Y=16586\r\n\r\nButton A: X+73, Y+24\r\nButton B: X+22, Y+87\r\nPrize: X=7200, Y=9945\r\n\r\nButton A: X+59, Y+12\r\nButton B: X+17, Y+62\r\nPrize: X=13527, Y=11308\r\n\r\nButton A: X+74, Y+12\r\nButton B: X+18, Y+62\r\nPrize: X=13170, Y=15556\r\n\r\nButton A: X+76, Y+38\r\nButton B: X+29, Y+77\r\nPrize: X=2488, Y=3494\r\n\r\nButton A: X+25, Y+56\r\nButton B: X+76, Y+50\r\nPrize: X=6000, Y=4422\r\n\r\nButton A: X+74, Y+45\r\nButton B: X+22, Y+48\r\nPrize: X=6676, Y=13205\r\n\r\nButton A: X+24, Y+12\r\nButton B: X+17, Y+55\r\nPrize: X=3891, Y=12109\r\n\r\nButton A: X+13, Y+67\r\nButton B: X+79, Y+13\r\nPrize: X=2690, Y=4010\r\n\r\nButton A: X+15, Y+36\r\nButton B: X+34, Y+25\r\nPrize: X=18036, Y=9471\r\n\r\nButton A: X+40, Y+12\r\nButton B: X+56, Y+86\r\nPrize: X=18760, Y=4302\r\n\r\nButton A: X+11, Y+63\r\nButton B: X+73, Y+16\r\nPrize: X=17098, Y=11612\r\n\r\nButton A: X+65, Y+51\r\nButton B: X+11, Y+68\r\nPrize: X=4856, Y=4760\r\n\r\nButton A: X+60, Y+92\r\nButton B: X+98, Y+17\r\nPrize: X=11144, Y=5360\r\n\r\nButton A: X+17, Y+45\r\nButton B: X+52, Y+11\r\nPrize: X=19479, Y=7265\r\n\r\nButton A: X+43, Y+84\r\nButton B: X+61, Y+26\r\nPrize: X=5611, Y=3508\r\n\r\nButton A: X+60, Y+12\r\nButton B: X+14, Y+81\r\nPrize: X=12958, Y=14765\r\n\r\nButton A: X+25, Y+64\r\nButton B: X+38, Y+16\r\nPrize: X=1866, Y=2848\r\n\r\nButton A: X+46, Y+23\r\nButton B: X+25, Y+52\r\nPrize: X=5926, Y=12403\r\n\r\nButton A: X+95, Y+41\r\nButton B: X+17, Y+71\r\nPrize: X=7469, Y=5579\r\n\r\nButton A: X+89, Y+12\r\nButton B: X+65, Y+89\r\nPrize: X=3110, Y=3709\r\n\r\nButton A: X+46, Y+69\r\nButton B: X+43, Y+16\r\nPrize: X=2011, Y=1319\r\n\r\nButton A: X+84, Y+30\r\nButton B: X+40, Y+53\r\nPrize: X=8484, Y=4656\r\n\r\nButton A: X+11, Y+38\r\nButton B: X+27, Y+12\r\nPrize: X=7720, Y=16168\r\n\r\nButton A: X+54, Y+28\r\nButton B: X+32, Y+77\r\nPrize: X=4902, Y=7616\r\n\r\nButton A: X+28, Y+58\r\nButton B: X+55, Y+25\r\nPrize: X=15939, Y=5079\r\n\r\nButton A: X+17, Y+40\r\nButton B: X+37, Y+12\r\nPrize: X=19305, Y=14804\r\n\r\nButton A: X+11, Y+51\r\nButton B: X+32, Y+11\r\nPrize: X=16918, Y=9484\r\n\r\nButton A: X+12, Y+79\r\nButton B: X+71, Y+14\r\nPrize: X=1407, Y=5459\r\n\r\nButton A: X+58, Y+16\r\nButton B: X+28, Y+85\r\nPrize: X=3006, Y=8325\r\n\r\nButton A: X+32, Y+65\r\nButton B: X+93, Y+61\r\nPrize: X=9151, Y=8995\r\n\r\nButton A: X+65, Y+20\r\nButton B: X+15, Y+57\r\nPrize: X=5285, Y=1502\r\n\r\nButton A: X+11, Y+49\r\nButton B: X+71, Y+18\r\nPrize: X=5974, Y=7407\r\n\r\nButton A: X+42, Y+31\r\nButton B: X+11, Y+30\r\nPrize: X=15007, Y=353\r\n\r\nButton A: X+43, Y+12\r\nButton B: X+21, Y+33\r\nPrize: X=14784, Y=11570\r\n\r\nButton A: X+16, Y+43\r\nButton B: X+51, Y+11\r\nPrize: X=1247, Y=7498\r\n\r\nButton A: X+11, Y+41\r\nButton B: X+53, Y+34\r\nPrize: X=605, Y=8336\r\n\r\nButton A: X+68, Y+21\r\nButton B: X+35, Y+38\r\nPrize: X=7367, Y=3825\r\n\r\nButton A: X+40, Y+14\r\nButton B: X+37, Y+79\r\nPrize: X=4076, Y=3276\r\n\r\nButton A: X+36, Y+96\r\nButton B: X+67, Y+30\r\nPrize: X=8755, Y=10710\r\n\r\nButton A: X+42, Y+99\r\nButton B: X+66, Y+36\r\nPrize: X=6066, Y=6048\r\n\r\nButton A: X+30, Y+82\r\nButton B: X+63, Y+14\r\nPrize: X=428, Y=16660\r\n\r\nButton A: X+46, Y+80\r\nButton B: X+81, Y+25\r\nPrize: X=3686, Y=5020\r\n\r\nButton A: X+11, Y+19\r\nButton B: X+26, Y+11\r\nPrize: X=18842, Y=11157\r\n\r\nButton A: X+27, Y+54\r\nButton B: X+75, Y+41\r\nPrize: X=4368, Y=2741\r\n\r\nButton A: X+76, Y+43\r\nButton B: X+13, Y+32\r\nPrize: X=19094, Y=13020\r\n\r\nButton A: X+15, Y+35\r\nButton B: X+41, Y+12\r\nPrize: X=7257, Y=10139\r\n\r\nButton A: X+38, Y+61\r\nButton B: X+42, Y+11\r\nPrize: X=18860, Y=2346\r\n\r\nButton A: X+17, Y+36\r\nButton B: X+44, Y+15\r\nPrize: X=1985, Y=19601\r\n\r\nButton A: X+21, Y+31\r\nButton B: X+92, Y+16\r\nPrize: X=2127, Y=2421\r\n\r\nButton A: X+20, Y+55\r\nButton B: X+94, Y+25\r\nPrize: X=3960, Y=1550\r\n\r\nButton A: X+14, Y+52\r\nButton B: X+67, Y+23\r\nPrize: X=15899, Y=7175\r\n\r\nButton A: X+41, Y+68\r\nButton B: X+67, Y+13\r\nPrize: X=3721, Y=3424\r\n\r\nButton A: X+57, Y+19\r\nButton B: X+26, Y+64\r\nPrize: X=2836, Y=9752\r\n\r\nButton A: X+58, Y+17\r\nButton B: X+18, Y+72\r\nPrize: X=17924, Y=6536\r\n\r\nButton A: X+22, Y+79\r\nButton B: X+83, Y+19\r\nPrize: X=6208, Y=7782\r\n\r\nButton A: X+11, Y+55\r\nButton B: X+71, Y+23\r\nPrize: X=18429, Y=3449\r\n\r\nButton A: X+13, Y+76\r\nButton B: X+69, Y+82\r\nPrize: X=4805, Y=10736\r\n\r\nButton A: X+30, Y+44\r\nButton B: X+44, Y+21\r\nPrize: X=10066, Y=14602\r\n\r\nButton A: X+14, Y+36\r\nButton B: X+19, Y+13\r\nPrize: X=15186, Y=1550\r\n\r\nButton A: X+32, Y+56\r\nButton B: X+98, Y+20\r\nPrize: X=9530, Y=2588\r\n\r\nButton A: X+94, Y+43\r\nButton B: X+11, Y+98\r\nPrize: X=3537, Y=4500\r\n\r\nButton A: X+82, Y+17\r\nButton B: X+23, Y+60\r\nPrize: X=10372, Y=7563\r\n\r\nButton A: X+29, Y+95\r\nButton B: X+89, Y+55\r\nPrize: X=4491, Y=8325\r\n\r\nButton A: X+74, Y+50\r\nButton B: X+12, Y+31\r\nPrize: X=18242, Y=19036\r\n\r\nButton A: X+94, Y+96\r\nButton B: X+66, Y+18\r\nPrize: X=7298, Y=4242\r\n\r\nButton A: X+92, Y+61\r\nButton B: X+14, Y+71\r\nPrize: X=1382, Y=2953\r\n\r\nButton A: X+12, Y+35\r\nButton B: X+77, Y+35\r\nPrize: X=10507, Y=17735\r\n\r\nButton A: X+13, Y+48\r\nButton B: X+54, Y+17\r\nPrize: X=12088, Y=2129\r\n\r\nButton A: X+38, Y+19\r\nButton B: X+19, Y+64\r\nPrize: X=1900, Y=3784\r\n\r\nButton A: X+99, Y+12\r\nButton B: X+27, Y+24\r\nPrize: X=2871, Y=1032\r\n\r\nButton A: X+14, Y+30\r\nButton B: X+77, Y+52\r\nPrize: X=13213, Y=12702\r\n\r\nButton A: X+20, Y+46\r\nButton B: X+60, Y+36\r\nPrize: X=2540, Y=9734\r\n\r\nButton A: X+69, Y+27\r\nButton B: X+71, Y+89\r\nPrize: X=2467, Y=2557\r\n\r\nButton A: X+60, Y+15\r\nButton B: X+62, Y+83\r\nPrize: X=3362, Y=2933\r\n\r\nButton A: X+21, Y+62\r\nButton B: X+86, Y+33\r\nPrize: X=2246, Y=4422\r\n\r\nButton A: X+19, Y+72\r\nButton B: X+76, Y+15\r\nPrize: X=13363, Y=7820\r\n\r\nButton A: X+44, Y+73\r\nButton B: X+50, Y+20\r\nPrize: X=15466, Y=11257\r\n\r\nButton A: X+13, Y+72\r\nButton B: X+41, Y+13\r\nPrize: X=4132, Y=3618\r\n\r\nButton A: X+18, Y+48\r\nButton B: X+55, Y+27\r\nPrize: X=2806, Y=3414\r\n\r\nButton A: X+90, Y+22\r\nButton B: X+71, Y+86\r\nPrize: X=573, Y=346\r\n\r\nButton A: X+81, Y+71\r\nButton B: X+17, Y+59\r\nPrize: X=1598, Y=1974\r\n\r\nButton A: X+53, Y+30\r\nButton B: X+11, Y+48\r\nPrize: X=1661, Y=5034\r\n\r\nButton A: X+44, Y+21\r\nButton B: X+28, Y+64\r\nPrize: X=3288, Y=10147\r\n\r\nButton A: X+83, Y+23\r\nButton B: X+39, Y+43\r\nPrize: X=9245, Y=3753\r\n\r\nButton A: X+47, Y+13\r\nButton B: X+50, Y+67\r\nPrize: X=6439, Y=6779\r\n\r\nButton A: X+18, Y+83\r\nButton B: X+76, Y+58\r\nPrize: X=7258, Y=6855\r\n\r\nButton A: X+21, Y+80\r\nButton B: X+61, Y+27\r\nPrize: X=4236, Y=2582\r\n\r\nButton A: X+57, Y+26\r\nButton B: X+29, Y+65\r\nPrize: X=16648, Y=2720\r\n\r\nButton A: X+14, Y+40\r\nButton B: X+79, Y+47\r\nPrize: X=2127, Y=5683\r\n\r\nButton A: X+49, Y+12\r\nButton B: X+41, Y+76\r\nPrize: X=18691, Y=8548\r\n\r\nButton A: X+57, Y+22\r\nButton B: X+46, Y+83\r\nPrize: X=8941, Y=9584\r\n\r\nButton A: X+72, Y+23\r\nButton B: X+13, Y+38\r\nPrize: X=12327, Y=10708\r\n\r\nButton A: X+89, Y+21\r\nButton B: X+28, Y+75\r\nPrize: X=7466, Y=2172\r\n\r\nButton A: X+52, Y+23\r\nButton B: X+25, Y+42\r\nPrize: X=8514, Y=8187\r\n\r\nButton A: X+88, Y+61\r\nButton B: X+18, Y+98\r\nPrize: X=5110, Y=4825\r\n\r\nButton A: X+46, Y+14\r\nButton B: X+34, Y+72\r\nPrize: X=2146, Y=17272\r\n\r\nButton A: X+51, Y+24\r\nButton B: X+47, Y+73\r\nPrize: X=5035, Y=18165\r\n\r\nButton A: X+80, Y+31\r\nButton B: X+17, Y+27\r\nPrize: X=3266, Y=3266\r\n\r\nButton A: X+51, Y+15\r\nButton B: X+18, Y+75\r\nPrize: X=1217, Y=14870\r\n\r\nButton A: X+35, Y+17\r\nButton B: X+24, Y+57\r\nPrize: X=6471, Y=11508";

    protected override string Part1Internal(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var machines = new List<ClawMachine>();

        var i = 0;
        Coord a = null;
        Coord b = null;
        Coord target = null;
        while (i < lines.Length)
        {
            if (lines[i].StartsWith("Button A"))
            {
                var l = lines[i];
                a = new Coord(int.Parse(l.Substring(l.IndexOf('+'), l.IndexOf(',') - l.IndexOf('+'))), int.Parse(l.Substring(l.LastIndexOf('+'))));
            }
            if (lines[i].StartsWith("Button B"))
            {
                var l = lines[i];
                b = new Coord(int.Parse(l.Substring(l.IndexOf('+'), l.IndexOf(',') - l.IndexOf('+'))), int.Parse(l.Substring(l.LastIndexOf('+'))));
            }
            if (lines[i].StartsWith("Prize"))
            {
                var l = lines[i];
                target = new Coord(int.Parse(l.Substring(l.IndexOf('=') + 1, l.IndexOf(',') - l.IndexOf('=') - 1)), int.Parse(l.Substring(l.LastIndexOf('=') + 1)));
                machines.Add(new ClawMachine(a, b, target));
            }

            i++;
        }

        var counter = 0L;

        foreach (var machine in machines)
        {
            var point = new Coord(0, 0);
            var cost = 0;
            var n = 0;
            var answers = new List<int>();
            while (point.X < machine.Target.X && point.Y < machine.Target.Y)
            {
                point = new Coord(point.X + machine.A.X, point.Y + machine.A.Y);
                cost += 3;
                n++;
            }

            if (point.X == machine.Target.X && point.Y == machine.Target.Y)
            {
                answers.Add(cost);
            }

            while (n > 0)
            {
                point = new Coord(point.X - machine.A.X, point.Y - machine.A.Y);
                cost -= 3;
                n--;

                while (point.X < machine.Target.X && point.Y < machine.Target.Y)
                {
                    point = new Coord(point.X + machine.B.X, point.Y + machine.B.Y);
                    cost += 1;
                }

                if (point.X == machine.Target.X && point.Y == machine.Target.Y)
                {
                    answers.Add(cost);
                }
            }

            if (answers.Any())
            {
                counter += answers.Min();
            }
        }

        return counter.ToString();
    }

    private record struct ClawMachine(Coord A, Coord B, Coord Target);
}
