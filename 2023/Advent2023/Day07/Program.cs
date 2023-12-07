using System.Linq;

namespace Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = _input;
            var comparer = new HandComparer(true);

            var lines = input.Split(Environment.NewLine);
            var hands = lines.Select(x => new Hand(x.Substring(0, 5), int.Parse(x.Substring(6))));

            var orderedHands = hands.Order(comparer).ToArray();

            var counter = 1;
            var total = 0;
            foreach(var h in orderedHands)
            {
                var winnings = (counter * h.Bet);
                total += winnings;
                counter++;
            }

            Console.WriteLine($"Winnings are: {total}");
        }

        private record Hand
        {
            public Hand(string Cards, int Bet)
            {
                this.Cards = Cards;
                this.Bet = Bet;
                if (!this.Cards.Contains('J'))
                {
                    JokerCards = Cards;
                }
                else
                {
                    JokerCards = this.Cards.Distinct().Select(c => this.Cards.Replace('J', c)).OrderDescending(new HandStringComparer()).First();
                }
            }

            public string Cards { get; }
            public int Bet { get; }
            public string JokerCards { get; }
        }

        private class HandStringComparer : IComparer<string>
        {
            public int Compare(string? x, string? y)
            {
                var xOfAKind = x.GroupBy(xx => xx);
                var yOfAKind = y.GroupBy(yy => yy);

                if (xOfAKind.Count() != yOfAKind.Count()) return yOfAKind.Count() - xOfAKind.Count();

                if (xOfAKind.Select(xx => xx.Count()).Max() != yOfAKind.Select(yy => yy.Count()).Max()) return xOfAKind.Select(xx => xx.Count()).Max() - yOfAKind.Select(yy => yy.Count()).Max();

                for (var i = 0; i <= 4; i++)
                {
                    if (x[i] == y[i]) continue;

                    var xn = Translate(x[i]);
                    var yn = Translate(y[i]);
                    return xn - yn;
                }

                return 0;
            }

            private int Translate(char c)
            {
                switch (c)
                {
                    case 'A': return 14;
                    case 'K': return 13;
                    case 'Q': return 12;
                    case 'J': return 11;
                    case 'T': return 10;
                    default:
                        return int.Parse(c.ToString());
                }
            }
        }

        private class HandComparer : IComparer<Hand>
        {
            private readonly bool jokerMode;

            public HandComparer(bool jokerMode)
            {
                this.jokerMode = jokerMode;
            }

            public int Compare(Hand? x, Hand? y)
            {
                //Console.Write($"Comparing {x.Cards} and {y.Cards} - ");
                var result = StraightCompare(x, y);
                //Console.WriteLine(result);

                return result;
            }

            private int StraightCompare(Hand? x, Hand? y)
            {
                string xCards = jokerMode ? x.JokerCards : x.Cards;
                string yCards = jokerMode ? y.JokerCards : y.Cards;

                var xOfAKind = xCards.GroupBy(xx => xx);
                var yOfAKind = yCards.GroupBy(yy => yy);

                if (xOfAKind.Count() != yOfAKind.Count()) return yOfAKind.Count() - xOfAKind.Count();

                if (xOfAKind.Select(xx => xx.Count()).Max() != yOfAKind.Select(yy => yy.Count()).Max()) return xOfAKind.Select(xx => xx.Count()).Max() - yOfAKind.Select(yy => yy.Count()).Max();

                for (var i = 0; i <= 4; i++)
                {
                    if (x.Cards[i] == y.Cards[i]) continue;

                    var xn = Translate(x.Cards[i]);
                    var yn = Translate(y.Cards[i]);
                    return xn - yn;
                }

                return 0;
            }

            private int Translate (char c)
            {
                switch (c)
                {
                    case 'A': return 14;
                    case 'K': return 13;
                    case 'Q': return 12;
                    case 'J': return jokerMode ? 0 : 11;
                    case 'T': return 10;
                    default:
                        return int.Parse(c.ToString());
                }
            }
        }

        //5J2Q2 and 22J29
        private static string _test = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";
        private static string _test2 = "5J2Q2 684\r\n22J29 220\r\nQQQJA 483";
        private static string _input = "Q94A5 121\r\nAQ56Q 611\r\nT6746 196\r\n38853 434\r\n69K88 178\r\n44454 238\r\n6KKKQ 913\r\n4446J 425\r\n9KK38 281\r\nKQ8TK 319\r\nA6A62 407\r\n26J93 60\r\n9A47Q 110\r\n4464K 656\r\n35373 558\r\nQ222Q 258\r\nT6377 243\r\nTQ9JQ 554\r\nJ373A 525\r\n59222 150\r\n44JJ4 738\r\n6Q662 452\r\nJTK95 684\r\n29KKK 697\r\n63363 254\r\nQ53A2 543\r\nT55T5 479\r\n5J39Q 743\r\nT338T 629\r\n8K5QT 561\r\nK6T45 902\r\n32544 857\r\nAA8A8 421\r\n66922 105\r\n222J2 833\r\n87878 949\r\nA966A 661\r\n4AA68 415\r\nJQ2Q7 794\r\n3QT93 618\r\n665Q6 78\r\n5599J 467\r\n575A5 577\r\nQJ699 846\r\nKKKKQ 28\r\nTKJTT 242\r\nKJ868 115\r\n59TTT 120\r\n87J44 861\r\n3A269 128\r\n292T2 70\r\n5AJ3K 412\r\nJ7TK8 916\r\nJQJ6Q 241\r\n22K22 590\r\nT868J 584\r\nA887A 971\r\n77787 701\r\nQ882J 758\r\n4AA4A 880\r\n3AJQ3 423\r\nK3KK7 465\r\n6956T 512\r\nQ2Q52 530\r\n98883 922\r\n58AQ8 963\r\n223TT 565\r\nTT53T 626\r\n6K244 843\r\n6JQ3T 687\r\nA7A7K 708\r\n5TK62 457\r\n4T44J 280\r\nK3K22 470\r\nQ8QK5 184\r\n4Q9Q4 164\r\nKKK66 934\r\n9Q875 753\r\n3Q98Q 230\r\n22K2K 789\r\n59949 553\r\n33388 478\r\nTTTAA 5\r\n73787 501\r\n4236J 222\r\n4J665 749\r\n6T666 431\r\nJ42K8 469\r\nQ2722 598\r\n33539 840\r\n55445 204\r\n98J88 302\r\n87778 305\r\n678J4 123\r\nJ464J 134\r\nKKAKJ 32\r\n98JQ9 329\r\nQ9TQQ 36\r\nA8569 380\r\nT2447 726\r\n3558T 609\r\nK23JQ 335\r\nAK9T3 303\r\n98ATJ 156\r\nTAJKT 291\r\n3A4T7 894\r\n48J28 327\r\n8K3JT 386\r\nTTT3K 486\r\nQ8K28 528\r\n9A4AA 444\r\n3AA5Q 657\r\nTT6TT 781\r\n428JA 569\r\n99899 176\r\n63666 80\r\n9AJ9A 273\r\n8829A 364\r\n68TQ4 151\r\nA5849 202\r\n47TT4 961\r\n44483 999\r\n3Q9A5 777\r\nK383J 55\r\nT2274 122\r\n99J66 326\r\n9939T 550\r\nTQJ56 219\r\nQ58T6 992\r\nK93KK 937\r\n44A38 797\r\nT4428 266\r\n6AAAJ 87\r\nQQ444 505\r\n4Q62Q 279\r\n63623 983\r\n969J3 223\r\n8J888 357\r\nJA3A3 354\r\n88JQQ 878\r\nA42J3 336\r\n7A7A3 828\r\nJQ68J 323\r\n25555 883\r\nQ488Q 669\r\nT6784 395\r\nT7524 683\r\n98969 659\r\n9894K 159\r\n7Q2QQ 655\r\nJ7946 304\r\n532QT 998\r\n22QT2 935\r\n9TT9T 564\r\nK999J 769\r\n5AK4A 968\r\n8AAAA 490\r\n92356 627\r\nAA8J8 21\r\n3Q343 986\r\nTKTKT 824\r\nK2465 770\r\nJ7774 535\r\n8J97K 124\r\n4444J 976\r\n75Q79 283\r\nJJJ44 668\r\n4JK47 317\r\n8A268 276\r\n99Q6Q 389\r\nJ7J75 109\r\nAAJKK 931\r\n73366 347\r\n37997 403\r\n6572J 345\r\nJ48J4 763\r\nA9AAQ 648\r\n87A99 172\r\n787A8 51\r\nTJ24J 92\r\n4T278 852\r\n77T2Q 264\r\n22J44 991\r\nQ666Q 958\r\nJ74A9 318\r\nTQJKA 265\r\nJA5AK 454\r\nA5J3J 808\r\n3TT3J 796\r\n62QJ5 539\r\n5QA5Q 563\r\n6QQQQ 495\r\nT48J5 893\r\nK9259 334\r\n957AK 671\r\n97393 481\r\nK4848 216\r\nKJJ3T 647\r\nQQJJ7 125\r\n354T3 921\r\n55777 112\r\n47TA7 810\r\nJ3J29 520\r\nQJTQQ 874\r\nTT272 277\r\nQJQQ6 728\r\nJ55TK 518\r\n22622 850\r\nJQ236 155\r\nQ7TTK 489\r\n7TKTJ 41\r\nAAAAJ 14\r\nT3A3J 192\r\n433K4 508\r\n55545 398\r\n77KQ9 361\r\nA737J 967\r\nA66J6 84\r\n4745J 793\r\nT2Q2T 666\r\n5A54A 1000\r\n753J2 714\r\n55556 485\r\n8TT8T 775\r\nT9767 908\r\n99299 907\r\n227JJ 568\r\n64952 62\r\n555Q7 414\r\nT86T9 943\r\nJJ6K6 463\r\nKKK3K 703\r\nQ553J 370\r\n97QQ7 596\r\n44484 491\r\n69367 730\r\nJ583K 206\r\n35898 194\r\n4K2QK 179\r\nA56J7 405\r\n4282Q 126\r\n225JK 786\r\nQ5J33 806\r\nT44T8 941\r\n99AAA 442\r\nT88T8 670\r\n3T963 69\r\nQ33Q3 381\r\nJ2K2K 394\r\nA99K8 167\r\n739QK 400\r\n8J93K 635\r\n88688 891\r\n5J232 66\r\n57252 376\r\nQQQQT 306\r\n33232 628\r\nAJJAA 915\r\n72J22 750\r\nA77AA 270\r\nQQTTT 75\r\n536A4 170\r\n95795 61\r\nKQJ2J 16\r\n9TA6Q 617\r\n999J8 33\r\nQA63J 952\r\n6QT28 246\r\nT787J 127\r\n3J373 496\r\nJ8QK4 691\r\n383KK 477\r\n97757 988\r\n727J2 585\r\n9992T 368\r\nTT222 225\r\nQQ33J 191\r\nT656A 373\r\n42222 873\r\n44A4A 4\r\nT9ATJ 725\r\nQKJKK 166\r\nTT633 153\r\n833QJ 274\r\n23993 22\r\nTQ99Q 267\r\nJ9583 605\r\n798TK 823\r\nK33KK 331\r\nA25J7 212\r\n949Q9 514\r\n62T66 911\r\nT5239 851\r\n97733 385\r\nT2Q6J 845\r\nAA66A 311\r\n5Q5K3 129\r\n89J98 152\r\nQ6374 161\r\n966K6 586\r\n82J3A 175\r\nQT7K7 308\r\nQQ67Q 203\r\nT9Q28 587\r\nK2539 445\r\n5554J 48\r\n859J6 436\r\n92A92 677\r\n64JQ8 499\r\n88885 9\r\n88A3T 945\r\n299J2 674\r\n4QQ4K 435\r\n64TJ8 630\r\n238T7 169\r\nTTTT4 784\r\nAAAA2 290\r\nQQKQQ 453\r\n3924J 716\r\nTT6KK 56\r\nQQKTT 751\r\nA2658 531\r\n7AT3Q 145\r\nJKKKK 948\r\nQQQ8A 972\r\n4484K 706\r\n9A6Q7 64\r\n343TT 46\r\nAJQ2J 523\r\n655T6 23\r\n4KK4K 15\r\n3TJK7 792\r\nT78T4 527\r\n3J57A 817\r\n24444 675\r\nK3459 599\r\nAAAA9 734\r\n663T6 658\r\n5Q555 456\r\nQQQ2Q 927\r\n32594 960\r\nT65KQ 841\r\n28T76 44\r\n97777 287\r\n66544 429\r\nJ5K58 135\r\n33Q33 236\r\n222J3 804\r\n64J59 532\r\n4335A 707\r\n3782A 195\r\nQ29A6 358\r\n89JA2 771\r\n26QQ5 650\r\nT99TJ 2\r\n635J6 637\r\n27723 106\r\n6KQT8 404\r\nT3TTT 868\r\n3KJ27 560\r\n6KAJ3 409\r\nKTKKK 724\r\n58T34 85\r\nQA223 136\r\nTTTKA 578\r\nQ44A4 989\r\n6J7J6 946\r\n2Q2T6 890\r\n34982 278\r\n2242K 548\r\nJ9333 181\r\n88448 686\r\n757QQ 38\r\n2KK2Q 340\r\n74JJK 341\r\nAJ8Q6 93\r\n7JJ95 757\r\nKK8K8 131\r\n55252 83\r\n9T557 269\r\n523T4 722\r\n9TA9K 207\r\nK242K 209\r\n26666 830\r\n8888A 768\r\n92QQQ 116\r\n2222A 210\r\nJ4287 417\r\nA55Q9 875\r\nTA74A 330\r\nQ87A7 160\r\n2876J 694\r\n28992 715\r\nA5996 954\r\n3J53J 90\r\n2A2JK 259\r\n8JA4A 936\r\n8QTJK 638\r\nTTQTT 113\r\nJAT79 455\r\n6J72A 606\r\n26J42 94\r\nT68KK 138\r\n4QQA9 919\r\nQ55Q3 869\r\n22JJ5 570\r\n4AJA3 837\r\n3TQQA 250\r\nAJAJ6 693\r\nAK9AK 372\r\nJ4795 576\r\n3235K 108\r\n9A88A 799\r\n2K5J6 933\r\n95QA7 613\r\nQJ7A4 838\r\n262QQ 787\r\nQ5J99 189\r\nKK7T3 262\r\n88779 342\r\n6QQ6Q 174\r\nA2656 119\r\nJ555J 393\r\n3T2T6 723\r\n562J3 767\r\nQ46Q4 422\r\nT3QQQ 897\r\n56T28 99\r\n95J32 182\r\n6888T 574\r\nTQTQQ 881\r\n9T9T9 353\r\n77KKK 289\r\nQT555 625\r\n56655 74\r\n84442 72\r\nJT883 81\r\nQQ7Q7 297\r\n5555K 337\r\n8A2AJ 371\r\nA4266 188\r\nQ5J52 964\r\nJ6666 406\r\nJQ382 825\r\n66J4J 253\r\nTT998 877\r\n4382A 622\r\n88AA5 460\r\n29869 374\r\nKK6J4 295\r\nK792J 268\r\n44474 612\r\n66669 947\r\n4Q9T3 990\r\n66K56 511\r\nJJ88Q 664\r\nJTTTJ 923\r\n49499 672\r\nQ7683 855\r\nJQQ66 232\r\nJ2KK7 383\r\n995KA 65\r\n4A272 52\r\n223QQ 620\r\n9J9J9 420\r\n289AA 63\r\nTTJTT 944\r\n339K9 45\r\nTA586 886\r\n46767 836\r\n65A66 871\r\n22499 892\r\n25533 292\r\nJT4T4 676\r\n447A2 592\r\nQ2KKJ 733\r\n777T7 26\r\n57T77 39\r\n73763 809\r\n77774 978\r\nT449Q 484\r\n44996 382\r\n7836A 464\r\n99488 667\r\n2333K 211\r\nAJ8KT 524\r\nK4444 284\r\n6AAAA 483\r\n5AQ65 940\r\nT67J7 766\r\n9QQQQ 811\r\nJJAJA 816\r\nQ8898 199\r\nKKKK8 77\r\n9J499 737\r\n24472 352\r\nKKK9K 709\r\n7887K 631\r\n588T2 688\r\nK72T7 829\r\n26578 831\r\n72AQ3 348\r\n38KQK 79\r\n76676 545\r\nKJ577 447\r\nT2696 239\r\n84A67 760\r\n4T6QA 905\r\nKKQT5 256\r\nQ9K25 190\r\n67TT4 820\r\nQTAJ6 149\r\nQ5JQ5 86\r\n5QQ56 173\r\n6KK9J 807\r\n77789 288\r\nAA666 815\r\n7742A 788\r\nA5T8Q 889\r\nQTJ75 299\r\nQ7QK7 717\r\n4QQQ8 102\r\n52J25 526\r\n33633 953\r\nT97A3 594\r\n9A48K 17\r\nJ87QJ 76\r\n2TTTT 433\r\n2Q222 660\r\n6626J 416\r\n6T5TQ 387\r\n3233A 778\r\n257K8 597\r\nJ77J7 957\r\n2777A 40\r\n6K666 538\r\nQ666K 271\r\nK3J59 339\r\nT4TJ9 441\r\nTA3JT 193\r\n65695 350\r\n4JKK8 761\r\n732KK 482\r\n6AAK9 980\r\nA8TA8 754\r\nTKK4T 926\r\n4K42Q 426\r\n793KK 286\r\n84Q95 25\r\n87K8J 461\r\n5588A 519\r\n34Q82 472\r\n86688 663\r\n57QQ9 581\r\n6K6K7 973\r\n26T2J 870\r\n2T983 100\r\nK269J 720\r\n752J7 712\r\nQQQQJ 731\r\nAJ5J5 31\r\n59QQ5 437\r\nK8TAQ 969\r\n38737 408\r\n58K88 756\r\n54379 493\r\nQ5Q44 1\r\nAAKKK 614\r\n99898 680\r\nT7T77 552\r\n3Q3QQ 111\r\nJTQJT 604\r\n824K7 739\r\nJ243T 965\r\n49849 682\r\nQ666J 513\r\nQ27K5 970\r\n888Q8 917\r\n87364 762\r\n885TA 180\r\n5T44T 517\r\n399JA 791\r\n366T4 301\r\n54858 928\r\n2TT39 997\r\n33A3T 579\r\n82883 492\r\n8A99A 765\r\n93939 480\r\n7K7K4 296\r\nA5TQ5 785\r\n3J22J 801\r\n8J688 466\r\nAAQ77 678\r\n9A68J 856\r\nTJ7TT 546\r\nT8A96 529\r\n33J85 649\r\nJ84JJ 369\r\nJ3QJQ 918\r\n8T4AT 746\r\nAT8TT 428\r\n8JJJJ 685\r\nT3A5T 430\r\nJQJQQ 247\r\n95926 818\r\n58885 424\r\n55K8K 312\r\nJA6JK 231\r\n7K8KK 154\r\nT676T 993\r\n5Q4A3 692\r\n5T455 118\r\n5QQ55 862\r\n42422 607\r\nQ4QA4 542\r\n66AA7 57\r\nA2K7K 547\r\n454K4 711\r\n5Q546 379\r\n7365A 834\r\nQA737 887\r\nJ3683 704\r\nAJKT5 474\r\n79299 772\r\n8K2TA 476\r\n6K6QJ 397\r\nT36TT 349\r\n68466 537\r\nK34KK 427\r\n92722 224\r\n95444 309\r\n44494 187\r\nKQT2K 795\r\nKK884 310\r\n5T399 3\r\n7A77A 803\r\n5QQ5Q 975\r\n4295K 89\r\n363Q3 313\r\n9KK9K 333\r\n44577 632\r\nJ4456 747\r\nJ86A6 205\r\n77J42 275\r\n28442 43\r\n3333J 654\r\n3754J 744\r\n49T85 411\r\n7A7K7 904\r\n6TTQK 853\r\n474J7 168\r\n44434 813\r\n3676K 324\r\nKJKJT 867\r\nAJ77A 551\r\nT42TT 681\r\nAAQA3 589\r\nKAT2T 197\r\nA422Q 98\r\n52JKK 619\r\nQ6Q26 144\r\n33666 600\r\nT85T4 237\r\nKTA88 536\r\nQ68A7 752\r\nJ7676 282\r\n7JK93 872\r\n98TA7 399\r\n35757 186\r\n35533 634\r\nKKAKQ 745\r\n9JJ2J 163\r\nT7K36 325\r\n8TAJ5 251\r\n28628 924\r\n7K723 7\r\n43626 139\r\n2QAAA 826\r\n77822 215\r\n7KJ79 567\r\n22J29 864\r\n88223 201\r\n645Q2 471\r\n9959A 458\r\n777J2 884\r\n9KA5Q 462\r\n6J464 88\r\nQ639Q 10\r\n5J595 974\r\nJ4454 146\r\n33JA3 54\r\n24228 49\r\nJ525T 996\r\n2J22J 549\r\n55JT5 20\r\nAKJ8K 583\r\n35635 645\r\n295Q8 914\r\n73TQK 615\r\n23333 229\r\n6J6K2 446\r\n282J6 502\r\n5J5A7 59\r\nKQQK2 504\r\n2KKKK 162\r\nJ3Q6J 510\r\nA8AA5 249\r\nATA55 593\r\n7A7A8 955\r\n7333Q 137\r\n6TA79 858\r\nTTJT8 117\r\n53939 509\r\n8848A 198\r\n9J2K3 402\r\n5Q855 418\r\n7KKK9 410\r\n44Q44 498\r\n82J83 540\r\nK89QQ 696\r\n82J87 293\r\n95T99 995\r\n54834 741\r\nA7865 396\r\n28262 73\r\nT4JTT 557\r\nT9T8T 977\r\nK2K82 29\r\n8686J 865\r\n77766 101\r\nQ5Q6Q 245\r\n423A4 879\r\n6AT29 515\r\n83J88 432\r\nAA62A 322\r\n777A7 344\r\n99994 727\r\n4297A 451\r\n3AQT8 157\r\n2652J 355\r\n4T4KA 640\r\nKA976 158\r\n22559 285\r\nQ7K36 842\r\n6655J 362\r\n555J5 764\r\n85887 367\r\n35588 141\r\n59995 805\r\n56Q6Q 208\r\n9T2Q2 494\r\nT4Q58 616\r\nA74Q8 366\r\n8J885 779\r\n96AJ9 702\r\n83333 67\r\n7TQ55 748\r\nAJ6KQ 679\r\n9999J 822\r\n87Q6T 544\r\nJ77TJ 882\r\nKK4KK 328\r\n29995 651\r\n3J33J 534\r\nK3774 721\r\n99599 556\r\nKT528 27\r\n38938 147\r\n5QKA6 876\r\n4K869 885\r\n8TJQJ 300\r\n6A22A 653\r\n68A8J 263\r\n6A666 588\r\n439QQ 863\r\nK8256 713\r\n57466 213\r\n923A7 384\r\nA9696 255\r\n7Q7JQ 755\r\n95955 895\r\n7Q279 800\r\n43895 140\r\n3T332 835\r\n5KK55 298\r\nKT2A4 591\r\n3K33K 930\r\n4TJ5T 500\r\nKA2AK 690\r\n45556 363\r\n76TT7 903\r\n333A3 13\r\nJ2TQQ 939\r\nKAKKK 782\r\nTT778 185\r\n9Q99Q 143\r\n77224 227\r\nKJTKT 860\r\nJ4K73 956\r\n737J3 377\r\n3844J 440\r\n34K4K 689\r\nA5A66 966\r\n2AQ5K 200\r\n27774 896\r\n227TQ 776\r\nJ448Q 673\r\n45JT5 221\r\n57J74 97\r\n55355 47\r\n8T888 641\r\nAAA3A 50\r\n392A2 774\r\nKKK7K 475\r\nQQ96J 35\r\nK444J 96\r\n44632 37\r\nJ52J4 220\r\n56839 644\r\nJ5TTT 438\r\n5Q49K 866\r\nK8888 742\r\nQK9K2 468\r\n2J4TA 951\r\nAA888 888\r\n5K65Q 356\r\n6T548 859\r\n9J799 261\r\n55KJK 165\r\n56AQJ 320\r\n77T82 844\r\nT8AKK 316\r\nQKKKQ 392\r\nT9236 448\r\nJ7339 639\r\nJ6998 705\r\n88338 82\r\n7Q5A3 929\r\n5JJ88 847\r\nATKQ7 783\r\nJJ22T 332\r\nT999Q 595\r\n5A5AA 773\r\n4484Q 987\r\n7622Q 950\r\nQQ44Q 602\r\n8T43A 942\r\n2A88A 95\r\nJ23T3 228\r\nJ7T86 42\r\n3Q66T 981\r\nQA28T 8\r\n5522T 925\r\n22437 260\r\nTQ758 759\r\n398JQ 582\r\n32Q24 272\r\nA3QQ8 315\r\n9QK6Q 906\r\nA25A4 580\r\n49JK9 214\r\nAQAAA 994\r\nK565K 572\r\n93792 812\r\nQT8QQ 391\r\nT9595 506\r\n468Q9 827\r\nA52J4 351\r\n98779 718\r\n344TT 848\r\n552J5 832\r\nA5JA2 573\r\nKJK7K 473\r\n63QQJ 699\r\n99799 503\r\nK2JKK 19\r\n448A8 443\r\n3K44Q 522\r\nKJ8KK 662\r\nK77JJ 623\r\nA5Q8A 912\r\n2K968 68\r\n7TTJ8 307\r\nQ4QQ7 621\r\nT68QJ 962\r\nKQ8Q8 375\r\n45A55 360\r\n27727 819\r\nJQ53T 900\r\n97979 798\r\n7T6QA 642\r\n77377 790\r\n286TT 218\r\n69A52 566\r\n444A4 854\r\n66TK9 610\r\nJ7777 740\r\n34J3J 901\r\n2QQQ2 821\r\n5A6J3 58\r\n863T6 910\r\n777Q7 624\r\nQ78K9 507\r\nK3333 652\r\n8J6Q9 439\r\n29TQ5 91\r\nQ2727 177\r\n6JK6T 571\r\n28J6T 240\r\n884JT 450\r\n58J85 541\r\n4K4KA 24\r\nKAQ23 314\r\n22992 601\r\n5J454 736\r\nQ3332 107\r\nAJ9Q5 710\r\nTA979 521\r\n6TJTQ 575\r\n29242 735\r\n3JJQ3 608\r\n7J252 183\r\nQJTQK 388\r\nAAQAK 802\r\n48775 248\r\n65666 378\r\n5389A 234\r\nTTTQ2 979\r\n7J7T7 71\r\nQ894A 603\r\n8Q86Q 6\r\n55T55 343\r\n33343 34\r\n3636Q 103\r\n5JJ5J 390\r\n8996K 633\r\n788A6 898\r\nK7777 985\r\nQ999K 114\r\n35333 732\r\nTK83A 53\r\n88887 235\r\n5TT5T 359\r\nQQAAQ 132\r\nQTTQ2 12\r\n25975 346\r\n2A72J 839\r\n888JJ 719\r\nKKKJT 365\r\n4QJ44 533\r\nTT335 636\r\n5J2Q2 459\r\n5556K 130\r\n97A39 148\r\n6A5Q8 133\r\n4A45A 104\r\n9TTTJ 233\r\n8J8JJ 338\r\nA9AJ3 413\r\nQK2QT 497\r\nQ929Q 401\r\n44949 899\r\nK666K 30\r\n555AA 932\r\n66Q6T 11\r\n65258 559\r\nA75AA 18\r\nK7QK7 814\r\nJ7923 217\r\n66667 226\r\n55K5Q 909\r\n9TJAA 562\r\n632AJ 294\r\nJJJJJ 488\r\n55KQQ 849\r\nJ6336 780\r\n2Q2J4 244\r\n285J5 698\r\n7QT3J 321\r\nKKKK5 555\r\nQ39K6 257\r\n4A693 643\r\n2T97A 665\r\n26624 419\r\nT9J95 646\r\nKKJKJ 959\r\n5J55K 700\r\n6TA39 171\r\n7TT74 487\r\n9K494 729\r\n44JJ9 449\r\nTAK79 984\r\nT2992 516\r\n9QK6T 938\r\n79272 982\r\n22282 695\r\n4JT95 920\r\n56AK9 142\r\nTT66T 252";
    }
}
