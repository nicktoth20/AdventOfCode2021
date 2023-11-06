using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AdventOfCode2021
{
    public class Day16
    {
        private readonly Parser _parser;
        private int _result = 0;

        public Day16()
        {
            _parser = new Parser();
        }

        public int ExecutePart1(string fileName)
        {
            var map = _parser.ParseLines(fileName).ToList();
            //var binaryString = String.Join(String.Empty,
            //    map[0].Select(
            //        c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
            //    )
            //);
            //var version = Convert.ToInt32(binaryString[..3], 2).ToString();
            //var packageTypeId = Convert.ToInt32(binaryString.Substring(3, 3), 2).ToString();
            //var lengthTypeId = Convert.ToInt32(binaryString.Substring(6, 1), 2);
            //var length = lengthTypeId == 0 ? 15 : 11;
            //var lengthOfSubPackets = Convert.ToInt32(binaryString.Substring(7, length), 2);
            //binaryString = binaryString.Substring(7 + length, lengthOfSubPackets);

            var packet = GetPacket(map[0]);
            if (packet.PackageTypeId == 4)
            {
                var (a, b) = packet.GetLiteralValue();
                return (int)a;
            }

            var length = packet.SubPacketLength;
            var result = 0;
            var subpacket = new Packet(packet.SubPackets);
            _result += packet.Version;
            do
            {
                _result += subpacket.Version;
                var (a, b) = subpacket.GetLiteralValue();
                var l = (int)b + (subpacket.Length + 6);
                result += l;
                if (result < length)
                {
                    subpacket = new Packet(packet.SubPackets[l..]);
                }
            } while (result < length);

            return _result += packet.Version;
        }

        public Packet GetPacket(string hexCode)
        {
            var binaryCode = GetBinaryCode(hexCode);
            return new Packet(binaryCode);
        }

        public void GetSubPacketCount(Packet packet)
        {
            //var subPacket = new Packet(packet.SubPackets);
            //if (subPacket.PackageTypeId != 4)
            //{
            //    _result += subPacket.Version;
            //    GetSubPacketCount(subPacket);
            //}
            //else
            //{
            //    _result += subPacket.Version;
            //    var (test, nextPacket) = subPacket.GetLiteralValue();
            //    //_result += (int)test;
            //    if (nextPacket.Any(a => a == '1'))
            //    {
            //        subPacket = new Packet(nextPacket);
            //        var (a, b) = subPacket.GetLiteralValue();
            //        //_result += (int) a;
            //    }
            //}
        }
        public string GetBinaryCode(string hexCode)
        {
            return string.Join(string.Empty,
                hexCode.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
        }

        public class Packet
        {
            private string BinaryCode { get; }
            public Packet(string binaryCode)
            {
                BinaryCode = binaryCode;
            }

            public int Version => Convert.ToInt32(BinaryCode[..3], 2);
            public int PackageTypeId => Convert.ToInt32(BinaryCode.Substring(3, 3), 2);
            public int LengthTypeId => Convert.ToInt32(BinaryCode.Substring(6, 1), 2);
            public int Length => PackageTypeId == 4 ? 0 : LengthTypeId == 0 ? 15 : 11;
            public string SubPackets => PackageTypeId == 4 ? null : BinaryCode[(7 + Length)..];
            public int SubPacketLength => Convert.ToInt32(BinaryCode.Substring(7, Length), 2);
            public string LiteralValue => PackageTypeId == 4 ? BinaryCode[6..] : null;

            public (int?, int?) GetLiteralValue()
            {
                if (PackageTypeId != 4)
                {
                    return (null, null);
                }

                var digitPackets = LiteralValue;
                var sb = new StringBuilder();
                var cont = true;
                var length = 0;
                do
                {
                    cont = digitPackets[0] == '1';
                    sb.Append(digitPackets[1..5]);
                    length += 5;
                    if (digitPackets.Length > 5)
                    {
                        digitPackets = digitPackets[5..];
                    }
                } while (cont);
                return (Convert.ToInt32(sb.ToString(), 2), length); 
            }
        }
    }
}
