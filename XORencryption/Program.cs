using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORencryption
{
    class Program
    {
        static void Main(string[] args)
        {

            string t = "Pokud hledáte pomocnou ruku, najdete ji na konci své paže.";
            string key1 = "PRAVDA";
            int key2 = 7;


            Console.WriteLine("------------------------ Encrypce: ------------------------\n");

            Console.WriteLine("XOR:");
            string xor = XOREncryptDecrypt(PreEdit(t), key1);
            Console.WriteLine(xor);
            Console.WriteLine("\n");

            Console.WriteLine("Caesar:");
            string caesar = EncryptCaesarCipher(PreEdit(t), key2);
            Console.WriteLine(caesar);
            Console.WriteLine("\n");


            Console.WriteLine("------------------------ Decrypce: ------------------------\n");

            Console.WriteLine("XOR:");
            Console.WriteLine(XOREncryptDecrypt(xor, key1));
            Console.WriteLine("\n");

            Console.WriteLine("Caesar:");
            Console.WriteLine(DecryptCaesarCipher(caesar, key2));
            Console.WriteLine("\n");


            Console.ReadLine(); 
        }


        private static string PreEdit(string text)
        {
            string _text = String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
            _text = _text.ToUpper();
            string output = "";
            for (int i = 0; i < _text.Length; i++)
            {
                char ch = '.';
                switch(_text[i])
                {
                    case 'Á':
                        ch = 'A';
                        break;
                    case 'Č':
                        ch = 'C';
                        break;
                    case 'É':
                        ch = 'E';
                        break;
                    case 'Ě':
                        ch = 'E';
                        break;
                    case 'Í':
                        ch = 'I';
                        break;
                    case 'Ň':
                        ch = 'N';
                        break;
                    case 'Ó':
                        ch = 'O';
                        break;
                    case 'Ř':
                        ch = 'R';
                        break;
                    case 'Š':
                        ch = 'S';
                        break;
                    case 'Ť':
                        ch = 'T';
                        break;
                    case 'Ú':
                        ch = 'U';
                        break;
                    case 'Ů':
                        ch = 'U';
                        break;
                    case 'Ý':
                        ch = 'Y';
                        break;
                    case 'Ž':
                        ch = 'Z';
                        break;
                    case '.':
                        ch = '.';
                        break;
                    case ',':
                        ch = '.';
                        break;
                    default:
                        ch = _text[i];
                        break;
                }
                if(ch != '.') output += ch;
            }
            return output;
        }


        private static string XOREncryptDecrypt(string text, string key)
        {
            char[] output = new char[text.Length];

            for (int i = 0; i < text.Length; ++i)
            {
                output[i] = (char)(text[i] ^ key[i % key.Length]);
            }

            return new string(output);
        }

        public static string EncryptCaesarCipher(string text, int key)
        {
            string output = "";

            foreach (char ch in text)
            {
                output += (char)((((ch + key) - 'A') % 26) + 'A');
            }

            return output;
        }

        public static string DecryptCaesarCipher(string text, int key)
        {
            return EncryptCaesarCipher(text, 26 - key);
        }
    }
}
