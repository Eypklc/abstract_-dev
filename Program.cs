using System.ComponentModel;
using System.Threading.Channels;

namespace ödev_abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region HomeWork
            //Örnek: Bir tane Tasit sınıfı oluşturalım ancak bu sınıftan nesne üretilemesin.
            //İçerisinde Marka, Model, TabanFiyat property'leri  bir de türeyen her sınıfa
            //özel hesaplanacak abstract Fiyat property'si ekleyelim.
            //Tasit'dan türeyen Araba, Ucak, Tren ve Gemi class'larımız olsun.
            //Araba'ya özel fiyat hesabı YakitTuru, VitesTuru bilgilerine göre yapılsın
            //(Dizel'se +5000, Otomatikse'se +10000)
            //Uçak'a özel fiyat hesabı kapasite bilgisine göre yapılsın.
            //(Kapasite başına +100)
            //Trene özel fiyat hesabı vagon sayısı ve sınıf bilgisine göre yapılsın
            //(sınıf A ise + 50000, B ise +10000 vagon sayısı başına + 30000)
            //Gemi'ye özel fiyat hesabı kamara sayısına göre yapılsın
            //(kamara başına +40000)
            #endregion
            //Araba araba = new Araba();
            //araba.Marka = "ford";
            //araba.Model = "masteng";
            //araba.TabanFiyat = 20000;
            //araba.Fiyat(20000);

            //Ucak ucak = new Ucak();
            //ucak.Marka = "turkish airlains";
            //ucak.TabanFiyat = 10000;
            //ucak.kapasite = 30;
            //ucak.Fiyat(10000);

            //Tren tren = new Tren();
            //tren.vagonSayisi = 8;
            //tren.Marka = "M8";
            //tren.TabanFiyat = 2000;
            //tren.Fiyat(2000);

            //gemi Gemi = new gemi();
            //Gemi.Marka = "mavi vatan";
            //Gemi.kamara = 4;
            //Gemi.TabanFiyat = 5000;
            //Gemi.Fiyat(5000);

            // taban fiyatı ile fiyatı eşitlemem birazcık saçma oldu ama onsuz da yapılabilir. // düzeltemedim tek sıkıntı yer orası onun dışında kod çalışıyo

        }
    }
    public abstract class tasit
    {
        public abstract string Marka { get; set; }
        public abstract string Model { get; set; }
        public abstract double TabanFiyat { get; set; }

        public abstract void Fiyat(double fiyat);
    }
    public class Araba : tasit
    {
        public override string Marka { get; set; }
        public override string Model { get; set; }
        public override double TabanFiyat { get; set; }
        public bool dizelMi { get; set; }
        public bool OtomatikMi { get; set; }

        public override void Fiyat(double fiyat)
        {
            Console.WriteLine("dizel mi yoksa otomatik mi? \n1-dizel \n2-otomatik");
            int secim = Convert.ToInt32(Console.ReadLine());

            if (dizelMi || secim==1)
            {
                fiyat += 50000;
                TabanFiyat = fiyat;
                dizelMi = true;
                Console.WriteLine("dizel fiyatı: " + TabanFiyat);
            }
            else if (OtomatikMi || secim == 2)
            {
                fiyat += 10000;
                TabanFiyat = fiyat;
                OtomatikMi = true;
                Console.WriteLine("otomatik fiyatı: " + TabanFiyat);
               
            }
            else
            {
                //Console.WriteLine(fiyat);// ne koyacağımı bilemedim ):
            }
            Console.WriteLine("marka: "+Marka+" model: "+Model+" tabanfiyatı: "+TabanFiyat +" dizelMi: "+dizelMi+" otomatikMi: " + OtomatikMi +" fiyatı: "+fiyat);
        }
    }
    public class Ucak : tasit
    {
        public override string Marka { get; set; }
        public override string Model { get; set; }
        public override double TabanFiyat { get; set; }
        public int kapasite {get; set; }

        public override void Fiyat(double fiyat)
        {
            for (int i = 0; i < kapasite; i++)
            {
                fiyat += 100;
            }
            Console.WriteLine("taban fiyatı: "+ TabanFiyat);
            TabanFiyat = fiyat;
            Console.WriteLine("fiyat: "+ fiyat + " kapasitesi: " + kapasite +" Marka: " +Marka );
        }
    }
    public class Tren : tasit
    {
        public override string Marka { get; set; }
        public override string Model { get; set; }
        public override double TabanFiyat { get; set; }
        public int vagonSayisi { get; set; }
        public char sınıfBilgisi {  get; set; }

        public override void Fiyat (double fiyat)
        {
            Console.WriteLine("A class mı B class mı? (A/B)");
            sınıfBilgisi = Convert.ToChar(Console.ReadLine());
            if (sınıfBilgisi == 'A')
            {
                fiyat = fiyat + 50000;
            }
            else if (sınıfBilgisi == 'B')
            {
                fiyat = fiyat + 10000;
            }
            for (int i = 0;i < vagonSayisi; i++)
            {
                fiyat += 30000;
            }
            Console.Write(" tabanfiyat: " + TabanFiyat);
            TabanFiyat = fiyat;
            Console.WriteLine(" marka: " + Marka + " fiyatı: " + fiyat + " vagon sayisi: "+ vagonSayisi+" sınıfbilgisi: "+sınıfBilgisi );
        }
    }
    public class gemi : tasit
    {
        public override string Marka { get; set ; }
        public override string Model { get; set; }
        public override double TabanFiyat { get; set; }
        public int kamara { get; set; }

        public override void Fiyat(double fiyat)
        {
            for (int i = 0; i < kamara; i++)
            {
                fiyat += 40000;
            }
            Console.WriteLine("taban fiyatı: "+ TabanFiyat);
            TabanFiyat = fiyat;
            Console.WriteLine("marka: "+Marka+" kamaraSayısı: "+ kamara+" fiyat "+fiyat);
        }
    }
}
