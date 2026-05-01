using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store_Updated
{
    internal class Program
    {
        static int User_ID = 0;
        static string User_Surname = string.Empty, User_Name = string.Empty, User_Fathername = string.Empty, User_Password = string.Empty;
        static void Login_User()
        {
            try
            {
                int Customer_ID = 1;
                string Employe_Role = string.Empty;
                bool AsK_User_Role = true;
                while (AsK_User_Role)
                {
                    Console.WriteLine("Укажите вашу роль: (Менеджер, Продавец, Продавец-Консультант, Товаровед, Покупатель)");
                    Employe_Role = Console.ReadLine();

                    switch (Employe_Role.ToLower())
                    {
                        case "менеджер":
                            AsK_User_Role = false;
                            break;

                        case "продавец":
                            AsK_User_Role = false;
                            break;

                        case "продавец-консультант":
                            AsK_User_Role = false;
                            break;

                        case "товаровед":
                            AsK_User_Role = false;
                            break;

                        case "покупатель":
                            bool Go_to_Registration_menu = true;
                            while (Go_to_Registration_menu)
                            {
                                Console.Clear();
                                Console.WriteLine("Хотите зарегистрироваться?:");
                                Console.WriteLine("Да (у меня нет аккаунта)");
                                Console.WriteLine("Нет (у меня есть аккаунт)");

                                string Ask_User = Console.ReadLine();

                                switch (Ask_User.ToLower())
                                {
                                    case "да":
                                        Customer_Registration_Menu();
                                        Go_to_Registration_menu = false;
                                        break;

                                    case "нет":
                                        Go_to_Registration_menu = false;
                                        break;
                                }
                            }
                            AsK_User_Role = false;
                            break;

                        default:
                            Console.WriteLine("Нет такой специальности");
                            Console.ReadKey();
                            Console.Clear();
                            AsK_User_Role = true;
                            break;
                    }
                }

                Console.ReadKey();
                Console.Clear();
                    

                string Manager_Father_Name = string.Empty;
                bool User_ID_Check = false, User_Surname_Name_Check = false, User_Name_Check = false, User_Father_Name_Check = false, User_Password_Check = false;

                Console.WriteLine("Добропожаловать в магазин сотовых телефонов");
                Console.WriteLine("Прежде чем начать пользоваться системой пожалуйста заполните форму для входа в свой аккаунт");
                Console.WriteLine("Введите свой ID: ");
                int Manager_ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите свою фамилию: ");
                string Manager_Surname = Console.ReadLine();
                Console.WriteLine("Введите своё имя: ");
                string Manager_Name = Console.ReadLine();

                bool Ask_User_Have_a_Father_Name = true;

                while (Ask_User_Have_a_Father_Name)
                {
                    Console.WriteLine("У вас есть отчество?: (Да) или (Нет): ");
                    string Have_User_a_Father_Name = Console.ReadLine();

                    switch (Have_User_a_Father_Name.ToLower())
                    {
                        case "да":
                            Console.WriteLine("Введите своё отчество: ");
                            Manager_Father_Name = Console.ReadLine();
                            Ask_User_Have_a_Father_Name = false;
                            break;

                        case "нет":
                            Manager_Father_Name = "Отсутсвует";
                            Ask_User_Have_a_Father_Name = false;
                            break;
                    }
                }

                Console.WriteLine("Введите свой пароль: ");
                string Manager_Password = Console.ReadLine();

                switch (Employe_Role.ToLower())
                {
                    case "менеджер":
                        FileStream fs = new FileStream($"Managers\\Manager_{Manager_ID}.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        string temp_string;

                        while (sr.EndOfStream == false)
                        {
                            temp_string = sr.ReadLine();

                            if (temp_string.Contains("ID менеджера:"))
                            {
                                if (Manager_ID == Convert.ToInt32(sr.ReadLine()))
                                {
                                    User_ID = Manager_ID;
                                    User_ID_Check = true;
                                }
                            }

                            if (temp_string.Contains("Фамилия:"))
                            {
                                if (Manager_Surname == sr.ReadLine())
                                {
                                    User_Surname = Manager_Surname;
                                    User_Surname_Name_Check = true;
                                }
                            }

                            if (temp_string.Contains("Имя:"))
                            {
                                if (Manager_Name == sr.ReadLine())
                                {
                                    User_Name = Manager_Name;
                                    User_Name_Check = true;
                                }
                            }

                            if (temp_string.Contains("Отчество:"))
                            {
                                if (Manager_Father_Name == sr.ReadLine())
                                {
                                    User_Fathername = Manager_Father_Name;
                                    User_Father_Name_Check = true;
                                }
                            }

                            if (temp_string.Contains("Пароль:"))
                            {
                                if (Manager_Password == sr.ReadLine())
                                {
                                    User_Password = Manager_Password;
                                    User_Password_Check = true;
                                }
                            }
                        }
                        sr.Close();
                        break;

                    case "продавец":
                        FileStream fs2 = new FileStream($"Seller\\Seller_{Manager_ID}.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr2 = new StreamReader(fs2);

                        string temp_string2;

                        while (sr2.EndOfStream == false)
                        {
                            temp_string2 = sr2.ReadLine();

                            if (temp_string2.Contains("ID продавца:"))
                            {
                                if (Manager_ID == Convert.ToInt32(sr2.ReadLine()))
                                {
                                    User_ID = Manager_ID;
                                    User_ID_Check = true;
                                }
                            }

                            if (temp_string2.Contains("Фамилия:"))
                            {
                                if (Manager_Surname == sr2.ReadLine())
                                {
                                    User_Surname = Manager_Surname;
                                    User_Surname_Name_Check = true;
                                }
                            }

                            if (temp_string2.Contains("Имя:"))
                            {
                                if (Manager_Name == sr2.ReadLine())
                                {
                                    User_Name = Manager_Name;
                                    User_Name_Check = true;
                                }
                            }

                            if (temp_string2.Contains("Отчество:"))
                            {
                                if (Manager_Father_Name == sr2.ReadLine())
                                {
                                    User_Fathername = Manager_Father_Name;
                                    User_Father_Name_Check = true;
                                }
                            }

                            if (temp_string2.Contains("Пароль:"))
                            {
                                if (Manager_Password == sr2.ReadLine())
                                {
                                    User_Password = Manager_Password;
                                    User_Password_Check = true;
                                }
                            }
                        }
                        sr2.Close();
                        break;

                    case "продавец-консультант":
                        FileStream fs3 = new FileStream($"Seller-Consultant\\Seller-Consultant_{Manager_ID}.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr3 = new StreamReader(fs3);

                        string temp_string3;

                        while (sr3.EndOfStream == false)
                        {
                            temp_string3 = sr3.ReadLine();

                            if (temp_string3.Contains("ID продавца-консультанта:"))
                            {
                                if (Manager_ID == Convert.ToInt32(sr3.ReadLine()))
                                {
                                    User_ID = Manager_ID;
                                    User_ID_Check = true;
                                }
                            }

                            if (temp_string3.Contains("Фамилия:"))
                            {
                                if (Manager_Surname == sr3.ReadLine())
                                {
                                    User_Surname = Manager_Surname;
                                    User_Surname_Name_Check = true;
                                }
                            }

                            if (temp_string3.Contains("Имя:"))
                            {
                                if (Manager_Name == sr3.ReadLine())
                                {
                                    User_Name = Manager_Name;
                                    User_Name_Check = true;
                                }
                            }

                            if (temp_string3.Contains("Отчество:"))
                            {
                                if (Manager_Father_Name == sr3.ReadLine())
                                {
                                    User_Fathername = Manager_Father_Name;
                                    User_Father_Name_Check = true;
                                }
                            }

                            if (temp_string3.Contains("Пароль:"))
                            {
                                if (Manager_Password == sr3.ReadLine())
                                {
                                    User_Password = Manager_Password;
                                    User_Password_Check = true;
                                }
                            }
                        }
                        sr3.Close();
                        break;

                    case "товаровед":
                        FileStream fs4 = new FileStream($"Merchendiser\\Merchendiser_{Manager_ID}.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr4 = new StreamReader(fs4);

                        string temp_string4;

                        while (sr4.EndOfStream == false)
                        {
                            temp_string4 = sr4.ReadLine();

                            if (temp_string4.Contains("ID товароведа:"))
                            {
                                if (Manager_ID == Convert.ToInt32(sr4.ReadLine()))
                                {
                                    User_ID = Manager_ID;
                                    User_ID_Check = true;
                                }
                            }

                            if (temp_string4.Contains("Фамилия:"))
                            {
                                if (Manager_Surname == sr4.ReadLine())
                                {
                                    User_Surname = Manager_Surname;
                                    User_Surname_Name_Check = true;
                                }
                            }

                            if (temp_string4.Contains("Имя:"))
                            {
                                if (Manager_Name == sr4.ReadLine())
                                {
                                    User_Name = Manager_Name;
                                    User_Name_Check = true;
                                }
                            }

                            if (temp_string4.Contains("Отчество:"))
                            {
                                if (Manager_Father_Name == sr4.ReadLine())
                                {
                                    User_Fathername = Manager_Father_Name;
                                    User_Father_Name_Check = true;
                                }
                            }

                            if (temp_string4.Contains("Пароль:"))
                            {
                                if (Manager_Password == sr4.ReadLine())
                                {
                                    User_Password = Manager_Password;
                                    User_Password_Check = true;
                                }
                            }
                        }
                        sr4.Close();
                        break;

                    case "покупатель":
                        FileStream fs5 = new FileStream($"Customers\\Customer_{Manager_ID}.txt", FileMode.Open, FileAccess.Read);
                        StreamReader sr5 = new StreamReader(fs5);

                        string temp_string5;

                        while (sr5.EndOfStream == false)
                        {
                            temp_string5 = sr5.ReadLine();

                            if (temp_string5.Contains("ID покупателя:"))
                            {
                                if (Manager_ID == Convert.ToInt32(sr5.ReadLine()))
                                {
                                    User_ID = Manager_ID;
                                    User_ID_Check = true;
                                }
                            }

                            if (temp_string5.Contains("Фамилия:"))
                            {
                                if (Manager_Surname == sr5.ReadLine())
                                {
                                    User_Surname = Manager_Surname;
                                    User_Surname_Name_Check = true;
                                }
                            }

                            if (temp_string5.Contains("Имя:"))
                            {
                                if (Manager_Name == sr5.ReadLine())
                                {
                                    User_Name = Manager_Name;
                                    User_Name_Check = true;
                                }
                            }

                            if (temp_string5.Contains("Отчество:"))
                            {
                                if (Manager_Father_Name == sr5.ReadLine())
                                {
                                    User_Fathername = Manager_Father_Name;
                                    User_Father_Name_Check = true;
                                }
                            }

                            if (temp_string5.Contains("Пароль:"))
                            {
                                if (Manager_Password == sr5.ReadLine())
                                {
                                    User_Password = Manager_Password;
                                    User_Password_Check = true;
                                }
                            }
                        }
                        sr5.Close();
                        break;
                }
                

                if (User_ID_Check == true &&
                    User_Surname_Name_Check == true &&
                    User_Name_Check == true &&
                    User_Father_Name_Check == true &&
                    User_Password_Check == true)
                {
                    Console.Clear();
                    Console.WriteLine("Вы успешно вошли в систему. Добропожаловать и желаем вам хорошего рабочего дня.\nНажмите на любую клавишу для того чтобы продолжить");
                    Console.ReadKey();

                    switch (Employe_Role.ToLower())
                    {
                        case "менеджер":
                            Manager_Menu();
                            break;

                        case "продавец":
                            Seller_Menu(); 
                            break;

                        case "продавец-консультант":
                            Seller_Consultant_Menu();
                            break;

                        case "товаровед":
                            Merchendiser_Menu();
                            break;

                        case "покупатель":
                            Customer_Menu();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Мы не можем вас впустить в систему так как форма заполнена неправильно или вас нет в системе.\nНажмите на любую клавишу для того чтобы продолжить");
                    Console.ReadKey();
                    Login_User();
                }
            }
            catch (FileLoadException)
            {
                Console.WriteLine("Не удалось загрузить файл");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }
            catch (ArgumentException)
            {

            }
            catch (FormatException)
            {
                Console.WriteLine("Введён неверный тип данных");
            }
        }

        static void Seller_Menu()
        {
            bool Seller_Menu_bool = true;

            while (Seller_Menu_bool)
            {
                Seller seller = new Seller(User_ID, User_Surname, User_Name, User_Fathername, User_Password);
                Console.Clear();
                Console.WriteLine("Что вы хотите сделать?:");
                Console.WriteLine("1) Продать товар покупателю");
                Console.WriteLine("2) Запросить информацию о товаре");
                Console.WriteLine("3) Заполнить отчёт о товаре");
                Console.WriteLine("4) Ввернуться в меню логина");

                int User_Choice = Convert.ToInt32(Console.ReadLine());

                switch (User_Choice)
                {
                    case 1:
                        Console.Clear();
                        seller.Sell_Goods();
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        seller.Requare_Info_About_Goods();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        seller.Write_log_about_sold_Goods();
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Login_User();
                        Console.ReadKey();
                        Seller_Menu_bool = false;
                        break;
                }
            }
        }

        static void Seller_Consultant_Menu()
        {
            bool Seller_Consultant_Menu_bool = true;

            while (Seller_Consultant_Menu_bool)
            {
                Seller_Consultant seller_Consultant = new Seller_Consultant(User_ID, User_Surname, User_Name, User_Fathername, User_Password);
                Console.Clear();
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1) Посоветовать товар покупателю");
                Console.WriteLine("2) Продать товар покупателю");
                Console.WriteLine("3) Запросить информацию о товаре");
                Console.WriteLine("4) Заполнить отчёт о проданных товарах");
                Console.WriteLine("5) Вернуться в меню логина");
                int User_Choice = Convert.ToInt32(Console.ReadLine());

                switch (User_Choice)
                {
                    case 1:
                        Console.Clear();
                        seller_Consultant.Recomend_Goods_to_Customer();
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        seller_Consultant.Sell_Goods();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        seller_Consultant.Requare_Info_About_Goods();
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        seller_Consultant.Write_log_about_sold_Goods();
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Login_User();
                        Console.ReadKey();
                        Seller_Consultant_Menu_bool = false;
                        break;
                }
            }
        }

        static void Customer_Registration_Menu()
        {
            Console.Clear();
            Console.WriteLine("Добропожаловать в форму регистрации покупателя");
            Console.WriteLine("Введите свою фамилию:");
            string User_Surname = Console.ReadLine();
            Console.WriteLine("Введите своё имя");
            string User_Name = Console.ReadLine();
            string User_Fathername = string.Empty;

            bool Have_Customer_a_Fathername = true;
            while (Have_Customer_a_Fathername)
            {
                Console.WriteLine("Есть ли у вас отчество?");
                Console.WriteLine("Да");
                Console.WriteLine("Нет");
                string Ask_User_about_Fathername = Console.ReadLine();
                
                switch (Ask_User_about_Fathername.ToLower())
                {
                    case "да":
                        Console.WriteLine("Введите своё отчество");
                        User_Fathername = Console.ReadLine();
                        Have_Customer_a_Fathername = false;
                        break;

                    case "нет":
                        User_Fathername = "Отсутствует";
                        Have_Customer_a_Fathername = false;
                        break;
                }
            }

            Console.WriteLine("Придумайте себе пароль");
            string User_Password = Console.ReadLine();

            int Customer_ID = 1;

            while (File.Exists($"Customers\\Customer_{Customer_ID}.txt") == true)
            {
                Customer_ID++;
            }

            FileStream fs = new FileStream($"Customers\\Customer_{Customer_ID}.txt", FileMode.CreateNew, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("ID покупателя:");
            sw.WriteLine(Customer_ID);
            sw.WriteLine("");

            sw.WriteLine("Фамилия:");
            sw.WriteLine(User_Surname);
            sw.WriteLine("");

            sw.WriteLine("Имя:");
            sw.WriteLine(User_Name);
            sw.WriteLine("");

            sw.WriteLine("Отчество:");
            sw.WriteLine(User_Fathername);
            sw.WriteLine("");

            sw.WriteLine("Пароль:");
            sw.WriteLine(User_Password);
            sw.WriteLine("");

            sw.WriteLine("Список купленных товаров:");

            sw.Close();
            Login_User();
        }

        static void Customer_Menu()
        {
            Console.Clear();
            Console.WriteLine("Добропожаловать в магазин сотовых телефонов");
            Console.WriteLine("Что вы хотите сделать?:");
            Console.WriteLine("1) Купить товар");
            Console.WriteLine("2) Запросить информацию о товаре");
            Console.WriteLine("3) Посмотреть список купленных товаров");
            Console.WriteLine("4) Вернуться в меню логина");

            int User_Choice = Convert.ToInt32(Console.ReadLine());

            switch (User_Choice)
            {
                case 1: 
                    Console.WriteLine("Введите ID товара который вы хотите купить:");
                    int Goods_ID_Customer_want_buy = Convert.ToInt32(Console.ReadLine());

                    Goods goods = new Goods();
                    goods.Load_Data_from_File(Goods_ID_Customer_want_buy);

                    FileStream fs = new FileStream($"Customers\\Customer_{User_ID}.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine($"{goods.Goods_ID}: {goods.Mobile_Phone_Brand} {goods.Mobile_Phone_Model}");
                    sw.Close();
                    Customer_Menu();
                    break;
                    

                case 2:
                    Console.WriteLine("Введите ID товара информацию о котором вы хотите получить информацию:");
                    int Goods_ID_Customer_want_get_info = Convert.ToInt32(Console.ReadLine());

                    Goods goods2 = new Goods();
                    goods2.Load_Data_from_File(Goods_ID_Customer_want_get_info);

                    Console.WriteLine($"ID товара: {goods2.Goods_ID}");
                    Console.WriteLine($"Название брэнда телефона: {goods2.Mobile_Phone_Brand}");
                    Console.WriteLine($"Название модели телефона: {goods2.Mobile_Phone_Model}");
                    Console.WriteLine($"Стоимость товара: {goods2.Goods_Price} рублей");
                    Console.WriteLine($"Описание товара: {goods2.Mobile_Phone_Description}");
                    Console.ReadKey();
                    Customer_Menu();
                    break;

                case 3:
                    FileStream fs2 = new FileStream($"Customers\\Customer_{User_ID}.txt", FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs2);

                    string temp_string = string.Empty;

                    while (sr.EndOfStream == false)
                    {
                        temp_string = sr.ReadLine();
                        if (temp_string.Contains("Список купленных товаров:"))
                        {
                            Console.WriteLine($"{sr.ReadLine()}");
                        }
                    }
                    Console.ReadKey();
                    Customer_Menu();
                    break;

                case 4:
                    Login_User();
                    break;

                default:
                    Customer_Menu();
                    break;
            }
        }

        static void Merchendiser_Menu()
        {
            Merchendiser merchendiser = new Merchendiser();
            Console.Clear();
            Console.WriteLine("Что вы хотите сделать?:");
            Console.WriteLine("1) Заполнить карточку товара");
            Console.WriteLine("2) Запросить информацию о товаре");
            Console.WriteLine("3) Проверить карточку товара на заполнение");
            Console.WriteLine("4) Ввернуть в меню логина");

            int User_Choice = Convert.ToInt32(Console.ReadLine());

            switch (User_Choice)
            {
                case 1:
                    Console.WriteLine("Введите ID товара:");
                    int Goods_ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите название бренда телефона:");
                    string Mobile_Phone_Brand = Console.ReadLine();
                    Console.WriteLine("Введите название модели телефона:");
                    string Mobile_Phone_Model = Console.ReadLine();
                    Console.WriteLine("Введите стоимость товара в рублях:");
                    int Goods_Price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите описание товара:");
                    string Goods_Description = Console.ReadLine();

                    merchendiser.Fill_info_of_Goods(Goods_ID, Mobile_Phone_Brand, Mobile_Phone_Model, Goods_Price, Goods_Description);
                    Console.WriteLine("Карточка товара заполнена");
                    Console.ReadKey();
                    Merchendiser_Menu();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите ID товара информацию о котором вы хотите получить:");
                    int Goods_ID_find = Convert.ToInt32(Console.ReadLine());
                    merchendiser.Get_info_of_Goods(Goods_ID_find);
                    Console.ReadKey();
                    Merchendiser_Menu();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите ID товара для проверки карточки товара:");
                    int Goods_ID_find2 = Convert.ToInt32(Console.ReadLine());
                    merchendiser.Check_Goods_Card(Goods_ID_find2);
                    Console.ReadKey();
                    Merchendiser_Menu();
                    break;

                case 4:
                    Login_User();
                    break;
            }
        }

        static void Manager_Menu()
        {
            Manager manager = new Manager(User_ID, User_Surname, User_Name, User_Fathername, User_Password);

            bool Main_Menu_Active = true;
            bool Look_at_list_of_employes = false;
            bool Hire_a_new_Employe = false;
            bool Fire_a_Employe = false;

            while (Main_Menu_Active)
            {
                Console.Clear();
                Console.WriteLine("Меню менеджера:");
                Console.WriteLine("Что вы хотите сделать?:");
                Console.WriteLine("1) Посмотреть список сотрудников");
                Console.WriteLine("2) Добавить нового сотрудника");
                Console.WriteLine("3) Уволить сотрудника");
                // Console.WriteLine("4) Задать цель сотрудникам");
                Console.WriteLine("5) Выйти в меню логина");

                int User_Choice = Convert.ToInt32(Console.ReadLine());

                switch (User_Choice)
                {
                    case 1: //просмотр списка сотрудников
                        Look_at_list_of_employes = true;
                        while (Look_at_list_of_employes)
                        {
                            switch (User_Choice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Список каких сотрудников вы хотите посмотреть?:");
                                    Console.WriteLine("1) Менеджеров");
                                    Console.WriteLine("2) Продавцов");
                                    Console.WriteLine("3) Продавцов-Консультантов");
                                    Console.WriteLine("4) Товароведов");
                                    Console.WriteLine("5) Выйти в меню действий");

                                    int Employe_Role = Convert.ToInt32(Console.ReadLine());

                                    switch (Employe_Role)
                                    {
                                        case 1:
                                            Console.Clear();
                                            manager.See_a_List_of_Employes("менеджер");
                                            Console.ReadKey();
                                            break;

                                        case 2:
                                            Console.Clear();
                                            manager.See_a_List_of_Employes("продавец");
                                            Console.ReadKey();
                                            break;

                                        case 3:
                                            Console.Clear();
                                            manager.See_a_List_of_Employes("продавец-консультант");
                                            Console.ReadKey();
                                            break;

                                        case 4:
                                            Console.Clear();
                                            manager.See_a_List_of_Employes("товаровед");
                                            Console.ReadKey();
                                            break;

                                        case 5:
                                            Look_at_list_of_employes = false;
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;

                    case 2: //найм нового сотрудника
                        Hire_a_new_Employe = true;

                        while (Hire_a_new_Employe)
                        {
                            Console.Clear();
                            Console.WriteLine("Какой тип сотрудника вы хотите нанять");
                            Console.WriteLine("1) Менеджер");
                            Console.WriteLine("2) Продавец");
                            Console.WriteLine("3) Продавец-Консультант");
                            Console.WriteLine("4) Товаровед");
                            Console.WriteLine("5) Выйти в меню действий");

                            int Employe_Role = Convert.ToInt32(Console.ReadLine());

                            switch (Employe_Role)
                            {
                                case 1:
                                    Console.Clear();
                                    manager.Hire_new_Employe_menu = true;
                                    manager.Hire_new_Employe("менеджер");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    manager.Hire_new_Employe_menu = true;
                                    manager.Hire_new_Employe("продавец");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.Clear();
                                    manager.Hire_new_Employe_menu = true;
                                    manager.Hire_new_Employe("продавец-консультант");
                                    Console.ReadKey();
                                    break;

                                case 4:
                                    Console.Clear();
                                    manager.Hire_new_Employe_menu = true;
                                    manager.Hire_new_Employe("товаровед");
                                    Console.ReadKey();
                                    break;

                                case 5:
                                    Hire_a_new_Employe = false;
                                    break;
                            }
                        }
                        break;

                    case 3: //увольнение сотрудника

                        Fire_a_Employe = true;

                        while (Fire_a_Employe)
                        {
                            Console.Clear();
                            Console.WriteLine("Какой тип сотрудника вы хотите уволить");
                            Console.WriteLine("1) Менеджер");
                            Console.WriteLine("2) Продавец");
                            Console.WriteLine("3) Продавец-Консультант");
                            Console.WriteLine("4) Товаровед");
                            Console.WriteLine("5) Выйти в меню действий");

                            int Employe_Role = Convert.ToInt32(Console.ReadLine());

                            switch (Employe_Role)
                            {
                                case 1:
                                    Console.Clear();
                                    manager.Fire_Employe("менеджер");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.Clear();
                                    manager.Fire_Employe("продавец");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    Console.Clear();
                                    manager.Fire_Employe("продавец-консультант");
                                    Console.ReadKey();
                                    break;

                                case 4:
                                    Console.Clear();
                                    manager.Fire_Employe("товаровед");
                                    Console.ReadKey();
                                    break;

                                case 5:
                                    Fire_a_Employe = false;
                                    break;
                            }
                        }
                        
                        break;

                    case 5:
                        Console.Clear();
                        Login_User();
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Login_User();
        }
    }
}