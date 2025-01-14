using _5_3_delegaty.scr.enums;
using _5_3_delegaty.scr.Enums;
using _5_3_delegaty.scr.Models;
using _5_3_delegaty.scr.Servises;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _5_3_delegaty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PasswordManager.PasswordVerified += (username, success) => Console.WriteLine($"Logowanie użytkownika {username} : {(success ? "udane" : "nieudane")}");

            PasswordManager.SavePassword("AdminUser", "adminPassword");
            PasswordManager.SavePassword("ManagerUser", "managerPassword");
            PasswordManager.SavePassword("NormalUser", "userPassword");
            PasswordManager.SavePassword("xyz", "userPassword");

            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("---- System logowanie ----");

                Console.Write("\nWprowadź nazwę użytkownika: ");
                string username = Console.ReadLine();

                Console.Write("Wprowadź hasło: ");
                string password = Console.ReadLine();

                if (!PasswordManager.VerifyPassword(username, password))
                {
                    Console.WriteLine("Niepoprawna nazwa użytkownika lub hasło");
                    Console.ReadKey();
                    continue;
                }

                var user = new User(username);
                if (username == "AdminUser") user.AddRole(Role.Administrator);
                else if (username == "ManagerUser") user.AddRole(Role.Manager);
                else user.AddRole(Role.User);

                var rbacSystem = new RBAC();
                string filePath = "testFile.txt";

                bool loggedIn = true;
                while (loggedIn)
                {
                    Console.Clear();
                    Console.WriteLine($"Zalogowano jako: {username}");
                    Console.WriteLine("\nWybierz opcję:");

                    Console.WriteLine("1. Odczyt plik");
                    if (rbacSystem.HasPermission(user, Permission.Write)) Console.WriteLine("2. Zapisz do pliku");
                    if (rbacSystem.HasPermission(user, Permission.Delete)) Console.WriteLine("3. Modyfikuj plik");
                    if (rbacSystem.HasPermission(user, Permission.ManageUsers)) Console.WriteLine("4. Dodaj użytkownika");
                    Console.WriteLine("5. Wyloguj się");
                    Console.WriteLine("6. Wyjdź z programu");

                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            FileManager.ReadFile(filePath); break;
                        case 2:
                            if (rbacSystem.HasPermission(user, Permission.Write)) FileManager.WriteToFile(filePath); break;
                        case 3:
                            if (rbacSystem.HasPermission(user, Permission.Delete)) FileManager.ModifyFile(filePath); break;
                        case 4:
                            if (rbacSystem.HasPermission(user, Permission.ManageUsers)) FileManager.AddNewUser(); break;
                        case 5:
                            Console.WriteLine("Wylogowano");
                            loggedIn = false;
                            break;
                        case 6:
                            Console.WriteLine("Zamykanie programu");
                            Environment.Exit(0);
                            break;
                    }
                }

                Console.ReadKey();
            }
        }
    }
}