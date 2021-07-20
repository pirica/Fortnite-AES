using System.IO;
using System.Net;

namespace FortniteAES.Grabber
{
    public class AESGrabber
    {
        const string aesurl = @"https://benbot.app/api/v1/aes";

        public static string GetKeys()
        {
            var wc = new WebClient();
            var keys = wc.DownloadString(aesurl).Split(new[] { '\r', '\n' })[0].Replace(",", "\n");
            return keys;
        }

        public static string WriteKeysToFile(string path)
        {
            var wc = new WebClient();
            var keys = wc.DownloadString(aesurl).Split(new[] { '\r', '\n' })[0].Replace(",", "\n");
            File.WriteAllText(path, keys);
            return path;
        }

        public static string GetMainKey()
        {
            var wc = new WebClient();
            var keys = wc.DownloadString(aesurl).Split(new[] { '\r', '\n' })[0].Replace(",", "\n");

            var keywithextra = keys.Remove(0, 69);
            int noofchar = 0;

            foreach (char c in keywithextra)
            {
                int temp = noofchar;
                noofchar = temp + 1;
            }

            var key = "";

            var tempnoc = noofchar;
            noofchar = tempnoc - 66;

            if (keywithextra.StartsWith("0x"))
            {
                key = keywithextra.Remove(66, noofchar);
            }
            else if (keywithextra.StartsWith("x"))
            {
                var temp = keywithextra;
                key = keywithextra = "0" + temp;
                key = keywithextra.Remove(66, noofchar);
            }
            else
            {
                throw new System.Exception("Failed. Key does not start with 0x.\n" + key);
            }

            return key;
        }
    }
}
