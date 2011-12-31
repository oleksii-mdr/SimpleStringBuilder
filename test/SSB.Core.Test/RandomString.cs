using System;
using System.Text;

namespace SSB.Core.Test
{
    public static class RandomString
    {
        private static Random _random = new Random();

        public static string NextString(this Random r, int size)
        {
            var data = new byte[size];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)r.Next(0, 128);
            }
            var encoding = new ASCIIEncoding();
            return encoding.GetString(data);
        }
    }
}
