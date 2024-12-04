﻿using AdventUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2024;

internal class Day04 : DayBase
{
    protected override string _sample1 => "MMMSXXMASM\r\nMSAMXMSMSA\r\nAMXSXMAAMM\r\nMSAMASMSMX\r\nXMASAMXAMM\r\nXXAMMXXAMA\r\nSMSMSASXSS\r\nSAXAMASAAA\r\nMAMMMXMMMM\r\nMXMXAXMASX";

    protected override string _part1 => "XMXXXMMXXSXMSMMMSXMSSSMASXMAXSMMMAASAMXASASXSXSASMSMSSSXSMASXMMSAMMMSAMXSMMMAMMSMMSXSAMXMSMSASMSMSMSSSMMSMMMMMASMSSMSSXMAMXMASAMAMXSXSXMMASA\r\nMXMMMMMSXMASMMAASAMXMASAMXMXXSAASMMSAMXXAAXAAAAAXAAXAXMASXASAXAAASAXAASMXMAMXMAXMAMAMAMXXSAMXAXAAAAXAAAMAMAMMSAMSAXAMMSMAMSMMAMXSXMSAMXXSASX\r\nXAAMAAAMXXMMASMMMXMASMMXSAXSAMSMSAASAMMSMSMMMMMAMSMSXXMXMMMSAMSSMMASXMMMXSSSSMSSMASASAMMMMAMMMSMSMSMSMMMSSXMAMAMXMMXMAAXXXAASAMAMASMXMAXMASA\r\nSSMXSMSMXSSSMMMXMXAMXAAASASMXMASXMMSXMAAXAAAXMXAXAXSMMMAMAMMMMXAXXXMAXMXAXXAAAMAMAXXSASXASAMAAXXXAXAXSMMAAAMSSSMMXAMMSSSMMSMMAMASXMAAMMXMXMX\r\nAAAXMAXMAXAAAXAAMXSSSMMMSXXMASMSMMASAMSSMMSXSXSASMAMAAXMSAXAAMXMMMMSXMSMSSMSMMMAMMSMSMMMXMAMSASAMAMXSASMMMMAAAAMSMSAMAMAAXMASMMXSASMXAXMXMAM\r\nSXMXSASMMMSMMMMMSAXAAXSXMAMMAXMSXMAXAMAXAXMAMXMASMAMSSSMSXSSXSAAAAAXAXXAXAMXMXMAMXAAXAAXMSSMMMAXSXSXSAMSXXSMMSMMAAXSMAMSMMSAMAXASAMASMMXAAAM\r\nMASMAXSAMAAAMXAXMXMXXMASAAMMSXMMAMMSSMAXSASXXMXAXXXMXAAAXAXXASXSSSSSMMMSSXMAMAXAMXMSMMMSAAMAMSMMMASAMMMXMXMAXMMSMSMMSXMAXAMMMSMASAMMMASMSSSS\r\nSAMAMXSXMSSSMMSMMMSAXMAXMXSAXASMSMAAXMXXMAAAASMSSMXAMXMMSMMMXMAXAAAMMAXXSAXSSSMSSXAAAAAMMXSAMSXAMAMAMXMAXSMMMAAMXAAMAMXAMMSXAXMMMASXSXMAMAMM\r\nMXMXXXMAAAXXXXMASAXSAXAXSAMMSAMAMMMSSMSMMSMSMMAMAMAXAMAMXAAXAMXMMMSMSXSASXMMAMAAAMAMXMXSAAXMSXMMMSSMMSSMASAMMMMMSSXMAMXXSSMMXSAMXMAXXAMSMSMM\r\nSASXSASAMASMMXSXMAMMMMMMMAMXMAMMMAAMXAXSAAAAMMXMAAMSSXMXSSMSXSXMAXAAAAMXMAXMAMMMMSSSMSXMMSSMSASXXXMASXAMAXAMMMMMXAMXASXMMAASMSXSMMSASMMXAMAM\r\nSASASMSASAXAMMMMSMMAAAMASMMXSXMXSMSXMXMMSMSMSMSSSSMAXASAMAMAMSXSASMMMXMXSXMMXMXMXAAAXAMXAMAASAMASXSXMSXMAMSMSASXSAXMAXMASMMMAMXMAAXMASAMAMAA\r\nMAMXMXSAMXSSMSAAAASXMMSASASXAXAXAMMXSMXMMMMAXAAXAAMASMMASMSAASXXXXAASAMXMXAXAXMXMMMMMMMMSMMMMXMSAMXAMAMMMMMASASMAAMMSMSMMMXMXMASMMXXMAMMASMS\r\nMXMXSAMAMMXMASAMSMMAMMMMXAAASXXSAMMASAAXMAMMMMMXXAMXSMMXMAXAMSAMSMSMSASASMSMSXSASXSMMAMXAAMAXSMXMXSMSAMXXASAMAMXMXMAMAMAAMASMSMSASASAMXSXSAM\r\nSMMAMASXMXMMXMAMXXSAMSASMSMXAAAMXMMASMMSSMSXAXSXSXSAMXMSMXMSMMAMXAAASAMXMSAAAASASXAMSAMMSSMASMMAMXAXMAMXMAXAMXMSXXMASMSXMSMSAXXSAMMMXSMMAMMM\r\nXAMXSAMAMXSAMXXSXAMXMSAXXXXXMMMMSMMASASAAXSMMXSAAMMXSMMAAAAMASXMMSMMMSMXXAMMMAMAMMAMSAMXAXMXMMAXSAMXMAMSXMXAMAMXMXMASXAMMSAMMMAMAMXAASAMXMXS\r\nSSMMMMSAMAMAMSMSMMMSMMSMAXMXXXMASAMSSXMMSMMAMAMMMMMXMMSSMXMSAMAMAMSXMASXXMASXSMXMAMMMXMMASXSAMXMXMMXMSMSASMMSXSAMAMAMMSAMXAMMAMMMMMMXSAMXSSX\r\nAAMXAAXASXSAMAAXAAAAXAASAMXAMXMASXMASAXMAMXAMASASASAAMAMXSAMAMXMASXXSAXMXXMXMASMAMXAMASMAMASMMMMXMSXXXAMAMSAAASXSASAXAAAXSAMXXSAMAMXASMMAMAS\r\nSSMSMMSAMASMXMXMMMXMSXMAMAXMSAMXMXAMXSXSMMXSSMXAMASXXMMSXSAMXXAXMMXAMXSAMAMASMXMAXSASMSMSMAMAAAXXXAMAMMMMMMXMMMXSASAMSSXMAMXMAXASMSAMXXMASMA\r\nXMASAAMAMMXAXSMSXSSXSAMXASXAMASAMAXXAMXMAXAXAMSXMMMMSMMMAMXXASXSSMMXSXMMSXXAXXMMAMSAMAXAXMASMMSXXAAXAXMAXXXSXXMASXMAXXMMASXMSMSAMAXXMAMMMXXM\r\nMMAMMMSXMXMMSMAXAAXAXMMSAMXMSMMMSSMMMSXSAMXSAMAASXSXAMAMMMMMMSAAAASAMAXAXXMSSSSMSXMAMMMXMXAMXSAASXMMSXMASMASXASAMMSXSASMAMAAAMMMMMMXXXSASMMX\r\nASAMSAMXMAAXAMXMMMMSMMMAMSMXAMAXXMAXXAMAMMAMAMSSMAXSMSAMAAAAAMMMSMMAXXMMSMMAAAXAMMSSMXSSMSMSMMMMMAAAXAXAAMAMSXMASMMASAMMXSMMMSAXMAMXAASMXAXX\r\nXXASXMXAXMSSMXAXAMSMAAAAXAXSMMSSSSSMMASMMMASMMMMMXMMMAASXSSMXXXXMMSSMAXAAAMMSMMMMXMASAMXAAAAMAMASMMMSMMSAMAMSMMAMAMMMAMXMXAAXMXMMAXSMMSXSMMS\r\nXSXMAMSSXSAMXSMXAXAMMMXSSMMAXSXAMAXAXASXMMXSMAMMMXMAAMXMXAXXMSMMXAAAXMMSXMMMAMAXXXSAMXSMSMSMXMSXSSMAAXAMASXSXAMMSAMXMAMXMSAMXSASMSMXAXMMAXAX\r\nMAMXSXAMXMAXMAMXSSMSSSMAAXAMXAMSMMSSMXSAMMSXMAMAAAMAXSAMMXMASAAXMMSSMXXMASMSASXXSAMXSAMMMMXXXMAXXXMXSSXSAMXSMSMAAAMMXXMAXAXSXMASAMMSMMSSMMAS\r\nAMXAXMMMMXAMMSAAXAMAAAASMMMXMXAMAMAMMMSAMSASMXSMXMSAXSAMXAXMSSSMXMAXMAMXXAAMMMMAAXMAMAXMXXAMMMSAMASXAAXMXMAMAAMXXMMSASMXMMXSAMAMAMXASAAAXXXX\r\nMMMMMXAASXSAAMMMSMMXSMMMXSXASXMXAMXSXAMAMMASXMAXAAMMMSXXSXSXXXMXAMXXMSSXMMAMAXMXMSMSSSMSSMMSAAMXSAMMMMMMAMASXMSMMSXMASAMXXXXAMAXSMSAMMXMMSXM\r\nXMAXASMSMAMMMMAXAXMMMMXMXXSAXMMSASMMMMMMMMAMAMAMMSMMAXMXSAMXMXSSMSSMAAMASXMSSSMMXXXMAXAAMSAMMSMAMASMMMASXSASAMMAASAMXMMAXMMSXMAXMXMAMAMMAMAS\r\nXXSMAMXAMXMAXSMXMMSASAMXAXMMSMXAAMAMAAASMSXSAMXSAAAXXXXAMXMASAAAMAAMMMSAMAXAAAMAAMXMAMMMSMXXXAMXSAMXASAXMAMSAXMMMXMSSSXSXAAAAMSSMASMMAMMASAM\r\nXAMAMXXSSXSAMAAMSASXSASMMXSAAXAMMMMXSSMSAAAMASXMXSMMSMMMSXXASMSMMSSMXAMASXMMSMMSMSASMSMSAMXXSXSMMMMSAMASXMASAMXSMSMAMMAMXMMSSMAAMAMXMAMXAMAS\r\nXMXAXSXMAASXXMSMMAMAXMMAAAMMMSXXXXSAMXXMMMSMASXSXMAAXAAXMMMXSXMXAAAMMMSMMAXAAAAAAXASAAXSASXMSAMXAAMMXXXMASAMXAXSAAMMXSAMAMMXAMSAMXXXMASMASAM\r\nMAAXXSSMMMMASXMMMSMSMMSAMXSSMMMSAASAMXSMXAXAMXASAMMMMSMMAAXXMASMSMMAAMAASXMMSSMMSMSMXMMSAMXMMAMSMSXAMSXSXMXSXSAMSMSXASASXSSSMMXXSSMSMAMMAMAS\r\nAXXXXXAMXAMAMAAXXAAMAAAAXAAAASASMXMAMAMMMSSMXMMMAMMAXXXXASXAMMMMMXXMXXMMMAAMAMXXMXXAMXMMASXXMAMXMAMAMMAMXMXXMXMMMXMMMMXMAAAAXXXAAAAXMASMXSMM\r\nSMMSXSAMSMMMMSMMMMMMMMMMMMSMMMASXMSAMXSAAAAXAXASXMAXMASAMXXXAAAAAAXSMMSSSSMMASAXMAMMMMXSXMASXSSXMSSSMSAMAMMMSAMASAXASXMMMMSMMSMMMMMMMSAMXSAM\r\nMAXAAXAMAXMXAXASXSSXXAAMXMXXSMMMAXSXMMSMMSMMMXMSMMMSMAMMSMMMMSMSMSAAXXAAXAASAMAAMMSMAAMAMMMXMAAXXAAAASASXSAAMAXASMSMMAAXXXAMAXXAAAAMXMASASAM\r\nMSMMSSMSSSMMMMAXAAASMSMSAASASXSMXMMAXAXXAXXMSAMXAAXAMMSASAASAMAXAXMMMMMSSSMMAXSXSMAXSSSXSAMXSMSMMMSMMMAMMSMSMSMAXMAMXSMMSXMAXMXSSSMSMSXMXXXM\r\nAAXXAAMAASXAXSAMMMMXXAASXMMAMAXAAMSSMSSMMMAASMXSSMXXMXMAMSASASAMAMSXAASAMXMSMMXAMXMMMAMASMSASXMASAMXAMXMXXMXAXMMMSSSMAASXMXSAMXAAXAAASXMXMXX\r\nSXSMSSMSXMSMMAMASAMXMMMMAMMAMMMASAAAAAXAASXMMSAAAMXSXMMSMMXSXMAMXMAXSXMXMAXAMMMAMAMAMAMMMAMAXASMMMMAXXMAMXSMXMAMAXAAMSMMMXAMAMAMAMSMMMASAMSA\r\nXAXAXXAXMXXSXAMMSASXSXASXMSMSXXAMMMMMMMMASAAAMMSMMAMASAMXAAXMXASAMXAXASXSMSASAMAMASASMSSMMMSMMMSSXMSMSMSXMAMSSXMMXMAMXAAAMMSMSAXAXAMSSXMXMAS\r\nMXMMMMXMAMMMXMMXXASAXXXMMXMXSAMSSSXSSXASASXMMMXXXMASAMASXMASMSMXAMXXSAMAAAXAXXXASXSXSAAAAMAMAMAAMMMAAMAMMSAMXMASASXMSSSMMMAAASMSMMXSAXAMXXSX\r\nSMMAAMASMSAMXMXMMAMXMASMSMSASXAMAMAXMAXMAXXMSSSMSMMMXSAMAXAAMAMMMSMMMMMMMMMSMSAMMAXMMMSSMMAXAMMMMASMSMAMASASAMAMAMAAAXMSMSSMMMMAXXSMMSSSMSAS\r\nAAXMMSMSASXSAAAXAAMASAMAAAMASXSMAMMMMSSMSMSXMAMAAXXAMMXSMMMXSASAAAXAAXAXAAAAAXAXMASXMMAAMSSSMSMXSASAMXASXSASASXMAMMMMMXAMAXXXSSMSXMAASAAMMSA\r\nSSMSAAXMAMASMSMXSASXSAMMMSMMMXAMXMXAXAXAXAXMMSMSMSMAMAMSXSXASAXMSMSSMSMSSMSSSSMMSXMASMSSMAMAMAAAMAMAMSXSXMASXMASASASMXSSSMASMMAXMASXMMSMMXAM\r\nMAAMSSMMAMXMXXAXXXMASAMXXMAMXMSAMXSMSMMMMSMSXXAMAMMSMSSMASMXMSMXAMXAXXMAMXAAAAMAMASXMAMAMXSAMMMMSMSSMMSXXMAMASAMXSASXAMAAXAMASMMMAMAAXXXSMMX\r\nSMMMAMASXSASXMASXMMMSSMXMXXMSAMXSXMXAXAMSXAMAMAMAMAMXXAMXMAAMXSMAMSAMMMMSMMSMMMAXXMAMMMMMXMASXXMMXMAASAMXMXSXMMSMMAMMMMSMMMSAMXAXASMMMSMMAAX\r\nXAMMASXMASASAXAMASMXSASMSXSMSMSASASMSMMXMMAMSMXSXMASASXMASMMMASMAXXAXSAMXAAXAMSXSASXSXMAMXMMMMMXMASMMXXAXMAXAXAAAMAMAAMAAXXMAMSASAMXASMASMMS\r\nSMMSASAMXMAMMMAXXMAXMAMXXAXAXAMXSAMXXASAMMAAXMASXAASAMXSAMAAMASXMMSAMSAMMMMXAMAXSXMASASASASAAXXMXAMXSMMMAMMMSMSSSMASMXSASXMASAMMXMAXXASAMAAM\r\nAMAMXSAMXMSMMSAMSSSSMSMMMMMMMMSAMXMMSXMASMMSSMAMXMMSASXMASXMMMMAXMASMMXMASXXSMMMMAMAMMSASAXMXMMSSSMXAASXMMSAXAAAMXMSAAXMMAAAMASAMMSMXMMMMMMM\r\nXMAXMSAMAXMAXSAMXAAXMAXAAAAAAXMXMASXMAMAMAMAXMAMMMMXAMAMMMMASASAMSAMXXMSXSAMXAXMSAMAMXMAMAMSMSAAAAXSMMMAAAAASMMSMSSMMMSAXXMXSAMMMAAAMAAXXAAX\r\nMAMSASXSXSXMMMAMMMMMSAMXMSSXSAAASASAMSMAMXMXXSASMMSMMSSMSXSAMXAMXMAMXMMSAXXASXSASXSMSXMAMXMAAAMMMMMXMXSMMMMXMASXAXAASMMMSMMMMMSXXSMSASMSASXS\r\nMXAAXMMXMSASXSSMXMXAMMMSAXMAMMSASMSAMMSMSXMAMXMAAAXAAAMXXMMASXMMMSXMASAMAMMMAAAMXMAXAXXXMAMASMASXMSAAASXMXXMSSMMMSSMMSAAAAAAAAXAMXAXXAASMMSS\r\nMSAMXMXSXSAMAMAAXMASAAAMMMMMMAXMSAXXAXAMXXAAXAXSMMMMMSMAMMSAMXXMASAMXMMSSMMMMSMXASMMMSMASAMMAXXXAASXSMMAXSAMXMAAAAAXASMSSSMSXSSSSMMMSMXMXXAX\r\nAMMXSAAMAMXMAMMMMMSMSMASMASAMXMAMXMMXXAMAMMMXMMMASMXMAMXAMAMXXAMMSAMSAAAAAXAXAXXXMAAAAXXMAMAXMAMMMMAMXSAMSAMXXMMXSAMXSXAAAAMAMAMXAMASAMXXMXM\r\nMMXAXMSMSASXSMMAAXAAXXMAXAXXMAMXMMXMASXMMSASXSASAASXSSSMXMAMAMXMXMAMXMMMSMMMMMSMSSSMSSSMMAMMMSMMSAMAMAMMXSAAMSXXAXAMMSMMXMMMAMAMXXMASASMSMSA\r\nXSMMSAAAAXXAAXSSMSMSMMXMMMSMMMSMMMSMMMAAMSASASASXMAMXAAMXXMXMAAMMSMMAMSMXASXASAXAAMAMAMXSAXXAMAAMAXSSMSMASAMAAXMXSAMAMASAMXSXSXXXAMXSAMAAAMS\r\nXMASMMMSMXMMMMMAAAXAXXAMAMAMAMAMAAXMASMMMXAMAMAMAXAXXSMMMMSAMMMMMAAMXMAASAMMMXASMSMAMSMASAXMSSMMSSMAAAXMASASMMXMASXMXMAMSMXXXMAMSMMXMXMMMMMX\r\nMSSMMAAMXMSASMXMSSSMMSSMSSSSXSASMMSAAAAXMMMMXMAMMSSSMXXXAASXSASASXSMSAMMMASAMSMMXAMAXXMASMASASAAAMMMMMMMXSAMAMASAMXXSMMSAXMMMMAMAAXSAXMASAMX\r\nAXAAXSSMAASASXAXAAAXMAMAXMAAXSAMAASXMSSMAXSAMSASXAXXAMMMMXSASASXSAXASMMXXAXMXAASXMSXSAMASXMMAXMMSXXSXXAMMMXMASAMAMSAXASMMXXAAXAMMSMMMMSASASA\r\nSMXSMAXXMXMMMMMMSSMMSAMXMMMMMXASXMMXMAMAMXAAMXAXMSSMMMAXXAMAMXMAMAMAMAXXMSSMMSXMAMAXSAMMSAXMAMSAXMAMMAMXXAXSXMMSSMMMSMMMXMSSSSSSXXAXXAMMSXMX\r\nXAAMMMMSMAAAAAAAMAMMXMXXAAXAMSAMAXSAMXXSXSSMMMMMMAMMSSMSMXSAMAMMMAMASAMXMAAAAXASXMSXSXMXSAMXSMMASXMAASMSMSMXAAAXMAAMAXSSMMAAXAAXAMXMMXSASAMA\r\nMSMMAXAASMSSSSMMSAMXMMMMSMSMMMAXXMMXSMMXXMAXXXXASAMAMAASAMSXSASMMASAMXSAXMXMAMAMXAXAMASAMXSAXAMXMAMSXXAXAXASXMMSSSMSAMMASMMSMMMMMMAXMAMMSAMS\r\nXXXSAMMXMXAMAAAASMMXAAAAAMAXXSAMSSMMAMAMXSAMSMSXSASXSMMMSXMASAXAAAMMMMSXSMMSMMAMMXMAMMMASAMMMXMMSSMMAMSMSMXMAAMAAMXMAMSAMMMXMXAAASASMXSMSAMA\r\nMXAMASXASMSMSMMMSMXSSMXMASAXXAAXAAXSAMSSMMMXXAAASAMAXAXXXXMMMAMSMMMSAAMAMAAAASXMSMMMXXSXMXSXXSMMAXAMAMXSAMXSSMMMMMXXXMMXMASAMXSMMXMAXXAASAMM\r\nAMXMAXMMSAMXXAXAXMAXAASXMMMSSSSSMMMMAMAMMAMMMMMXSAMSMMXMAXMXMSMMAXAMMSMASXMMMMAAAMASMMMASMAMMMAMMSSMXAXXSXMAMXSXSSMMAXXXSXMASAMSASAAAMMMMASX\r\nSSMMAMSAMAMMSSMMAMMSMMMAAXSAMMAAXXASAMMMSASXSSXASMAXMASAMMSMMXASMMSSMMMXXMSMAMMSMSASAASAMXAAMMMMMAAXMAMAAXMMMMMMMAASAMMMMSMAMAMAMSMMSSSMSAMM\r\nXAMXMAMASMMXAXASXAAXMASMMMMASMSMMMXXASAAXMSAMXMXSAMXMMMXSAAXAMAMXAMAXMMMSAASXMXXMMMSMMXMMXMXSAMAMSXMMAMAXMASAMSAMAMMASXASAMXSAMMAXAXAAAAMSSX\r\nSXMAMMSXMMMMMXXMAMXSMMAMXMMAMXMMMMSSMMMSSMMAMAXXXXMASXAAMXSMSXMMMSSSMSAXMSMSXMASMMAMMSMSAMSASAXXMAMAXXSSMAMSAMSASXSSXMMXMMSMSASXSXSMMMMMMMMM\r\nMXSASMMMXXASMSSSXSSSXSXSAMXSMMMAAAXAAMAXXAXMMSSMMMSXSMMXSAMXXAAMAMXXAMXSMMXSAMAXAMSXMAAMAMSASMMMMMASAMAMAMMMMMMAMAMASMSXMXSASMMAMAAAXAAMXXAM\r\nXAMXXAXSASXSAAXMASXMAMASMMAAAXSSMXXMMMXMSSMAAXAMAAAXXAAAMASASMMMMXXMSMAMAAAMMMXMXMXASMSMSMMAMXSAAXXMMMASXSXSXXMAMXMAMXAXSASMSAMAMSMMMXSXSMAM\r\nMMSMMSAMASAMMMMMMMAMAMMMXMMSMMXMAMSXMAXXAMSMMSMSMMMSXSMSSXMAMAXMMSAAAMAXMMSXSASXMASAMAMXAAMXMASMSSSSXSXMAAAMAXSXMXMXSXMSMAXXXAMXMASAMXXAXMAM\r\nMSAXAMXMAMAXSAXXASXSASXSXSMAXMAAAASXSASMXMAXXAXAAXSMMAAXXXXXSAMAASMSSSMSAAXAMAAMMXMMMAMAMAMXMASXAAAAAMMMSMMMMMMASAMSSMXAMXMMSMMSMAMXMAMAMSMX\r\nMSAXXSXSXSAMSAMSAMASXSAMAMMAMMMMMSMAMMAAAXMMSSSMSMAASMMMMMXMAMSMMSXAXAASMMMXMXMASAAXMSMSAMXMMXSXMMMMXMAAAAXXMAMAMASAXAXMSMSMAAAMMAMAXAMXMAMS\r\nXMSMAXASAMMMMAMMSMAMAMXMAMMSSXSASAMXMSMSSMSAXAAAXMSMMAAAAAXMMMSAMMMMMMMMXMXMAMXASMSXMMAMMMASMMMMXSAXAMMSSXMSSXMMMMMMSSXMAAASMMMXSASMSMXAXAXA\r\nXAAMXMXMMMAAMXMAXMAMAMAMASXAAASXSAMXMXXXMAMMSSMMMAMMASMSSSMSAAXXMAXXAAAXMMAMAMSMMMMASMAMXSAMXAASASMSMSAXMAMXAASMMSAXAAASMSMSXXAXSAMXAASXSMSM\r\nMSMSXMXXXSSSSMMSMSSSMSASASAMMMMMSAMSSSMMMMMMAMAXMAMAAXAMAMASMMMASXSSSSSMXSASAAAAAXSAMSXXXMSSXSSMASAAAAMASMMMMMMAASXMMSXMAXXSXSAAMAMSXMAMXMAX\r\nMAXAXXMAXMAAAXAXXXAAASXMASAXMASASAMAAAXAASAMMSMMMAMMMMAMAMMMASMMMMAAAAXMAXMSMSXSMMMMMMMSAAMMMMAMAMMMSMSAMXAAASMMMMAXXXAMAMXMASXMSSMXMASXSSMS\r\nMMMAXMSSSXMSMMAXMMXMMMXXXMXMSMMMSXMMXMMSSSMMXAXMMSSMMSSMSSMMXMASXMMMMMMMMSAMMMMMMAAXXAASMMMAMSAMXXSAMXMAXSMMMMAXXXSMMMAMXXAMXMAMAMXMXAXMMAAA\r\nMXSAMXAAAMXAXMSASAXSASMSSMMXXAMXMMMSAMXMAMXASMMSAMAAXAXXAAASASMMAMAMAMAAXMAMAXAASMSSMMMSXXSAMMSMMMMMSASAMMASMSMMSAAASXSMSSSXASXMASAMXMXASAMX\r\nAAAAMMMSMAAMXMMAMAXSASAAAAMMSSMAXAAMASMXAASAMAAMASXMMMXMMSMMXMMAMSAXAMMSSSXMMSMMMAAXMAMXMXMXMSAXAXAXMMMMSMAMAASASXMMXAASMAMSXMXSSXXXAMSMMMSM\r\nMMMMMXMAXSAXAMMXMSMMAMMMSMSAAASXMMSXXMAXXAMAMMMSMMXAAAASXMXSAMXSXMMXXXAMXXAAAMASMMMMMAXAMSSMSAMMMSMSMAAAAMAMSMMMSAXAMSMMMAMXSMMMAMSSXMAMAAAX\r\nSXXSXMXXXMXMMSMMMMAMXMSMMAMMSMMSMAXMMMSMSASAMXAMXMSSMSXSAMASMSMMMXSASMSMASMMMSAMAMAAXMSXSAAMXMXMMAMAXSSSMMMXXASASAMXMAAMSMSAMMASAMXAXMXSMSSS\r\nMMMSAASXMSSMMAAAXSAMSXSAMSMXXXMAMASMAMAAAMXASMMSAMMMAMXMAMAMXSXMAXMAMAMAAAASAMASMMMSSMAXMXSMAXAMMAXAXXAAXSSXSAMASXMAMXXMAXMASAAMASMMMSAMXAAX\r\nMAAMAMAAAAAMSSSMXMMMSASXMXMXMXMMMAXMAXMMMASMMXAMXXASMSMSSMSSMSAMSSMMMSMMMSMMSMXMASAAAMXMMAMMMXMSSSMXSASXMAMMMMMMMMXXSSMMSXSAMMSSMXMAXMAMMMXM\r\nSMSXSXSSMMSXMAXXAAMAMMMXMAMASMMXMSSSSSSSMAMMAMMMSAASAAAAXAXMAMMMAAMSAAAXAAASASXSSMMSXMAMMASAXAAXAMAMXMMAMASAAAAAAXAAAAAAAMMXXXXAAASMSSMSSSMA\r\nMAMXMAMMAAXAMXSSSSMASASAXXSAXASMXMAMAAAXMASMAMMAMMMMXMMMMSMMMMXMSSMMSMSMSXSMMAXXXMAAAXAMSXSASMSMXMXAAXXXMXSXXSSSSSXMSSMMSSSSXSSXMASXAAAAAXMS\r\nMAMAMAMSMMSSSXAAAXXASXSASMMXMSMXAMAMMMMMMAXMXXMASXMXXXMXAMAMXSMMMXMAXXMXMXAAXMMMMMMSSMSMMAMXAXAMSSMSMSAXXMMXMAMMMAAXMXXAMXAXAXMMMAMMSMMMSMXM\r\nSASMSMMXSXAAAMMMMMMXSAMXAASMMMASXSSSMXMMMASXMASASASMSSSMMSSMASXAASMSSSMAXSXMMXAAAMMAMXMAMXMAMMAMXAAAAMMMXXAAMXSAMMXMAMMMSMMMAMMXMXSAMAAMXMAM\r\nAAXMAMAMAMMSMSXSAXSAMXMMMMMMMMAMAAAMXAXAAXSAAMMASAMAAAAXAAAMAXSSMSAAAAMSMMAAMSSSSXMASMSAMXSMXXASMMMMSAXSXMSXSASXSXSMSMAXSAMXAAMMMMMMSSMMAMAS\r\nMMSSMMMSAXMAAMAMAMMASXSSXMASAMAMMSMSSSMSXMSMSSMAMAMMMXMMMMSMMMAMAMMMXSMMASMMMAXAXMSMSXSXMASXMSASXAAXMXXSAMAAMMSXMXMAMXSXSAXSASMAAAAXMASXXMAS\r\nSAAAXXXSMSMMSMAMAAXMMMAMMSASAXXMAXAAAAXXAMXAMMMMSMMASASXSAXAXMAMXMSMXMAMMMSAMXSMMMAASASAXMSAAMXMMMMMMMASXMMSMMXMXAMAMMMAXAMXXMXSMSSXSAMMSMAS\r\nMMSSMSMSMAXMXMASASMSAMAMAMASXMSSMMMMMMASXMMSMXAMAMMXSAMASAMMMSMMAMAXAMAMMXMSAXXXASMSMAMMMAMXMASXSXSAXMXSAMXAMAAMSAMAXAMXMSMSMMAMXAAXMASAAMAM\r\nXAAAXAAMSAMMAMXSAAASMSSSSMAMXXXAAXAXSXMAAAAMMSMSMMXXMMMAMXMAAAASASMSXSSMSAMXXMSSXSXXMMMXMSASXAMXMASAXMAMMMMMMMMMMASXSMSAAXAAAMAXMMMMSSMXXMAS\r\nMMSMSMSMMMXMASXMMMMMMSAMASASMMSAMMMMXAXSMMXSAAAAMMMXAAMAXASMXSMSXXXAMXAASMSAMAMMMMXMASAXXMASMMMAMMMMSMMMAAAAAAMAMAMAAMSMMMSMSMSMXSAAXAASMSAS\r\nXMAXAMMAMASXSMXSXXAAXMAMASMSAAXAMXXSSSMMXMMMMMMMXASXMMSMSXSAAXAMASAMAXMMMXAXMSMSASASAMXASMAMAMMMXMAMXAASMSSSXSSSXMSMMXXAAXXAXAAXXAMXXMMMAMAS\r\nMSMSSSSMMAMXAAXSXSXSMSXMAXAMMMSXMXSAXXAXMXXAAMSSMMSAAAAXSXMMMSAMAMAMSSXMXSMMMMASASAMASXAXMAMXSASMSMMSSMSAAMMAXAXAASXXXMSMSMSMMMXSASASMSMXMAM\r\nMAMAXMASMXSSMMMSAMXXXSAMXMSMMMSAMXMMMSSMAMMXXMAAXASXMMSASXXAASAMXSXMAXAAAXXXAMMMXMXMAXMXXSXXASASAAAAXAXSMMSMSMAXMXMASMXMASAAAAAMXAMASMAMSMXS\r\nSAMMXXAMXAAAMAAMMMMXAXAASXAAXAXAMMAXAXXMSASAMMSSMAXAXAMMXAMMMXXXXAMMXSXMAXMSXSXXXMSXMXSXMASMXMXMMMSMSMMSAAXMXMXMXAXXAMXMMMSSXMSMMXMAMXAMMAMA\r\nSXSXMSSMMSMSMSAXXSXMMMMMMMSMMMSMMMAMSSSXXXMAMAAAAXSSMSXXXMASAXMAXMXMAMMAXAAXAAMAAAMAMAMAXAXXXXMSSMMAXMAMMSMSAMSAMXXASXSXAMAXASAMXMMASXMSMAMM\r\nXAXXAAAXAAAAAXXMXAAXAAXAXAAMAAAMXMAXXAXMMMSSMMSSMXMMAXAAXXXXMSMSMAMSAMAAXMMMMSASMMSSMSSSMSSSSMMAAAMMMSSXAXMSAMXXMSAMMAAXXMASXMAXMASMSMAAMASX\r\nSMMMMSSMXMXMSMMMSSSMMSSXSSSSSSMSASXSMMMMSAAAXAAMMMAMAMMMMMMAXSAMXAAMAXMSXSAAAAMAAAAAXMAAAAAAXAMSSMMSASAMXMAMMMSMMMAAMXMASMMMAXAMSAMASMSMSXSX\r\nAAXMAXAMASAMAAAXAAAMAAXXMAMMMAASASMXAAXAAMSSXMMSASAMXMXMAAXSMMAMSSMSMMXAAMXMMMAMMMMXMMMMMMMMMSAMXMAMMMMXSMXMAASAAMXMXSXXMAMXSMAXSAMXMAMXSXMM\r\nMXMMMSAMASASXMMAMMMMSXSMMAMASMMMAMXSXMXMMMMMXMMSASXMAXSSSMSAASAMXXAAAMMMSMMSSSSXSMMSMMAXAMMSXXXSAMXSSMSAMMAMMASXMSMSAMMMSMMAMXSMSMMAMAMXMASA\r\nSMSMAMMMXSXMASXSSSSXXAMXAASXSSMMMMMSXSASXAAMSXAMMMAMXXMAAXAMXMAXAMMMMMXXXMAAXAMAMSAAASMSAMSAMXMMMSMAMAMMSSSSMMSMMAXMASAAAXMXXAMAXXMMSMXXSAMA\r\nAAAMASXSASAMSMAMMASAMXMXSMSASAXXXAAXASASXSAMMMSSSSMMSSMXMMSXMSSMXSSXSMXMAMMSMMMAMMMXXMAAXSXMAXMAAAMAMXMAAAXXMXSASMSAMXMMMSMAMSMMMXXAAMAMMMSM\r\nMSMSMSAMASMMAMAMMAMXMMMAMAMXMMMXSAMMXMXMXMAXXAXXMAXAASMXSXMAAAXMASXAAAXMAAAAAXMASXSSMSMMXAMXSMMMSMSMSMSMMSMXSASMMASMMAAAMXMSSMAAAAMSMMMMAXAM\r\nAXMXMMXMAMASXSMSMXSSMAMAXAMXAXXXXASXSMXMASAMMSSMSSMMMSXAMASMMSSSXMMSMMXXMSSMMAMXXAAXAAAXSXSAXAXAMMSAAAMAMAMXMASXMXXASMXSAAXMAMSMMSXMAMXSMSSS\r\nMSXMSSMMXXXMAMMMMAMMSASXSSXXMMMMSAMAAXXMASMMMAAAAXAXAXMMSAXSAMXAAXAMAMXSMMAAMSMSMMMMSSSMAAMASMMXSAMMMMSAMMSSMAMAXXMMMMAAMXMSMMMAAXMSMSXMAMAM\r\nXAAMASAMSSSMASAAMASXSMXAAMMXMAAAXAMSMMAMASASXSXMSSMMSMAXAXXMXSSSSMSSSSXAXSSMMMAAXAXXAAMXMMMMMXAMMMMXSXSMSAAAMSSSMSXSAMMSXAMXSASMMSAAASXMAMAS\r\nMASMASXMAAXSAMXXSASXMASMMMAAXXMSXMMXAXXMXSAMAXXMAAXAAXSASMXSXAAAMMMAXAMMMAMAAMSMSMSMMSMXSXXXMAMSAXSXMASAMMSSMAAAAAXSASAMMXSAMXSAMXMMSMASXSSS\r\nXAMMAMXMMSMMXMAXMASAXAAXXMSMSAMXASMSXMMMAMAMAMAMSMMSSSMAXMASAMMMMAMXMMMXMASXMXAMXAXXMMMAMMSSXMASMSMAMAMSMMXMMMMMMMXSMMASAXMASAXAMAMXAXAMXXMM\r\nMSSMMSXSAMXAAXMXMASAMSSXSXAAXMASXMASMAAMXSXMASAMAXAXMAMAMMAMMXMASXSXMXSXSXMAMXMMMMMMAAMMMAAMAXMMMAMAMAMMSMXXMXMSMMMXAMSMXXSAMXSSMSSMMSMMMMMM\r\nMXAAAXXMSSXMMXMAMASXMXXAAMMMMXMMSMXMASXMAMASASASMSSXXAMAXMMXSASXSASAMAAMAMMSMMAASAAASXSMMMSSMMSMSSSSSMSAAMAXAAXXAAXAMMMAXXSAMXMXAMXMAAAASAMA\r\nMXSMMSXMMMAAAAMMMASAMXMXMXAMSAMSAMXXXXAMMXAMASAMAAMMSXXMXXXMMAMAMAMXMAXMXSAMXMSMXMXXMXSAASAAXAAMAAAAAAAMAXAXSSSSSMSSXXMAMMXAMXXMXMAMSSMMXASX\r\nXAXAXAXSASXMSXMAMXSASXSASMMXSASAMXSXSMSMSAXMXMAMMMXAAMSXXMAMMSMMMAMSXAMMAMAXXMMMSXSASASXMXXXMSXMMSMSMMMSSMMXMAMAAAAAMMSASXXSMSXMASXXAMMMSMMM\r\nMASXMAXSAXXXAMMSMMSXMASASXMASMMASAMMSXMAAMXMXMXXXAMXSMAASMSMAMAXSSSSMSAMXXSMSXXAAAMAMXSAMSMSMMMMAAXMAXMAMAMSMAMXMMMXAASASAAMAMMSASXMAMSAAAAX\r\nXMAMASXMMMSMMSAXAASXMXMAMMMAMAXAMASAMXMMMXSMASMMMSMSAMMSMAAMMXSMAXXXAXXAMXMASAMMMSMMMXSMMAAAAMAMSSMSAMMMSSMMSXMASMSMSMMAMMMMAMAMXMAMAMMSSSMS\r\nMMXXXXAMSASAAMAMMMSASXMMMMMMSSMMSMMMSXMASMMMAMAAXAMXAMXXMSMMXAXMXMMMSMSSMXMAMXSAAXAASMXXSMSMXMAMXAAMXMXAAXAMXSSXSAAAXMMMMSASXMASAXSMSMXAMXXM\r\nMSMSMSMMMAXMXMXMSMSAMXXAAXXMAAXMAMSMSMSAMAXMSSSMMMSSMMXXAXAXMMSAAAXAXXAASMMMMAMMSSSMSAXAXXMAXSASMMMMXXMMSSXMAXXAMAMSMSMSASXSXXSXMXXAAMMASXMS\r\nSAXAAAXSMSMSMSMAXAMAMASXMMSMMSMMAMAAXASASMSXAAXMSXAAXSMMMSSMXMAMAXMASMSSMXAXMXXAMXAXMMMSMMMSMSASXMAXAMMMAMMMMXSAMXMXAXAMAMMMXXXAMAMMMXSAMAAA\r\nSMSMSMSXAXAAAAMXMAMAMXMAAAXXAAASMMMSAMMAMXAMMMMMXMSSMMAAMAMSXMXSXMSAXAXXASMSAMXSMMSMXXMAAMMAMMXMAXAXXMAMMXMAXXAAMAXMSMSMXMAAXXMAMAXAXXMASMMM\r\nSXMMAXXMAMXMSSSMASXXXAMSMMSMSXXAAXAXMMMMMSMXSAASAMMXMMSMMAMMXSAMAXAMMMMMXMXXAXAXAMAMXMSSSMSASXASXMSSSSSXXXSASXASMXSAMAXAXSMMSMSAMXSMSMSAMXAX\r\nXAMSSSMSASXXAAAMSMASXSAXXMMMMSMMMMXSASAAAMXASXSMASXAMAXAMSMSASMSAMMXAMMMAMXSMMMSAMXXAAAAXAMAMMMMSAXAAAAXSXMASMXMASAMSAMMMMAMMMAMMXAAAXAMMSMS\r\nSXMAAMASASMMMSMMAMXMAXMMMXAAMXXSXMMSAMSMSSMMSMMMAMXXMASXMAAMASASXMXSMSMSASMMMAXAXXMSSSMSMMMSMAMMMMMMMMMMMAMAMAMMMMAXMAMXMSAAASASMXMMMMMMAAMM\r\nAAMMSMAMAMAAAMXSMSSMSMMAAXMSSMMSAAAMXMASAXMXSASMXMMXXASASMXMXMAMAXXMXAAMAMAAXSSMMSAAXMAXAMAAASAMASAXSAXASAMMMSAAMMSMMAMXXSASXSASASXMSSSMSSSM\r\nSXMAXMASAAXMSMAMXAAAMAMMMAMXAXASMMMSAMXMXXSAMMMXXSAXMXSAMXAXAXAMSMAAMMSMXSSMMXAAASXMXSXSMMXMXMASAMXXXAMMXXMSAXSMSAAMSMSSMXAMXMAMASAXAAAAAAAX\r\nMMXSXSMSXSXSAMSSMSSMMSMAASMMMMXSAMXSMXSAMXMAMSAASMSSMAMAMSSSMSMXXAMXAMXMAMAASMMMMSAXXMXAMSMSSSMMMSXSXSXMSSMMSMXMMMSXAAAXMMMMXMXMXMMMMXMMMSMM\r\nXAAXXSXMAMXMASAMMMMMAMMXMMAAXMASAMXMAMXMAXSAMMMMAAXXMAXXMAAAAXXAXAXMSMAMASMMMAAXAXMMAMMSMAASAAXAXMAMAXAMAAAAMXMASXMXSSMMXAAAXSASAAMMXMAXXMAS\r\nMMMSASXSSMXSSMASXSASASXAXMSMXAMXMASMAMMMSXMXSXSXMMMSSMSXMMSMMMMMSMMXAMAXMMMMSXMMMSXMAXAXMXSMMMMMSMSMXXAMSSMMSAAMXSAAXAXXSSSSXXAMSXMAASXMMSAS\r\nMAAMMMAXAAASXSXMASAMASXSSMASXSMMMXXMMMMAMXMASAAXXAXMAXAMSXMMAAAMAMASMSSMSAMASAMAAAASASXSMSAMXSAXSAAMMXSMMAXASMSXAMXMMMMMAXAMXMSMXSMMMSXAXMAS\r\nMMSSXMXMMMMSAMSAMXXMMMMAAMAMMXAXSAMXSMMASAMAMSMMSAMSMMMXMAASXSMSAMAMXXAASAMASASXMXMMAMMAMXAMAMXMMAMXSAMASMMASAMMXMAXMAAXMSSXSAAAXXSSSMMSMMSM\r\nAXAXAAAMXMXMXMAMXMMMXAMSSMMMASMMXMMASAMSSXMAMMXMMMAAMASASXMMXMASAMSSSMMMSAMXSXMAMSAMXMSMMSAMSSMSMMMAMASAMXXASXMAASXSSSSSXMAAMSMSMAASAAAMMMAM\r\nSMXSASASAMMMMSXSXMAMXXMAMASMMMXAMXMAXAMXXMXMSSMSAXSASXSASMXXAMMMAXAAMXXAMAMXMXSAMXMAMXXXASMMAMXAAAMXSAMASAMXSAMXASAXXMXMAMMMMAXXMSMSXMASASAS\r\nAAASAMXMMSAAXAASXSAMXXMASAMAMSMSASMMSSMMMSSMAAMSAMMMMAMMMMMSXSXMXMMXMMMSSMMSAAMAMXMSMSMMMSAMASMSSMMXAMXMSASAXAMMSMXMXMMSAMXSXXSXAXXMAMXSASAS\r\nMMMSXMMXASMSMMXMMMXSAASXMMSAMAAMXMAXAXAXAAMMMSMMMMAAMAMAAXXMAMAMSSXMMXAAAAMMMMXAMXXAAAAAXSAMXXMAAASAMXMASAMAMSXMAAMSSMAMAXAMXXXMXMXSAMXMAMMM\r\nXAAMAXMMMSAMMMAAXAAMXMMASXSAMMMMASMMMSSMMSSXMMMMMSMMSASMMSAMASAMAAXAXMMXXMMXMASASXSMSMXSXSXMXXMMSMMAXMMMMMMAMMASMSMAAMASMMSMSAMXAMMMMSAAXMAX\r\nSMXSAMXXXMAMAXXSMMSSSXSXMAMXMSXSASAAAAXXAMMXSAMXAAAMSXSMASXSASXMMSASMSMSMXMXXMAMMAMAAAMMASXASXMAXMSMMSAAAMMXMSAMAAMSSMXSXAXAMMASXAAXMXAMMSXS\r\nMAMAMMMMSSMMSXSAMMMMMASMMMMAXXAMASMMMMMMXXSAXASMSMSMMAMMAMXAASXMXMAXAXAAMAMSMXMASAMXMSMMAMMAXAMAMAXSASXSSSMSAMXMASMMAMAMMXMAMMMAMXXSMMSAMXMA\r\nMAMAMAAAMXAAAXAMXAAAMXMASXXSXMMMAMXXAAAMAXMMSXAAAXXXMSMMMSMMXMAXAMXMMMMMSAXAMAMXXAXMXXXMMMAMMSMXXAMMXSXMAAASMXSAMXMMXMAMMMSAMXSSMSXAAAXAMASX\r\nSASASMSSMSMMSSMXSSSMSASXMMMMMAAMMSMSSSSSMSSXAMMXMASMXMASAAASXSMMSSMMXSAASMSMSASXSMMSAMMSSMSAAXAXMSMSMSAMSMMMSASASXSSMSXSAAMAMAAAASMMMMSASASA\r\nSASASMAMMAAAAAXAXAAASASXAAAAASXMSAAXAAAMAAXXMAXAXMAAASMMSSSMAAXAAAAMASMMMAAASASAAXXMASAAAAAMSMXMAAAAASMMAAAAMMSAMXXAAAXMMMSAMXSMMMMSAMXXMASM\r\nMXMXMMSMSSSMSSMXSMMMMSXMASMSXXAMSMMMMMMMMMSMXSSXSXXSASXXMXMMSMMMSSSMXSXXMSMMMSMMMMXSAMMSSMXXXXMASMSMMMMASMMSSXMXMASMMMSXMASASXMXMASXXSAAMMMX\r\n";

    private Regex _basicXmas = new Regex("(?<=XMAS)|(?<=SAMX)");

    protected override string Part1Internal(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
        var indices = Enumerable.Range(0, lines[0].Length);
        var maxLength = indices.Count();


        var forwardDiagonals = Enumerable.Range(-maxLength, maxLength * 2).Select(a =>
        {
            var c = a;
            return new string(lines.Select(b => 
            {
                c++;
                var result = c < maxLength && c >= 0 ? b[c] : '\0';
                return result;
            }).ToArray());
        }).ToArray();
        var backDiagonals = Enumerable.Range(0, (maxLength * 2)).Select(a =>
        {
            var c = a;
            return new string(lines.Select(b => 
            {
                c--;
                var result = c >= 0 && c < maxLength ? b[c] : '\0';
                return result;
            }
            ).ToArray());
        }).ToArray();

        //verticals
        IEnumerable<string> verticalLines = indices.Select(a => new string(lines.Select(b => b[a]).ToArray()));

        Console.WriteLine($"Horizontal matches: {lines.Sum(_basicXmas.Count)}");
        Console.WriteLine($"Vertical matches: {verticalLines.Sum(_basicXmas.Count)}");
        Console.WriteLine($"forward diagonal matches: {forwardDiagonals.Sum(_basicXmas.Count)}");
        Console.WriteLine($"back diagonal matches: {backDiagonals.Sum(_basicXmas.Count)}");

        var result = lines.Sum(_basicXmas.Count) + 
            verticalLines.Sum(_basicXmas.Count) + 
            forwardDiagonals.Sum(_basicXmas.Count) + 
            backDiagonals.Sum(_basicXmas.Count);

        return result.ToString();
    }
}
