using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using Newtonsoft.Json;

namespace PW10
{
    class user
    {
        public int id;
        public string login;
        public string password;
        public roli rol;
    }
    enum roli
    {
        Неопределенный_пользователь = 0,
        Администратор = 1,
        Менеджер_персонала = 2,
        Склад_менеджер = 3,
        Кассир = 4,
        Бухгалтер = 5
    }
    class CRUD : nachalo_rezni
    {
        protected static void update(object a)
        {
            foreach (user d in myusers)
            {
                if (d == a)
                {
                    Console.Clear();
                    Console.WriteLine($"\t\t\t\t\tРоль: {roli.Администратор}");
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.WriteLine("-");
                    }
                    Console.WriteLine($"  ID: {d.id}\n  Логин: {d.login}\n  Пароль: {d.password}\n  Роль: {d.rol}");
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine(">>");
                    for (int i = 2; i < 15; i++)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 36, i);
                        Console.WriteLine("|");
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 32, 3 + i);
                        Console.WriteLine($"{i} - {(roli)i}");
                    }
                    Console.SetCursorPosition(Console.WindowWidth - 32, 10);
                    Console.WriteLine("Сохранить - S");
                    int pos = 2;
                    ConsoleKeyInfo k;
                    do
                    {
                        Console.SetCursorPosition(0, pos);
                        k = Console.ReadKey();
                        if (k.Key == ConsoleKey.UpArrow)
                        {
                            pos--;
                            if (pos < 2)
                                pos = 5;
                        }
                        if (k.Key == ConsoleKey.DownArrow)
                        {
                            pos++;
                            if (pos > 5)
                                pos = 2;
                        }
                        if (k.Key == ConsoleKey.Enter)
                        {
                            if (pos == 2)
                            {
                                Console.SetCursorPosition(6, 2);
                                Console.WriteLine("               ");
                                Console.SetCursorPosition(6, 2);
                                d.id = Convert.ToInt32(Console.ReadLine());
                            }
                            if (pos == 3)
                            {
                                Console.SetCursorPosition(9, 3);
                                Console.WriteLine("               ");
                                Console.SetCursorPosition(9, 3);
                                d.login = Console.ReadLine();
                            }
                            if (pos == 4)
                            {
                                Console.SetCursorPosition(10, 4);
                                Console.WriteLine("               ");
                                Console.SetCursorPosition(10, 4);
                                d.password = Console.ReadLine();
                            }
                            if (pos == 5)
                            {
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine("                               ");
                                Console.SetCursorPosition(8, 5);
                                d.rol = (roli)Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        Console.Clear();
                        Console.WriteLine($"\t\t\t\t\tРоль: {roli.Администратор}");
                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.SetCursorPosition(i, 1);
                            Console.WriteLine("-");
                        }
                        Console.WriteLine($"  ID: {d.id}\n  Логин: {d.login}\n  Пароль: {d.password}\n  Роль: {d.rol}");
                        Console.SetCursorPosition(0, pos);
                        Console.WriteLine(">>");
                        for (int i = 2; i < 15; i++)
                        {
                            Console.SetCursorPosition(Console.WindowWidth - 36, i);
                            Console.WriteLine("|");
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            Console.SetCursorPosition(Console.WindowWidth - 32, 3 + i);
                            Console.WriteLine($"{i} - {(roli)i}");
                        }
                        Console.SetCursorPosition(Console.WindowWidth - 32, 10);
                        Console.WriteLine("Сохранить - S");
                    } while (k.Key != ConsoleKey.S);
                }
            }
        }
        protected static void del(int pos)
        {
            myusers.RemoveAt(pos);
        }
        protected static void read()
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t\t\tРоль: {roli.Администратор}");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("-");
            }
            Console.WriteLine($"\tID\tЛогин\t\tПароль\t\tРоль");
            foreach (user s in myusers)
            {
                Console.WriteLine($"\t{s.id}\t{s.login}\t\t{s.password}\t\t{s.rol}");
            }
            for (int i = 2; i < 15; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 36, i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(Console.WindowWidth - 32, 3);
            Console.WriteLine("Добавить запись - +");
            Console.SetCursorPosition(Console.WindowWidth - 32, 5);
            Console.WriteLine("Найти запись - P");
            Console.SetCursorPosition(Console.WindowWidth - 32, 7);
            Console.WriteLine("Изменить - Enter и навести на ");
            Console.SetCursorPosition(Console.WindowWidth - 32, 8);
            Console.WriteLine("позицию, которую нужно изменить");
            Console.SetCursorPosition(Console.WindowWidth - 32, 10);
            Console.WriteLine("Удалить запись - '-' и навести");
            Console.SetCursorPosition(Console.WindowWidth - 32, 11);
            Console.WriteLine("на нужную запись удаления");
            Console.SetCursorPosition(Console.WindowWidth - 32, 13);
            Console.WriteLine("Выйти из админа - Escape");

        }
        protected static void add()
        {
            user = new user();
            int pos = 2;
            Console.Clear();
            Console.WriteLine($"\t\t\t\t\tРоль: {roli.Администратор}");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("-");
            }
            ConsoleKeyInfo k;
            Console.WriteLine("  ID: \n  Логин: \n  Пароль:  \n  Роль:"); ;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(">>");
            for (int i = 2; i < 15; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 36, i);
                Console.WriteLine("|");
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 32, 3 + i);
                Console.WriteLine($"{i} - {(roli)i}");
            }
            Console.SetCursorPosition(Console.WindowWidth - 32, 10);
            Console.WriteLine("Сохранить - S");
            do
            {
                Console.SetCursorPosition(0, pos);
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos < 2)
                        pos = 5;
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos > 5)
                        pos = 2;
                }
                if (k.Key == ConsoleKey.Enter)
                {
                    if (pos == 2)
                    {
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine("               ");
                        Console.SetCursorPosition(6, 2);
                        user.id = Convert.ToInt32(Console.ReadLine());
                    }
                    if (pos == 3)
                    {
                        Console.SetCursorPosition(9, 3);
                        Console.WriteLine("               ");
                        Console.SetCursorPosition(9, 3);
                        user.login = Console.ReadLine();
                    }
                    if (pos == 4)
                    {
                        Console.SetCursorPosition(10, 4);
                        Console.WriteLine("               ");
                        Console.SetCursorPosition(10, 4);
                        user.password = Console.ReadLine();
                    }
                    if (pos == 5)
                    {
                        Console.SetCursorPosition(8, 5);
                        Console.WriteLine("                               ");
                        Console.SetCursorPosition(8, 5);
                        user.rol = (roli)Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.Clear();
                Console.WriteLine($"\t\t\t\t\tРоль: {roli.Администратор}");
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.SetCursorPosition(i, 1);
                    Console.WriteLine("-");
                }
                Console.WriteLine($"  ID: {user.id}\n  Логин: {user.login}\n  Пароль: {user.password}\n  Роль: {user.rol}");
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(">>");
                for (int i = 2; i < 15; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 36, i);
                    Console.WriteLine("|");
                }
                for (int i = 0; i < 6; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 32, 3 + i);
                    Console.WriteLine($"{i} - {(roli)i}");
                }
                Console.SetCursorPosition(Console.WindowWidth - 32, 10);
                Console.WriteLine("Сохранить - S");
            } while (k.Key != ConsoleKey.S);
            myusers.Add(user);
        }
    }

    class nachalo_rezni
    {
        protected static user user;
        protected static List<user> myusers;

        protected static void avtorization()
        {
            Console.Clear();
            user = new user();
            int pos = 0;
            ConsoleKeyInfo k;
            Console.WriteLine("  Логин: \n  Пароль: \n  Авторизация");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(">>");
            string pas = "";
            do
            {
                Console.SetCursorPosition(0, pos);
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos < 0)
                        pos = 2;
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos > 2)
                        pos = 0;
                }
                if (k.Key == ConsoleKey.Enter)
                {
                    if (pos == 0)
                    {
                        Console.SetCursorPosition(9, 0);
                        Console.WriteLine("               ");
                        Console.SetCursorPosition(9, 0);
                        user.login = Console.ReadLine();
                    }
                    if (pos == 1)
                    {
                        ConsoleKeyInfo ak;
                        pas = "";
                        user.password = "";
                        do
                        {
                            Console.SetCursorPosition(10, 1);
                            ak = Console.ReadKey();
                            if (ak.Key != ConsoleKey.Backspace)
                            {
                                if (ak.Key != ConsoleKey.Enter)
                                {
                                    user.password += ak.KeyChar;
                                    pas += "*";
                                }

                            }
                            else
                            {
                                if (user.password.Length != 0)
                                {
                                    user.password = user.password.Remove(user.password.Length - 1);
                                    pas = pas.Remove(pas.Length - 1);
                                }
                            }
                            Console.SetCursorPosition(10, 1);
                            Console.WriteLine("                   ");
                            Console.SetCursorPosition(10, 1);
                            Console.WriteLine(pas);
                        } while (ak.Key != ConsoleKey.Enter);
                    }
                    if (pos == 2 && (user.login == null || user.password == null))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Вы не заполнили все поля");
                        Thread.Sleep(1000);
                    }
                }
                Console.Clear();
                Console.WriteLine($"  Логин: {user.login}\n  Пароль: {pas}\n  Авторизация");
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(">>");
            } while (pos != 2 || k.Key != ConsoleKey.Enter || user.login == null || user.password == null);
            vhod(user.login, user.password);
        }
        protected static void vhod(string name, string keyy)
        {
            if (myusers.Count == 0)
            {
                myusers.Add(user);
                Console.Clear();
                string err = "Так как вы не найдены в нашей базе - вы прошли этап регистрации. Повторите вход...";
                Console.SetCursorPosition(Console.WindowWidth / 2 - err.Length / 2, Console.WindowHeight / 2);
                Console.WriteLine(err);
                Thread.Sleep(1000);
            }
            else
            {
                int ak = 0;
                foreach (user j in myusers)
                {
                    if (j.login == name)
                    {
                        ak = 1;
                        break;
                    }
                }
                if (ak == 1)
                {
                    foreach (user f in myusers)
                    {
                        if (f.login == name)
                        {
                            if (f.password == keyy)
                            {
                                if (user.login.ToLower() == "админ")
                                {
                                    f.id = 1;
                                    f.rol = roli.Администратор;
                                    admin.administrator();
                                    break;
                                }
                                else
                                {
                                    string err = "Простите, но вы обычный юзер, попросите админа зарегать вас";
                                    Console.Clear();
                                    Console.SetCursorPosition(Console.WindowWidth / 2 - err.Length / 2, Console.WindowHeight / 2);
                                    Console.WriteLine(err);
                                    Thread.Sleep(1000);
                                }
                            }
                            else
                            {
                                string err = "Вы ввели неверный пароль, попробуйте еще раз";
                                Console.Clear();
                                Console.SetCursorPosition(Console.WindowWidth / 2 - err.Length / 2, Console.WindowHeight / 2);
                                Console.WriteLine(err);
                                Thread.Sleep(1000);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    string err = "Так как вы не найдены в нашей базе - вы прошли этап регистрации. Повторите вход...";
                    Console.SetCursorPosition(Console.WindowWidth / 2 - err.Length / 2, Console.WindowHeight / 2);
                    Console.WriteLine(err);
                    user.id = myusers.Count + 1;
                    myusers.Add(user);
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                File.WriteAllText("ЛюблюРезнюТочкаСишарпТочкаПомогите\\текст.json", JsonConvert.SerializeObject(myusers));
            }
        }
    }
    class admin : CRUD
    {
        public static void administrator()
        {
            while (true)
            {
                read();
                File.WriteAllText("ЛюблюРезнюТочкаСишарпТочкаПомогите\\текст.json", JsonConvert.SerializeObject(myusers));
                ConsoleKeyInfo de = strelka();
                if (de.Key == ConsoleKey.Escape)
                    break;
            }
        }
        static void search()
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t\t\tРоль: {roli.Администратор}");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("-");
            }
            Console.WriteLine("  ID\n  Логин\n  Пароль\n  Роль");
            ConsoleKeyInfo k;
            int pos = 2;
            do
            {
                Console.SetCursorPosition(0, pos);
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("  ");
                    pos--;
                    if (pos < 2)
                        pos = 5;
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("  ");
                    pos++;
                    if (pos > 5)
                        pos = 2;
                }
                Console.SetCursorPosition(0, pos);
                Console.WriteLine(">>");
            } while (k.Key != ConsoleKey.Enter);
            Console.Clear();
            if (pos == 2)
            {
                Console.Write("Id: ");
                int a = Convert.ToInt32(Console.ReadLine());
                poisk(a);
            }
            if (pos == 3)
            {
                Console.Write("Логин: ");
                string a = Console.ReadLine();
                poisk(a);
            }
            if (pos == 4)
            {
                Console.Write("Пароль: ");
                string a = Console.ReadLine();
                poisk(a);
            }
            if (pos == 5)
            {
                Console.Write("Роль: ");
                roli a = (roli)Convert.ToInt32(Console.ReadLine());
                poisk(a);
            }

        }
        static void poisk(object a)
        {

            Console.Clear();
            Console.WriteLine($"\t\t\t\t\tРоль: {roli.Администратор}");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("-");
            }
            Console.WriteLine($"\tID\t\tЛогин\t\tПароль\t\tРоль");
            List<user> vv = new List<user>();
            foreach (user j in myusers)
            {
                if (j.id.ToString() == a.ToString() || j.login == a || j.password == a || j.rol.ToString() == a.ToString())
                {
                    vv.Add(j);
                }
            }
            if (vv.Count != 0)
            {
                foreach (user o in vv)
                {
                    Console.WriteLine($"\t{o.id}\t\t{o.login}\t\t{o.password}\t\t{o.rol}");
                    int pos = 3;
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine(">>");
                    ConsoleKeyInfo ad;
                    do
                    {
                        Console.SetCursorPosition(0, pos);
                        ad = Console.ReadKey();
                        if (ad.Key == ConsoleKey.UpArrow)
                        {
                            pos--;
                            if (pos < 3)
                                pos = 3;
                        }
                        if (ad.Key == ConsoleKey.DownArrow)
                        {
                            pos++;
                            if (pos > vv.Count + 2)
                                pos = vv.Count + 2;
                        }
                    } while (ad.Key != ConsoleKey.Enter);
                    update(o);
                }
            }
            else
            {
                while (true)
                {
                    ConsoleKeyInfo x = Console.ReadKey();
                    if (x.Key == ConsoleKey.Enter)
                        break;
                }
            }
        }
        static ConsoleKeyInfo strelka()
        {
            ConsoleKeyInfo aw;
            int pos = 3;
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(">>");
            do
            {
                Console.SetCursorPosition(0, pos);
                aw = Console.ReadKey();
                if (aw.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("  ");
                    pos--;
                    if (pos < 3)
                        pos = 3;
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine(">>");
                }
                if (aw.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("  ");
                    pos++;
                    if (pos > myusers.Count + 2)
                        pos = myusers.Count + 2;
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine(">>");
                }
                if (aw.Key == ConsoleKey.Add)
                {
                    add();
                    break;
                }
                if (aw.Key == ConsoleKey.Subtract)
                {
                    del(pos - 3);
                    break;
                }
                if (aw.Key == ConsoleKey.P)
                {
                    search();
                    break;
                }
                if (aw.Key == ConsoleKey.Escape)
                    break;
            } while (aw.Key != ConsoleKey.Enter);
            if (aw.Key == ConsoleKey.Enter)
                update(myusers[pos - 3]);
            return aw;
        }
    }
    class Program : nachalo_rezni
    {
        public static string path = Directory.GetCurrentDirectory();
        static void Main()
        {
            if (Directory.Exists("ЛюблюРезнюТочкаСишарпТочкаПомогите") == false)
            {
                Directory.CreateDirectory(path + "/ЛюблюРезнюТочкаСишарпТочкаПомогите");
            }
            if (File.Exists("ЛюблюРезнюТочкаСишарпТочкаПомогите\\текст.json") == false)
            {
                FileInfo fi = new FileInfo(path + "/ЛюблюРезнюТочкаСишарпТочкаПомогите" + "/текст.json");
                FileStream fs = fi.Create();
                fs.Close();
            }
            myusers = JsonConvert.DeserializeObject<List<user>>(File.ReadAllText("ЛюблюРезнюТочкаСишарпТочкаПомогите\\текст.json")) ?? new List<user>();
            while (true)
            {
                avtorization();
            }
        }
    }
}