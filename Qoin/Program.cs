using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qoin
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Masukan Jumlah Pemain");
            int inputPemain = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Jumlah Dadu");
            int inputDadu = Convert.ToInt32(Console.ReadLine());
            printLempar(inputPemain, inputDadu);
        }
        public static List<Pemain> listLempar(int inputPemain, int inputDadu)
        {
            var listLemparan = new List<Pemain>();
            var totalDadu = new int[inputDadu];
            Random rnd = new Random();
            
            for (int i = 0; i < inputPemain; i++)
            {
                for (int j = 0; j < inputDadu; j++)
                {
                    int dice = rnd.Next(1, 7);
                    totalDadu[j] = dice;
                }
                listLemparan.Add(new Pemain { Nomer = i, Dadu = totalDadu.ToList(), Skor = 0 });
                Array.Clear(totalDadu,0,inputDadu);

            }
            return listLemparan;

        }
        public static List<Pemain> CekAngka(List<Pemain> pemain)
        {
            var angka1 = new List<int>();
            foreach (var item in pemain)
            {
                foreach (var item2 in item.Dadu.ToList())
                {
                    if (item2 == 6)
                    {
                        item.Skor += 1;
                    }
                    else if (item2 == 1)
                    {
                        angka1.Add(item.Nomer);
                    }
                }
                item.Dadu.RemoveAll(Angka6);
                item.Dadu.RemoveAll(Angka1);
            }
            var batas = pemain.Count() - 1;
            for (int i =0; i < pemain.Count; i++)
            {
                foreach (var item in angka1)
                {
                    if (pemain[i].Nomer == item && pemain[i].Nomer != batas)
                    {
                        pemain[i + 1].Dadu.Add(1);
                    }
                    else if (pemain[i].Nomer == item && pemain[i].Nomer == batas)
                    {
                        pemain[0].Dadu.Add(1);
                    }
                }
            }

            return pemain;
        }
        private static bool Angka6(int angka)
        {
            return angka == 6;
        }
        private static bool Angka1(int angka)
        {
            return angka == 1;
        }
        public static void printLempar(int inputPemain, int inputDadu)
        {
            var lemparan = listLempar(inputPemain, inputDadu);
            string pemain = "";
            foreach (var item in lemparan)
            {
                string dadu = "";
                foreach (var item2 in item.Dadu)
                {
                    dadu += item2.ToString() + ",";
                }
                pemain = "Pemain #" + (item.Nomer + 1) +"(" + item.Skor +")" + ":" + dadu;
                string pemain2 = pemain.Remove(pemain.Length - 1, 1);
                Console.WriteLine(pemain2);

            }
            printEvaluasi(CekAngka(lemparan));
        }
        public static void printEvaluasi(List<Pemain> lemparan)
        {
            string pemain = "";
            Console.WriteLine("");
            Console.WriteLine("Setelah Evaluasi");
            foreach (var item in lemparan)
            {
                string dadu = "";
                foreach (var item2 in item.Dadu)
                {
                    dadu += item2.ToString() + ",";
                }
                pemain = "Pemain #" + (item.Nomer + 1) + "(" + item.Skor + ")" + ":" + dadu;
                string pemain2 = pemain.Remove(pemain.Length - 1, 1);               
                Console.WriteLine(pemain2);

            }
        }


    }
}
