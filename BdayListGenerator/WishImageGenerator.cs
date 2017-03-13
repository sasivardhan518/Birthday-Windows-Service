using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BdayListGenerator
{
    public class WishImageGenerator
    {
        public WishImageGenerator(string path,string name)
        {
            byte[] lnBuffer;
            byte[] lnFile;

            HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create("http://mynamepixs.com/result_display.php?id=2013&name="+ name + "&name2=fdfdgfgf");
            using (HttpWebResponse lxResponse = (HttpWebResponse)lxRequest.GetResponse())
            {
                using (BinaryReader lxBR = new BinaryReader(lxResponse.GetResponseStream()))
                {
                    using (MemoryStream lxMS = new MemoryStream())
                    {
                        lnBuffer = lxBR.ReadBytes(1024);
                        while (lnBuffer.Length > 0)
                        {
                            lxMS.Write(lnBuffer, 0, lnBuffer.Length);
                            lnBuffer = lxBR.ReadBytes(1024);
                        }
                        lnFile = new byte[(int)lxMS.Length];
                        lxMS.Position = 0;
                        lxMS.Read(lnFile, 0, lnFile.Length);
                    }
                }
            }

            using (System.IO.FileStream lxFS = new FileStream(path+@"\" + name.Replace(" ","")+".jpg", FileMode.Create))
            {
                lxFS.Write(lnFile, 0, lnFile.Length);
            }
        } 
    }
}
