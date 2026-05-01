using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store_Updated
{
    internal class Manager
    {
        public Manager(int ID_Manager, string Manager_Surname, string Manager_Name, string Manager_Fathername, string Manager_password)
        {

        }

        public void See_a_List_of_Employes(string Employe_Role)
        {
            string Employe_Type = string.Empty;
            int Employe_ID;

            switch (Employe_Role.ToLower())
            {
                case "менеджер":
                    Employe_ID = 1;
                    while (File.Exists($"Managers\\Manager_{Employe_ID}.txt") == true)
                    {
                        Employe_Type = $"Managers\\Manager_{Employe_ID}.txt";
                        FileStream fs = new FileStream(Employe_Type, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        string temp_string;

                        while (sr.EndOfStream == false)
                        {
                            temp_string = sr.ReadLine();

                            if (temp_string.Contains("ID менеджера:"))
                            {
                                Console.WriteLine($"ID менеджера: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Фамилия:"))
                            {
                                Console.WriteLine($"Фамилия менеджера: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Имя:"))
                            {
                                Console.WriteLine($"Имя менеджера: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Отчество:"))
                            {
                                Console.WriteLine($"Отчество менеджера: {sr.ReadLine()}");
                            }
                        }
                        Console.WriteLine("");
                        sr.Close();
                        Employe_ID++;
                    }
                    break;

                case "продавец":
                    Employe_ID = 1;
                    while (File.Exists($"Seller\\Seller_{Employe_ID}.txt") == true)
                    {
                        Employe_Type = $"Seller\\Seller_{Employe_ID}.txt";
                        FileStream fs = new FileStream(Employe_Type, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        string temp_string;

                        while (sr.EndOfStream == false)
                        {
                            temp_string = sr.ReadLine();

                            if (temp_string.Contains("ID продавца:"))
                            {
                                Console.WriteLine($"ID продавца: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Фамилия:"))
                            {
                                Console.WriteLine($"Фамилия продавца: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Имя:"))
                            {
                                Console.WriteLine($"Имя продавца: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Отчество:"))
                            {
                                Console.WriteLine($"Отчество продавца: {sr.ReadLine()}");
                            }
                        }
                        Console.WriteLine("");
                        sr.Close();
                        Employe_ID++;
                    }
                    break;

                case "продавец-консультант":
                    Employe_ID = 1;
                    while (File.Exists($"Seller-Consultant\\Seller-Consultant_{Employe_ID}.txt") == true)
                    {
                        Employe_Type = $"Seller-Consultant\\Seller-Consultant_{Employe_ID}.txt";
                        FileStream fs = new FileStream(Employe_Type, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        string temp_string;

                        while (sr.EndOfStream == false)
                        {
                            temp_string = sr.ReadLine();

                            if (temp_string.Contains("ID продавца-консультанта:"))
                            {
                                Console.WriteLine($"ID продавца-консультанта: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Фамилия:"))
                            {
                                Console.WriteLine($"Фамилия продавца-консультанта: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Имя:"))
                            {
                                Console.WriteLine($"Имя продавца-консультанта: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Отчество:"))
                            {
                                Console.WriteLine($"Отчество продавца-консультанта: {sr.ReadLine()}");
                            }
                        }
                        Console.WriteLine("");
                        sr.Close();
                        Employe_ID++;
                    }
                    break;

                case "товаровед":
                    Employe_ID = 1;
                    while (File.Exists($"Merchendiser\\Merchendiser_{Employe_ID}.txt") == true)
                    {
                        Employe_Type = $"Merchendiser\\Merchendiser_{Employe_ID}.txt";
                        FileStream fs = new FileStream(Employe_Type, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        string temp_string;

                        while (sr.EndOfStream == false)
                        {
                            temp_string = sr.ReadLine();

                            if (temp_string.Contains("ID товароведа:"))
                            {
                                Console.WriteLine($"ID товароведа: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Фамилия:"))
                            {
                                Console.WriteLine($"Фамилия товароведа: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Имя:"))
                            {
                                Console.WriteLine($"Имя товароведа: {sr.ReadLine()}");
                            }

                            if (temp_string.Contains("Отчество:"))
                            {
                                Console.WriteLine($"Отчество товароведа: {sr.ReadLine()}");
                            }
                        }
                        Console.WriteLine("");
                        sr.Close();
                        Employe_ID++;
                    }
                    break;
            }
        }

        public bool Hire_new_Employe_menu;

        public void Hire_new_Employe(string Employe_Role)
        {
            while (Hire_new_Employe_menu)
            {

                Console.Clear();
                Console.WriteLine("Введите ID нового сотрудника:");
                int Employe_ID = Convert.ToInt32(Console.ReadLine());

                if (File.Exists($"Managers\\Manager_{Employe_ID}.txt") == true ||
                    File.Exists($"Seller\\Seller_{Employe_ID}.txt") == true ||
                    File.Exists($"Seller-Consultant\\Seller-Consultant_{Employe_ID}.txt") == true ||
                    File.Exists($"Merchendiser\\Merchendiser_{Employe_ID}.txt") == true)
                {
                    Console.WriteLine("Такой сотрудник уже нанят");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Введите фамилию нового сотрудника:");
                    string Employe_Surname = Console.ReadLine();
                    Console.WriteLine("Введите имя нового сотрудника:");
                    string Employe_Name = Console.ReadLine();

                    bool Ask_User_Have_a_Father_Name = true;
                    string Employe_Fathername = string.Empty;

                    while (Ask_User_Have_a_Father_Name)
                    {
                        Console.WriteLine("Есть ли отчество у нового сотрудника?: (Да) или (Нет): ");
                        string Have_User_a_Father_Name = Console.ReadLine();

                        switch (Have_User_a_Father_Name.ToLower())
                        {
                            case "да":
                                Console.WriteLine("Введите отчество нового сотрудника");
                                Employe_Fathername = Console.ReadLine();
                                Ask_User_Have_a_Father_Name = false;
                                break;

                            case "нет":
                                Employe_Fathername = "Отсутствует";
                                Ask_User_Have_a_Father_Name = false;
                                break;
                        }
                    }

                    Console.WriteLine("Задайте пароль нового сотрудника:");
                    string Employe_Password = Console.ReadLine();

                    switch (Employe_Role)
                    {
                        case "менеджер":
                            FileStream fs = new FileStream($"Managers\\Manager_{Employe_ID}.txt", FileMode.CreateNew, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);

                            sw.WriteLine("ID менеджера:");
                            sw.WriteLine(Employe_ID);
                            sw.WriteLine("");

                            sw.WriteLine("Фамилия:");
                            sw.WriteLine(Employe_Surname);
                            sw.WriteLine("");

                            sw.WriteLine("Имя:");
                            sw.WriteLine(Employe_Name);
                            sw.WriteLine("");

                            sw.WriteLine("Отчество:");
                            sw.WriteLine(Employe_Fathername);
                            sw.WriteLine("");

                            sw.WriteLine("Пароль:");
                            sw.WriteLine(Employe_Password);
                            sw.WriteLine("");

                            sw.Close();

                            Hire_new_Employe_menu = false;
                            break;

                        case "продавец":

                            FileStream fs2 = new FileStream($"Seller\\Seller_{Employe_ID}.txt", FileMode.CreateNew, FileAccess.Write);
                            StreamWriter sw2 = new StreamWriter(fs2);

                            sw2.WriteLine("ID продавца:");
                            sw2.WriteLine(Employe_ID);
                            sw2.WriteLine("");

                            sw2.WriteLine("Фамилия:");
                            sw2.WriteLine(Employe_Surname);
                            sw2.WriteLine("");

                            sw2.WriteLine("Имя:");
                            sw2.WriteLine(Employe_Name);
                            sw2.WriteLine("");

                            sw2.WriteLine("Отчество:");
                            sw2.WriteLine(Employe_Fathername);
                            sw2.WriteLine("");

                            sw2.WriteLine("Пароль:");
                            sw2.WriteLine(Employe_Password);
                            sw2.WriteLine("");

                            sw2.Close();

                            Hire_new_Employe_menu = false;

                            break;

                        case "продавец-консультант":

                            FileStream fs3 = new FileStream($"Seller-Consultant\\Seller-Consultant_{Employe_ID}.txt", FileMode.CreateNew, FileAccess.Write);
                            StreamWriter sw3 = new StreamWriter(fs3);

                            sw3.WriteLine("ID продавца-консультанта:");
                            sw3.WriteLine(Employe_ID);
                            sw3.WriteLine("");

                            sw3.WriteLine("Фамилия:");
                            sw3.WriteLine(Employe_Surname);
                            sw3.WriteLine("");

                            sw3.WriteLine("Имя:");
                            sw3.WriteLine(Employe_Name);
                            sw3.WriteLine("");

                            sw3.WriteLine("Отчество:");
                            sw3.WriteLine(Employe_Fathername);
                            sw3.WriteLine("");

                            sw3.WriteLine("Пароль:");
                            sw3.WriteLine(Employe_Password);
                            sw3.WriteLine("");

                            sw3.Close();

                            Hire_new_Employe_menu = false;

                            break;

                        case "товаровед":

                            FileStream fs4 = new FileStream($"Merchendiser\\Merchendiser_{Employe_ID}.txt", FileMode.CreateNew, FileAccess.Write);
                            StreamWriter sw4 = new StreamWriter(fs4);

                            sw4.WriteLine("ID товароведа:");
                            sw4.WriteLine(Employe_ID);
                            sw4.WriteLine("");

                            sw4.WriteLine("Фамилия:");
                            sw4.WriteLine(Employe_Surname);
                            sw4.WriteLine("");

                            sw4.WriteLine("Имя:");
                            sw4.WriteLine(Employe_Name);
                            sw4.WriteLine("");

                            sw4.WriteLine("Отчество:");
                            sw4.WriteLine(Employe_Fathername);
                            sw4.WriteLine("");

                            sw4.WriteLine("Пароль:");
                            sw4.WriteLine(Employe_Password);
                            sw4.WriteLine("");

                            sw4.Close();

                            Hire_new_Employe_menu = false;

                            break;
                    }
                }
            }
        }

        public void Fire_Employe(string Employe_Role)
        {
            int Employe_ID;
            switch (Employe_Role)
            {
                case "менеджер":
                    Console.WriteLine("Введите ID сотрудника которого вы хотите уволить:");
                    Employe_ID = Convert.ToInt32(Console.ReadLine());

                    if (File.Exists($"Managers\\Manager_{Employe_ID}.txt") == true)
                    {
                        File.Delete($"Managers\\Manager_{Employe_ID}.txt");
                    }
                    else
                    {
                        Console.WriteLine("Такого сотрудника нет в списке");
                    }
                    break;

                case "продавец":
                    Console.WriteLine("Введите ID сотрудника которого вы хотите уволить:");
                    Employe_ID = Convert.ToInt32(Console.ReadLine());

                    if (File.Exists($"Seller\\Seller_{Employe_ID}.txt") == true)
                    {
                        File.Delete($"Seller\\Seller_{Employe_ID}.txt");
                    }
                    else
                    {
                        Console.WriteLine("Такого сотрудника нет в списке");
                    }
                    break;

                case "продавец-консультант":
                    Console.WriteLine("Введите ID сотрудника которого вы хотите уволить:");
                    Employe_ID = Convert.ToInt32(Console.ReadLine());

                    if (File.Exists($"Seller-Consultant\\Seller-Consultant_{Employe_ID}.txt") == true)
                    {
                        File.Delete($"Seller-Consultant\\Seller-Consultant_{Employe_ID}.txt");
                    }
                    else
                    {
                        Console.WriteLine("Такого сотрудника нет в списке");
                    }
                    break;

                case "товаровед":
                    Console.WriteLine("Введите ID сотрудника которого вы хотите уволить:");
                    Employe_ID = Convert.ToInt32(Console.ReadLine());

                    if (File.Exists($"Merchendiser\\Merchendiser_{Employe_ID}.txt") == true)
                    {
                        File.Delete($"Merchendiser\\Merchendiser_{Employe_ID}.txt");
                    }
                    else
                    {
                        Console.WriteLine("Такого сотрудника нет в списке");
                    }
                    break;
            }
        }
    }
}