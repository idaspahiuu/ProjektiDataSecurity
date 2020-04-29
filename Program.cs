using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace _ds
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0].Equals("caesar"))
            {
                if (args[1].Equals("encrypt"))
                {
                    String text = args[3];
                    int key = Int32.Parse(args[2]);
                    String ctext = caesar.Encipher(text, key);
                    Console.WriteLine(ctext);
                }
                else if (args[1].Equals("decrypt"))
                {
                    String ctext = args[3];
                    int key = Int32.Parse(args[2]);
                    String plaintxt = caesar.Decipher(ctext, key);
                    Console.WriteLine(plaintxt);

                }

            }
            else if (args[0].Equals("vigenere"))
            {
                if (args[1].Equals("encrypt"))
                {
                    String text = args[3];
                    String key = args[2];
                    String ctext = vigenere.Encipher(text, key);
                    Console.WriteLine(ctext);
                }
                else if (args[1].Equals("decrypt"))
                {
                    String ctext = args[3];
                    String key = args[2];
                    String plaintxt = vigenere.Decipher(ctext, key);
                    Console.WriteLine(plaintxt);
                }
            }
            else if (args[0].Equals("rail-fence"))
            {
                if (args[1].Equals("encrypt"))
                {
                    String text = args[3];
                    int key = Int32.Parse(args[2]);
                    String ctext = RailFenceCipher.Encrypt(text, key);
                    Console.WriteLine(ctext);
                }
                else if (args[1].Equals("decrypt"))
                {
                    String ctext = args[3];
                    int key = Int32.Parse(args[2]);
                    String plaintxt = RailFenceCipher.Decrypt(ctext, key);
                    Console.WriteLine(plaintxt);
                }

            }
            else if (args[0].Equals("create-user"))
            {
                String s = args[1];
                string path = s + ".xml";
                var keyGenerator = new RSACryptoKeyGenerator();
                var keys = keyGenerator.generateKeys(1024);
                RSA.create(s, keys.PublicKeys, keys.PrivateKeys);
                Console.WriteLine("Eshte krijuar celesi privat " + s + ".xml");
                Console.WriteLine("Eshte krijuar celesi privat " + s + ".pub.xml");
                if (File.Exists(path))
                {
                    Console.WriteLine("Gabim: Celesi " + s + "eshte krijuar paraprakisht.");
                }

            }
            else if (args[0].Equals("delete-user"))
            {
                //komanda delete-user
                string s = args[1];
                string path = "keys\\" + s + ".xml";
                string path1 = "keys\\" + s + ".pub.xml";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    File.Delete(path1);
                    Console.WriteLine("Eshte larguar celesi publik " + path1);
                    Console.WriteLine("Eshte larguar celesi privat " + path);

                }
                else if (!File.Exists(path))
                {
                    Console.WriteLine("Gabim: Celesi " + s + " nuk ekziston!");
                }
            }
            else if (args[0].Equals("export-key"))//komanda export-key
            {
                if (args[1].Equals("public"))//nese argumenti 3 eshte public kthen celesin public
                {
                    string user = args[2];
                    string pubkey = "keys\\"+ user + ".pub.xml";
                    if (args[3].Equals(null))
                    {
                        if (!File.Exists(pubkey))//nese nuk ekziston fajlli me userin e caktuar e krijon dhe pastaj e ktthen celesin publik
                        {
                            var keyGenerator = new RSACryptoKeyGenerator();
                            var keys = keyGenerator.generateKeys(1024);
                            RSA.create(user, keys.PublicKeys, keys.PrivateKeys);
                            RSA.ex(pubkey);

                        }
                        else
                        {
                            RSA.ex(pubkey);

                        }
                    }
                    else
                    {
                        if (!File.Exists(pubkey))//nese nuk ekziston fajlli me userin e caktuar e krijon dhe pastaj e ktthen celesin publik
                        {
                            var keyGenerator = new RSACryptoKeyGenerator();
                            var keys = keyGenerator.generateKeys(1024);
                            RSA.create(user, keys.PublicKeys, keys.PrivateKeys);                            
                                                          
                               
                            RSA.exf(pubkey, args[3]);                                                      
                            Console.WriteLine("Celesi publik u ruajt ne fajllin " + args[3] + " ne folderin keys.");

                        }
                        else
                        {
                            RSA.exf(pubkey, args[3]);
                            Console.WriteLine("Celesi publik u ruajt ne fajllin " + args[3] + " ne folderin keys.");
                        }
                       
                    }
                }
                else if(args[1].Equals("private"))//komanda e cila kthen celesin privat
                {
                    string user = args[2];
                    string key = "keys\\" + user + ".xml";
                    if (args[3].Equals(null))
                    {
                        if (!File.Exists(key))//nese nuk ekziston fajlli me userin e caktuar e krijon fajllin dhe e shfaq celsin privat
                        {
                            var keyGenerator = new RSACryptoKeyGenerator();
                            var keys = keyGenerator.generateKeys(1024);
                            RSA.create(user, keys.PublicKeys, keys.PrivateKeys);
                            RSA.ex(key);

                        }
                        else
                        {
                            RSA.ex(key);

                        }
                    }
                    else
                    {
                        if (!File.Exists(key))//nese nuk ekziston fajlli me userin e caktuar e krijon fajllin dhe e shfaq celsin privat
                        {
                            var keyGenerator = new RSACryptoKeyGenerator();
                            var keys = keyGenerator.generateKeys(1024);
                            RSA.create(user, keys.PublicKeys, keys.PrivateKeys);
                            RSA.exf(key, args[3]);
                            Console.WriteLine("Celesi privat u ruajt ne fajllin " + args[3] + " ne folderin keys.");

                        }
                        else
                        {
                            RSA.exf(key, args[3]);
                            Console.WriteLine("Celesi privat u ruajt ne fajllin " + args[3] + " ne folderin keys.");

                        }
                    }
                }
                


            }

        }
    }

        class caesar
        {

            public static char cipher(char ch, int key)
            {
                //Kushti i cili merr parasysh edhe hapsirat
                if (!char.IsLetter(ch))
                {

                    return ch;
                }

                char d = char.IsUpper(ch) ? 'A' : 'a';
                return (char)((((ch + key) - d) % 26) + d);//kthen ciphertextin si charArray


            }


            public static string Encipher(string input, int key)
            {
                string output = string.Empty;

                foreach (char ch in input)
                    output += cipher(ch, key);

                return output;//kthen cipphertextin si string
            }

            public static string Decipher(string input, int key)
            {
                return Encipher(input, 26 - key);//kthen plaintextin
            }
        };

        class vigenere
        {
            private static int Mod(int a, int b)
            {
                return (a % b + b) % b;
            }//Funksioni per modulim

            private static string Cipher(string input, string key, bool encipher)
            {
                for (int i = 0; i < key.Length; ++i)
                    if (!char.IsLetter(key[i]))
                        return null; // Kushti qe merr parasysh edhe hapsirat

                string output = string.Empty;
                int p = 0;

                for (int i = 0; i < input.Length; ++i)
                {
                    if (char.IsLetter(input[i]))
                    {
                        bool cIsUpper = char.IsUpper(input[i]);
                        char offset = cIsUpper ? 'A' : 'a';
                        int indeksi = (i - p) % key.Length;
                        int k = (cIsUpper ? char.ToUpper(key[indeksi]) : char.ToLower(key[indeksi])) - offset;
                        k = encipher ? k : -k;
                        char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                        output += ch;
                    }
                    else
                    {
                        output += input[i];
                        ++p;
                    }
                }

                return output;
            }
            //funksioni per enkriptim
            public static string Encipher(string input, string key)
            {
                return Cipher(input, key, true);
            }
            //funksioni per dekriptim
            public static string Decipher(string input, string key)
            {
                return Cipher(input, key, false);
            }
        }

        public static class RailFenceCipher
        {

            public static string Encrypt(string text, int rails)
            {
                // Fshin karakeret e panevojshme ne tekst
                text = text.ToUpper();
                text = Regex.Replace(text, @"[^A-Z0-9]", string.Empty);

                var lines = new List<StringBuilder>();

                for (int i = 0; i < rails; i++)
                    lines.Add(new StringBuilder());

                //Mbushja e matrices

                int currentLine = 0;
                int direction = 1;

                for (int i = 0; i < text.Length; i++)
                {
                    lines[currentLine].Append(text[i]);

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }



                //rezultati ne nje rresht te vetem
                StringBuilder result = new StringBuilder();

                for (int i = 0; i < rails; i++)
                    result.Append(lines[i].ToString());

                return result.ToString();
            }

            public static string Decrypt(string text, int rails)
            {

                text = text.ToUpper();
                text = Regex.Replace(text, @"[^A-Z0-9]", string.Empty);

                var lines = new List<StringBuilder>();

                for (int i = 0; i < rails; i++)
                    lines.Add(new StringBuilder());

                //gjatesia e tekstit
                int[] linesLenght = Enumerable.Repeat(0, rails).ToArray();


                int currentLine = 0;
                int direction = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    linesLenght[currentLine]++;

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }

                int currentChar = 0;

                for (int line = 0; line < rails; line++)
                {
                    for (int c = 0; c < linesLenght[line]; c++)
                    {
                        lines[line].Append(text[currentChar]);
                        currentChar++;
                    }
                }

                StringBuilder result = new StringBuilder();

                currentLine = 0;
                direction = 1;

                //Tregon nga cili rresht merret karakteri
                int[] currentReadLine = Enumerable.Repeat(0, rails).ToArray();

                for (int i = 0; i < text.Length; i++)
                {

                    result.Append(lines[currentLine][currentReadLine[currentLine]]);
                    currentReadLine[currentLine]++;

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == rails - 1)
                        direction = -1;

                    currentLine += direction;
                }

                return result.ToString();

            }

        }
    class RSA
    {

        static RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();



        public static string create(string user, string pubKey, string prvKey)
        {
            string public_key;
            string private_key;
            public_key = "keys\\" + user + ".pub.xml";//path
            private_key = "keys\\" + user + ".xml";

            File.WriteAllText(public_key, pubKey);
            File.WriteAllText(private_key, prvKey);

            return "";
        }
        
        public static string ex(string path)
        {
            string xmlString = System.IO.File.ReadAllText(path);
            Console.WriteLine(xmlString);

            return "";
        }
        public static string exf(string path, string s)
        {
            string path1 = "keys\\" + s;
            string xmlString = System.IO.File.ReadAllText(path);
            File.WriteAllText(path1, xmlString);

            return "";
        }

    }

        public class RSAKeysTypes
        {
            public string PublicKeys { get; set; }
            public string PrivateKeys { get; set; }
        }

        public class RSACryptoKeyGenerator
        {
            public RSAKeysTypes generateKeys(int size)
            {
                var rsaTypes = new RSAKeysTypes();
                using (var provider = new RSACryptoServiceProvider(size))
                {
                    var pubKey = provider.ToXmlString(false);
                    var prvKey = provider.ToXmlString(true);
                    rsaTypes.PublicKeys = pubKey;
                    rsaTypes.PrivateKeys = prvKey;
                }
                return rsaTypes;
            }
        }
      
    
            
    
}

    





