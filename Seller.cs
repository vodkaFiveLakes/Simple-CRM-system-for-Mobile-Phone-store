using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store_Updated
{
    internal class Seller
    {
        public int Goods_ID, Goods_Price;
        public string Mobile_Phone_Brand, Mobile_Phone_Model;
        public Seller(int User_ID, string User_Surname, string User_Name, string User_Fathername, string User_Password)
        {

        }

        public void Sell_Goods()
        {
            Console.WriteLine("Введите ID товара который вы хотите продать:");
            int Goods_ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите ID покупателя которому вы хотите продать товар:");
            int Customer_ID = Convert.ToInt32(Console.ReadLine());

            FileStream fs = new FileStream($"Goods\\Goods_{Goods_ID}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string temp_string;

            while (sr.EndOfStream == false)
            {
                temp_string = sr.ReadLine();

                if (temp_string.Contains("ID товара:"))
                {
                    Goods_ID = Convert.ToInt32(sr.ReadLine());
                }

                if (temp_string.Contains("Название брэнда телефона:"))
                {
                    Mobile_Phone_Brand = sr.ReadLine();
                }

                if (temp_string.Contains("Название модели телефона:"))
                {
                    Mobile_Phone_Model = sr.ReadLine();
                }
            }

            FileStream fs2 = new FileStream($"Customers\\Customer_{Customer_ID}.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw2 = new StreamWriter(fs2);
            
            sw2.WriteLine($"{Goods_ID}: {Mobile_Phone_Brand} {Mobile_Phone_Model}");

            sw2.Close();
            sr.Close();
        }

        public void Requare_Info_About_Goods()
        {
            Console.WriteLine("Введите ID товара информацию о котором вы хотите получить:");
            int Goods_ID_find = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            FileStream fs = new FileStream($"Goods\\Goods_{Goods_ID_find}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string temp_string = string.Empty;

            while (sr.EndOfStream == false)
            {
                temp_string = sr.ReadLine();

                if (temp_string.Contains("ID товара:"))
                {
                    Console.WriteLine(sr.ReadLine());
                }

                if (temp_string.Contains("Название брэнда телефона:"))
                {
                    Console.WriteLine(sr.ReadLine());
                }

                if (temp_string.Contains("Название модели телефона:"))
                {
                    Console.WriteLine(sr.ReadLine());
                }

                if (temp_string.Contains("Стоимость товара:"))
                {
                    Console.WriteLine(sr.ReadLine());
                }

                if (temp_string.Contains("Описание товара:"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }

            }
            sr.Close();
        }

        public void Write_log_about_sold_Goods()
        {
            string User_Surname = string.Empty, User_Name = string.Empty, User_Fathername = string.Empty;

            Console.WriteLine("Меню заполнения отчёта о проданных товарах");
            Console.WriteLine("Информация о продавце (ID, ФИО)");
            Console.WriteLine("Впишите свой ID:");
            int Write_your_ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ваше ФИО");

            FileStream fs = new FileStream($"Seller\\Seller_{Write_your_ID}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string temp_string = string.Empty;

            while (sr.EndOfStream == false)
            {
                temp_string = sr.ReadLine();

                if (temp_string.Contains("Фамилия:"))
                {
                    User_Surname = sr.ReadLine();
                }

                if (temp_string.Contains("Имя:"))
                {
                    User_Name = sr.ReadLine();
                }

                if (temp_string.Contains("Отчество:"))
                {
                    User_Fathername = sr.ReadLine();
                }
            }

            sr.Close();

            DateTime date = DateTime.Now;
            int Log_ID = 1;

            while (File.Exists($"Seller\\Logs\\Log_{Write_your_ID}_{Log_ID}.txt") == true)
            {
                Log_ID++;
            }

            FileStream fs_write_Log = new FileStream($"Seller\\Logs\\Log_{Write_your_ID}_{Log_ID}.txt", FileMode.CreateNew, FileAccess.Write);
            StreamWriter swo = new StreamWriter(fs_write_Log);

            swo.WriteLine("Отчёт о проданном товаре");
            swo.WriteLine($"Дата и время составления отчёта: {date}\n");
            swo.WriteLine($"Составитель отчёта:\nID продавца: {Write_your_ID}");

            Console.WriteLine($"Фамилия: {User_Surname}");
            swo.WriteLine($"Фамилия: {User_Surname}");
            Console.WriteLine($"Имя: {User_Name}");
            swo.WriteLine($"Имя: {User_Name}");
            Console.WriteLine($"Отчество: {User_Fathername}");
            swo.WriteLine($"Отчество: {User_Fathername}");
            swo.WriteLine("");
            Console.ReadKey();
            Console.Clear();

            int Goods_Price = 0;
            string Goods_Brand = string.Empty, Goods_Model = string.Empty;

            Console.WriteLine("Меню заполнения отчёта о проданных товарах");
            Console.WriteLine("Какой товар был продан и в каком количестве");
            Console.WriteLine("Введите ID товара:");
            int Write_Goods_ID = Convert.ToInt32(Console.ReadLine());

            swo.WriteLine("Товар который был продан:\n");

            fs = new FileStream($"Goods\\Goods_{Write_Goods_ID}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr2 = new StreamReader(fs);

            temp_string = string.Empty;

            while (sr2.EndOfStream == false)
            {
                temp_string = sr2.ReadLine();

                if (temp_string.Contains("Название брэнда телефона:"))
                {
                    Goods_Brand = sr2.ReadLine();
                }
                
                if (temp_string.Contains("Название модели телефона:"))
                {
                    Goods_Model = sr2.ReadLine();
                }

                if (temp_string.Contains("Стоимость товара:"))
                {
                    Goods_Price = Convert.ToInt32(sr2.ReadLine());
                }
            }

            sr2.Close();

            Console.WriteLine("Введите количество проданного товара:");
            decimal Count_of_Sold_Goods = Convert.ToInt32(Console.ReadLine());

            swo.WriteLine($"ID товара: {Write_Goods_ID}");
            swo.WriteLine($"Бренд товара: {Goods_Brand}");
            swo.WriteLine($"Модель товара: {Goods_Model}");
            swo.WriteLine($"Цена за одну единиу товара: {Goods_Price} рублей");
            swo.WriteLine($"Количество проданого товара: {Count_of_Sold_Goods} штук");
            swo.WriteLine($"Цена за {Count_of_Sold_Goods} штук товара: {Count_of_Sold_Goods * Goods_Price} рублей");
            swo.WriteLine("");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Меню заполнения отчёта о проданных товарах");
            Console.WriteLine("Введите ID покупателя:");
            int Customer_ID = Convert.ToInt32(Console.ReadLine());


            FileStream fs3 = new FileStream($"Customers\\Customer_{Customer_ID}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr3 = new StreamReader(fs3);
            string Customer_Surname = string.Empty, Customer_Name = string.Empty, Customer_Fathername = string.Empty;

            temp_string = string.Empty;

            while (sr3.EndOfStream == false)
            {
                temp_string = sr3.ReadLine();

                if (temp_string.Contains("Фамилия:"))
                {
                    Customer_Surname = sr3.ReadLine();
                }

                if (temp_string.Contains("Имя:"))
                {
                    Customer_Name = sr3.ReadLine();
                }

                if (temp_string.Contains("Отчество:"))
                {
                    Customer_Fathername = sr3.ReadLine();
                }
            }

            sr3.Close();

            Console.Clear();
            Console.WriteLine("Меню заполнения отчёта о проданных товарах");
            swo.WriteLine("Покупатель который купил товар:\n");
            swo.WriteLine($"ID покупателя: {Customer_ID}");
            Console.WriteLine($"Вы продали товар на сумму {Count_of_Sold_Goods * Goods_Price} покупателю с:");
            Console.WriteLine($"ID: {Customer_ID}");
            Console.WriteLine($"Фамилией: {Customer_Surname}");
            swo.WriteLine($"Фамилия покупателя: {Customer_Surname}");
            Console.WriteLine($"Имя: {Customer_Name}");
            swo.WriteLine($"Имя покупателя: {Customer_Name}");
            Console.WriteLine($"Отчеством: {Customer_Fathername}");
            swo.WriteLine($"Отчество покупателя: {Customer_Fathername}");

            Console.WriteLine("Отчёт о проданных товарах заполнен");
            Console.WriteLine("\nНажмите на любую клавишу чтобы сохранить");
            swo.Close();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
