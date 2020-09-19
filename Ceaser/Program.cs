using System;
using System.Net.Security;
using System.Text;

namespace Ceaser
{
    internal class Program
    {
        static string alphabet = "аәбвгғдежзийкқлмнңопрстуұүфхрцчшщъыіьэюя,. ";

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            ShowInfo();
            Console.Write(">");
            string command = Console.ReadLine();
            while (command != "quit")
            {
                Console.WriteLine("Мәтінді енгізіңіз:");
                string text = Console.ReadLine();
                Console.WriteLine("Кілтті енгізіңіз");
                int key = int.Parse(Console.ReadLine());
                EncryptParameter parameter = (EncryptParameter) int.Parse(command);
                Console.WriteLine(Encrypt(text, key, parameter));
                Console.Write(">");
                command = Console.ReadLine();
            }
            Console.ReadLine();
        }

        static string Encrypt(string text, int key, EncryptParameter parameter)
            {
                if (parameter == EncryptParameter.Decrypt)
                    key *= -1;
                string res = "";
                for (int i = 0; i < text.Length; i++)
                {
                    int pos = alphabet.IndexOf(char.ToLower(text[i]));
                    pos = (pos + key + alphabet.Length) % alphabet.Length;
                    res += alphabet[pos];
                }

                return res;
            }

            static void ShowInfo()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"[0]-Шифрлау
[1]-Кері шифрлау
[quit]-шығу");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        enum EncryptParameter
        {
            Encrypt = 0,
            Decrypt = 1
        }
}