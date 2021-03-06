using System.IO;
using System.Net;

namespace FortniteAES.AESHistory
{
    public class AESHistory
    {
        const string aesurl = @"https://benbot.app/api/v1/aes";

        public static string GetOldKeys(string version)
        {
            var wc = new WebClient();
            var keys = wc.DownloadString(aesurl + "?version=" + version).Split(new[] { '\r', '\n' })[0].Replace(",", "\n");
            return keys;
        }

        public static string WriteOldKeysToFile(string version, string path)
        {
            var wc = new WebClient();
            var keys = wc.DownloadString(aesurl + "?version=" + version).Split(new[] { '\r', '\n' })[0].Replace(",", "\n");
            File.WriteAllText(path, keys);
            return path;
        }

        public static string GetOldMainKey(string version)
        {
            var wc = new WebClient();
            var keys = wc.DownloadString(aesurl + "?version=" + version).Split(new[] { '\r', '\n' })[0].Replace(",", "\n");

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
                keywithextra = "0" + temp;
                key = keywithextra.Remove(66, noofchar);
            }
            else
            {
                throw new System.Exception("Failed. Key does not start with 0x.\n" + key);
            }

            return key;
        }

        public static string GetOldKey(string version, string FileName)
        {
            var requested = FileName;

            var wc = new WebClient();
            var keys = wc.DownloadString(aesurl + "?version=" + version).Split(new[] { '\r', '\n' })[0].Replace(",", "\n");

            string keywithextra = keys.Remove(0, keys.IndexOf(requested, 0));

            var keywithextraonend = keywithextra.Remove(0, requested.Length + 3);

            int length = keywithextraonend.Length;

            var key = keywithextraonend.Remove(66, length - 66);

            return key;
        }
    }
}
