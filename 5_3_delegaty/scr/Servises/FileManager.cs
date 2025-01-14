using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_3_delegaty.scr.Servises
{
    internal class FileManager
    {
        public static void ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Zawartość pliku:\n" + content);
            }
            else
            {
                Console.WriteLine("Plik nie istnieje");
            }
        }

        public static void WriteToFile(string filePath)
        {
            Console.Write("Podaj tekst do zapisania w pliku: ");
            string text = Console.ReadLine();
            File.WriteAllText(filePath, text);
            Console.WriteLine("Zapisano do pliku");
        }

        public static void ModifyFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                Console.Write("Podaj tekst do modyfikacji w pliku: ");
                string text = Console.ReadLine();
                File.AppendAllText(filePath, text);
                Console.WriteLine("Zmodyfikowano plik");
            }
            else
            {
                Console.WriteLine("Plik nie istnieje");
            }
        }

        public static void AddNewUser()
        {
            Console.Write("Podaj nazwę użytkownika: ");
            string newUsername = Console.ReadLine();

            Console.Write("Podaj hasło użytkownika: ");
            string newPassword = Console.ReadLine();

            PasswordManager.SavePassword(newUsername, newPassword);
            Console.WriteLine($"Dodano nowego użytkownika: {newUsername}");
        }
    }
}
