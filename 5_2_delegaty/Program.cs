using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Timers;

namespace _5_2_delegaty
{
    internal class Program
    {
        public enum Role
        {
            Administrator,
            Manager,
            User
        }
        public class User
        {
            public string UserName { get; set; }
            public List<Role> Roles { get; set; }
            public User(string username)
            {
                UserName = username;
                Roles = new List<Role>();
            }
            public void AddRole(Role role)
            {
                if (!Roles.Contains(role))
                {
                    Roles.Add(role);
                }
            }
        }
        //rbac role base access control
        public class RBAC
        {
            private readonly Dictionary<Role, List<string>> _rolePermissions;
            public RBAC()
            {
                _rolePermissions = new Dictionary<Role, List<string>>()
                {
                    { Role.Administrator, new List<string> { "Read", "Write", "Delete"} },
                    { Role.Manager, new List<string> { "Read", "Write"} },
                    {Role.User, new List<string> {"Read"} }
                };
            }

            public bool HasPermission(User user, string permission)
            {
                foreach (var role in user.Roles)
                {
                    if (_rolePermissions.ContainsKey(role) && _rolePermissions[role].Contains(permission))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public class PasswordManager
        {
            private const string _passwdFilePath = "userPasswords.txt";
            public static event Action<string, bool> PasswordVerfied;
            static PasswordManager()
            {
                if (!File.Exists(_passwdFilePath))
                {
                    File.Create(_passwdFilePath).Dispose();
                }
            }
            public static void SavePassword(string username,string password)
            {
                string hashedPassword = HashedPassword(password);
                File.AppendAllText(_passwdFilePath, $"{username},{hashedPassword}\n");
            }

            public static bool VerifyPassword(string username,string password)
            {
                string hashePassword = HashedPassword(password);
                foreach (var line in File.ReadLines(_passwdFilePath))
                {
                    var parts = line.Split(',');
                    if (parts[0] == username && parts[1] == hashePassword)
                    {
                        PasswordVerfied?.Invoke(username, true); 
                        return true;
                    }
                }
                PasswordVerfied?.Invoke(username, false);
                return false;
            }
            private static string HashedPassword(string password) 
            {
                using (var sha256 = SHA256.Create())
                {
                    var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(bytes);
                }
            }
        }
        static void Main(string[] args)
        {
            PasswordManager.PasswordVerfied += (username, success) => Console.WriteLine($"Logowanie użytkownika {username} : " +
                $"{(success ? "udane": "nieudane")}");

            PasswordManager.SavePassword("AdminUser", "adminPassword");
            PasswordManager.SavePassword("ManagerUser", "ManagerPassword");
            PasswordManager.SavePassword("NormalUser", "userPassword");
            PasswordManager.SavePassword("xyz", "userPassword");

            Console.Write("Wprowadź nazwę użytkownika: ");
            string username = Console.ReadLine();

            Console.Write("Wprowadź hasło: ");
            string password = Console.ReadLine();

            if (!PasswordManager.VerifyPassword(username, password)) 
            {
                Console.WriteLine("Niepoprawana nazwa użytkownika lub hasła.");
                return;
            }

            var user = new User(username);

            if (username == "AdminUser")
            {
                user.AddRole(Role.Administrator);
            }else if (username == "ManagerUser")
            {
                user.AddRole(Role.Manager);
            }
            else if (username == "NormalUser")
            {
                user.AddRole(Role.User);
            }

            var rbacSystem = new RBAC();

            Console.WriteLine("\nSprawdzanie dostępu do róznych zasobów: ");
            Console.WriteLine("Read: " + rbacSystem.HasPermission(user, "Read"));
            Console.WriteLine("Write: " + rbacSystem.HasPermission(user, "Write"));
            Console.WriteLine("Delete: " + rbacSystem.HasPermission(user, "Delete"));

            /*
            var user = new User("Janusz");
            var user1 = new User("Pawel");
            var user2 = new User("Mariusz");

            user.AddRole(Role.Administrator);
            user1.AddRole(Role.User);
            user2.AddRole(Role.Administrator);

            var rbac = new RBAC();

            Console.WriteLine("Admin: " + rbac.HasPermission(user, "Delete"));
            Console.WriteLine("User: " + rbac.HasPermission(user1, "Delete"));
            Console.WriteLine("User: " + rbac.HasPermission(user2, "Read")); 
            */
        }
    }
}

