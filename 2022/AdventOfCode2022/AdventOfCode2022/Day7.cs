﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day7
    {
        public static void Run(int puzzlePart)
        {
            if (puzzlePart == 1) Puzzle1();
            if (puzzlePart == 2) Puzzle2();
        }

        private static void Puzzle1()
        {
            Dictionary<string, List<string>> dirs = new Dictionary<string, List<string>>();
            Dictionary<string, long> files = new Dictionary<string, long>();
            var currentDir = new Stack<string>();
            var path = string.Empty;
            foreach (var line in _input.Split(Environment.NewLine))
            {
                if (line.StartsWith("$ cd "))
                {
                    var thisDir = line.Substring(5);

                    if (thisDir == "..")
                    {
                        currentDir.Pop();
                        path = currentDir.Peek();
                        continue;
                    }

                    path += $"/{thisDir}";

                    currentDir.Push(path);
                    dirs.Add(path, new List<string>());
                    files.Add(path, 0);
                    continue;
                }

                if (line.StartsWith("dir"))
                {
                    dirs[currentDir.Peek()].Add($"{path}/{line.Substring(4)}");
                }

                if (char.IsNumber(line.First()))
                {
                    var size = long.Parse(line.Substring(0, line.IndexOf(" ")));
                    files[currentDir.Peek()] += size;
                }
            }

            foreach (var key in dirs.Keys.OrderByDescending(x => x.Length))
            {
                foreach (var subDir in dirs[key])
                {
                    files[key] += files[subDir];
                }
            }

            var sum = files.Where(x => x.Value <= 100000).Select(x => x.Value).Sum();
            Console.WriteLine($"Directory sum is: {sum}");

        }

        private static void Puzzle2()
        {
            Dictionary<string, List<string>> dirs = new Dictionary<string, List<string>>();
            Dictionary<string, long> files = new Dictionary<string, long>();
            var currentDir = new Stack<string>();
            var path = string.Empty;
            foreach (var line in _input.Split(Environment.NewLine))
            {
                if (line.StartsWith("$ cd "))
                {
                    var thisDir = line.Substring(5);

                    if (thisDir == "..")
                    {
                        currentDir.Pop();
                        path = currentDir.Peek();
                        continue;
                    }

                    path += $"/{thisDir}";

                    currentDir.Push(path);
                    dirs.Add(path, new List<string>());
                    files.Add(path, 0);
                    continue;
                }

                if (line.StartsWith("dir"))
                {
                    dirs[currentDir.Peek()].Add($"{path}/{line.Substring(4)}");
                }

                if (char.IsNumber(line.First()))
                {
                    var size = long.Parse(line.Substring(0, line.IndexOf(" ")));
                    files[currentDir.Peek()] += size;
                }
            }

            foreach (var key in dirs.Keys.OrderByDescending(x => x.Length))
            {
                foreach (var subDir in dirs[key])
                {
                    files[key] += files[subDir];
                }
            }

            var usedSpace = files["//"];

            Console.WriteLine($"Used space: {usedSpace}");
            Console.WriteLine($"Unused space: {70000000 - usedSpace}");
            var targetUnused = 30000000;
            var shortfall = targetUnused - (70000000 - usedSpace);

            Console.WriteLine($"To delete: {shortfall}");

            var answer = files.Where(x => x.Value > shortfall).Min(x => x.Value);
            Console.WriteLine($"The answer is {answer}");

        }

        private static string _testInput = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

        private static string _input = @"$ cd /
$ ls
dir hdwsmn
dir lmlsvqsw
dir rlfgcqz
dir sjq
dir tpnspw
$ cd hdwsmn
$ ls
dir mrrqnc
dir qst
dir rlfgcqz
$ cd mrrqnc
$ ls
227398 rwhw
$ cd ..
$ cd qst
$ ls
152795 bblss.hnl
dir lvs
$ cd lvs
$ ls
81813 jwvtjgjb.sss
$ cd ..
$ cd ..
$ cd rlfgcqz
$ ls
dir hlltch
dir jqpnnmwc
$ cd hlltch
$ ls
219753 rtgdsbz.qlg
$ cd ..
$ cd jqpnnmwc
$ ls
164333 dmvchsd.ncw
141721 njsfs.pmd
dir rlfgcqz
$ cd rlfgcqz
$ ls
278398 vhh.jtr
dir wfnpcnr
$ cd wfnpcnr
$ ls
dir njsfs
$ cd njsfs
$ ls
46895 twfg.gzb
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd lmlsvqsw
$ ls
81577 bblss
12519 dlghs.dcz
260260 gphgq.ztw
dir mldg
6570 qgbg
61210 twfg.gzb
$ cd mldg
$ ls
152240 bgddpvj.cgb
dir rlfgcqz
$ cd rlfgcqz
$ ls
dir dbvjfgff
dir dnnd
112649 qwhmdlf
dir wcqpzpp
$ cd dbvjfgff
$ ls
dir rlfgcqz
$ cd rlfgcqz
$ ls
278899 wmclvlvq.fbf
$ cd ..
$ cd ..
$ cd dnnd
$ ls
17486 zhqjt.dwq
$ cd ..
$ cd wcqpzpp
$ ls
195207 cvqtfn
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd rlfgcqz
$ ls
63895 gbwqg
35085 lllv.jpl
155195 nhrbwg.dcf
84099 wsh.sps
$ cd ..
$ cd sjq
$ ls
48652 dmvchsd.ncw
$ cd ..
$ cd tpnspw
$ ls
81312 ftjrpmr.mfd
dir gcwq
dir lvvztw
dir msrdg
dir ncgljn
dir njsfs
dir ptncs
263168 rwglhrm
192446 twfg.gzb
$ cd gcwq
$ ls
dir bblss
dir hlmm
$ cd bblss
$ ls
120988 qgbg.tcm
326021 tbvgfdnc.cvl
$ cd ..
$ cd hlmm
$ ls
287707 dmvchsd.ncw
319996 gpvfhpnr.jjl
$ cd ..
$ cd ..
$ cd lvvztw
$ ls
dir bdsvzhbm
155345 ftjrpmr.mfd
112094 qwhmdlf
9917 vnmtgsq.gcj
$ cd bdsvzhbm
$ ls
dir jmmltt
dir zgcjl
$ cd jmmltt
$ ls
130686 zsp.dcc
$ cd ..
$ cd zgcjl
$ ls
318547 dmvchsd.ncw
$ cd ..
$ cd ..
$ cd ..
$ cd msrdg
$ ls
dir wjp
$ cd wjp
$ ls
301898 bjccpf
97684 mcnqbl.bwn
160132 qwhmdlf
315893 twfg.gzb
$ cd ..
$ cd ..
$ cd ncgljn
$ ls
dir bblss
119737 gdc.mrs
196706 ggljwvgj.blh
162440 mlgnvbhj.gbw
163186 qwqlfwfw.mfj
167447 twfg.gzb
$ cd bblss
$ ls
dir bblss
dir njsfs
137986 nlmbnm
dir qgbg
229544 zhqjt.dwq
$ cd bblss
$ ls
186733 wcqpzpp.mmr
$ cd ..
$ cd njsfs
$ ls
dir tjbrtt
$ cd tjbrtt
$ ls
284955 rlfgcqz.ltq
$ cd ..
$ cd ..
$ cd qgbg
$ ls
dir dmcmw
15196 ftjrpmr.mfd
dir gbpqj
236891 ghlm.wlm
156863 qgbg
dir wfvqv
$ cd dmcmw
$ ls
116526 dhzhmj.qpw
251858 dmvchsd.ncw
dir ffqghmp
dir njsfs
148820 njsfs.zvm
290169 twfg.gzb
186117 wcqpzpp.vsd
$ cd ffqghmp
$ ls
dir wcqpzpp
$ cd wcqpzpp
$ ls
dir rfmsdjr
$ cd rfmsdjr
$ ls
291669 psmg.ldm
$ cd ..
$ cd ..
$ cd ..
$ cd njsfs
$ ls
35762 dmvchsd.ncw
97427 njsfs
261675 twfg.gzb
15426 wcqpzpp
dir zvnjrnrw
$ cd zvnjrnrw
$ ls
18370 dmvchsd.ncw
10620 wsgd.fjt
$ cd ..
$ cd ..
$ cd ..
$ cd gbpqj
$ ls
10204 fdlpjd.tgr
117954 rlfgcqz
$ cd ..
$ cd wfvqv
$ ls
dir fsq
133485 twfg.gzb
$ cd fsq
$ ls
156862 qwhmdlf
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd njsfs
$ ls
dir bblss
dir bzlpqv
dir cvm
dir dbbngm
dir gbtmsjgl
224200 nrffnj
$ cd bblss
$ ls
dir dhmwcmf
280202 hmp
66351 ndnr.wjh
85218 qhrhjb
dir tcqnf
dir wjv
dir zwlpqrb
$ cd dhmwcmf
$ ls
dir qtdf
dir scsllc
$ cd qtdf
$ ls
dir fmbsgvr
$ cd fmbsgvr
$ ls
1641 jdtcd.qhw
109819 qwhmdlf
$ cd ..
$ cd ..
$ cd scsllc
$ ls
dir brthfcm
dir qqgh
81391 rlfgcqz.pcj
192835 rlfgcqz.rnf
$ cd brthfcm
$ ls
135591 qwhmdlf
$ cd ..
$ cd qqgh
$ ls
270614 djjq
dir njsfs
$ cd njsfs
$ ls
18629 fngbfvr
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd tcqnf
$ ls
25594 gvqjrdlr.fps
314758 rlfgcqz.ndb
269846 wcqpzpp.gvz
$ cd ..
$ cd wjv
$ ls
dir dtddhqbj
dir njsfs
dir pgfrd
95552 pjzgwggg.hpc
29427 rlfgcqz
dir shhzzrf
$ cd dtddhqbj
$ ls
dir fmzhtfd
36982 ftjrpmr.mfd
dir gqsg
dir wcqpzpp
$ cd fmzhtfd
$ ls
dir psqnghl
226561 rttdhnnm
220713 tsfcpzzv
$ cd psqnghl
$ ls
136028 qwhmdlf
280539 rlfgcqz.nzf
129468 zhqjt.dwq
dir zlb
$ cd zlb
$ ls
dir qgbg
$ cd qgbg
$ ls
188576 ftjrpmr.mfd
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd gqsg
$ ls
302134 dmvchsd.ncw
161569 drzt.pmq
$ cd ..
$ cd wcqpzpp
$ ls
254804 bblss.sqp
280941 dbvw.mdw
dir gfs
317925 njsfs.wpr
dir qgbg
$ cd gfs
$ ls
dir jrctzlg
dir lrnzq
233927 njsfs.bmd
45942 twfg.gzb
125290 vbtr.wvj
dir wcqpzpp
$ cd jrctzlg
$ ls
88635 qwhmdlf
204938 vlnwcv
$ cd ..
$ cd lrnzq
$ ls
253736 bblss.ddj
272769 vsrvgsc.cwl
$ cd ..
$ cd wcqpzpp
$ ls
301739 ftjrpmr.mfd
63733 qwhmdlf
$ cd ..
$ cd ..
$ cd qgbg
$ ls
dir cpr
196886 hgj
188348 lqvq
132024 twfg.gzb
213866 zhqjt.dwq
$ cd cpr
$ ls
dir wznlzpzj
115532 zhqjt.dwq
$ cd wznlzpzj
$ ls
dir bcwnrc
$ cd bcwnrc
$ ls
289013 dmvchsd.ncw
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd njsfs
$ ls
296178 mpprqbgc
128104 zhqjt.dwq
$ cd ..
$ cd pgfrd
$ ls
dir slgztr
$ cd slgztr
$ ls
dir htjd
dir rlfgcqz
243751 twfg.gzb
dir wcqpzpp
$ cd htjd
$ ls
216650 ftjrpmr.mfd
$ cd ..
$ cd rlfgcqz
$ ls
144834 qwchd.qtn
$ cd ..
$ cd wcqpzpp
$ ls
133476 qwhmdlf
$ cd ..
$ cd ..
$ cd ..
$ cd shhzzrf
$ ls
dir hbp
dir jqfhdn
dir qgbg
dir tftrnfpd
dir zppjlf
$ cd hbp
$ ls
158562 fbwsrbbg
297036 zph.mbd
$ cd ..
$ cd jqfhdn
$ ls
166463 bblss.sgd
125240 dmq
48389 ftjrpmr.mfd
dir njsfs
dir rlfgcqz
$ cd njsfs
$ ls
dir tbjp
307427 zhqjt.dwq
$ cd tbjp
$ ls
76200 rcfv.bgh
$ cd ..
$ cd ..
$ cd rlfgcqz
$ ls
294331 bblss.vwj
$ cd ..
$ cd ..
$ cd qgbg
$ ls
dir qnpdnjdl
dir rdmj
$ cd qnpdnjdl
$ ls
dir sblj
$ cd sblj
$ ls
39051 twfg.gzb
2405 zhqjt.dwq
$ cd ..
$ cd ..
$ cd rdmj
$ ls
213965 zhqjt.dwq
$ cd ..
$ cd ..
$ cd tftrnfpd
$ ls
294450 chbgd.vjv
318594 hvwbj
dir nznzzw
96252 twfg.gzb
dir vlfdtwj
dir vsvj
dir wvnjtmt
dir zlj
dir zwqff
$ cd nznzzw
$ ls
115971 nndbd.rhl
$ cd ..
$ cd vlfdtwj
$ ls
167648 ddvqzlh.cpw
$ cd ..
$ cd vsvj
$ ls
dir dfzcrmt
dir ffpvbczr
110196 njsfs.zsh
257204 qrgnw.mhw
dir rptmp
131871 zhqjt.dwq
$ cd dfzcrmt
$ ls
dir hqbthjc
dir hztrwjr
11874 rsd
252800 zhqjt.dwq
$ cd hqbthjc
$ ls
135533 bblss.clm
231343 rlfgcqz.zfh
176061 rrzqhdp
$ cd ..
$ cd hztrwjr
$ ls
dir zmpm
$ cd zmpm
$ ls
297930 rpb
$ cd ..
$ cd ..
$ cd ..
$ cd ffpvbczr
$ ls
dir qdvppt
dir qgbg
$ cd qdvppt
$ ls
323419 bblss.lnl
$ cd ..
$ cd qgbg
$ ls
158408 dmvchsd.ncw
$ cd ..
$ cd ..
$ cd rptmp
$ ls
280342 rqlbtpw
$ cd ..
$ cd ..
$ cd wvnjtmt
$ ls
dir bblss
249330 fgc.ftp
dir gtbbfzzn
dir wcqpzpp
$ cd bblss
$ ls
1570 zhqjt.dwq
$ cd ..
$ cd gtbbfzzn
$ ls
65850 lmbrdhc.jbz
$ cd ..
$ cd wcqpzpp
$ ls
62362 qwhmdlf
$ cd ..
$ cd ..
$ cd zlj
$ ls
103758 lrhflmsw.qhq
163919 qwhmdlf
$ cd ..
$ cd zwqff
$ ls
dir ghfc
dir njsfs
$ cd ghfc
$ ls
131979 hpcgrvms
$ cd ..
$ cd njsfs
$ ls
126387 wcqpzpp
$ cd ..
$ cd ..
$ cd ..
$ cd zppjlf
$ ls
241176 rlfgcqz.ctz
$ cd ..
$ cd ..
$ cd ..
$ cd zwlpqrb
$ ls
272627 bblss.gpv
261635 blczb.srs
dir lnhzzl
153210 njsfs
55633 twfg.gzb
$ cd lnhzzl
$ ls
dir dtwcsvzf
$ cd dtwcsvzf
$ ls
74858 dtz.rpc
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd bzlpqv
$ ls
157801 gdqhdd
318418 nmq
266938 qwhmdlf
$ cd ..
$ cd cvm
$ ls
1145 dmvchsd.ncw
233344 ftjrpmr.mfd
263393 njsfs.hvb
74436 twfg.gzb
dir wcqpzpp
96596 whq
$ cd wcqpzpp
$ ls
dir rlfgcqz
$ cd rlfgcqz
$ ls
244048 gspw
324759 qgbg.wrf
190410 qwhmdlf
$ cd ..
$ cd ..
$ cd ..
$ cd dbbngm
$ ls
dir bblss
184222 bcfzt.grj
dir rlfgcqz
41851 sshb.nzv
113784 wgjc.mrr
13594 zhqjt.dwq
$ cd bblss
$ ls
102201 qwhmdlf
$ cd ..
$ cd rlfgcqz
$ ls
91063 bblss.msn
2918 dqhbnt
74771 nbprqmbs.jwj
$ cd ..
$ cd ..
$ cd gbtmsjgl
$ ls
207664 cnfpq.wbl
$ cd ..
$ cd ..
$ cd ptncs
$ ls
dir bmpts
dir bpmf
dir brhp
dir gzjppjfr
dir jrd
321627 jss.jsh
130602 lfmrp.csp
dir prfz
dir qgbg
dir qjgchtwb
dir rvqrjms
174888 ttmwlrs.wbc
dir vwgsmc
55854 zhqjt.dwq
$ cd bmpts
$ ls
124846 dmvchsd.ncw
283278 mlcmzqdf.pfj
dir plbpr
312240 qwhmdlf
74910 rlfgcqz.jqp
dir tvrvwv
$ cd plbpr
$ ls
37432 dmvchsd.ncw
dir wcqpzpp
$ cd wcqpzpp
$ ls
18638 bsfsc.gfs
$ cd ..
$ cd ..
$ cd tvrvwv
$ ls
dir tsgp
$ cd tsgp
$ ls
141689 wcqpzpp.jdc
$ cd ..
$ cd ..
$ cd ..
$ cd bpmf
$ ls
201372 ftjrpmr.mfd
dir nhtjhsp
dir qgbg
dir sbqfdzh
dir wcqpzpp
178078 zhqjt.dwq
$ cd nhtjhsp
$ ls
225213 ftjrpmr.mfd
$ cd ..
$ cd qgbg
$ ls
214193 cwnphff
296165 ftjrpmr.mfd
260246 zhqjt.dwq
$ cd ..
$ cd sbqfdzh
$ ls
281546 njsfs.rjz
dir qgbg
246263 qqbsjtp.nbn
10231 srllsw
$ cd qgbg
$ ls
92801 dmvchsd.ncw
66784 pbz
226132 wcqpzpp.vjs
242775 wgt.bbw
$ cd ..
$ cd ..
$ cd wcqpzpp
$ ls
55886 bblss.vzh
313619 rlfgcqz
$ cd ..
$ cd ..
$ cd brhp
$ ls
321184 nnfzrm.mgz
190867 rlfgcqz.qbs
$ cd ..
$ cd gzjppjfr
$ ls
67036 ftjrpmr.mfd
$ cd ..
$ cd jrd
$ ls
293867 dmvchsd.ncw
dir drjbp
dir njsfs
10759 pcpvd.hsg
dir qfghvhsr
dir thf
268195 tmwvbl
$ cd drjbp
$ ls
dir ccdmcgvz
276381 gbhhwlv.rlt
252224 zqt.wpc
$ cd ccdmcgvz
$ ls
4082 cffmcz
31006 mws.tvb
dir njsfs
$ cd njsfs
$ ls
dir bblss
$ cd bblss
$ ls
180561 lfd
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd njsfs
$ ls
115688 qgbg
34653 qwhmdlf
$ cd ..
$ cd qfghvhsr
$ ls
3280 ssg.ctr
$ cd ..
$ cd thf
$ ls
dir bzhbrlh
dir qgbg
$ cd bzhbrlh
$ ls
148423 wjtlhwq
$ cd ..
$ cd qgbg
$ ls
dir rrtb
dir slhbmldf
$ cd rrtb
$ ls
30387 rlfgcqz
$ cd ..
$ cd slhbmldf
$ ls
dir vszhrc
$ cd vszhrc
$ ls
235629 qwhmdlf
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd prfz
$ ls
254587 bblss
dir bmfg
dir bsw
dir cfjdjcmt
321761 dmvchsd.ncw
35369 ftjrpmr.mfd
dir nqrbhdcn
237737 rlfgcqz.wsp
dir smdsrzlc
25049 tbwfsp
$ cd bmfg
$ ls
dir bblss
275693 wcqpzpp.zvw
$ cd bblss
$ ls
dir lddn
$ cd lddn
$ ls
dir mqlpwvcg
$ cd mqlpwvcg
$ ls
34635 zztv
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd bsw
$ ls
dir ljqv
dir vhpqbw
$ cd ljqv
$ ls
119525 ftjrpmr.mfd
$ cd ..
$ cd vhpqbw
$ ls
154199 twfg.gzb
$ cd ..
$ cd ..
$ cd cfjdjcmt
$ ls
22258 zhqjt.dwq
$ cd ..
$ cd nqrbhdcn
$ ls
dir bblss
84121 fbgqdsn
232625 hrjft
201822 ltfpl.lsq
194572 pgbqncwc.vqq
43024 qfgrmw
dir wcqpzpp
dir wvtnznjn
$ cd bblss
$ ls
326048 jctnwzn.zcq
$ cd ..
$ cd wcqpzpp
$ ls
265643 bzjmjng.vhr
dir lwt
dir qgbg
164876 twfg.gzb
dir vswqzjc
264349 wcqpzpp.lzp
$ cd lwt
$ ls
156024 ftjrpmr.mfd
287930 lmjwqw
dir qvr
56184 qwhmdlf
203952 twfg.gzb
95508 wcqpzpp
$ cd qvr
$ ls
dir ndqmn
$ cd ndqmn
$ ls
153880 njsfs.fvr
$ cd ..
$ cd ..
$ cd ..
$ cd qgbg
$ ls
244154 ftjrpmr.mfd
dir pztf
dir qgbg
dir rlfgcqz
dir zpvcn
$ cd pztf
$ ls
dir njsfs
dir sfrbvhp
$ cd njsfs
$ ls
268512 dmvchsd.ncw
$ cd ..
$ cd sfrbvhp
$ ls
dir wcqpzpp
$ cd wcqpzpp
$ ls
2126 dmvchsd.ncw
$ cd ..
$ cd ..
$ cd ..
$ cd qgbg
$ ls
123331 zhqjt.dwq
$ cd ..
$ cd rlfgcqz
$ ls
4261 lflphd.cfn
144504 twfg.gzb
110656 wcqpzpp.cjr
$ cd ..
$ cd zpvcn
$ ls
259119 qgbg
$ cd ..
$ cd ..
$ cd vswqzjc
$ ls
dir qgbg
dir rlfgcqz
$ cd qgbg
$ ls
76795 qwhmdlf
dir wcqpzpp
293923 zfcwvpz.vrn
$ cd wcqpzpp
$ ls
296986 qwhmdlf
$ cd ..
$ cd ..
$ cd rlfgcqz
$ ls
dir dtwv
dir rfbrzf
200095 rlqrlh
$ cd dtwv
$ ls
306977 bblss.dzm
139644 njsfs
$ cd ..
$ cd rfbrzf
$ ls
96622 cnb.wdl
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd wvtnznjn
$ ls
320558 lvtrqjnv.twq
$ cd ..
$ cd ..
$ cd smdsrzlc
$ ls
dir mbfqdbl
$ cd mbfqdbl
$ ls
dir hrhc
$ cd hrhc
$ ls
110162 hgbng
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd qgbg
$ ls
41978 mrfvnb.zbh
172912 rlfgcqz.qlf
$ cd ..
$ cd qjgchtwb
$ ls
243299 dmvchsd.ncw
91104 jbwss
207317 llqnrd.czw
145298 znzb.lsj
$ cd ..
$ cd rvqrjms
$ ls
40049 twfg.gzb
$ cd ..
$ cd vwgsmc
$ ls
dir qzl
dir rlfgcqz
dir tmpjd
dir vqt
$ cd qzl
$ ls
324024 cspbrpgv.fcc
8468 hfdwz.bjq
dir nvrpj
46755 qgbg.lhn
247926 qwhmdlf
dir thtq
17180 wcqpzpp
$ cd nvrpj
$ ls
dir vpscvbj
$ cd vpscvbj
$ ls
225620 bvrzrw
$ cd ..
$ cd ..
$ cd thtq
$ ls
dir pqqhcl
276922 qwhmdlf
59145 sshgg.bcf
dir wclbp
$ cd pqqhcl
$ ls
123067 vvhlq.bbg
$ cd ..
$ cd wclbp
$ ls
dir djbbpzjz
$ cd djbbpzjz
$ ls
5446 wtn.gnz
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd rlfgcqz
$ ls
dir njsfs
$ cd njsfs
$ ls
178834 flrr
$ cd ..
$ cd ..
$ cd tmpjd
$ ls
1973 fnlwgc.rbq
240728 njsfs.sgm
dir qgbg
51532 qgbg.vdc
330859 rdvzpf.lld
dir sjlq
259561 twfdn.vnm
dir zlbmf
$ cd qgbg
$ ls
273408 bznqvg
45710 dmvchsd.ncw
306311 jcvn.brh
269315 rlfgcqz.crg
51046 rnqb.wlt
dir wqfprrd
dir zjscb
$ cd wqfprrd
$ ls
276417 zhqjt.dwq
$ cd ..
$ cd zjscb
$ ls
276541 bblss.dhl
dir mlsdv
dir njsfs
$ cd mlsdv
$ ls
251030 qwhmdlf
$ cd ..
$ cd njsfs
$ ls
dir cfmfsbc
$ cd cfmfsbc
$ ls
234880 zhqjt.dwq
$ cd ..
$ cd ..
$ cd ..
$ cd ..
$ cd sjlq
$ ls
25547 nqvnpgs.zhl
$ cd ..
$ cd zlbmf
$ ls
21812 pjn.hbf
dir rcgvwrg
$ cd rcgvwrg
$ ls
19512 qwhmdlf
$ cd ..
$ cd ..
$ cd ..
$ cd vqt
$ ls
80263 njsfs.zmr";
    }
}
