using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PngToBin
{
    class Program
    {
        static void Main(string[] args)
        {
            String src = args[0];
            Path.GetFileName(src);
            ;
            String dst = Path.GetDirectoryName(src) + Path.DirectorySeparatorChar+Path.GetFileNameWithoutExtension(src) + ".bin";
            FileStream fs = new FileStream(dst, FileMode.Create);
            Bitmap b = new Bitmap(src);
             for (int y = 0; y < b.Height; y++)
                {
                for (int x = 0; x < b.Width; x++)
                {
                    Color c = b.GetPixel(x, y);
                    byte[] tmp = new byte[4];
                    tmp[3] = c.A;
                    tmp[2] = c.R;
                    tmp[1] = c.G;
                    tmp[0] = c.B;
                    fs.Write(tmp, 0, 4);
                }
            }
            fs.Close();
        }
    }
}
