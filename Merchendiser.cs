using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store_Updated
{
    internal class Merchendiser
    {
        public int Goods_ID, Goods_Price;
        public string Mobile_Phone_Brand, Mobile_Phone_Model, Mobile_Phone_Description;
        public Merchendiser()
        {

        }

        public void Fill_info_of_Goods(int Goods_ID, string Mobile_Phone_Brand, string Mobile_Phone_Model, int Goods_Price, string Goods_Description)
        {
            FileStream fs = new FileStream($"Goods\\Goods_{Goods_ID}.txt", FileMode.CreateNew, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("ID товара:");
            sw.WriteLine(Goods_ID);
            sw.WriteLine("");

            sw.WriteLine("Название брэнда телефона:");
            sw.WriteLine(Mobile_Phone_Brand);
            sw.WriteLine("");

            sw.WriteLine("Название модели телефона:");
            sw.WriteLine(Mobile_Phone_Model);
            sw.WriteLine("");

            sw.WriteLine("Стоимость товара:");
            sw.WriteLine(Goods_Price);
            sw.WriteLine("");

            sw.WriteLine("Описание товара:");
            sw.WriteLine(Goods_Description);
            sw.WriteLine("");

            sw.Close();
        }

        public void Get_info_of_Goods(int Goods_ID_find)
        {
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

        public void Check_Goods_Card(int Goods_ID_find)
        {
            bool Goods_ID = true, Goods_Name = true, Goods_Model_Name = true, Goods_Price = true, Goods_Description = true;

            FileStream fs = new FileStream($"Goods\\Goods_{Goods_ID_find}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string temp_string = string.Empty;

            while (sr.EndOfStream == false)
            {
                temp_string = sr.ReadLine();

                if (temp_string.Contains("ID товара:"))
                {
                    if(sr.ReadLine() == string.Empty)
                    {
                        Goods_ID = false;
                    }
                }

                if (temp_string.Contains("Название брэнда телефона:"))
                {
                    if(sr.ReadLine() == string.Empty)
                    {
                        Goods_Name = false;
                    }
                }

                if (temp_string.Contains("Название модели телефона:"))
                {
                    if(sr.ReadLine() == string.Empty)
                    {
                        Goods_Model_Name = false;
                    }
                }

                if (temp_string.Contains("Стоимость товара:"))
                {
                    if(sr.ReadLine() == string.Empty)
                    {
                        Goods_Price = false;
                    }
                }

                if (temp_string.Contains("Описание товара:"))
                {
                    if(sr.ReadToEnd() == string.Empty)
                    {
                        Goods_Description = false;
                    }
                }

            }

            if (Goods_ID == false ||
                Goods_Name == false ||
                Goods_Model_Name == false ||
                Goods_Price == false ||
                Goods_Description == false)
            {
                Console.WriteLine("Карточка товара заполнена не полностью");
            }
            else
            {
                Console.WriteLine("Карточка товара заполнена полностью и корректно");
            }

            if (Goods_ID == false &&
                Goods_Name == false &&
                Goods_Model_Name == false &&
                Goods_Price == false &&
                Goods_Description == false)
            {
                Console.WriteLine("Карточка товара не заполнена");
            }
            else
            {
                Console.WriteLine("Карточка товара заполнена полностью и корректно");
            }
            sr.Close();
        }
    }
}