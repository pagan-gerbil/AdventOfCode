﻿using AdventUtils;
using AdventUtils.Models;

namespace Advent2024;

internal class Day12 : DayBase
{
    protected override string _sample1 => "RRRRIICCFF\r\nRRRRIICCCF\r\nVVRRRCCFFF\r\nVVRCCCJFFF\r\nVVVVCJJCFE\r\nVVIVCCJJEE\r\nVVIIICJJEE\r\nMIIIIIJJEE\r\nMIIISIJEEE\r\nMMMISSJEEE";

    protected override string _part1 => "YYYYYMMMMMMUUUUUUUUNNNNUTTTTTAASAXXXXXHHEEHHEEEEERYYYYYYYYYYHHHHHHHHHHHHHHHHFFFFFFFFFFAAAAAAAAAAAAAOOOOOOOOYYYYYYYYYYYYYYYYVVVVWWWWWWWZZZZZZ\r\nYYYYYMMMMMMUMUUUUUUUUUUUTTAAALAAAAXXXHHFHHHEEEEEERRRRYYYYYYQHHHHHHHHHHHHHHHHHFFFFFFFFFAAAAAAMMMMMMMMMMMOOOOOYYYYYYYYYYYYYYYVVVWWWWWWKWZZZZZZ\r\nYYYYYMMMMMMMMMMUUUUUUUUUTAAAAAAAAXXXXHHHHHHEEEEEERRRYYRYYYYQQHHHHHHHHHHHHHHHHFFFFFFAAAAAAAAAMMMMFMMMMOOOOOOOYYYYYYYYYYYYYYVVVVWWWTWKKWZKKZZZ\r\nYYYYYYMMMMMMMUUUUUUUUUUUUAAAAAAAAHHHHHHHHHHHEEERRRRRYYRQQQQQQHHHHHHHHHHHHHHHHFFFFFAAAAAAAAAAAMMMMMMMMOOOOOOOYYYYYYYYYYYNDDDDDDTTTTTKKKKKKZZZ\r\nYYYYMMMMMMMMMUUUUUUUUUUUUAAAAAAAAHHHHHHHHHHHMEERRRRRRRRRQQQQQQQHHHHHHHHHHHHHFFFFFFAAAAAAAAAAAMMMMMMMMOOOOOOOOYYYYYYYYYYNDDDDDDDDTTKKKKKKKKKK\r\nYYYMMMMMMMMMMMMUUUUUUUUUUAAAAAAAAHHHHHHHHHKHMEERRRRRRRRQQQQQQQQQHHHHHHHHHHHHHFFFFFFFAAAAAAMMMMMMMMMMMOOOOOOOYYKYYYYYYYYNNDDDDDDTTKKKKKKKKKKM\r\nYYYYMMMMMMMMMMMUUUUUUAUUUAAAAAAAHHHHHHHHMMMMMEERRIRRRQQQQQQQQQQQIHHHHHHHHHHHHHFFTTTFAVVAUUUUMMMMMMMMMMOOOOOOOYYYYYCYYDDDDDDDDDDTTTTTKKKKKKKM\r\nYYYMMMMMMMMMMMMMUPPUUAAAAAAAAAAAAHHYYLQQMMMMMEEIIIRRRRQQQQQQQQQQHHHHHHHHHHLLHFFTTTTTRRVVVVUUMMMMMMMMMMMOOOOOOYYYYYFFVVDDDDDDDDDKKKKKKKKKKKKK\r\nYYYMMMMMMMMMMMMMUPPPAAAAAAAAAABBAHHHHLQLLMLLMEIIIIIIRRQQQQQQQQQQQXHHHHHHHHKLHFFTTTTTRRVVVVVUMMMMMMMMPOOOOOOOYYYFYFFFFFFDDDDDDDDDKKKKKKKKKKKK\r\nYYYYMMMMMMMMMMOOUPPPPPNNAAAAABBOHHHHHLLLLLLLLIIIIIINIRRQQQQQQQQQQXHHHHHHHHKKHFFOOTTVVVVVVVVMMMMMMMMMPOOOOOOOOOFFFFFFFFFDDDDDDDDDWWKKKKKKKKKK\r\nYYYYYMMMMMMMMMMUUPPPPNNNAAABBBBOHHHHLLLLLLLLIIIIIIIIIRQQQQQQQQQQQXXHHHHHHHKKHFFKOTTVVVVVVVVVOMMMMMZMPOOOOOOOOOFFFFFFFFFFDDDDDDDDDWWKKKKKKKKK\r\nYEEMMMMMMMZMMMRRRPPNNNNNNAABBBBOOHHLLLLLLLLLLLIIIAIIIRRRQRQQQQQQQQXXHHHKCHKKKKKKOOOVVVVVVVVVVSMMMMMSOOOOOOOOOOFFFFFFFFFDDDDDDDDDWKKKKKKKKKKK\r\nEYEEMMMMMMMMMMRNNPNNNNNNAAAABBBOOLLLLLLLLLLLLIIIIIIIRRRRRRRRQQSQCSXXXXXKKKKKKKKKOOOVVVVVVSVVVSMMMMSSSOOOOOOOOOFFFFFFFFFFDDDDDDDDWKKKKKKKKWKK\r\nEEEEEQMMMMMGMRRTNNNNNNNNAAAAPAJAALLLLLLLLLLLLIIIIIIIRRRRRRRRQSSSSSSXXKKKKKKKKKKKKVVVVVVVRSVVSSMMSSSSSOOOOOOOCCFFFFFFFFFFDDDDDDDDWWKWWWWWKWWW\r\nEEEEEEEMNNMGTTTTTNNNNNNNAAAAAAAAALLLLLLLLLLLLIIIIIIIIRRRRRRRRSSSSSSXXKKKKKKKKKZZVVVVVVVVRSSSSSSSSSSSLOOOOLLOOLZFFFFFFFFFFFFDDDDDWWWWWWWWWWWW\r\nEEEEEEEMMEGGTTTTNNNNNNNWNAAAAAAJALLLLLLLLLLLIIIIIIIIBZZZZRRRSSSSSSSSSKKKKKKKKKZZZVVVVVRRRRRSSSSSSSLLLOLLLLLLLLPFFFFFFPFPFFDDDDDDDWWWWWWWWWWW\r\nEEEEEEEEEEEEVTTTNNNNNNNNNAAAAAAAPLLLWLLWWLLLLIIIIIIIBZZZZRRSSSSSSSSSAKKKKKKKKKZZZZVVVRRRRRRSSSSSSLLLLLLLLLLLLPPFFFFPPPPPFDDDDDDDDVWWWWWWWWWW\r\nEEEEEEEEEEEEETTTTTNNNNNNNAAAAAPPPPPLWWWWWLLLLLLZIIIBBBZZZZRSSSSSSSSSSKKKKKKKZZZZZZZVVRRVRRRRSSTSSLSLLLLLLLLLLLPPPPPPPPPPPDDDDDDDVVWWWWWWWWWW\r\nEEEEEEEEEEEEEEETTTNNNNNNNAAAAPPPPPPPPWWTWLLLLLLZZIIBBBZZZRRRSSSSSSWSKKKKKZZKZZZZZZZZZTRRRRRRTSTTSSSNNLLLLLLLLPPPPPBPPPPVDDDDDDDDDVVVWWWWWWWW\r\nEEEEENEEEEEEEEETTNNNNNNNNAAAAPPPPPPPPWAWWLLWLLZZZZIZZZZZZZRRSSSSSSSHHKKKKKZZZZZZZZZZZTTRRRRRTTTSSSSNNNNLLLLLLPPPPPPPPPBVVVDDDDDVVVVVWWWWWWWW\r\nEEEENNNEEEEEEEENNNNNNNNNNAGGDGGGGPPPPWWWWWWWLLZZZZZZZZZZZZRRSSSSSSSHHKKKKKQZZZZZZZZZZTTTTRRTTTTTSSSNNNNLLLLLLLLPPPPPPPVVVVVDDVDVVVVVWWWWWWWW\r\nEEEENNNNNNEEPPEPNNNNNNNMGGGGDDGGGGPPPWWWWWWWWWZZZZZZZZZZZZRRSSSSSSSHKKKKNNNPPZZZZZZZTTTTRRRTTTNNSNSNNNNLNLLLLLLPPPPPPPPVVVVVVVVVVVVWWWWWWWWW\r\nEEEENNNNNNNNPPPPNNNNNNNMGGGGGGGGGWWPPPWWWWWWWZZZZZZZZZZZZZZRRRSSSSSHHHHHHNNNZZZZZZZZTTTTTTTTNNNNNNNNNNNNNNLLLLPPPPPPEPEVVVVVVVVVVVVVWWWWWWWW\r\nEEENNNNNHNNNPNNNNNNNNNNNNGGWGGGGGGWWWWWWWWWWWZZZZZZZZZZZZZZRSSSSSSSSHHHHHNNNNNZZZZZTTTTTTTTTTNNNNNNNNNNNNNLLLLPPPPPPEPEEEVVEVVVVVVVVWWWWWUUW\r\nENNNNNNNNNNNNNJJNVVVVVNENGGGGGGGGGWWWWWWWWWSSRZRZZZZZZZZZZZZSSSSSSSHHHHQHHNNNZZZTTTTTTTTTTTTTNNNNNNNNNNNNNNNNLPPPPPPEEEEEEEEEEVVVVVWWVWWWUWW\r\nNDNNNNNNNNNNNNGGGVVVVNNVVGGGGGGGGGWWWWWWWWWWSRRRZZZZZZZZZZZZZSSSSSQHHHQQQQNNNNZTTTTTTTTTTTTTNNNNNNNNNNNNNNNNLLLLPPEEEEEEEEEEEEVVVVVVVVWWWUUU\r\nNNNNNNNNNNNNGGGGGGVVVVVVGGGGSGBBGGGWWWWWWWRRRRRNNNZZZZZZZZZZZQQQSQQQHQQQQNNNNNTTTTTTTTTTTTNTNNNNNNNNNNNNNKLLLLLLPPEKEEEEEEEEEEEEVVVVVWWWWWWU\r\nNNNNNNNNNNNNGGGGGGGGVVVVGGGGBBBBGGGGGWWWWVRRRRRRRNZZZZZZZZZZZQQQSQQQQQQQQNNNNNTTTTTTTTTTTTNNNNNNNNNNNNNNNKLLLLLKKKKKEEEEEEEEEEEEVVVVVWWWWWUU\r\nNNNNNNNNNNNNNGGGGGGGVVVGGBBBBBBBGGGGGGWWWRRRRRRRRRZZZZZZZZZZZQQQQQQQQQQQNNNNNNNTTTTTTTTTTTYNNNNNNNNNNNNYYKKKLLLKKKKKKKEEEEEEMMMMVVVMWWWWWWUW\r\nNNNNNNNNNNNNNZGGGGGVVVGGGGGGGGBGGGGGGOOWXRRRRRRRRRLZWWHZKZRZQQQQQQQQQQQQNNOOONTTTOBBTTTTTTTBBBNNNNNNNNNYYYKKKKKKKKKKKKEKEFEMMMMMZMMMWWWWWWUW\r\nNNNNNNNNNNNNZZZZZJJJJGGGGGGGGGGGGGGGGOOOXRRRRRRRRRRWWWWWWRRZQQQQQQQQQQQQQNNOONMTOOBBBTTCTCTBBBNNNNNNYYNYYYYYKKKFKFFKKKEKEMMMMSMMMMMMWWWWWWWW\r\nNNNNNNNNNNNNNZJJJJJJJJGGGGZGGGGGGGGGGGOOOORRRRRRRRWWWWWWWRWMWQQQQQQQQQPNNNOOOOOOOOOBTTTCCCBBBBNINNNNNYNYYYYYYFFFFFFFAKEKKMMMMMMMMMMWWWWWTTWW\r\nNNNCCNNNNNNNNNNJJJJJJJGGGZZZGGGGGGGGGGGOOLLTTRRRRRWWWWWWWWWWWWQQQQQQQQQQQOOOOOOOOOOBBBTTCCBBBBBNNTNNYYYYYYYYYFFFFFFAAAKKMMMMMMMMMMMWWWWWWTTW\r\nCCCCCNNNNNNNNJJJJJJJJCZZZZZZZGGGGGGGGGGOOLLTTRRRRRWWWWWWWWWQQQQQQQQQQQQQDDOOOOOOBOBBBBBBBBBBBBBYTTNYYYYYYYYYYFFFAALAAAAAMMMMMMMMMMMMWWWWWWTW\r\nCCCCCIINNNNNJJJJJJJJJJZZZZZZZGGGGGGGGGGGGTTTRRRRRWWWWWWWWWWQQQQQQQQQQQQQDDOOOOOOBBBBBBBBBBBBBBBYYYYYYYYYYYYYFFFFFAAAAAAAMMMMMMMMMMMMMWWWWWWW\r\nCCCCCCCCNNNKKKKJJJJJZZZZZZZZGGGGGGGGGGYTTTTTTRRWRWWWWWWKKZQQQQQQQHQZZTQQQOOOOOOOOBBBBBBBBBBBBBBYYYYYYYYYYYYYFFFFAAAAAAAAMMMMMMMMMMMMMWWWWWWW\r\nCCCCCCCCCNNNKJJJJJJZZZZZZZZZZGGGGGGJGTTTTTTTTRWWWWWWWWKKKKQQQQQQQQQQZZQZZOZOOOOOOBBBBBBBBBBBBKKYYYYYYYYYYYYWWFFFAAAAAAMMMMMMMMVVVMMMMWWWWWWW\r\nCCCCCCCCCNNNKMJJJJJZZZZZZWWWNWWKGGOJOTTTTTTTBRWWWWWWWWKKKKQQQQQQQQVZZZZZZZZOOOBBOBBBBBBBBKKBKKKKYYYYYYYYYYWWWFWFAAAAAAAMMMVVVVVVVVMMWWWWWWWW\r\nCCCCCCCCCCNNJJJJJJJZZZZZZZWWWWWWWGOOOOTTTTTTTWWWWWWWWKKKKKQQQQTQQQVVVVZZZZZMGBBBBBBBBBBBBBKKKKKYYYYYYYYYYWWWWWWWAAAAAAAMMMMVVVVVVVWWWWPPPPPW\r\nCCCCCCCCCNNNNJJJJJJZZZZZZZZWWZZZWOOOOTTTTTTTWWWWWWWWWKKKKEEEZZZZZZZVVVZZZZZGGBBBBBBBBBBKKKKKKKLLLYYYYYYYYGWWWWWWWWWWAAMMMMMMVVVVWWWWWWPDPPPW\r\nCCCCCCCCCCNFNFJJJZJJZZZZZZZWWZZBBBBOQQQTTTTTTWWWWWWWWKKKKKEGGZZZZZZZZZZZZZZGGGGGBBBBBKKKKKKKKKKLLYYYYYYYYGWWWWWWWWWWWWPMMMVVVVVVWWWPPPPPPPPP\r\nCCCCCCCCCCNFNFFZZZZZZZZZZZWWWZZBBBBBBBBBBTTRWWWWWWWWWWKKEEEGGGRZHHZZZZZZZZGGGGGBBBBBKKKKKKKKKKKKKYYYYYYYYWWWWWWWWWWWWWPPPPVVVVVVWWWPPPPPPPPP\r\nCCCCCCCCCCCFFFFFFZZZZZZZZZZZZZZBBBBBBBBBBTRRRRRRWWWWWWWWEEGGGGRRRHZZZZZZZZGGGGGGBBBEEEGKKKKKKKKKKYYYYYYYWWWWWWWWWWWWWWWPPPPDDVDWWWPPPPPPPPPP\r\nCCCCCCCCCCCFFFFFFFZZZZZZZZZZZZWBBBBBBBBBBQRRRRRRWRRRWWWWWEEGGGGRHHHZZZZZGGGGGGGGBBEEEEEKKKKKKKKKKKYKMJYYLWWWWWWWWWWWWWWWWWDDDDDWWWPPPPPPPPPP\r\nCCCCCCCCCCCCXPFFFFFZZZZZZZZZZZWBBBBBBBBBBQRRRRRRRRRRWRWWWEWRRRRRHHZZZZZZGGGGGGGGGBEEEEEEEEEKKKKKKKYKMMMLLLLWWWWWWTWWDDDDDDDDDDWWWWPPPPPPPPPP\r\nCCCCCCCCCCCCPPPPFFFZZZZZZZZZZZBBBBBBBBBORRRRRRRRRRRRRRWWWWWWRRRHHHHHHHZZGGGGGGGGGGEEEEEEEEKKKKKKKKKKMMMMMLLLLWWWTTWTTTDDDDDDDDDDDWPPPPRRPPPC\r\nCCCCCCCCCCCPPPPPFFFFZZZZZZZZZZBBBBBBBBBOLLRRRRRRRRRRRRWWWWWRRRHHHHHHHHHGGGGGGGGGGGEEEEEEEEEKKKKKKMMMMMMMMMMLLLWWTTTTTTTTDDDDDDDDDDPPPPPRPPPP\r\nCCCCCCCCCCCCPPPAFPLFZZZZZZZZZZBBBBBLLLLLLLRRRRRRRRRRRRWRWRRRRRHHHHHHHHHHGGGGGGGBBBGEEEEEEEEEKKKKMMMMMMMMMMMLNNNNTTTTTTTDDDDDDDDDCCCPPPPRRRPR\r\nCCCCCCCCCCPPPPPPPPBBZZZZZZZZBBBBBBBLLLLLLLLYYRRRRRRRRRRRRRRRRHHHHHHHHHHHGGGGGGGBBBGGGEEEEKKKKKKKMMMMMMMMMMMLLNNNNTTTTDDDDDDDDDDCCCCPPRRRRRPR\r\nCCCCCCCCCCCPPPPPPPBBBBBBBBDWBBBBBBBLLLLLLLLLRRRRRRRRRRRURRRRHHHHHHHHHHHBBBBBBBBBBBGGGEEEEEKKKKKMMMMMMMMMMMMLLNNNTTTTTTTDDDDDDDCCCRRRRRRRRRRR\r\nCCCCCCCCCCPPPPPPPBBBBBBBDDDWBBBBBBBLLLLLLLLLRBRRARLLLLRUURRRHWHHHHHHHHGBBBBBBBBBBGGQGEEEEEEKKKKMMMMMMMMMMMMMLNNNTTTTTTTTTDDDDDDWRRRRRRRRRRRR\r\nCCCCCCCCCCPPPPPPPBBBBBBDDDDDBBBBBBBBBBOLLLLLBBRRRLLLLLRUUUURRHHHHHHHHHHBBBBBBBBBBGGGGEEEEKKKKKMMMMMMMMMMMNNNNNNNNNNNTTTTWDDDDDWWRRRRRRRRRRRR\r\nCCBBBBCCCCPPPPPPPBBBBBBBBDDDBBBBBBBBBBLLLLLLBBRRLLLLLLRUUUUURHHHHHHHHHHBBBBBBBBBBAAAAEEEEKKKKKKKMMMMMMMMMNNNNNNNNNNNTWWWWWWWDWWWWRRRRRRRRRRR\r\nRRBRRBCBBCPPPPPPPBBBBBMMDDDDBBBBBBBBBBBLLLLLBBBRBLLLJJJUUUUUUEHHHHHHQQHBBBBBBBBBBAAAAEEEKKKKHHHHHHHHMMMMMNNNNNNNNNNNTWXWWWWWWWWWWWHRRRRRRRRR\r\nRRRRRBBBBBBBJPPBBBBBBBBBBDDDBBBBBBBBBBBLLLLLLBBBBBBLJJJBUUUUUEEHHHHQRQQQBBBBQQAAPAAAAEEAKKKKHHHHHHHHMZMMMNNNNNNNNNNNNWXWWWWWWWWWWWHRRRRRRRRR\r\nRRRBBBBBBBBJJPPBBBBBBBBBBBDDIIIIIIIIBBBLLLYLTTBBBBBLJJBBBUUUUEEHHHHQQQQQBBBBQQAAAAAAYEAAAKKKHHHHHHHHMZNNNNNNNNNNNNNXXXXWWZZZWWWJWWRRRRRRRRRR\r\nRRRBBRBBBIJJIBBBBBBBBBBBBBIIIIIIIIIIBBBLLLLLTTBBBBBLBJBBBBUBBHHHHHHHQQQQBBBBAAAAAAAAAAAPYKKKHHHHHHHHMZZZNNNNNNNNNNNNNXXXXZZBZZJJWWRRRRRRRRRR\r\nSSSSSSXBBIJIIIIBBBBBBBBBPIIIIIIIIILLLLLLLLLTTTBBBBBLBBBBBBBBBHHHHHHHQQQQBBBBAAAAAAAAAEEEEKKKYZZHHHHZZZZZZNNNNNNNNNNNXXXXZZZZZZJJJJJARRRRRRRR\r\nSLSSSSSIIIIIIIIBBBBBBBBIIIIIIIIIIIIILLLLLLLLTBBBBBBBBPBBBBBBHHHHHHQQQQQQQQQQAAAAAAAAAEEEEYKKYYYHHHHZZZZZZNNNNNNNNNXXXXXXZZZZZZZJJJJAAARRRRRR\r\nSSSSRSSIIIIIIIBBBBBBBBBBIIIIIIIIIIIELLLLLLTTTTBBBBPPPPPBIIBBBHHHHHHQQQQQQQQQQAAAAAAAAEEEEYYKYRRHHHHZZZZZZNNNNNNNNNNXXXZZZZZZZZJJJAAAAAARRRRR\r\nSSSSSSSPIIIIIIIIBBBBBBBKIIIIIIIIIIILLLLLLLTTTBBIIPPPPPIIIBBBBBHHHHHQQQQQQQQQQAAAAAAAAEEEEYYYYRRHHHHZZZZZZZNNNOONTTNNZXZZZZZZZJJJAAAAAAARRRRR\r\nSSSSSSPPPIIIIIIIIBBEBBBIIIIIIIIIIIILLLLLLLWTIOOIIIIIPIIIIBBBBHHHHHHQQQQQQQQQQQQAAAAAAEEEEYYYYRRRVVVZZZZZZZZNNNNNTTTZZXZZZZZZZZZZAAAAAAARRRRR\r\nSSSSSSIIIIIIIIIIIIEEBBQQIIIIIIIIIIIILLLLLLLLOOOIIIIIPIIIIBHBHHHHHHHHHQQQQQQQFQQAAAAAAEEEEYYYYYRRRVVVZVZZZZQCQQTTTTTTZZZZZZZZZAAAAAAAAAAAKRRR\r\nSSSSSSIIIIIIIIIIIIIIIIQQIIIIIIIIIILLLLLLLLLLROOOIIIIIIIIIHHHHHHHHHHHHQQQQQQQFFFBAAAAAEEEEYYRRRRRRVVVVVVVVQQQQQQTTTTTZZZZZZZZZOAAAAAAAAAAKRRF\r\nSSSSIIIIIIIIIIIIIIIIIIIQQIIIIIIIIILLLLLLLLLLOOOOOIIIIIFIIHHHHHHHDDDDQQQQQQQQQQFFQAEEEEEEEEEYRRRRRVVVVVVCVQQQQQLQTTTZZZZNZZZXAOAAAAAAAAAAAAAF\r\nSSIIIIIIIIIIIIIIIYYIJIIQQIIIIIIIIILLLLLLLLLLIIIIIIIIIIIJIHHHHHHHDDDDDQKQQQQQQQQFQAEEEEEEEEEYRRVVVVVVVVVCCQQQQQQQTTTTZZZNNNTTAAAAAAAAAAAAAAAF\r\nSSISSSIIIIIIIIHIIYIIHQQQQQIAAIIIIILLLLLLLLLLLIIIIIIIIIJJJJHHHHHHDDDDQQKQAQQQQQQQQAEEEEEEEEEYVVVVVVVVVVVVVVQQQQQQTTTTBBNNNTTTTAAAAAAAAAAAAAAF\r\nSSSSSSIIIIIIIHHHHHHHHHQQQAAAAIIAIALLLLLLHLLLIIIIIIIJJJJJHHHHHHHPDDDDDDDQQQSQQQQQQQEEEEEEEEEYYVVVVVVVVVVVFQQQQQQQQQTBBITNTTTTTTTTAAAAAAAAAAAF\r\nSSSSSSIIIHHIHHHHHHHHHHQQQQAAAAAAAAALHHHHHHHIIIIIEEJJJJJJJHHPPPPPDDDDDDDDSSSQQQQQQQEEEEEEEEEYVVVVVVVVVVVVQQQQQQQQQQQBBTTTTTTTTTTTTAAAAAAAABBB\r\nSSSSSSIIIHHHHHHHHHHHHHQAAAAAAAAAAAAHHHHHHHIIEEIEEJJJJJJJJEEPPPDDDDDDDDBYYSSQQQQQQQAYYDYYYYYYVVVRVVVVVVVVQQQQQQQQQQKBBOTTTTTTTTTTAAAAAAABBBBB\r\nRSSSSSSIIHHHHHHHHHHHHHQAAAAAAAHAAAAHHHHHHHHHHEEEEJJJJJJJEEEPDDDDDDDDDYBBYYQQQQQQQYYYYYYYYYYYYYVVVVVVVVVQQQQQQQQQQBBBBBZTTTTTTTTTTTAAAAABOBBB\r\nRSSSSSSHHHHHHHHHHHHHHHQQQDAAAAHHHHHHHHHHEHEEEEEEEEJEJEEEEEEDDDDDDDDDDYYYYYSQQQQQQQYYYYYYYYYYYYVVVVVVVVVVQQQQQQQBHBBBBBBTTTTTTTTTTTHAAAAABBBB\r\nRRRRRRVHHHHHHHHHHHHHHHHDDDAAAHHHHHHHHHHHEEEEEEEEEEJEEEEEDDDDDDDDDDDDDYYYIYSQQQQQQQQYYYYYYYYYYYVVVVVVVVVVVQQQQAAAAAAAAABBTTTTTTTTHHHAHAHBBBBB\r\nRRRRRRVHVVHVHHHHHHHHFFHDDDAAADHHHHHHHHHHECEEEEEEEEEEEEEDDDDDDDDDDDDDDYLYYYSSSSSSQQQYYYYYYYYYYVVVVVVVVVVVVVQQQAAAAAAAAABWTVVTTTTTHHHHHHHHHBBB\r\nRRRRRRVHVVVVVHHHHHHHFFFFDDDDDDHHHHHHHHHHECEEEEEEEEEEEEEDDDDDDDDDDDDDDLLLYQEESSSSSSSYYYYYYYYYYHVVVVVVVVVQQAAAAAAAAAAAAABSSSSTTTAHHHHHHHHHHBBB\r\nRRRRVVVVVVVVVVHHHHHHHFFDDDDDDDDHHDHHHHHHHEEEEEEEEETTEETDDDDDDDDDDDDDLLLLLEEEESSSSSSSSYYYYYYYYHLVVVLVVPIQQAAAAAAAAAAAAASSSSQTSTNNHHHHHHHHHHHH\r\nRRRRRVVVVVVVVVHHHHHHHFFDFDDDDDDDDDDHDHHHHHEEEEEEEETTTTTTTDDDDDDDDDDDLLZZZZEEEEEEESSSSYYYYYYXXLLLLLLIIIIIIAAAAAAAAAAAAASSSSSSSSNNNHHHHHHHHHHH\r\nRRRRVVVVVVVVVVDHHHHHFFFFFIDDDDDDDDDDDNHHHHEEEEEEEETTTTTTTTDDDDDDDDDDDZZZZZZEEEEEESEESEGYNXXXXXLLLLLIIIIIIAAAAAAAAAAAAASSSSSSNNNNNHHHHHHHHHHH\r\nRRRRVVVVVVVVVVVHHHHFFFFFIIDDDDDDDDDDDNNHHNQQEEEEEETTTTTTTZDDDDDDDDDDZZZZZZEEEEEEEEEEEEGXXXXXLLLLLLLLIIIIIAAAAAAAAQSSSSSSSSSSSSVHHHHHHHHHHHHH\r\nRRRRVVVVVVVVVVVJOHJFJJJIIDDDDDDDDDDDDNNHNNNNIEEEEETTTTTTTDDDDDDDDDDDZZZZZZZZZEEEEEEEEEEEXXXXXXXLLLLLLIIAAAAAAAAAAQSSSSSSSSSSGSVHHHHHHHHHHHHH\r\nRRRVVVVVVVVVVVVJOJJJJJJJIDDDDDDDDDDDNNNNNNNIIEYYEKTTTTTTTTDDDDNDNDZZZZZZZZZZEEEEEEEEEEXXXXXXXLLLLLIIIIIAAAAAAAAAAAAAZSSSSSSSSSSSVVVHHHHHHHHH\r\nRKRRVVVVVVVVVVJJJJJJJJJIIIIIDDDDDDDDDNNNNNNIIINYYATNTBTTTTDDDDNNNNNZZZZZZZZZEEEEEEEEEXXXXXXQLLLLLLIIIIIAAAAAAAAAAAAASSSSSSSSSCVVVVVHHHHHHHHH\r\nKKRRRVNVVVVVJJJJJJJJJJIIIIIIDDDDDDDDDNNNNNNNNNNYNAANABTTTTADDDNNNNNNZZZZZZZZEEEEEEEEXXXXXXQQQLLQLQIIIIIAAAAAAAAAAAAAASSSSSSSSVVVVVHHHHHHHHHH\r\nKKKKRNNVVVVVJJJJJJJJJIIIIIIDDDDRDDDDNNNNNNNNNNNNNAAAAATTAAAADDNNNNNNZZZZZZZEEEEEEEEXXXXXXXQQQOJJJJJJQIIAAAAAAAAAAAAAASSSSSSSSVVVVVVVVVVHHHHH\r\nWKKKWNVVVVVFJJJJJJJJJIIIIIIDDDDRRDNNNNNNNNNNNNUUUAAAAAAAAAAAADNNNNNSSZZZZEEEEEEEEEEEXXXJJJJJJJJJJJJJQIIIMEEEEEEEAAAAAEESSSYVVVVVVVVVVWVHHHHH\r\nWWWWWNNVVVVVVJJJJJJJJIIIIIIDDDRRRRRRNNNNNNNNNNNAAAAAAAAAAAAAADNNNNNSSSZZZEEEEEEEEEEFXSSJJJJJJJJJJJJJQQDSMMMEEEEEAAAAAESSSYYYVVVVVVVVVVVHHHHH\r\nWBWWWNNNVVVVJJJJJJJJJIIIIDDDDRRRRRRRNNNNNNNNNNEAAAAAAAAAAAAAANNNNNNZZZZZEEEEEEEEEEEEXSSJJJJJJJJJJJJJQQSSSSSSEEEEAAAAAEESSVVVVVVVVVVVVVVHHHHA\r\nBBWWWNNNVVJJJJJJJJJJJIIDDDDDRRRRRRRNNNNNNNNNNNEEEAAAAAAAAAAAANNNNNNSSSSEEEEEEEQEEENNNSSSJJJJJJJJJJJJQQSSSSSEEEEEAAAAEEEEVVVVVVVVVVVVVVHHHHHA\r\nBBWWWWNNNNNJJJJJJJJJIIIDDLLORRRRRRRRNNNNNNNNNNEEEAAAAAAAAAAAANNNNNNNNNEEEHHHEEEEEEEEESSSJJJJJJJJJJJJQSSSSPPPEPEEAAAAEEEEVVVVVVVVVVVVVVAAAAHA\r\nCBBBGGNGGNNNJJJJJJJJJILLLLLLQLRRRRROOOONNYNEEEEEAAAEEAAAAAAEENNNVVNNNNHHHHHEEEEEEEEESSSJJJJJJJJJJJJJSSSSSPPPPPPPAAAAEEEEEVVVVVVVVVSSVVVAAAAA\r\nCBBBGGGGGNNNNJJXJJJJJXBBBBLLLLRRRRRROOOONNNEOEEEEAAEEAAAAAAEEENNNVNNNNNNNHHEEEEESSSSSSSJJJJJJJJJSSSSSSSSSPPPPPPPPPEEEEEOOVVVVVVVSSSAAAAAAAAA\r\nCCBBGGGGGNNNNJXXJXXXXXBBBKLLLFRURRUUOOOOONOOOOOEEEEEEAEAAAEEENNNNNNNNNNNNEHEEEHEESSSSSSJJJJJSSSSSSSSSSSSPPPPPPPPPEEEEEEEOAAVVVVVVVAAAAAAAAAA\r\nCCBGGGGGGGNNXXXXXXXXXBBKBKKLLKUUUUOOOOOOOOOOOOOEEEEEEAEAEEEENNNNNNNNNNNNREEEEHHEESSSSSSJJJJJSSSSSSSSSSSSPPPPPPPPPEEEEEEEERAAAAAVAAAAAAAAAAAA\r\nCCCCGGGGGGNNXXXXXXXXXKKKKKKKLKKUUUUOOOOOOOOOOEEEEEEEEEEAEEEEEENNNNNNNNNNNNNJJIHHEHSWSSSJJJJJSSSSSSSSSPPMPPPPPPPPPEEEEEEEERAAAAAAAAAAAAAAAAAA\r\nCCCCGGGGGGGGXXXXXXXXXKKKKKKKKKKUUUUUDDOOOOOOOEEEEEEEEEEEEEEENNNNNNNNNNNNNJJJJIHHHHSWWSSJJJJJSKKKKSSSSSPPPPPPPPPPPVVEEEEEEEAAADAAAAAAAAAAAAAA\r\nCCCCGGGGGGGGXXXXXXXXXKKKKKKKKKKKKUUUDDOOOOOOOOEEEEEEEEEEEREEENNNNNNNNNNNNJJJIIIIISSSSVSSSRRSSKKKKSKSSPPZPPPPPPPPPPVEEEEEFFFADDADAAAAAAAAAAAA\r\nCCCGGGGGGGGGXXXXXXXXXXXKKKKKKKKKKKDDDNNOOOOOOEEEEEEEEEEEEREEENNNNNNNNNNXWJJJIIIIVVVVVVVVSKKKKKKKKSKKKKKZZPPPPPPPPPEEOEEEEFFDDDDDDDAAAAAAAAAA\r\nCCCCGGGGGGGGFXXXXXXXXKKKKKKKKKKKDDDDDNNNOOOOEEEEEELEEEEEERRRRRNNNNNNNNNXWJJJIIIIIIVVVVVIIKKKKKKKKKKKKKKKPPPPEEEPPPEEELEEEEDDDDDDDDAAAAAAAJAA\r\nCCCGGGGGGGGGFFXXLLXXKKKKKKKKKKKDDDDDDNNOOOOOEEEELLLLLLEEEERERRRNNNYNNNNWWWWIIIIIIIVIIIVIIYKKKKKKKKKKLLLKKPPPPEEEEPEEZEEEECDDDDDDDDAAAAAAXAAA\r\nCCCCGGGGGGGLLFFLLLLXXKKKKKKKKKKDDDDDNNOOOOOEELLLLLLLLLEEEEEEENNNNNMMMNNWWWIIIIIIIIIIIIIIBKKKKKKKKKKLLLKKEPEEEEEEEEEEEEEAEDDDDDDDDDDAXAXXXAAA\r\nCCCCGGGGGGLLLLLLLLXXDDKKKKKDKDDDDDDDDNNNNNNNNLLLLLLLLLEEEEEZENNRRRMLLLWWWWWWWIIIIIIIIIIIBKKKKKKKKKKKLLLLEEEEEEEEEEEEEEEAEADDDDDDDDDXXXXXXXXC\r\nCCCCGGGGGGWLLLLLLLXDDKKKKKKDKDDDDDDIIINNNNNNLLLLLLLLLLEEEEZZNNNMMMMLMMMWWWWWWIIIIIIIIQIBBBKKKKKKKKKKKKLLEEEEEEEEEEEEEPPAAADDDDDDDXXXXXXXXXXC\r\nCCCCGFGGGGWLLLLLLLLDDKKKDDDDDDDDDIIIIINNNNNNNLLLLLLLLLLEZZZMMMMMMMMMMMMGWWWWIIIIIIIIIQQQBBKKKKKKKKKKKKKLEEEEEEEEEEEEEEPAAADDDDDDDXXXXXXCCCCC\r\nCCCCCLLMGLLLLLLLLLLDDDKDDWDDDDDNNNNIIIIIIINNNNNLLLSSLSLZZZZZMMMMMMMMMMMMMWWWIIIIIIIIIIQQBBBKKKKKKKKKKKKKEEEEEEEEEEEEEPPPPADDDDDHDXXXXXMMMCCC\r\nCCLLLLLLLLLLLLLLLLLDDDKDDWWDWWWWNNNIIIIINNNNNNLLNLSSSSLLZZZMMMMMMMMMMMMMMWWWWIIIIIIIIKQQBBQKKKKKKKKKKKKKEEEEEEEEEEPEEEPPPDDDDDDDDXXXXXXMMMMM\r\nCCCCLLLLLLLLLLLLLLLDDDDDWWWWWWPPNNNIIIIJNNNNNNNNNLSSSULLZZZZMMMMMMMMMMMMMMWWIIIQIQIQQQQQBBQMKKKKKKKKKKKKEEEEEEEEEEPEEPPPDDDDDTDDDXXXXXXMMMMM\r\nCCCCLLLLLLLLLLLLLLLDDDDDDWWWWWWITIIIIIIINNNNNNNNNNSNSUZZZZZMMMMMMMMMMMMMMMWWIIQQQQQQQQQQQBQQXKKKKVVHHKKKKEEEEZEEEEPPPPPPPDDDDDDDXXXXXXXMMMMM\r\nCCCCCLLLLLLLLLLLLLLLLLDDDWWWWWWIIIIIIIIINNNNNNNNNNNNNQQZZZZZMMMMMMMMMMMMMMWWIIZZQQQQQQQQKQQQXXKKVVHHHHHHEEEEEZSEEEPPPPPVPPDVXXXXXXXMXXXMMMMM\r\nCCCCCLTLLLLLLLLLLLPLDDDDDWWWWWWIIIIIIIIINNNNNNNNNNNNQQZZZZZZMMMMMMMMMMMMMMMMZZZQQQQQQQQQQQQXXXXXHHHHHHHHHHZZZZSEPPPPPPPVVVVVVVXXXXXMMMMMMMMM\r\nCCCCCCTTLLLLLLLLTLLDDDDDDDWWWWWWWIIIIIINNNNNNNNNNNNNQQQQQQQQQMMMMMMMOOOMMMMZZZQQQQQQQQQBBQQXXHHHHHHHHHHHHHZZZZZZPPPPPPPVVVVVVVVXVVXMMMMMMMMM\r\nCCCCCCCLLLLLLLLLTLLDDDWWWDWWWWWWWIWTIINNNNNNNNNNNNNNQQQQHQQQKKKKKOMOOXOMMMMZZZZQQQQQQQQQQQQQXHHHHHHHHHHHGZZZZZLZPPPPPPPXNVVVVVVVVVMMMMMMMMMM\r\nRRCCCCRRLYLLLLTTTIDDDDWWWWWOWWWWWWWWIIWNNNNNNNNNNNNNQQQQQQQQQQKKKOOOOOOMMMMZZZZZQQQQQQQQQQQQHHHHHHHHHHHHGZZZZZZZPPPPXXPXVVVVVVVVVVMMMMMMMMMM\r\nRCCCRRRLLYRAALLTRIIIIIBWWWWWWWWWWWWWWWWNNNNNNNXNNNNQQQQQQQQQQKKKKKOOOMMMMMMMZZZZQQQQQQQQQQQQWHHHHHHHHHHHHZZZZZZZYPPPXXXXDVVVVVVVVVVMMMMMMMMM\r\nRRRCRRRRRRRRRZRRRIIIIIBBWWZWWWWWWWWWWWNNNNNNNXXXNNNQQQQQQQQQKKKKKKOOOOMMMMMMZKKKKKQQQQQQQQQQWWHHHHHHHHHHSZZZZZZZMPPPXXXXXVVXMMVVVVMMMMMMMMMM\r\nRRRRRRRRRRRRRRRRIIIIIIBWWWZZWWWWWWWWWNNNNNNTTXXNNNQQQQQQQQQQQQNNNNNOOOMMMMMMZZZZZZQQQQQQQQQWWWHHHHHHHHHSSZZZZZZMMMMMXXXXXXXXMMVVVVTMMMMMMMMM\r\nRRRRRRRRRRRRRRFRIIIIIIBBBWWZZWWWWWWWWNNNNNTTTXNNQQQQQQQQQQQQQQZNNNNNNNMMMMMMMZZZZZQWWQQQQQQWWWWHHHHHHHHHSZZZMZMMMXXXXXXXXXXXXXXXVCMMMMMMMMMM\r\nRRRRRRRRRRRRRRRIIIIIIIIBBWWZZZWWWWWWWWWNCTTTTTQQQQQQQQQQQQQQQSNNNNNNNNNNMMMMMMGGGGQWWWWQQQQWWWWHLHHHHHHSSSZMMMMMMXXXXXXXXXXXXXXCVCMMMMMMMMMM\r\nRRRRRRRRRRRRRRRIIIIIIIISBBBIZZZWWWWWWWTTTTTTTTQQQQQQQBBQQMQPQNNNNNNNNNNNMMMMMMGIGGGGWWWQQVQLLLWLLHHHHHHHSMMMMMMMMMXXXXXXXXXXXXCCCCMMMMMMMMMM\r\nRRRRRRRRRRRRRRRIIIIIIGSSBBIIIIZZWWWWWTTTTTTTTTTQQQGQQBBQQQQQHNNNNNNNNNNNMMMGGGGGGGGGWWWWQQTTLLLLLHUHHHHHSMMMMMMMMMJJTXTTXXXXXXCCLLKKMMMMMMMM\r\nRRRRRRRRRRRRRRCIIIIISSSSBBSIIIIIWWWWWWITTTTTTTTTQQGQQBBBQQQNHNNNNNNNNNNNNMMMMGGGGGGGGGWTTTTTTTLLLLUHHHHSSMMMMMMMMMJJTTTTXXXXXLLLLLKLLMMMMMTM\r\nRZRRRRRRRRRRRRIIIIIIIISSSSSIIIIIWWWIIIITTTTTTTTTTTGQAGBBQBQNNNNNNNNNNNNNNNMMMGGGGGGGGTTTTTTTTTLLLTTHHHHSMMMIMMMJMJJJJTTTXXXXXZZLLLLLLWMWMMMZ\r\nZZRRRRJRRRRRRRIIIIIIIISSSSSIIIIIWIIIIIIIIITTTTGGGGGGGGBBBBBNNNNNNNNNNNNNNNMMMMMGGGGGGTTTTTTTTTLLTTTHLAAAAMMAJJJJJJJJTTTTXXXXXLLLLLLLLWWWMMMM\r\nZZZRRRJJRRRRRIIIIIIISSSSSSIIIIIIIIIIIGGIIIIITTGGGGGGGGGGGBBBNNNNNNNNNNNNNMMMMMMMMGGGTTTTTTTTTTTTTTAAAAAAAMAAJJJJJJJJTTTTXXXXXXLLLLLLLLWWMMWW\r\nZZZRZZJJJJRJIIIIIIIIISPSSSFPIIIIIIIIIGGIIIIGGGGGGGGGGGGGGBNNNNNNNNNNNNWNMMMMMMMMMMMTTTTTTTTTTTTTTTTAAAAAAQAAAAAJJJJJJJTXXXXXXXLLLLLLLLLWWWWW\r\nZZZZZJJJJJJJJJJIIIIIIIIJSFFFIIIIIIIIIGIIIIIGGGGGGGGGGGGGGGQYNNNNNNNYNNYNMMMMMMMMMMMTDTTTTTTTTTTTTTAAAAAAAAAAAAAJJJJXXXXXXXXXXXLLLLLLLFLWWWWW\r\nCZZZZJJJJJJJJJIIIIIIJIJJFFFFIIIIIIIIIIIIIIGGGGGGGGGGGGGGGYYYYYYNNNNYYYYYYYDMMMMMMMMMDDTTTTTTTTTTTTAAAAAAAAAAAAJJJJJXXXXXXXXXAAAALLLLLLLLWWWW\r\nCZZZZJJZZJJJJJJJJIIIJIJFFFFFIIIIIIIIIIIIIIIGGGGGGGGGGGGGGYYYYYYYYYYYYYYYYYDMMMMMMMMDDDDTTTTTTTTTTTADAAAAAAAAYJJJJJJJJXXXXXXXXXXALLLLLLXBBWWW\r\nZZZZZZZZAZJJJRJRRRIIJJJOWWYYIIIIIIIIOOIIIIGGGGGGGGGGGGAAAYYYYYYYYYYYYYYYYYYMMXMMMMDDDDDDDDTTDDTTTTDAAAAAAAAAYJJJJJJJWWWXWWWXXAAAAALLYLXBBWBB\r\nZZZZZZZZAZJRRRRRRJJIJJOOWWYYIIYIOOOOOOOIIGGGGGGGGGGGAGAAYYYYYYYYYYYYYYYYYYYYMMMMEDDDDDDDDDDDDDDDTDDDAAAAAAAAADJJJJJJWWWWWWWWAAAAALLLLLLBBBBB\r\nZZZZZZZZZZJJRRRJJJJJJOOOWYYYYYYIOOOOOOOOGGGGGGGGGGGGAGAAAYYYYYYYYYYSYYYYYYYEEEMEEEEDDDDDDDDDDDDDDDDDDAAAAAADDDDJDJKWWWWWWWAAAAAALLLSBBBBBBBB\r\nZZZZZZZZZJJWWWWJJJJOJOOOOOOCYYBOOOOOOOOOGGSGGGGGGGGGAAAAYYYYYYYYYYSSSSYYEEEEEEEEEEDDDDDDDDDDDDDDDDDDDAADDDDDDDDDDKKKWKKWWWWWAAAAALLSBBBBBBBB\r\nZZZZZZZZZZZWWWWJJJJOOOOOOOOOOFOOOOOOOOOOOGGGGGGDDDQQQQQAAYYYYYYYYSSSSSSYEEEEEEEEEDDDDDDDDDDDDDDDDDDDDDDDDDDDDDKKKKKKKKKWWWXXAAAAASSSSBBBBBBB\r\nZZZZZZZZZWWWWWWWWJOOOOOOOOOOIOOOOOOOOOOOGBBBGGGDDQQQQQQQYYYYYYYYYYGSSSSSSSEEEEEEEDDDDDDDDDDDDDDDDDDDDDDDDDDDDKKKKKKKKKKWWXXXAAAAAASSSBBBBBBB\r\nZZZZZZWWWWWWWWWWJJOOOOOOOOOOOOAOOOOOOOOBBBBBGTSSDQQQQQQQYYYYYYYYOOCCSSSSSEEEEEEEEEDDDDDDDDDDDDDDEDDDDDDDSDDDDKEKKKKKKKKXXXXXWWWAAABBBBBBBBBB\r\nZZZZZZWWWWWWWWWWJJOOOOOOOOOOOOOOOOOOOBBBBBBBBSSSSQQQQQQQYVYYYYYYYOOCCCSSCEEEEEEEEEEDDDDDDDDDDDDDEEEDSSDDSDDDKKKKKKKKKKKXXXXXWWWWBUBBBBBBBBBB\r\nSZZZZZZWWWWWWWWSOOOOOOOOOOOOOOOOOOOOBBBBBBBBBSSSQQQQQQQQYYYYYYYMYOOCCCSSCCCCCCCEEEEDDDDDDDDDDDDEEEEEPSSSSDKKKKIKKKKKKKKBXXXXXWWWBBBBBBBBBBBB\r\nZZWWWWZWWWWWWWWWOOOOOOOOOOOOOOOOOOOOOOOBBBBBBBBBQQQQQQQQQYYYYOOYYOKKCCCCCCCCCCCCEEEDDDDDDDDZEEEEEEESSSSSSSSSDKKKKKKKKKKXXXXXXWWWWWWBBBBBBBBB\r\nZWWWWWWWWWWWWWWWWNNNOOOOOOOOOOOOOOOOOOBBBBBBBBBBQQQQQQQQQQQQYOOOOOKKKCCCCCCCCCCEEEEDDDEDDDDDEEEEEEFSSSSSSSSSSKKKKKKKKKXXXXXXWWWWWWWBBBBBBBBB\r\nMWWWWWWWWWWWWWWNNNNNOOOOOOOOOOOOOOOOOOBOBBBBBBBBBSQQQQQQQQQQQOOOOOCCKKCCCCCCCCCEEEEEEEEEEDDEEEEEEEEESSSSSSSSKKKKKKKKKKXXXXXWWWWWWBBBBBBBBBBB\r\nMMWWWWWWWWWWWWWWWNNNOOOOOOOOOOOOOOOOOOOOBBBBBBBBBBQQQQQQQQQQQOOOOOCCCCCCCCCCLLCEEEEEEEEEEEEEEEEEEEEEMSSSSSISRKIIKKKKGKXXXXXXXWWWWBBBBBBBBBBB";

    protected override string Part1Internal(string input)
    {
        long counter = GetAreaValues(input, false);

        return counter.ToString();
    }

    protected override string Part2Internal(string input)
    {
        long counter = GetAreaValues(input, true);

        return counter.ToString();
    }

    private static long GetAreaValues(string input, bool countSidesNotPerimeter)
    {
        var grid = input.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToArray();

        var height = grid.Length;
        var width = grid[0].Length;

        var visitedLocations = new HashSet<Coord>();

        var adjacents = new Queue<Coord>();
        adjacents.Enqueue(new Coord(0, 0));

        var counter = 0L;

        for (var x = 0; x < height; x++)
        {
            for (var y = 0; y < width; y++)
            {
                if (visitedLocations.Contains(new Coord(x, y))) { continue; }
                if (!adjacents.Any())
                {
                    adjacents.Enqueue(new Coord(x, y));
                }

                var letter = grid[x][y];
                var area = 0;
                var perimeter = 0;
                var sides = 0;

                var cellsInThisRegion = new List<Coord>();

                while (adjacents.Any())
                {
                    var next = adjacents.Dequeue();
                    if (grid[next.X][next.Y] == letter)
                    {
                        if (visitedLocations.Contains(next)) { continue; }
                        area++;
                        if (next.X > 0) adjacents.Enqueue(new Coord(next.X - 1, next.Y)); else perimeter++;
                        if (next.Y > 0) adjacents.Enqueue(new Coord(next.X, next.Y - 1)); else perimeter++;
                        if (next.X < height - 1) adjacents.Enqueue(new Coord(next.X + 1, next.Y)); else perimeter++;
                        if (next.Y < width - 1) adjacents.Enqueue(new Coord(next.X, next.Y + 1)); else perimeter++;
                        visitedLocations.Add(next);
                        cellsInThisRegion.Add(next);
                    }
                    else
                    {
                        perimeter++;
                    }
                }

                sides = GetNumberOfSidesX(cellsInThisRegion) + GetNumberOfSidesY(cellsInThisRegion);

                counter += countSidesNotPerimeter ? (area * sides) : (area * perimeter);
            }
        }

        return counter;
    }

    private static int GetNumberOfSidesX(List<Coord> cellsInThisRegion)
    {
        var result = 0;

        var rows = cellsInThisRegion.Select(x => x.X).Distinct().Order().ToArray();

        if (rows.Length == 1) return 2;

        var lastRow = new List<(long min, long max)>();

        for (var r = 0; r < rows.Count(); r++)
        {
            var cells = cellsInThisRegion.Where(x => x.X == rows[r]).Select(x => x.Y).Order().ToArray();

            var contiguousSetsInRow = new List<(long min, long max)>();
            var current = (min: cells.First(), max: 0L);
            for (var i = 1; i < cells.Length; i++)
            {
                if (cells[i] == cells[i - 1] + 1)
                {
                    continue;
                }
                current.max = cells[i - 1];
                contiguousSetsInRow.Add(current);
                current = new (cells[i], cells[i]);
            }
            if (!contiguousSetsInRow.Contains(current))
            {
                current.max = cells[cells.Length - 1];
                contiguousSetsInRow.Add(current);
            }

            if (r == 0)
            {
                result++;
                lastRow = contiguousSetsInRow;
                continue;
            }

            var count = contiguousSetsInRow.Count * 2;
            count -= contiguousSetsInRow.Sum(x => lastRow.Count(y => y.min == x.min)) + contiguousSetsInRow.Sum(x=>lastRow.Count(y=>y.max == x.max));
            result += count;

            lastRow = contiguousSetsInRow;

            if (r + 1 == rows.Count())
            {
                result += contiguousSetsInRow.Count;
            }
        }

        return result;
    }

    private static int GetNumberOfSidesY(List<Coord> cellsInThisRegion)
    {
        var result = 0;

        var columns = cellsInThisRegion.Select(x => x.Y).Distinct().Order().ToArray();

        if (columns.Length == 1) return 2;

        var lastColumn = new List<(long min, long max)>();

        for (var c = 0; c < columns.Count(); c++)
        {
            var cells = cellsInThisRegion.Where(x => x.Y == columns[c]).Select(x => x.X).Order().ToArray();

            var contiguousSetsInColumn = new List<(long min, long max)>();
            var current = (min: cells.First(), max: 0L);
            for (var i = 1; i < cells.Length; i++)
            {
                if (cells[i] == cells[i - 1] + 1)
                {
                    continue;
                }
                current.max = cells[i - 1];
                contiguousSetsInColumn.Add(current);
                current = new(cells[i], cells[i]);
            }
            if (!contiguousSetsInColumn.Contains(current))
            {
                current.max = cells[cells.Length - 1];
                contiguousSetsInColumn.Add(current);
            }

            if (c == 0)
            {
                result++;
                lastColumn = contiguousSetsInColumn;
                continue;
            }

            var count = contiguousSetsInColumn.Count * 2;
            count -= contiguousSetsInColumn.Sum(x => lastColumn.Count(y => y.min == x.min)) + contiguousSetsInColumn.Sum(x => lastColumn.Count(y => y.max == x.max));
            result += count;

            lastColumn = contiguousSetsInColumn;

            if (c + 1 == columns.Count())
            {
                result += contiguousSetsInColumn.Count;
            }
        }

        return result;
    }

}
