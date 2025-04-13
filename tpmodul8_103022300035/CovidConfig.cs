using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300035
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_demam { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private const string CONFIG_PATH = @"../../../covid_config.json";

        public static CovidConfig LoadConfig()
        {
            if (!File.Exists(CONFIG_PATH))
            {
                var defaultConfig = new CovidConfig();
                defaultConfig.SaveConfig();
                return defaultConfig;
            }

            string json = File.ReadAllText(CONFIG_PATH);
            return JsonSerializer.Deserialize<CovidConfig>(json);
        }

        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CONFIG_PATH, json);
        }

        public void UbahSatuan()
        {
            satuan_suhu = satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
            SaveConfig();
        }
    }
}
