﻿using AdventUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024;

internal class Day07 : DayBase
{
    protected override string _sample1 => "190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20";

    protected override string _part1 => "25056746772: 4 47 136 21 79 49\r\n3790126111: 371 8 10 125 325 788\r\n37542888: 3 977 944 5\r\n785818128: 1 8 5 9 4 73 5 7 860 7\r\n19035366: 37 41 1 42 555 9 366\r\n1387: 33 502 69 775 5\r\n59640870978: 1 68 355 870 9 78\r\n10960521957: 7 369 8 6 4 1 5 23 53 5 9\r\n176844307608: 5 8 8 806 7 875 5 9 63 1\r\n3379786560: 3 2 349 1 6 4 7 5 4 16 9\r\n461716: 17 456 18 939 667\r\n7619: 2 5 9 671 6\r\n256034: 7 95 251 2 1 8\r\n106298: 21 156 11 5 6\r\n12374947048: 4 7 9 64 9 1 2 2 129 3 8 1\r\n16488497354846: 50 117 47 615 7 121 7\r\n15786760: 2 62 7 4 6 760\r\n25180862688: 874 335 5 8 7 1 36\r\n13552740: 1 1 51 9 535 595 1 6 4 9\r\n49121708165: 338 3 2 3 7 374 4 4 24 7\r\n138095646: 2 9 170 48 76\r\n564899635: 56 4 89 695 4 6 258 5\r\n69595110: 748 304 43 2 153\r\n55219024127: 492 1 28 745 5 6 8 2 5 5\r\n46695428: 9 2 5 8 9 373 4 49 1 7 8 3\r\n38256713: 1 17 565 7 569\r\n48706758: 994 49 7 6 1\r\n4201474: 8 194 2 10 9 9 3 5 3 9 2 2\r\n858412920: 8 8 8 372 8 728 3 1 8 6 9\r\n25236648217: 2 3 53 992 8 9 4 2 4 2 1 7\r\n527367299: 26 36 7 578 787 2 2\r\n6909290: 7 25 1 4 3 8 949 56 58 5\r\n5157699: 912 9 56 9 9\r\n23561802: 9 1 9 2 1 438 3 5 8 4 6 11\r\n7648: 59 2 4 6 47 4 838 7 783\r\n11572848: 50 33 8 782 690 903 6\r\n1880830063709: 79 65 831 521 846\r\n210687: 2 92 5 72 85 2\r\n369305847: 1 651 59 2 26 880 2 87\r\n363017: 775 9 6 52 5\r\n346237056576: 921 275 8 356 5 6 96\r\n557278: 5 51 3 59 78\r\n9090: 4 3 1 1 3 101 6\r\n687: 9 311 357 5 5\r\n973265869856: 6 5 1 5 9 80 6 9 2 5 6 926\r\n197459100256: 956 19 506 131 164\r\n10248: 3 5 1 628 6 24 4 89 77\r\n499778581512881: 822 76 322 68 911 80\r\n146: 7 2 4\r\n4282671384: 1 91 6 184 745 47 3\r\n3120908012: 9 1 4 861 7 3 26 5 3 6 3\r\n523211166: 657 8 3 3 77 19 838 3\r\n32003849: 4 87 1 5 65 3 566 18 6 2\r\n4365816: 7 8 51 3 35 82 1 1 7 6 26\r\n542781284215: 8 4 9 7 1 50 6 256 84 3 5\r\n33536: 6 500 252 3 3 983\r\n16641327: 9 5 321 6 3 6 2 4 8 4 78 1\r\n700542188: 222 676 129 2 39 2 8\r\n607023912: 7 81 3 583 47 9 8 2 9 2\r\n424106741951: 794 835 2 759 703\r\n6275587: 58 1 18 72 59 6\r\n405657094: 959 900 2 47\r\n1518: 8 8 3 3 69\r\n467096: 46 6 3 36 760\r\n1220: 484 19 8 8 47 16 2 54 2\r\n8264892: 19 2 6 8 7 88 4 7 5 437\r\n482060814: 6 3 39 520 9 8 7 832 1 4\r\n9488565: 9 4 4 5 4 5 49 7 231 9 1 9\r\n5813406768: 884 1 84 24 782\r\n46860432: 236 8 73 8 34\r\n2499932367: 985 282 26 3 9\r\n173191616: 319 7 1 554 7 9 45 9 5 2\r\n114944997: 13 4 5 485 7 92 7 3 27 2\r\n251719: 7 290 9 41 22 92 7\r\n573436: 65 11 802 3 6\r\n11284430: 275 23 410\r\n270875635008: 4 6 5 233 5 2 5 40 5 1 5\r\n80871: 8 169 2 9 58 3 2 1 4 8 7 1\r\n6512606: 937 695 2 5 451\r\n10440603360: 1 87 77 4 836 3 614\r\n151927449: 9 8 2 68 724 6 5 51 898\r\n252: 39 209 4\r\n13392230780: 1 593 3 9 9 9 1 7 6 50 6 5\r\n5316048: 4 353 51 4 2 9 67\r\n26810922294: 4 74 5 1 72 58 482 6 9\r\n1520767: 93 7 4 9 582\r\n111602483: 182 35 7 9 68\r\n42365412: 8 473 5 4 12\r\n2567787: 69 62 7 9 3 6 8\r\n187915097: 364 1 489 455 97\r\n84681: 552 36 4 36 9\r\n4370577: 2 421 1 6 1 6 2 3 9 134 6\r\n8069187: 57 807 2 7 5 499 9 5 7 7\r\n33883: 2 9 3 565 306 8 4\r\n1570334: 506 3 58 205 84 842 4\r\n8235171: 44 68 18 717 9 7 1\r\n32100468182: 4 84 4 5 908 8 1 73 6 9 8\r\n4387597732: 2 11 9 5 75 949 4 279 2\r\n4029835: 1 7 4 257 490 75\r\n64103135033: 1 776 2 65 819 50 34\r\n10941: 5 8 47 9 4\r\n60205113: 4 56 20 5 116\r\n230750208: 6 7 8 6 61 6 2 1 72 3 4 78\r\n5615853749: 701 80 78 53 748\r\n207880251273: 9 4 76 681 278 798 9\r\n951962599: 45 899 19 1 5 4 588 7\r\n5901259500: 797 40 6 748 2 74\r\n33856: 391 12 84 4\r\n12426: 1 9 7 17 11 14\r\n4210: 65 51 83 98 714\r\n430609635633: 12 7 301 77 46 955 22\r\n27747: 9 2 40 9 3\r\n12515069533: 627 998 6 8 6 76 20 5 8\r\n50803472: 3 1 1 8 210 7 24 15 34 8\r\n8755749: 71 786 1 7 11 53 1 4 49\r\n7465549: 123 4 6 4 1 20 2 6 817\r\n525281: 4 5 98 268\r\n25655744751: 25 655 7 44 753\r\n52598990: 28 7 7 8 4 38 6 6 1 3 86 4\r\n1858306521598: 688 6 8 8 4 83 53 5 38 1\r\n75400: 6 2 96 392 65\r\n1950: 7 2 4 4 4 800 583 9 330\r\n5615: 7 9 8 1 6 9 67 3 364 1 4 3\r\n9792: 444 4 5 1 911\r\n14726467: 294 5 60 94 49 7\r\n2860698497: 5 2 55 698 497\r\n169152: 4 9 1 710 463 3 573 96\r\n10681820859: 8 72 9 4 9 330 44 6 8 59\r\n284: 8 5 7 1 3\r\n3094474: 1 439 2 177 891 1 4 5\r\n51993191: 6 62 1 5 5 6 67 535 62 2\r\n1970: 15 55 30 1 969\r\n1643410: 8 9 1 128 9 6 708 9 16\r\n1673: 9 3 6 3\r\n7220921373998: 72 209 213 73 95 4 8\r\n117013: 2 9 7 6 3 1 448 3 7 16 3 7\r\n711235397: 47 9 9 9 8 78 98 2\r\n11804015630: 99 12 184 876 6 54\r\n860327: 817 43 327\r\n322250: 17 12 130 2 5 5 5 7 4\r\n403096716736: 6 5 218 21 2 264 8 203\r\n2699280: 48 4 984 57 47 403 5 8\r\n64886890841: 3 50 9 6 1 7 6 620 31 71\r\n1420300: 4 1 4 1 3 7 4 389 434 2 5\r\n4905054134: 2 1 2 6 2 7 481 4 2 85 34\r\n324551745: 6 44 5 5 8 9 7 9 6 44 61 9\r\n1004646988169: 3 164 44 6 69 3 5 816 9\r\n544410321: 3 7 6 880 34 909 6 869\r\n3325922543: 332 5 922 5 36 7\r\n742660002: 9 3 5 4 83 5 29 266 189\r\n19247712: 6 3 2 3 3 7 7 3 84 8 6 22\r\n1314594: 5 65 43 4 7 1 2 8 2 36 9 2\r\n3779624205: 7 25 4 78 668 2 4 39\r\n683991264: 341 9 2 761 90 29 9 3\r\n6894699: 98 4 875 82 7\r\n186547379: 639 6 7 3 6 6 134 81 5\r\n5660: 85 5 830 6 60 4 90 4\r\n6549376: 65 483 65 4 864 142 1\r\n40381836: 67 602 38 9 836\r\n93387336: 7 748 322 5 2 9 9 7 7 24\r\n1268462: 66 568 4 90 2 5\r\n56283: 29 6 668 80 42\r\n1641620: 5 1 90 5 316\r\n843489: 266 352 1 89 9\r\n16530: 7 9 499 2 30\r\n9433356: 3 91 333 5 8\r\n257471: 76 7 3 55 918 61 8 504\r\n321025: 4 8 20 102 5\r\n3322869212502: 598 6 30 72 6 70 2 441\r\n2434381562: 8 692 2 2 5 6 7 6 269 2 4\r\n6604: 18 5 9 85 3 6 1 9 8 81 2\r\n652721: 1 3 1 4 647 995 1\r\n102062704: 9 378 5 1 2 3 2 1 2 6 82 4\r\n2043839584: 236 1 866 7 958 4\r\n820306511: 1 277 73 6 642\r\n7563649: 10 952 171 68 7\r\n19654474571: 257 194 827 5 87 68\r\n67364: 842 8 5\r\n867984401: 6 717 6 662 8 78 393 8\r\n7425210: 7 4 3 341 1 96 474\r\n285360: 58 82 60\r\n1603: 501 275 99 6 722\r\n35376257: 2 33 304 72 253 4\r\n47762703362: 6 6 289 45 3 6 528 2 6 2\r\n15029227: 29 9 112 292 25\r\n1635772109: 47 2 1 5 4 39 24 771 4\r\n18903684: 441 9 1 8 3 66 2 7 5 7 6 2\r\n42531801: 3 442 3 1 8 9 2 5 1 2 8 1\r\n49724160: 52 986 650 8 7 1 92 5 8\r\n2712559598614: 19 9 6 460 9 351 861 4\r\n6390687: 49 2 42 1 1 45 687\r\n9203094405: 774 41 7 6 1 5 468 29\r\n517926540: 81 21 1 510 10 9 6 2\r\n75188493: 7 518 20 64 94\r\n232106948102: 6 47 368 512 38 822\r\n418550259709: 95 5 7 8 2 412 9 4 6 2 55\r\n1540: 43 11 668 821\r\n68647590438: 5 1 550 90 41 9 7 8 1 85\r\n492083: 8 7 71 33 7 2 3 27 7 5 3 8\r\n3804175818457: 76 5 41 758 184 43 15\r\n101633: 4 84 43 30 8 3 617 98 7\r\n31819898888: 285 64 708 88 7 4 8\r\n372666920: 2 971 755 66 92 2\r\n535907: 267 2 2 93 5 6 785 618\r\n351993237: 5 2 8 13 1 543 8 8 6 30\r\n1112: 4 98 3 5 9\r\n99809285: 4 510 1 9 57 6 9 95 57 5\r\n6015205808: 620 12 431 97 1\r\n7583055: 26 52 4 82 713 1 237\r\n229960: 869 831 95 8 2 24 8 8\r\n8007: 7 440 92 30 445\r\n102061576152: 122 497 845 1 3 664\r\n2866474: 2 381 29 414 451 41\r\n328814: 548 6 14\r\n850969275: 2 2 89 60 62 4 3 6 8 3 5 5\r\n8708334: 1 837 46 4 7 981\r\n81837: 1 26 79 712 7 6 6\r\n564774: 1 8 54 592 6\r\n4074896: 22 79 8 5 39 20 165 4\r\n403340: 4 3 268 35\r\n23481882483: 60 9 76 7 8 9 55 8 6 7 3\r\n732168: 93 182 89 43 523\r\n9936240: 9 934 1 8 4 40\r\n1354515796: 99 4 358 2 508 7 79 3 3\r\n2906312: 7 1 52 582 79 6 4 2 9\r\n144276: 8 2 64 9 98 2 78\r\n290090904: 4 8 85 8 3 9 306 2 90 4\r\n17647227656: 18 8 10 53 104 69 65 5\r\n135872: 1 104 20 43 64\r\n885732869754: 63 266 633 545 9 14\r\n2368173: 645 733 8 708 9 5 623\r\n2012562: 7 1 6 22 3 3 2 43 8 4 8 4\r\n3519929959: 961 991 7 77 528 1 4\r\n3425588288496: 170 8 98 1 3 194 1 839\r\n424161249680: 45 123 537 2 940\r\n54929784: 361 38 38 6 4\r\n174000483: 738 40 90 2 25 1 8 482\r\n29684291: 9 5 6 98 2 97 5 9 31 86\r\n3697187286: 78 1 9 2 7 2 47 6 2 2 7 87\r\n160736810: 6 80 3 897 7 13 1 53\r\n115305432: 7 6 83 9 15 95 374 3 5\r\n318242731: 2 5 30 8 78 273 1\r\n158006974: 82 3 8 7 4 2 6 4 9 8 40 4\r\n46276000: 13 3 514 74 92 25\r\n1164169835403: 63 1 89 241 299 600\r\n2074291: 3 204 21 21 92\r\n566883: 2 8 5 5 3 26 80\r\n38806371747690: 3 880 637 174 7 6 8 8 2\r\n20240258: 7 7 3 6 3 530 2 8 2 55 3 1\r\n4437: 7 18 13 6 37\r\n2797344853233: 946 639 9 985 4 412 3\r\n30654054965: 94 37 585 4 49 5 965\r\n1734694175: 2 5 906 6 372 947 3 7\r\n524706030: 6 558 7 4 8 8 1 2 405 9 4\r\n8272422: 4 75 115 84 54 307\r\n83160: 633 9 4 897 3 8\r\n27135: 9 9 9 26 4 238 2 3\r\n827585: 973 2 848 55 730\r\n7257: 6 9 2 5 331\r\n273640160: 992 898 421 4 60 296\r\n3666184: 992 4 340 851 70 6\r\n889: 6 1 798 30\r\n39181991: 3 918 1 9 90\r\n8506852354: 849 7 9 852 353\r\n385760: 3 165 7 3 383 18 3 639\r\n35997454949: 5 9 47 22 7 1 7 91 4 4 6 3\r\n25605535: 18 471 8 80 644 95\r\n6308290: 630 8 283 7\r\n27743: 22 9 79 41 2\r\n779582: 17 7 602 396 186\r\n1232243: 47 76 22 46\r\n332: 3 24 1 3 5\r\n30291120: 8 17 4 12 96 746 360\r\n3320162208: 794 4 145 4 9 4 142 44\r\n58257: 2 682 5 17 2 115\r\n1619: 1 5 5 28 78\r\n388257: 75 88 940 352 1\r\n417864098: 5 7 7 850 48 29 3 7 8\r\n8634000: 837 6 4 2 3 7 3 9 11 5 75\r\n295125441: 5 9 4 5 4 1 7 53 4 8 1 2\r\n94948: 8 584 889 9 4 9 51 65\r\n17752926751: 91 56 9 7 48 7 8 5 325\r\n30656: 997 3 74 1 3\r\n8551: 8 56 8 932 62 87 620 2\r\n48106385: 862 558 2 665 3 109\r\n746660955448: 711 35 660 955 446\r\n7151: 74 32 7 3 26\r\n221025320881: 4 39 514 5 3 20 87 9\r\n80841110: 3 1 43 47 10 14 94\r\n114836: 5 82 70 9 4\r\n5340607046: 9 7 2 8 60 4 893 5 8 8 8 3\r\n156526029: 37 2 13 4 602 7\r\n244615170: 1 6 3 3 18 8 7 319 97 4 5\r\n1824254024838: 541 843 506 2 5 4 8 8\r\n6871740: 8 91 2 77 781 159 9 4 9\r\n767077655: 7 33 8 846 26 604 73\r\n10337184: 58 90 8 9 22\r\n740533: 147 5 4 9 6 31\r\n5941645084: 7 84 6 1 64 508 2 2\r\n419153872: 9 63 7 728 4 9 6 8 23 4 8\r\n23219862: 87 572 5 87 81\r\n35301252: 73 483 36 6 252\r\n173948: 2 5 3 7 39 234 2 6 6 92\r\n837802: 3 9 3 1 4 4 1 385 8 1 20 2\r\n51765: 5 15 1 2 13 161 7 255\r\n562759869633: 29 2 3 793 3 6 690 6 34\r\n1535: 70 9 238 668\r\n33537429463: 46 9 9 2 7 6 18 3 9 2 5 1\r\n16450316: 7 4 13 3 79 1 87 84 8\r\n83817942445: 131 17 9 4 4 71 36 5 4\r\n150194: 986 19 32 8 66\r\n107053729: 168 1 99 70 9 41 6 601\r\n548998: 989 555 64 39\r\n1020325: 824 384 3 6 13 9 2 7 1 4\r\n1985872: 936 13 3 149 14\r\n951266764816: 4 2 3 528 47 44 8 99 1 6\r\n2386585634: 4 2 7 254 4 5 3 54 4 1 1 9\r\n102797772: 22 73 762 11 84\r\n2169994: 840 41 3 8 21 20 86\r\n3172681837: 6 226 69 9 8 7 1 82 1 7\r\n38767548465: 40 8 2 7 8 85 4 2 785 5 9\r\n46680: 1 37 9 6 80\r\n37111: 9 5 4 87 35 5 610 32 32\r\n9392922: 87 15 9 2 3 79 8 9 14 99\r\n1856745433: 9 2 8 4 1 5 6 9 8 12 5 435\r\n152832: 89 9 2 786 64\r\n23470: 227 2 80 62 430\r\n755452930: 6 293 6 4 57 4 8 3 8 6 5\r\n504951876: 2 2 76 241 38 6 9 8 9 44\r\n1027684675803: 890 791 18 2 9 62 811\r\n21267825795: 1 7 6 7 8 9 5 807 25 83 9\r\n9538: 475 9 477 229 8 9 9\r\n3354426: 353 95 9 1 26\r\n437366652: 35 5 8 65 341 7 4 18 6\r\n1268: 5 6 3 7 6 7\r\n70230511: 37 102 57 3 630\r\n2335151574: 833 10 341 287 3 274\r\n96763450: 89 8 69 63 4 48\r\n46224762: 88 2 8 321 5 40 5 4 753\r\n45127: 772 58 2 6 338 5\r\n259272432: 2 75 9 6 764 6 7 4 6 8\r\n522741242399: 23 2 49 941 52 820 2\r\n1817683616: 402 3 942 26 16\r\n124093: 3 81 4 7 21 25\r\n72549: 3 1 76 678 3\r\n226594: 7 5 40 59 8 33 1\r\n29049491: 725 945 292 3 4\r\n13568439614: 4 7 7 6 8 7 790 54 6 7 8\r\n1471658220: 8 2 31 3 3 9 138 5 254 1\r\n1971364: 14 968 52 812 2 38\r\n1668902450: 9 868 2 2 6 8 8 9 55 7 3 5\r\n48960718: 81 6 60 59 1 31 96\r\n49496229835: 10 9 9 9 3 71 8 45 967 5\r\n66318213720266: 1 6 63 1 8 213 720 266\r\n1116735: 8 9 2 917 5 62 990 2 7 6\r\n1093816: 729 150 31 6\r\n288117: 46 4 7 62 3 1\r\n183064127: 8 7 6 535 82 459 1 6 8 4\r\n571546: 8 496 144 50 23 81\r\n1068545777: 606 462 54 577 7\r\n1129521767022: 39 3 8 3 45 7 8 4 4 6 717\r\n9755928: 5 952 8 9 1 8 157 4 8 7 8\r\n1303332706: 8 2 5 101 2 3 1 4 4 3 706\r\n3539479770: 3 7 4 968 66 1 2 4 9 9 2\r\n18137313: 4 7 808 19 89 9 39 231\r\n1205: 14 8 3 5 6\r\n15152558: 4 7 247 551 53 7\r\n36256: 7 96 38 5 74 3 7 6\r\n21205: 97 9 7 753 24 1 363 58\r\n182: 79 8 2 6 87\r\n833526: 74 9 35 1 24\r\n31182958: 445 37 7 7 21 58\r\n498: 6 68 9 6\r\n1690878204: 2 7 7 1 35 9 8 50 567 3 6\r\n521976416: 806 63 89 7 6 416\r\n259182810: 6 93 1 17 22 797 5 9\r\n51546726610: 4 9 363 75 7 92 9 6 6 3 7\r\n3367952: 24 31 565 634 8\r\n936138387: 156 803 4 1 597\r\n176928: 6 59 49 97 16\r\n28961715: 4 8 6 1 1 5 3 9 2 75 55 60\r\n33191645: 842 54 73 5\r\n1036: 503 5 6 4 2\r\n26433627920: 520 9 40 290 7 6 43 80\r\n4048: 94 8 171 14 226\r\n526790: 56 487 970 71 9\r\n172551676: 3 2 76 59 3 1 3 8 61 583\r\n422609263: 3 5 115 50 6 4 4 5 13 9\r\n3732: 4 472 6 68 811\r\n38878: 84 6 69 66 55 1 6 886\r\n68896: 5 27 67 7 2 32\r\n189554928: 379 5 4 8 6 928\r\n1787873: 859 842 86 821 49\r\n21825330: 3 52 3 778 80 79\r\n2042085: 72 2 87 163 21\r\n147909842696: 948 6 8 4 26 2 2 4 24 72\r\n4444020: 7 7 4 88 133 7 5 4 9 2 9 7\r\n312530697: 78 4 509 21 699\r\n33623: 332 4 2 1 2\r\n11927338: 394 8 785 5 7 33 1 5\r\n584845849: 6 2 11 6 4 520 165 49\r\n39246547: 2 6 1 6 37 3 5 58 39 2 7\r\n8737467: 1 53 855 356 9 53 3\r\n2667043565: 422 8 79 3 565\r\n12008836: 37 81 5 200 9 4\r\n50264: 5 5 9 3 3 302 93 695\r\n1953967: 9 16 8 5 69 5 9 5 9 716 3\r\n22518472: 1 7 9 6 3 1 5 2 3 5 313 68\r\n20398768: 80 315 44 2 808\r\n109761: 590 507 61\r\n1010371968: 19 446 6 368 54\r\n3323592: 11 69 81 69 54\r\n49599: 2 6 8 3 48 6 3 4 9 9 3\r\n6539: 3 296 3 441 2 1 6 1 322\r\n399745468: 919 3 19 72 734 2\r\n2908235656: 581 1 64 5 6 29 6 5 6\r\n166231: 8 153 9 656 88\r\n3640420728: 237 6 43 91 445 4 1 8\r\n25839: 819 17 25 3 3\r\n145515: 5 197 28\r\n1021285: 2 630 3 68 52 5\r\n119955505: 9 8 13 25 40 70 4 1\r\n173680: 446 719 95 911 80\r\n24123639: 344 7 15 421 3 1 9\r\n6335: 92 461 41 2 393\r\n101: 30 3 4 2 2\r\n2654691969: 42 632 70 221 96 6\r\n774177258: 8 8 885 5 917 8\r\n10366441060: 3 5 3 4 172 415 508 20\r\n32740848: 8 5 3 8 4 8 9 2 8 7 729\r\n34521935618: 860 90 6 28 162 86 4 8\r\n1837367184: 2 296 70 87 1 1 1 7 1 8\r\n16563129574: 7 30 9 29 6 4 747 3 7 8\r\n51874863: 518 364 3 2 379 63\r\n4038386616: 3 7 5 98 973 88 9\r\n5018096585736: 9 72 9 417 3 77 8 8 717\r\n2177721: 33 9 2 7 780 63 9 1 7 1\r\n1556549865632: 933 5 3 9 19 9 585 630\r\n239617747220: 83 6 2 689 2 2 4 52 17\r\n144870372109: 85 2 435 7 3 85 5 4 7 11\r\n35316: 46 3 4 62 832 3 8 8 4 84\r\n7911: 1 2 55 64 871\r\n154279361: 9 712 52 463 353\r\n79673: 2 1 9 963 4 2 5 8 866 5 2\r\n51282540: 50 3 2 8 9 147 5 1 4 340\r\n2979352: 31 347 88 4 5 3 426 68\r\n765: 1 2 97 527 47 92\r\n1161114: 3 7 3 21 709 1 7 862\r\n2864: 9 8 3 6 39 32 4 48 60 4\r\n1697532: 485 7 5 32\r\n51924213116: 7 1 982 763 8 99 1 13 3\r\n17866668: 1 36 64 8 4 54 976 4 3\r\n553344: 53 7 8 775 4 88 7 46\r\n7797435: 9 7 716 74 34\r\n47897133: 577 77 829\r\n2556544: 5 7 7 9 1 9 3 865 70 3 6 4\r\n47389312548: 498 4 2 59 6 4 1 8 548\r\n6640797796: 663 1 9 797 796\r\n901966: 99 1 9 281 984 700\r\n11114904372640: 95 2 60 19 78 146 638\r\n2357425250: 4 3 7 1 1 461 63 25 250\r\n5358144: 88 7 72 649 12\r\n59238568: 64 8 7 6 8 729 3 4 64 3 8\r\n6249647: 1 4 872 2 79 42 5\r\n16786854: 8 4 8 3 75 7 1 46 8 6 5 4\r\n174900: 619 900 71 2 55\r\n478593147: 39 67 818 931 47\r\n2419: 8 3 13 4 2\r\n29060600947: 950 70 231 437\r\n462473: 53 91 7 14 3 934 143\r\n146651904218391: 784 6 433 80 24 266 9\r\n3248684214432: 8 121 699 4 46 14 429\r\n1385528965: 1 50 2 633 3 96 371 3 5\r\n132397232: 175 843 44 13 34\r\n22292: 838 2 552 3 6\r\n672799497: 52 70 270 12 46 373\r\n669258: 4 328 9 3 999 8 5 6 2 7 6\r\n72262249398: 2 361 6 13 1 9 4 9 39 7\r\n5235945790: 7 315 8 715 78 7\r\n430448: 599 126 7 7 3 4 7 32\r\n28486505: 9 1 1 3 2 1 9 42 2 66 7 5\r\n77033: 24 85 568 93 33\r\n8762343: 83 1 85 2 69 9 33\r\n56395056608: 8 916 3 5 5 32 874 19\r\n14560: 4 66 4 4 13\r\n6159672906: 914 11 68 736 1 15 1 6\r\n14931054222: 7 9 21 7 413 9 6 5 422 2\r\n512698525: 31 2 5 242 1 82\r\n371317: 463 8 8 7 830\r\n26363455: 803 5 146 37 4 314 3 5\r\n350530493: 31 4 618 88 61 93\r\n69948: 61 9 652 5 58\r\n6760: 5 6 3 44 2 3 7 57 1 2 4 1\r\n286777568: 5 5 6 1 6 3 3 6 6 975 74 9\r\n4450855: 4 6 63 7 7 289 2 2 5 5 6 5\r\n47959993: 3 9 4 9 7 1 2 3 427 7 1\r\n44340765046: 443 40 6 9 7 498 6 3 2\r\n6487071140: 7 6 9 716 2 1 95 1 4 935\r\n5754733489: 3 5 2 4 71 16 94 5 3 4 9 2\r\n7603290: 2 9 5 3 5 58 2 889 52 5 9\r\n120768404294: 37 408 8 40 429 2\r\n117760: 5 1 98 430 128\r\n179: 17 2 49 94 2\r\n8654263319: 9 871 2 23 1 2 24 3 6 83\r\n2408267: 193 7 668 12 251 3\r\n55600842: 8 42 382 55 66\r\n91408: 91 40 8\r\n13806695: 7 845 917 62 8 87 937\r\n1873057: 18 721 90 643 225\r\n66128676554: 2 9 228 867 65 54\r\n15554266: 673 33 7 79 63\r\n216400: 485 7 45 4 5 80\r\n1457699893: 68 92 5 99 423 16\r\n1620853: 792 91 737 8 53\r\n904972: 37 3 73 8 972\r\n182902135: 7 620 77 5 6 3 4 2 2 8 6 6\r\n345700350: 6 26 8 3 7 9 7 496 2 127\r\n60345: 3 8 5 69 5\r\n10262: 36 67 4 579 475 7\r\n26244291580: 841 6 9 79 1 5 52\r\n24649395: 24 647 2 395\r\n2891520: 187 5 1 29 29 8 9 5 8 4\r\n132203271: 4 8 44 6 82 8 5 3 9 932\r\n463190: 367 631 2 27 9\r\n131034958: 5 9 6 6 636 18 9 1 4 3 5\r\n741317019584: 91 1 664 548 79 448 8\r\n9540536: 90 106 467 54 15\r\n86263827: 3 1 554 5 6 861 61 3 7 6\r\n856992000: 173 731 50 79 5 48\r\n1183024: 1 991 59 833 6\r\n239808826: 2 72 51 88 28\r\n56287025754: 860 77 100 6 7 236 85\r\n53675: 5 630 407 15 80 239 1\r\n9112704: 6 85 126 54 50\r\n462082219236: 99 9 3 8 9 71 6 1 923 6\r\n335119980: 3 4 51 4 73 34 39 3\r\n41255478: 2 6 7 3 86 8 293 4 6 7 7 1\r\n2377161: 23 25 12 40 161\r\n5944531622: 5 1 593 7 5 9 2 2 9 615 7\r\n921497176: 1 1 6 911 3 492 4 47 7 6\r\n8425: 841 6 7 4 1\r\n9446: 94 1 4 1 4\r\n80847379449: 5 3 3 59 6 1 83 803 84\r\n57892858: 66 87 47 28 58\r\n174916442: 2 13 25 4 46 34 41\r\n1659709186362: 362 98 86 68 8 1 2 362\r\n7166: 700 3 3 8 99\r\n3937363443369: 579 8 9 3 70 1 78 57 71\r\n9311004099: 7 266 1 90 3 7 8 10 5 9 9\r\n1092976: 64 4 3 36 11 16\r\n5557616652: 8 7 3 9 7 663 8 66 7 1 84\r\n327055: 3 270 5 2 2\r\n1707630: 9 3 600 7 352 79\r\n247793093: 38 5 67 5 5 7 6 7 6 1 6 9\r\n288275: 76 33 9 8 61 1 2 68 5\r\n1016999683568: 2 37 798 44 734 421\r\n347830399: 644 7 9 93 4 1 4 69 4 3 7\r\n410871: 3 8 18 2 6 4 92 3\r\n3534054: 9 17 886 560 5 4 8 1 6\r\n884578239: 69 14 16 8 6 461 9 1 1 9\r\n114625206: 2 796 3 6 2 3 1 5 50 4 67\r\n156502: 527 9 45 269 213\r\n247238402912: 85 395 79 652 2 912\r\n271486: 52 76 563 60 586\r\n236181937: 3 7 2 8 2 321 3 422 3 8 5\r\n12971305304: 14 75 515 283 304\r\n929207: 3 34 826 974 234\r\n1334079: 9 9 2 3 6 9 108 61 5 9 3 3\r\n276193925840: 711 84 388 58 40\r\n2227657: 578 74 8 1 7 61\r\n12079886: 671 9 92 2 4 6\r\n7161672: 7 6 1 2 502 9 9 5 57 9 3 4\r\n1373: 52 5 2 847 6\r\n37523520000: 8 4 6 50 505 2 48 215\r\n9284: 4 23 84\r\n75946: 70 92 71 149 244 11 2\r\n95408815198: 7 92 384 4 7 30 6 40\r\n335551450: 6 87 4 16 9 6 7 1 93 5 2\r\n135279: 2 676 79\r\n393481: 386 7 45 2 8\r\n6976620: 3 1 30 2 40 4 769 9 3 7 3\r\n2173497: 398 5 140 4 745 751\r\n127846425: 72 1 671 6 3 87 7 4 1 7 3\r\n3035827: 6 5 1 354 63 8 50 306\r\n1129827: 188 102 6 778 437\r\n5641655: 6 1 9 6 6 9 1 995 6 8\r\n1085064: 5 1 70 31 64\r\n34208: 5 2 213 8 16\r\n1757430211: 175 742 89 1 6 6 14\r\n228049076: 5 8 57 464 6 3 8 84 893\r\n1727227: 3 558 3 92 431 6 27\r\n429159039611: 74 9 46 40 6 1 3 519 3 8\r\n109530: 8 2 6 5 28 6 3 2 82 9 3 6\r\n1441620219696: 9 413 19 3 542 3 7 9 6\r\n22140395867: 47 1 5 361 17 2 47 866\r\n2285144433: 9 4 699 31 65 6 8 4 433\r\n4231947687: 5 9 2 31 6 2 7 781\r\n98129763409: 4 49 25 9 50 5 8 5 412\r\n2706: 3 9 2 66\r\n83125: 4 2 710 97 1 3 5 797 2 1\r\n35668630: 5 5 2 4 8 6 1 73 9 7 49 35\r\n30272121358: 69 427 809 121 358\r\n2814: 2 88 17 8 14\r\n6374: 2 4 16 4 4 23 51 8 8 14\r\n50232: 44 1 67 5 1 3 3 5 6 1 6 14\r\n6486718985: 87 9 998 7 847 966 5\r\n578702070: 76 81 3 7 2 6 9 94\r\n6701202: 98 8 67 79 325 6 9 116\r\n346676422387: 8 66 2 2 2 67 9 4 223 8 7\r\n4866: 47 87 77\r\n3107624016: 918 65 2 651 8\r\n3550: 3 1 6 71 5\r\n4092004: 93 5 44 20 4\r\n321906451: 8 9 418 18 94 733 2\r\n73497: 1 40 525\r\n2899023804171: 53 685 62 6 54 1 72\r\n9014948: 1 6 9 2 4 6 7 1 99 294 9 1\r\n1414224: 7 9 61 46 8\r\n2212724179: 424 632 891 88 52\r\n711557: 536 662 3 932 2 23\r\n27158: 64 423 4 82\r\n3299024: 1 7 87 6 33 41 87 6 82\r\n466146780846: 20 8 37 673 52 117 2 4\r\n155960199954: 4 2 66 4 4 5 554 4 9 1 9 2\r\n148374876: 97 51 37 487 8\r\n836: 6 2 36\r\n679699680: 8 253 6 58 965\r\n230673: 7 48 80 11 54 2 7 80 5\r\n249937693237: 656 635 2 1 25 22 6 3 7\r\n70565: 82 49 6 2 410 3 805 5\r\n521707566: 52 1 707 29 3 6 269\r\n3363581: 4 42 2 3 578\r\n64478535: 9 693 210 85 3 2\r\n12185988301: 4 2 4 1 37 6 254 2 5 81 1\r\n28725: 5 3 4 1 17 3 21 94 9 1 5 5\r\n114559694: 9 8 5 37 1 1 939 1 69 3\r\n33390: 372 84 21 5 1 7 2\r\n3241135: 9 9 57 26 27\r\n897144: 81 63 7 89 6 15\r\n1960174219551: 7 14 9 1 8 61 4 3 9 5 46 3\r\n10908: 2 98 6 6 9\r\n3455096: 616 98 56 2 4\r\n3773: 87 433 7 4 5 7 1 20\r\n356: 271 1 84\r\n7983099518: 736 7 2 774 9 7 20 337\r\n519: 4 69 7 2 6\r\n47490313850288: 847 617 5 1 21 46 58 8\r\n25305728: 709 81 804 4 8\r\n2641593: 2 5 14 82 1 29 8 294 3 3\r\n1197: 120 73 2 33 969\r\n64800: 4 83 3 45 16\r\n38767718: 71 5 51 7 718\r\n667608: 698 956 47 45 1 2 225\r\n4591296: 6 68 3 4 8 5 70 7 34 8 18\r\n2432595: 6 1 6 7 45 7 3 5 641\r\n62304140842: 75 59 5 8 350 8 401 44\r\n569238079: 8 997 2 617 9 51 49\r\n596271: 591 5 21 5 9 2\r\n17924: 8 9 8 84 40\r\n347150072: 2 507 7 85 4 9 4 5 3 8 6 3\r\n6927: 8 60 3 4 5 5\r\n141377300064: 93 8 527 224 286\r\n3520677195: 718 50 5 55 49\r\n1004458360: 55 6 3 6 8 6 23 5 83 55 7\r\n248227045: 2 46 86 9 6 6 959 12 75\r\n1137749: 193 655 1 9 8\r\n236732760: 353 3 53 8 6 660\r\n19368780: 38 2 90 15 5 23 938 6 3\r\n700857: 8 6 2 73 57\r\n13768450416: 4 5 530 40 16 3 63 48\r\n650107742: 870 12 965 399 57\r\n1037424: 4 1 185 2 14 59 35 315\r\n130560821243: 3 9 2 4 30 2 1 41 2 1 2 43\r\n78166897557: 868 48 4 1 10 8 4 6 5 3\r\n535492863975: 72 56 246 3 63 976\r\n91140: 7 7 358 35 7\r\n75325922139: 5 7 26 97 1 5 3 87 897\r\n439455908535: 8 787 2 118 160 3 7 7 5\r\n15330343081: 48 173 58 299 3 77 4 1\r\n469887: 1 521 9 73 14\r\n16290332576: 75 543 8 4 567 690 6\r\n2000164470: 5 7 7 5 7 43 1 1 6 4 470\r\n2240689: 1 322 2 766 7 9 71 1 5\r\n261033: 326 25 4 8 1\r\n334426765: 6 26 266 534 721\r\n5900784430230: 2 68 29 8 84 99 90 367\r\n59208888: 69 8 2 804 436 86\r\n731: 10 9 641\r\n384343: 8 4 8 5 6 4 12 1 9 39 5 2\r\n4692: 74 4 38 6\r\n21124: 1 8 3 32 6 4\r\n24351718154: 9 8 3 32 1 7 6 8 3 4 745 4\r\n3473630627: 403 9 1 43 2 2 161 466\r\n17522128348: 8 44 6 4 1 2 2 6 9 96 98 6\r\n55844559063: 55 8 4 455 906 3\r\n7446528849: 1 5 3 3 4 2 42 1 4 81 7 57\r\n1997871: 1 4 1 4 8 4 6 67 701 3 6 3\r\n104797340202: 935 6 6 2 6 1 8 44 8 8 7 2\r\n203839: 45 5 1 16 28\r\n362: 1 211 5 73 73\r\n1532909: 1 488 5 5 904 455 7 2 5\r\n6247138: 774 8 55 132 5\r\n5062432965: 253 11 17 95 4 4 82 2\r\n543829248: 639 3 9 1 6 8 861 3 8 82\r\n42336446: 8 27 196 399 49\r\n6859496072556: 685 949 60 72 535 23\r\n13652069124: 802 563 206 9 124\r\n25272158: 7 89 63 4 50 80\r\n100193281: 2 8 3 5 51 201 543 5 2\r\n346125: 13 15 71 25\r\n113769150000: 672 3 88 9 88 750 95\r\n31825: 8 715 6 964 6 9 1 2 1\r\n20830619: 6 347 9 8 2 6 5 5 6 776 4\r\n210053496: 86 6 6 82 493\r\n20256272: 4 140 8 31 5 1 4 47 61 2\r\n582: 18 5 54 8 1 8 8 5 77\r\n1555341863: 397 4 7 993 558 5 1\r\n508008: 6 8 61 3 926 49 259\r\n92628: 1 8 7 1 6 75 5 5 143 5 6 6\r\n1409254: 7 3 61 14 11\r\n393358: 7 386 27 7 1 14\r\n2102635646: 35 6 261 1 83 4 8 61 46\r\n151323: 909 4 51 943 15\r\n2322564: 1 20 64 6 2 8 4 9 2 1 3 57\r\n233915830206: 38 98 59 716 9 3 9 24 2\r\n1264151436: 6 6 553 3 7 5 3 678 9 6\r\n141119: 998 413 18\r\n25239072691600: 8 849 50 929 8 645 80\r\n1938: 6 5 9 2 8 2\r\n372484584501: 668 41 57 18 7 52 17 8\r\n9534069107: 9 5 3 3 404 665 104\r\n6125634327: 64 3 6 3 106 3 2 76 4 47\r\n1417820192: 2 918 90 20 332 856\r\n3038762: 97 8 628 5 5 69 12\r\n89418618: 69 797 2 813 2\r\n2601445324: 1 9 5 99 7 8 5 2 5 7 324\r\n252773462233: 6 210 48 1 913 848 9\r\n75723336: 120 82 89 468 9\r\n2246: 2 790 1 11 546 33 75\r\n594402820: 624 4 6 28 224 937 6 4\r\n309889855: 9 5 1 94 6 89 3 8 4 5 271\r\n3619047687543: 64 6 2 517 4 122 3 7 43\r\n4752690: 82 2 34 9 170\r\n225572: 9 56 719 14 8 8 30 4 6 8\r\n129175297514: 8 4 2 7 2 693 2 9 2 5 51 4\r\n151407309145: 242 97 645 913 9 3\r\n781650: 29 8 549 49 6 3 151\r\n449558930: 300 9 7 819 2 91\r\n341914: 627 68 8 25 801\r\n208260: 364 170 39 10\r\n4818: 6 3 48 371 6\r\n90484: 7 5 5 844 25 4 84\r\n112978975: 8 3 293 4 5 4 76 4 7 37 5\r\n12788020227: 333 856 8 7 684\r\n14177258: 22 5 7 240 2 3 4 3 5 3 1 1\r\n2426097636: 56 4 3 5 3 1 81 707 4 89\r\n242505900: 3 282 91 350 9\r\n39690: 687 655 5 7 5 79 32 27\r\n20700112: 36 25 23 1 12\r\n424567710: 4 4 41 3 36 29 8 75 2 1 3\r\n50: 4 7 3\r\n21090173: 3 260 620 3 8 8 3 6 532\r\n960347: 9 5 2 3 5 24 1 939 6 402\r\n66516885: 71 73 2 5 927\r\n457694: 2 6 762 75 494\r\n23621017539: 8 40 703 1 14 39 385 4\r\n7161589266: 56 837 92 21 189 1 6\r\n5165704: 65 1 43 455 4 544\r\n1272440898138: 658 660 17 293 33 6\r\n31268228520: 375 3 62 879 2 6 1 85\r\n347: 1 349 1\r\n2018425: 667 16 552 8 3 361\r\n4232592: 600 63 1 912 7\r\n8536831: 8 442 94 831 1\r\n1793971586: 1 7 15 3 740 971 586\r\n38903: 35 16 4 58 7\r\n7550409: 20 42 84 72 44 9\r\n554008: 3 92 1 200 8\r\n994140: 682 1 259 4 526 2\r\n1344706671: 922 411 8 3 706 6 6 6 3\r\n5565072723: 7 5 422 3 53 3 3 1 3 8 9 7\r\n1327866098: 795 92 17 88 914 101\r\n4039018590051: 6 4 68 4 442 8 7 4 953 9\r\n473199: 8 5 7 52 47 99 9 2 1 66\r\n98943132: 9 8 29 7 8 634 4 133\r\n78460: 98 8 5 7 3\r\n2646015: 17 1 90 14 15\r\n2337537: 649 5 5 72 779\r\n25240256910: 80 866 46 21 8 1 99 10\r\n756368: 774 977 93 6 69\r\n780615000: 5 73 5 5 66 4 25 57 5\r\n5810: 51 32 616 44 18\r\n1136856: 166 3 555 71 9 202 7\r\n61338: 612 7 6 61 4\r\n2236756: 21 663 23 7 674 58\r\n5547: 6 52 70 1 43\r\n93699: 32 75 963 7 87\r\n315035271: 309 5 9 38 5 9 910 3 71\r\n3706201034: 15 439 3 5 6 4 91 3 6 90\r\n583497711175: 711 5 825 710 36 82\r\n7164037: 7 970 1 6 31 34\r\n199107: 6 81 292 253 2\r\n39908241: 8 19 995 22 24 1\r\n726638499141: 726 54 9 84 989 2 34 7\r\n247: 222 8 8 5 4\r\n15861929048210: 5 9 3 843 7 733 8 7 20 9\r\n3936800: 260 8 1 96 2 569 4 4 50\r\n18492032561: 8 2 75 138 1 31 9 7 1 8 2\r\n221803: 6 62 335 13 20\r\n72491241: 5 58 9 491 244\r\n37430586884: 1 3 6 788 17 6 2 2 5 21 4\r\n260907840: 63 9 17 876 510\r\n1708445547: 30 94 69 8 4 553 549\r\n1108224: 9 95 2 666 8\r\n9196606: 1 3 2 5 852 844 8 58 9 7\r\n1018759: 9 7 81 8 7 19 42 672 2 5\r\n5908180: 628 48 5 94\r\n1289539: 9 463 58 61 47\r\n53114: 274 6 3 370 9 4\r\n33442230726: 6 3 8 1 53 2 1 705 6 726\r\n63268230: 60 255 35 3 5 41 2 19\r\n611452224: 8 527 717 663 22\r\n12035520: 16 7 4 2 8 884 45 8 6\r\n1374940: 91 921 301 90 98 1\r\n3420005: 724 19 354 53 13 30\r\n5124696: 6 14 54 283 4 83 2 191\r\n3026420675: 4 58 65 8 80 69 7 633 2\r\n1403196074: 936 64 8 8 6 7 366 20\r\n649139: 11 3 556 970 209\r\n102595: 32 8 49 4\r\n57152172: 8 26 12 24 9 2 5 308 3\r\n8707: 7 44 4 984 279\r\n41504953: 761 5 7 567 279 7\r\n5032530: 38 9 9 545 3\r\n551386621502: 771 10 57 25 386 13 1\r\n469: 46 1 8\r\n175985: 7 35 2 62 7 5\r\n1062: 48 67 66 881\r\n5528160383: 72 738 952 76 30\r\n14217966116: 1 3 651 2 150 84 11 4 2\r\n1977520: 7 48 5 18 6 5 328 2 6\r\n848561010: 6 8 552 478 67 114\r\n992596: 565 95 26 641 748\r\n193420535: 8 1 60 2 6 8 155 50 3 1 5\r\n658848: 13 62 8 5 6 5 9 345 8 4 6\r\n2731400: 8 315 1 8 9 8 52 34 3 8 4\r\n54563: 35 41 1 938 6 32\r\n397562: 331 7 1 58 560\r\n253371140108: 57 889 582 646 5 108\r\n2905189: 72 1 6 2 149 2 854 36";

    protected override string Part1Internal(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var answers = new List<long>();
        var counter = 0L;

        foreach (var line in lines)
        {
            var target = long.Parse(line.Substring(0, line.IndexOf(':')));
            var parts = new Queue<long>(line.Substring(line.IndexOf(':') + 1).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse));
            answers = new List<long>();

            while (parts.Any())
            {
                if (!answers.Any())
                {
                    answers.Add(parts.Dequeue());
                    continue;
                }

                var next = parts.Dequeue();

                var temp = answers.Select(x => x + next).ToList();
                temp.AddRange(answers.Select(x => x * next));
                answers = temp.Where(x => x <= target).ToList();
            }

            if (answers.Any(x => x == target))
            {
                counter += target;
            }
        }

        return counter.ToString();
    }

    protected override string Part2Internal(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var answers = new List<long>();
        var counter = 0L;

        foreach (var line in lines)
        {
            var target = long.Parse(line.Substring(0, line.IndexOf(':')));
            var parts = new Queue<long>(line.Substring(line.IndexOf(':') + 1).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse));
            answers = new List<long>();

            while (parts.Any())
            {
                if (!answers.Any())
                {
                    answers.Add(parts.Dequeue());
                    continue;
                }

                var next = parts.Dequeue();

                var temp = answers.Select(x => x + next).ToList();
                temp.AddRange(answers.Select(x => x * next));
                temp.AddRange(answers.Select(x => long.Parse(x.ToString() + next.ToString())));
                answers = temp.Where(x => x <= target).ToList();
            }

            if (answers.Any(x => x == target))
            {
                counter += target;
            }
        }

        return counter.ToString();

    }
}