using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Store_Updated
{
    internal class Goods
    {
        public int Goods_ID, Goods_Price;
        public string Mobile_Phone_Brand, Mobile_Phone_Model, Mobile_Phone_Description;

        public Goods()
        {
        }

        
        public void Load_Data_from_File(int Goods_ID_find)
        {
            FileStream fs = new FileStream($"Goods\\Goods_{Goods_ID_find}.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string temp_string = string.Empty;

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

                if (temp_string.Contains("Стоимость товара:"))
                {
                    Goods_Price = Convert.ToInt32(sr.ReadLine());
                }

                if (temp_string.Contains("Описание товара:"))
                {
                    Mobile_Phone_Description = sr.ReadToEnd();
                }
            }
        }
    }
}