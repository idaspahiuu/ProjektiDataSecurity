﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Net;


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
                Regex regex1 = new Regex(@"^[a-zA-Z0-9_]+$");

                String s = args[1];
                if (regex1.IsMatch(s))
                {
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
                else
                {
                    Console.WriteLine("Gabim: Emrat duhet te përmbajne vetem simbolet A-Z, a-z, 0-9, dhe \"_\" !");
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
                if (args[1].Equals("public"))//per cels publik
                {
                    if (args.Length == 3)//kontrollon numrin e argumenteve

                    {   //nese jane 3 argumente atehere vetem do te shfaqet permbajtja e celsit
                        string user = args[2];
                        string path = "keys\\" + user + ".pub.xml";
                        if (!File.Exists(path))//kontrollon a ekziston fajlli nga i cili do te behet eksporti
                        {
                            Console.WriteLine("Gabim: Celesi publik " + path + " nuk ekziston!");
                        }
                        else
                        {
                            RSA.ex(path);
                        }
                    }
                    else
                    {  
                        //nese jepet edhe shtegu ku do te ekportohet fajlli si argument
                        string user = args[2];
                        string path = "keys\\" + user + ".pub.xml";
                        string path1 = args[3];
                        if (!File.Exists(path))
                        {
                            Console.WriteLine("Gabim: Celesi publik " + path + " nuk ekziston!");
                        }
                        else
                        {
                            RSA.exf(path, path1);
                            Console.WriteLine("Celesi publik u ruajt ne fajllin " + args[3] + " ne folderin keys.");
                        }
                    }



                }
                else if (args[1].Equals("private"))//per cels privat
                {
                    if (args.Length == 3)//kontrollo numrin e argumenteve
                    {
                        //nese jane 3 argumente, kthen vetem permbajten e celsit
                        string user = args[2];
                        string path = "keys\\" + user + ".xml";
                        if (!File.Exists(path))
                        {
                            Console.WriteLine("Gabim: Celesi publik " + path + " nuk ekziston!");
                        }
                        else
                        {
                            RSA.ex(path);
                        }
                    }
                    else
                    {   //argumenti 4 paraqet shtegun ku do te eksportohet celsi
                        string user = args[2];
                        string path = "keys\\" + user + ".xml";
                        string path1 = args[3];
                        if (!File.Exists(path))
                        {
                            Console.WriteLine("Gabim: Celesi publik " + path + " nuk ekziston!");
                        }
                        else
                        {
                            RSA.exf(path, path1);
                            Console.WriteLine("Celesi privat u ruajt ne fajllin " + args[3] + " ne folderin keys.");
                        }
                    }

                }

            }


            else if (args[0].Equals("import-key"))//komanda import-key
            {
                RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();
                string user = args[1];
                string path1 = "keys\\" + user + ".xml";
                string path2 = "keys\\" + user + ".pub.xml";
                string path = args[2];

                //kontrollo nese fajlli nga i cili do te importojme celsin eshte xml file
                if (path.Contains(".xml"))
                {
                    string xmlString = System.IO.File.ReadAllText(path);
                    //kontrollo permbajtjen
                    if (xmlString.Contains("<P>"))
                    {
                        File.WriteAllText(path1, xmlString);
                        //gjenerimi i celsit publik pasi qe celsi qe importohet eshte privat
                        string strXmlParameters = objRSA.ToXmlString(true);
                        StreamWriter sw = new StreamWriter(path2);
                        sw.Write(strXmlParameters);
                        sw.Close();
                        Console.WriteLine("Celesi privat u ruajt ne fajllin " + path1);
                        Console.WriteLine("Celesi publik u ruajt ne fajllin " + path2);


                    }
                    //nese ekziston useri paraprakisht
                    else if (File.Exists(path1) || File.Exists(path2))
                    {
                        Console.WriteLine("Gabim: Celesi " + user + " ekziston paraprakisht.");
                    }
                    //ruajtja e celsit publik
                    else
                    {
                        File.WriteAllText(path2, xmlString);
                        Console.WriteLine("Celesi publik u ruajt ne fajllin " + path2);
                    }
                }
                //kontrollo nese path permban http
                else if (path.Contains("http"))
                {

                    //Get request

                    WebRequest request = WebRequest.Create(
                      path);

                    request.Credentials = CredentialCache.DefaultCredentials;


                    WebResponse response = request.GetResponse();



                    //marrja e trupit te pergjigjes si vlere e celsit
                    using (Stream dataStream = response.GetResponseStream())
                    {

                        StreamReader reader = new StreamReader(dataStream);

                        string responseFromServer = reader.ReadToEnd();

                        if (responseFromServer.Contains("<P>"))
                        {
                            File.WriteAllText(path1, responseFromServer);
                            string strXmlParameters = objRSA.ToXmlString(true);
                            StreamWriter sw = new StreamWriter(path2);
                            sw.Write(strXmlParameters);
                            sw.Close();
                            Console.WriteLine("Celesi privat u ruajt ne fajllin " + path1);
                            Console.WriteLine("Celesi publik u ruajt ne fajllin " + path2);
                        }
                        else
                        {
                            File.WriteAllText(path2, responseFromServer);
                            Console.WriteLine("Celesi publik u ruajt ne fajllin " + path2);
                        }
                    }


                    response.Close();
                }
                else
                {
                    Console.WriteLine("Gabim: Fajlli i dhene nuk eshte celes valid.");
                }

            }            
           

        }
    else if (args[0].Equals("write-message"))
            {
                if (args.Length == 3)
                {
                    string name = args[1];
                    string message = args[2];
                    byte[] inputByteArray;
                    string path = "keys\\" + name + ".pub.xml";

                    if (File.Exists(path))
                    {
                        DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                        DES.GenerateKey();
                        DES.GenerateIV();
                        inputByteArray = Encoding.UTF8.GetBytes(message);
                        MemoryStream Objmst = new MemoryStream();

                        CryptoStream Objcs = new CryptoStream(Objmst, DES.CreateEncryptor(DES.Key, DES.IV), CryptoStreamMode.Write);

                        Objcs.Write(inputByteArray, 0, inputByteArray.Length);

                        Objcs.FlushFinalBlock();



                        string ciphertext = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name)) + "." + Convert.ToBase64String(DES.IV) + "."
                            + Convert.ToBase64String(RSA.Encrypt(DES.Key, path)) + "." + Convert.ToBase64String(Objmst.ToArray());
                        Console.WriteLine(ciphertext);
                    }
                    else
                    {
                        Console.WriteLine("Gabim: Celesi publik " + name + " nuk ekziston!");
                    }


                }
                else
                {
                    string name = args[1];
                    string message = args[2];
                    byte[] inputByteArray;
                    string path1 = "keys\\" + name + ".pub.xml";
                    string path = args[3];

                    if (File.Exists(path1))
                    {
                        DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                        DES.GenerateKey();
                        DES.GenerateIV();
                        inputByteArray = Encoding.UTF8.GetBytes(message);
                        MemoryStream Objmst = new MemoryStream();

                        CryptoStream Objcs = new CryptoStream(Objmst, DES.CreateEncryptor(DES.Key, DES.IV), CryptoStreamMode.Write);

                        Objcs.Write(inputByteArray, 0, inputByteArray.Length);

                        Objcs.FlushFinalBlock();



                        string ciphertext = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(name)) + "." + Convert.ToBase64String(DES.IV) + "."
                            + Convert.ToBase64String(RSA.Encrypt(DES.Key, path1)) + "." + Convert.ToBase64String(Objmst.ToArray());


                        File.WriteAllText(path, ciphertext);
                        Console.WriteLine("Mesazhi i enkriptuar u ruajt ne fjallin " + path);
                    }
                    else
                    {
                        Console.WriteLine("Gabim: Celesi publik " + name + " nuk ekziston!");
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
        //funksioni per enkriptim, RSA
        public static byte[] Encrypt(byte[] plainText, string path)
        {
            string strXmlParameters = "";
            StreamReader sr = new StreamReader(path);
            strXmlParameters = sr.ReadToEnd();
            sr.Close();

            objRSA.FromXmlString(strXmlParameters);        

            byte[] byteCiphertext = objRSA.Encrypt(plainText, true);

            return byteCiphertext;
        }
        //funksioni per dekriptim, RSA
        public static byte[] Decrypt(byte[] plainText, string path)
        {
            string strXmlParameters = "";
            StreamReader sr = new StreamReader(path);
            strXmlParameters = sr.ReadToEnd();
            sr.Close();

            objRSA.FromXmlString(strXmlParameters);

            byte[] byteCiphertext = objRSA.Decrypt(plainText, true);

            return byteCiphertext;
        }

        //funksioni per krijimin e userave, ruan celsat ne pathin e caktuar
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
        
        public static string ex(string path)//funksioni qe shfaq celsin
        {
            string xmlString = System.IO.File.ReadAllText(path);
            Console.WriteLine(xmlString);

            return "";
        }
        public static string exf(string path, string s)//funksioni qe ben eksportimin e celsit pub/privat ne fajllin e caktuatr
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

    





