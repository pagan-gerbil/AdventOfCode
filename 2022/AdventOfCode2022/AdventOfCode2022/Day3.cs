﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3
    {
        public static void Run(int puzzlePart)
        {
            if (puzzlePart == 1) Puzzle1();
            if (puzzlePart == 2) Puzzle2();
        }

        private static void Puzzle1()
        {
            var lines = _input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var total = 0;

            foreach (var line in lines)
            {
                var part1 = line.Take(line.Length / 2).Distinct();
                var part2 = line.Skip(line.Length / 2).Distinct();

                var answer = part1.First(x => part2.Contains(x));

                var score = char.IsUpper(answer) ? (int)answer - 38 : (int)answer - 96;
                Console.WriteLine($"{answer}\t{char.IsUpper(answer)}\t{score}");
                total += score;
            }

            Console.WriteLine($"The final score is {total}");
        }

        private static void Puzzle2()
        {
            var lines = _input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var total = 0;
            var counter = 0;

            while (counter < lines.Length / 3)
            {
                var group = lines.Skip(counter * 3).Take(3).ToArray();
                var answer = group[0].Distinct().Single(x => group[1].Contains(x) && group[2].Contains(x));
                counter++;

                var score = char.IsUpper(answer) ? (int)answer - 38 : (int)answer - 96;
                Console.WriteLine($"{answer}\t{char.IsUpper(answer)}\t{score}");
                total += score;
            }
            
            Console.WriteLine($"The final score is {total}");
        }

        private static string _testInput = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

        private static string _input = @"QJRBMDMtRDCtJzBtJMfjNjhwvmNDvwjLVVgh
TPSNNPZGTjgmSmvfjL
bPlpZZbpsTlTsWprpGFCJtRtzMNdMMBBcWnJQB
tppvbQBhpQQdrzMMcLwhMc
gZnWRccRNgFGRGRFRNNgZgJMddddLLLMCPqwLCNPwqPJ
nRRmFSnWmlgZlTlTllSlSWWWTsfvfDQpBfBcpQvpVQpTfQQf
lRlsVFgTlMgRNsSNTlFgmbWnMPppPnMqWZMWPPWW
fDjgBJdCfCHHBnfLWpqnmnpZmf
GjQHHcdvJHQBHSSNsFQFslwwRg
NPwDLDHNwjLLHWjbdSbDfJJQTZsZDS
BcFBcvgFvghnFLrBpvrgcgrJSZJpQdfSTZbCsSdfZZfbCf
VrngVFRmrVWHLGVMlL
SNBBBDlfZDLqNGmgFjjmBsQgCFtF
VPPVbhpbhMhRhncnScRncbrQtCgQQFmjjjsgtRtQHmFQ
nhWcPJVhpbvMvwvwllvSlGlD
wNlNNqtqHHHPhqCz
MMMMcQSWSpQCWFnRRPchLVvPLLzhmhLzhh
CrgRSWrnrQpppRQrCTnRTRtGtBDBfbNBllbTJlZtfNBN
QNbbNrnNnCwHmNPQmzqQNPsCCfBFFGtsBBddBDtCJDJd
gvVgpZWgTWvRvlvLPDDJjGBfdsdpDDJGdd
ZRMWWRMVgRZghTggPSMZzQwwnqwmnzhNnNwHcQHm
VmPHzBmpmQHbVHSpNHBVQCtRPPCPvFFMqqntZCZqMR
dWlDcfcfcjcfDWjlsZfjJhdGvFLGnLsLqsRnvRvRGGRttC
wfJhZTllcfdZdfjJfjdmQzHVSzHzgHQTpHpmpV
qNnqmzmCBfvmDvBm
HcdhtQdttbbhtVcrVVDMfZvdMBTqsWZMBsWZ
HQGtctRblwqpNwRN
SBtBLBMZzPDDNFFDQnVVVnnDmf
dgCjblRdgRvrbwjJGzQQQzwJVJ
WpWbCWWvlgrcCHdvvCdvWbSLZzhhZhtLBPPStSPhMSpM
PlPnGGGzCqqlrqTRsbTmFRWgDPmR
wwpLtjwpzjDwFWRsWTWW
NZtJjHNNhHfnCBcJMBlCSz
wSrwggPrhJhCdddw
tLMNvMTFhDZdhTBh
LtMvFttGbNcWRsLFLsccRRgfnSrPjPnfljSfPWlnPhrS
TSZlwZSSccSHZLHVcllSvmDLmJhjDDffJmGjQjgQQJ
sdBdzsNnBMBstNNMFhNPNbPzgGfDgJrtrfjCjDrCfJmmDQJf
BnnBznRsFRFBsspzzbZpSTqVTpHVhpTvlqVW
VtVjjhdFmCCfhRRzzSDbDzpmgzmvgb
CHJqrswsWvbvJbpD
CqCPcZHGHTcsCBQsBrTGHMFnLVQjMjLVVhdhnFQVRL
tvlPSrlNNvtglTtPccldQdhbQbZdcqqZ
mRmBGHWmDFRsZqHrfbdhqhZZ
jjMGjWrJpttNjtgg
HPtCMJNjvJLMDZRdBgLSBSfsWBgG
VmnrhwwqhbbzrwnDrqpdWBgfdSdfBGgffGWRdh
qmnTFbVnpqVzpnvlDFJZDClNZPZN
NNRFQfzbNWhLHTVh
dGjptnrPqgvqjccvndnnPPhlHrVVTHLWMHlwmrlHMmVTWm
tDggGnPqDcPPpPpddjGhggtJCCSssfJbQsDfbZsbsbRZFQ
bqZWhbvvvqfvhqvQCChhZlllGwlwGjNRrNGrwGwNRQ
PmspSscJVJStzSVzWJlgwlwNlGRLDGrPgNwN
pdHmWMVStWJWFBBCCbMhCfbC
wtwbctGLwGWhGwfWwhNrnLrlrQFNmPNNVrrl
CSdqZRsMStdJMMSZqPnFmVqPQlnjNjqj
TMtsTBSSRZBCJStMJSZTHtfvpgvzzWwhbpwhggbzHpbW
HncMbCwCncHlcbMDMnMFGsNsJVFJGchVTTcmcG
RRfBRNjRLLJTLTThsq
zpBRjWRrRvBpNtRWrgwbrwQPDPMDwCnn
TDcPLTVRjntFwDwDnb
SJJhffHqHZZgHGSFFbdrGTGnGv
NQHWZgJQHNHgHQhlLLLBjpRTjLjMNNLM
sMNnNRNrlGlsZBrGsrFQpclWlWLfpWjtzTfDtpzj
gvhPgwTgdSHtHDtpDPLp
gwhSwdvTSTbSgRrZNrrNFFNBGb
rtZnDHJrrDtGtGHvGHDWfdfwCjcBhjBCffwwLv
lzVlzsTRsmzVNTspVsMMsmwCLcmjmcdbBBChwfBbCW
sVTMpTpppsVMsPRPVzMNFqMFwZtQrHZDGqgHZrSQQrQQJDGn
wGQQMMQvCTPPQnHPBS
FsWdJddszWrrRRJRTmRmpppRHBNPBppNHp
rWdFWlFJzbzzMTwcvvMbGMgc
WTnnTpqSnCLmjGgSgjztgg
rQRHQvbNLwrgtGtrmDglJt
PwHRNvQPsvHvPTTpLTcCLVnq
qTsqJDJHjjfMCSDj
RnGGNFGznzGVnBCWmfSMSLwWRwSj
NnBbVQFVCClctHQc
BHzmfDHfJLGcQBGgQLDcstNttlZgdlltldshgZZg
PwPPSJwPvSNZlvSl
CJwwjnJFFnWRMcMzcHMHRzGL
rmZpvcZcqccsqmqzzzcBRLBZbBBRLBlRGVdfZR
PwjFggwMDgNFwPgTwNFgtFJjfGLhBLsGRGbfBfBLbbTVLbdf
DWJwgDWMJJDWCCNHmrnscmqqcnpWSQ
bsRlVgMhtzHvhRvpzcLSZcTWLGzTTrGc
QJnDjmqjJdmDqqrGWWsZsZTc
nQPsnwCJdBDJDDJvhHhpMRCVlhlgRV
NBNwMCtNgqCHClHClq
JpQmFrQQfHfWjJTfLTjfLRRFRvnvhvnDGDcRcvVGGV
HTzzpzzdHgbBZZtdMB
SWcVvBFBVBjShWhGQtZnHFDHRGGQsR
pMZpmmJPbwbTTQttrDrRrttT
mZflqdlbMVcNjdWLSj
tvjdccdbLjhvhlcjRMvRTCQJmBPBCFRG
qgnqZfHpZDVnCpZzZJQFQBgmmPFJBmRQJQ
SHDZDDzpNVpfsNsHqpDSjLwCbbWLChwtwjtCWc
FsWTbcwmGfFFFrpl
LMhzdfqjLdHQQnSvldGvnS
VZjVNzfNLtjzDMhVDNtqDqwJwRmmmZJgmgcbWgRRwCbJ
ZJbPwwfJcGlwCrrZrMMddMMMtt
pTNvvSSHmmnbpFRp
SLSjSLDSQNLHNDbJbcfJclBzjGsz
WSQCWQWstCWCCgNNsDCZMZDBjjlLPnHMMLPrHlcrcLHHTjTh
bVFJFwfdRFFgjTPgnc
GmzRRqvRddbdRRdfJRJfsqsSSsZDsDBQZtCSgpgt
FPjprPpPCCFpFPHWsWvqnnllQsdLQMMlLtslLQMc
wmzJgzRSRRJghBbwGBBSbtGfLfGlcNnlltdddQtrMd
zDmRBmwDrpVFDTVDVp
FPGqjsZGlDJmzsHcTcTMMs
SQNLSvdbvVbrSbHcftGcrpHGfMmf
CNNGSCCdSCZqjqljZF
GvqpqrpqdqdsdGshSMhhRsSMhhlSlJ
DLCzzjzBwCbQWtQlRRFRRJFptfffgM
WzpLbLDbBcLPjWQWDBzzmnvNndHNqZqZNZNvcrNT
scHCGfWHsvWHVfGsggHfgvVcSLwLLPRwwDLPLllRPDzlPr
tbjqqNNTlPDTTSrD
QntmNbNnnddqJqqbFJHZWWHWJWvZHGVJsSsp
WZjpjwwGBGZQsqBLBHLHSRLP
mJhtdfVtDVJtvVLSmNRSccPPPlNHcH
JJLCFDhLCfVGGwbGGCwrGC
nBnsGSCrptmsLWGhWRvVRJVJ
rllMZZbcWWLJvhTl
MHwzczHwwHqZcdzMdbqSmwsssmtNCrBmtrnQNB
LzwrZNrNzBMrJBzJsfqqntMlVlSfhnhb
HTDPWDHPTgGHWTGcPFRgFpPPtfqmsfqlccmlSmnblbshqnmm
jWGgpRGPFRHjzdBBsrBJvj
hjNghjlwqjzGhwhGwLrMMrsMdsMfczPfsr
ZJQSFZFZpCTQSZHTTFbcWWPbWsWrdLVmrMWMfr
tttHSCpFQBQQpJZSJLgBNNDhqhBqvBvvRq
hLLJJJLcLPLfLwcJDchfhpSmqGbmdQGmGSdbqdbmqGGGdG
zgCCVVvVCNVssdbqmtMWvbnndD
rCCZZCVTjVZNzFZJBlflBLccDhBFFB
wwPPHfCMHQsrcwPbMPMcvQFJvqWgFTZgDFJltgZt
jRBVLhpNqpBmRhhRdNJZJgWTBBtgZWltZJJJ
mSjndhSzphjLRVqmhphNShrGMGrcbGbnGCHGwrwGfbbG
PVBRhBdlwRtRhRBwtBlVzDcGpVcZnggGzGMMsg
fFFWQqbFbLWCWvvFbTjjGnsZMfgsZcZzSZGMpSgD
QJTCCLFFLjFqFbHTbbltmhBNwwcNmthNhlHr
qwPJJsJdbPdwJddQCRCgCTMTRGGwMG
cLFcFBZNWWQLSQRfZjpljTGRCgGR
cFvrcNBFJDhzdQzv
zTsVTqDqQNtNwwMVmN
pHpSzPbRrvbRrGzGMwZwlBJmNtclwJpB
SjHRPfRbffPHqzCCCdTsTzqj
jnbMBnPjjjFtBtMjFPRtGfvvfzgWWHMfWHTlGgHH
dCpdqrVrmdpHfTJTCWGJgG
qVdrppqSTddqNwZcDPPPhZRBPBLBRLjF
VbHqLlGQlgjLjjQsNvCZTsNjMtCZvT
SJtttppwwpwBwdPvsvCvBZrvNrTrvM
JDnWJpDSSpmSwmpPzSwznhDlqGqqtqqHGHLlhblGbR
RqRJJVMPdRVVpqMdFwmvnSMwZcfCGfDSZc
CssQgjssvZvjffmS
zNlbbWTBLWCbCPPFPbVH
nvQsHSsGvNvnQghTRMrrjpjM
ttlLDlzPtGDcRRtpZTFjtgMj
PBLBwPPDzzLwblzffzLlVHHsCCHqsfvCCSsGSNWC
jHrTrThrtHgttThgHTtfgTgsmZZmBSZGSGsSGfZBZFFmQs
qCCPdbcCJddbRcsQSGhFzmZqZGmq
VVNNdVvclDcPbMWMwnnlwhphjp
ZdBgJqFWNNNqnZZNGsBCCCRvrCwCjCssCB
htDPMSPtMPzPTLMzMTMbRRbTbvwRCjfRfsbWWs
LhMmtMDWmHlpppplJZJgNd
mhtsjtbChcpLqmpmzL
DPlPprrfBrpGHHVGNVHRqcNvvLLqLcvJzzTvLc
VFfVPrrBQFPlDDwDwBpBtSgQjnghMhCdbSnnhtMM
DPDMpbsHPDPNtdtrgMtdnQ
WShWlSCJVlzccSBvBvhVZZWlgTNTrNrrQTjQjjjjgDSgSdNt
cvmCDvCJCcsRbmpFmqms
sSfFssmLnLwPtrrmttsFbDvWgCvddVgfgWdRDWlChD
nnGnHBzqHjqBJGChlRClhvghJWDd
jNzNcczMcGntPMwwSsSr
GGPCThCCvCTVWBCBGMVMsTgZJsrZtHNNtrsHJrgH
zjRwcwwfvSjmwznfzQSHDJtgrNrRNrLDsRrHtD
fjvzmcfSlSznwcnmnSQnhdlhWBpGpdBqhGhqhVPd
sHGGqpRqfNRVbDDtVwwzWf
CCLQZllTQLTcSShTQvjhQLnnWrDzVpwtDDwVDnczwMwM
vggZLZTldlhpCTlZlZCRRPNRmqdmGBHPFqsGqN
wwFDFLMDjjCNgNwNlwwgvR
frPbSJMSSPBqrfppSqrBZqMQhHlmNsRZmmslvghsmhsgggtZ
TPSPfBQrdJSfTTqSbbBfTfdcGWjFWWFDWnGMjLjGVFCj
LZRZbHtqnVztHTTTjMBQjQHH
rJcDGpwwgDwCCWFGSFMSffVWfF
cNNNgvhNglDnhdzsbLbmVs
RwmrGVPmNLzdmVpmrVtHDjjgDHHRqjFtngFt
CBlWhQWlTWshsblFGntjHtGbHG
WsTSGZSTQZZJpPNdzSrzwvpr
CVsggSgdwSwghVSTCgVZjJlRvlQNJHJGZVvjvj
qrrnzrrpDFMzbDbbzrMbBcNjRBHHQHGRRllHHPBNBljl
rnFppcpWcqnWMLDNsggSmWmsWfggdg
wjQzPjJcplwmDDBL
vghWhhnfWqzhftWtfnbFBmnGDnLGDbDmmC
zZNvZrNsWfgVftNZhQcSdPHPTcPHQQTTJV
WjvPVbWnbbFvjfLlcplQvLQvCwCl
sJhmrrTRTDDJHhhsmJhmrNDdQwLQQlHllHwwLpCLclBBlcPC
RJTRDdmPmmzNTDhnWtzMfMWtqjqqWM
vvpjqtllDMlHDtDBsPSSfBJFlSffNS
gwTmJrTcJWrNSmsNBBPfmf
VzzJzgTnddzWrwngnWqbHqbtLqjqvpvqhbMd
TlpzwGZGGFmZJdPpRtpHPrpcPs
CMJCMgQjMQvrfMHtMfHv
DjnNjCBqCCNnWWgDBQQDnCZwFJwmwwTznmFVwFmzTJJm
CcDPppDCFdDrFcFsMsdlLVjjLsMHvM
fqSmmtNGqLNffhHHbsMsbjbjNjbv
SthSGmLnmfwfWGWhSQGSQRnGpDpJPCDJrBPTcPrDwPzFcpFT
FdqjDtPWzqPdnPPtPFbssllqLJlqNppsJGppLp
TwfrcvwRgvfTBWRgBssJhspHfffJHlHNGh
MMZCQrrRBwQCCZMQwcTMwPztnFZSDWVWPttPSZzdzd
prHlrpJbdccllrrPbFdrgPzZfZhZVhRZVScNRNWtSZjWRW
LmwCCnvqwGCLMnsWtGRZWVfbfbftRW
bwnvBnLBvbsBvszHzpgBlPzHHlzg
grSJNTSgBHgpqhvCGbbZddGCGbbT
nDLMssQMRLwMtMWRWCZdQfqjfGvZQfCjCc
PqsDWPMLnwlRllJzghmgmSNhpgrl
TQGcWQBDnSzzsBSL
mJJlqJwVJdbSrhlrlhhsLL
JPtwMtdPbJbVqVNpPtmbpwZcQDFFcCccFjCQjpQWSWZg
JfbfpZJmzffmpZnZZwsrwDFvwHPP
RDdQtWTWQQSTGNRhsFsjnvjwrhPjtH
QccddTVQQldcGGRdGlgmVmBzfVpDmbgggmpL
HVnhVcHvpVFWDpmP
QswNZblTTwmqlntDPdqD
sGZzNwsGNThhMrhBBhzn
fQllBlVQncgwLlfWwWDvppZZggZqGpZgpGdvGG
shPTRsFbNFJmvqpGjrpvPDdr
RNFDtRRRssRTStRmTlnzwSVQlVVWfWzcQc
WmCpPCWTjQPCWWSjSTmrqRLGDRFGrTFDRFDLDD
gJnVcnVzdfnZgchvrslMDZGlRRDZLR
fdHhfncwfbfzJbnJzJfcczhhSmLCCNBjSpjmpjHjBQjpmpNW
BDvDPGRwRvCmLssGLmsL
frRjjlldrqtNspLWpqFcCmzm
ndSnVNtllldrdfSjfNvgVRHBwbbVMRbVPJgH
PpgjhpVLghPZhSgZVVzzcJWccPNCrcJzrFsJ
BdBNNMqMdfDnDNTFHHJCqHrJHzrFzF
wfMNtMndlBTlmTBndRpgghhjZRjvSZVjRw
ZQnQMWMcjHDHrWNF
TvtCvvBVgdRdmvBVNzDHlGFjFHjfRfDD
dvtCCbdJmhvhhhhbhVBPMwqZswnZqZjjMccsZJ
DDMzRBBSzRDTMQRZsbvssCbhZtCDtP
dLmwNplnmmwjGvPVCRtVVvVd
NNmjLmqWJjFRwFSrgcrSHBzcTz
TwTwTMBWcWBJJBtTWHddCmfgzlCzClsvmfsM
PPLDnNqPRLQNVnGNVsDQnNmzdhvdddlvdlqgqmdlrfvv
SQQsjPPLGLbDSnGLLNnWTFZJHbcpFctHZpwJWB
FzMltgtMzFpZtmzdjPpnvRTQTvRWTDfnnTlvwW
JcbVcBrqLCVJHJSNCcZVqVqqTRQRWWfNsTfTvDfsWvwTsnwv
rcZqVJVhmhgPmhmd
ttvSnlWvWWgcScMDsHHMPMjPmH
pzLGLfNRpJsvmmfvMDfs
GhpzRqqpZppNrhvFgwSlWnnBFn
sbQcDJQJJDbQhwchSctVnVnqTMvMWSqTMPSMlP
jtjCtNRLNCRgRnlTPPWg
pzpHdLtFNdJbDhJHsQhs
pSqnfqDnWPHNPCCHCp
GdJZQdgZbBvgQLcCZZCCZlPLRH
PzBgQggbvBthtMdMvbzvVfFfzTWqDmWDqzqWrfff
nnJdrfgfrdMCMdgrqMnWdgwNTTTzFhPSSHfSHhllzjzNFT
vBRvmvGZsLZZsHFNFFzTNPzb
LZVRmcDRvpQLmvvVGDGmpntJJwCWCnCPJwgJDrPDqM
QddMvdzlVfvdSQmGhmwLbGbmzbns
JtCCWqqZDsLpGhbGjD
FNrhqCTWMSRSrQQg
ZsBZJFsZSmmJsJSmrJrJrvsrdGdCQGQphMGwRMGQRGdbBChM
FlgfqNNNWnNnHfVnnHdbGwpwGWQhGdRMMdRM
LFnggHlDqDLvjDmZPcPmvP
CRHJWfvJvrQfrCsDlGGBszQBjjGB
LmPHVnMmpLlPssBPlDtd
MmMSZmVnncMFcmSVHvfSrffCwSvfbHWv
wsrJrpdJLsMCZDWL
BbLtGGbNmLQggqgQQtGgMmDCTnWZCZWZTmMmCZnT
qNBGNNgQcbbtGbbFBLVjfcfwHvrHHJHJcr
pCZCpdjBljhjBlpVccCpbDDwRWDsLhLbwDsDwsDw
HNgFSSNvSmdqwsFLFWLGttbw
gMMndNrzNHnzJZVlMCMCTcpc
CfsFNszCrrGzrsggsPfPVNVlqTdSjSqMTdSVTdLL
vRhcHllwJDmnJmDMMdhqSqpVMhdjdp
cvHRvwQBPZZlrQgz
TsFhCtQtQsBBLtBLPvgz
jjWZZjZSMNlNNjljNnlmjjfJLMBGGLvBdzPQpggJJLQzpg
wjbcmmlnQZmlrTsCFVwshwTr
nRGFnFjcdlwLSHSpNNnBfWHN
TgQvPbCMPRhbMPQvtQPvMCRBSHNQHBrQSNfWqpHHrWNWSf
PCgMbPvTZVDgtPRggtCCbgmmFJJLmcGFLjdmJFcDwJmm
dgWPssfdvQCLPLhL
pMtSMtpSmpMpFSMMFZjQCLbLQZZbVbVhNTLblZ
mpqcpzncfWwhzfRf
vntvVnRCsvpBpMjCpTpj
rQdZfhzczNzWcNLTpWgSvjjjpGpMSB
ZqNDQhfcNchLchQqcDqRHJtHVwnwbtvHsbVs
qtJGQgTrqtqQdQDgbGjPzZHWWzVjslPZlG
vBShwRRvvSRSvFvwLSvfcnfBWmHZHVWWHPzlNPWVWjZsWnWV
cLBFBFhCBLlwpFccFBFftqJDQdgdTDJJCbJgCCdg
wfmsPvPwNfvmfLNFvzzJbRMnllhlnLhRLC
gjtqDDTtjgpJcbnMTzCRnCCWhC
SDqtpGSStVtdqpgBVjBGZmFPJNJmffvfPsHZPZQd
HQMBBWrQQmPBvmBWnvrTnMSsbFfcfwgfCgscsmGgwgcJGg
NzzlJLthtlgswGFcwGst
JqNNRqpzhVRWTSQrrvSQ
mFpDZjvmtPPGvFjmmGTzTcFRbHczHTbzQgRS
fNdqhJsNrnnVNhwNVdrdsVczQCcwCMHSTCHgHCRzHgcM
JlgnNhsqVqNqNpPlvZvDDDGlZZ";
    }
}
