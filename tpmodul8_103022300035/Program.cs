using System;
using tpmodul8_103022300035;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam satuan {config.satuan_suhu}:");
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDemam = int.Parse(Console.ReadLine());

        bool suhuNormal = (config.satuan_suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                           (config.satuan_suhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5);

        if (suhuNormal && hariDemam < config.batas_hari_demam)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu telah diubah ke {config.satuan_suhu}.");
    }
}
