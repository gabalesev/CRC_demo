using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRC16CCITT_Demo
{
    public class Core
    {
        private static ushort ComputeChecksum(byte[] bytes)
        {
            ushort poly = 4129;
            ushort[] table = new ushort[256];
            ushort initialValue = 0;

            ushort crc = initialValue;
            for (int i = 0; i < bytes.Length; i++)
            {
                crc = (ushort)(
                    (crc << 8) ^ table[
                        (
                            (crc >> 8) ^ (0xff & bytes[i])
                        )
                    ]
                );
            }
            return crc;
        }

        private static ushort Crc16CcittO(byte[] bytes)
        {
            const ushort poly = 4129;
            ushort[] table = new ushort[256];
            ushort initialValue = 0xffff;
            ushort temp, a;
            ushort crc = initialValue;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                        temp = (ushort)((temp << 1) ^ poly);
                    else
                        temp <<= 1;
                    a <<= 1;
                }
                table[i] = temp;
            }
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc;
        }

        public static byte[] AddCrcToBuffer(byte[] bytes, int longitud /*, ushort numpaq*/)
        {
            byte[] buffer = new byte[longitud + 2];

            ushort rescrc;

            Array.Copy(bytes, buffer, longitud);

            rescrc = ComputeChecksum(buffer);

            buffer[longitud] = (byte)(rescrc >> 8);

            buffer[longitud + 1] = (byte)(rescrc & 0x00ff);

            return buffer;
        }

        public static byte[] AddCrcToBuffero(byte[] bytes, int longitud /*, ushort numpaq*/)
        {
            byte[] buffer = new byte[longitud + 2];

            ushort rescrc;

            Array.Copy(bytes, buffer, longitud);

            rescrc = Crc16CcittO(buffer);

            buffer[longitud] = (byte)(rescrc >> 8);

            buffer[longitud + 1] = (byte)(rescrc & 0x00ff);

            return buffer;
        }
    }
}
