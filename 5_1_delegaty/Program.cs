using System.Reflection.Metadata;

namespace _5_1_delegaty
{
    internal class Program
    {
        public delegate void NotificationHandler(string message);

        public interface INotifier
        {
            void Notify(string message);
        }
        

        public class EmailNotifier : INotifier
        {
            public void Notify(string message)
            {
                Console.WriteLine($"Email wysłany: {message}");
            }
        }
        public class SMSNotifier : INotifier 
        {
            public void Notify(string message)
            {
                Console.WriteLine($"SMS wysłany: {message}");
            }
        }
        public class PushNotifier : INotifier
        {
            public void Notify(string message)
            {
                Console.WriteLine($"Powiadomienie push wysłane: {message}");
            }
        }

        public class NotificationManager
        {
            public NotificationHandler Notify;

            public void AddNotificationMethod(NotificationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler)) 
                {
                    Console.WriteLine("Ta metoda jest juz dodana");
                    return;
                }
                else
                {
                    Notify += handler;
                    Console.WriteLine("Dodano metodę powiadomień");
                }
            }

            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Notify += handler;
                    Console.WriteLine("Usunięto metode powiadomienia");
                    return;
                }
                else
                {
                    Console.WriteLine("Nie można usunąć metody powiadomienia");
                }
            }

            public void SendNotification(string message)
            {
                if (Notify == null)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomień. Dodaj co namiej jedną metodę");
                    return;
                }
                foreach (var handel in Notify.GetInvocationList())
                {
                    try
                    {
                        handel.DynamicInvoke(message);
                        string logEnrty = $"\n[{DateTime.Now:yyyy-MM HH:mm:ss}] Wysłano {handel.Method.Name}, Wysłano wiadomość {message}{Environment.NewLine}";
                        File.AppendAllText("Log.txt",logEnrty);
                    }
                    catch (Exception ex) 
                    { 
                        Console.WriteLine($"Błąd podczas wysyłania powiadomienie: {ex.Message}");
                    }
                }
            }
            internal void ListNotificationMethod()
            {
                if (Notify == null)
                {
                    Console.WriteLine("Brak zarejestrowanych metod powiadomień");
                    return;
                }

                Console.WriteLine("Zarejestrowane metody powiadomień: ");

                var displayHandlers = new HashSet<string>();
                foreach(var handel in Notify.GetInvocationList())
                {
                    var target = handel.Target;
                    var methodName = handel.Method.Name;
                    var className = target?.GetType().Name;

                    var uniqueKey = $"{className},{methodName}";

                    //Console.WriteLine(uniqueKey);

                    displayHandlers.Add(uniqueKey);
                }

                foreach( var handel in displayHandlers)
                {
                    Console.WriteLine(handel);
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Dodaj powiadomienie Email");
            Console.WriteLine("2. Dodaj powiadomienie SMS");
            Console.WriteLine("3. Dodaj powiadomienie Push");
            Console.WriteLine("4. usuń powiadomienie Email");
            Console.WriteLine("5. usuń Powiadomienie SMS");
            Console.WriteLine("6. usuń Powiadomienie Push");
            Console.WriteLine("7. Wyślij powiadomienie");
            Console.WriteLine("8. Pokaż zarejestrowane metody powiadomień");
            Console.WriteLine("9. Wyjdż");
            Console.Write("\nWybierz Opcje:\n");

        }
        static void Main(string[] args)
        {
            var NotificationManager = new NotificationManager();
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            while (true)
            {
                try
                {
                    ShowMenu();
                    var choise = int.Parse(Console.ReadLine());

                    switch (choise) 
                    {
                        case 1:
                            NotificationManager.AddNotificationMethod(emailNotifier.Notify);
                            break;
                        case 2:
                            NotificationManager.AddNotificationMethod(smsNotifier.Notify);
                            break;
                        case 3:
                            NotificationManager.AddNotificationMethod(pushNotifier.Notify);
                            break;
                        case 4:
                            NotificationManager.RemoveNotificationMethod(emailNotifier.Notify);
                            break;
                        case 5:
                            NotificationManager.RemoveNotificationMethod(smsNotifier.Notify);
                            break;
                        case 6:
                            NotificationManager.RemoveNotificationMethod(pushNotifier.Notify);
                            break;
                        case 7:
                            Console.WriteLine("Wpisz wiadomość do wysłania");
                            var messenger = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(messenger))
                            {
                                Console.WriteLine("\nWiadomość nie może być pusta");
                                break;
                            }

                            if (messenger.Length > 20)
                            {
                                Console.WriteLine("Wiadomość jest zbyt długa (Max 20 znaków)");
                                break ;
                            }

                            NotificationManager.SendNotification(messenger);
                            break;

                        case 8:
                            NotificationManager.ListNotificationMethod();
                            break;
                        case 9:
                            return;
                        default:
                            Console.WriteLine("Nie prawidłowa opcja. Spróbuj ponownie");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            }
        }
    }
}