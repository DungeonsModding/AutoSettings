using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace AutoSettings
{
    internal class Program
    {
        // Declare some constants
        const string softwareRoot = "SOFTWARE\\EpicGames\\Unreal Engine\\4.22";
        const string subKey = "InstalledDirectory";
        const string keyName = softwareRoot + "\\" + subKey;
        public static string getDungeonsInstall()
        {
            var lg = new LoggingSystem();
            // Gets AppData Roaming location
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            // Gets Path for launcher_settings.json
            var jsonLocation = Path.Combine(appData, ".minecraft/launcher_settings.json");
            
            // Reads launcher_settings.json into a string
            var json = System.IO.File.ReadAllText(@jsonLocation);
            
            // Deserializes the json
            dynamic pdrJson = JsonConvert.DeserializeObject<dynamic>(json);
            
            // Sets variable productLibraryDir = to the Deserializd Object's productLibraryDir key
            string productLibraryDir = pdrJson.productLibraryDir;

            // Concatenates the path to mods folder with game Install Directory 
            string modLocation = productLibraryDir + @"\dungeons\dungeons\Dungeons\Content\Paks\~mods\";

            return modLocation;
        }

        public static string getUnrealInstall()
        {
            var lg = new LoggingSystem();
            RegistryKey localKey;
            if(Environment.Is64BitOperatingSystem)
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            else
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);

            string value = localKey.OpenSubKey(softwareRoot).GetValue(subKey).ToString();
            return value + @"\Engine\Binaries\Win64";
       
        }
        public static void MainCode()
        {
            var lg = new LoggingSystem();
            lg.CreateLog("Enter Name of Mod : ");
            var nameOf = Console.ReadLine();
            var gameLoco = getDungeonsInstall();
            var newModLocation = gameLoco + nameOf + ".pak";
            var unrealLocation = getUnrealInstall();
            lg.CreateLog(newModLocation);
            lg.CreateLog(unrealLocation);
            File.WriteAllText("user_settings\\package_output.txt", newModLocation);
            lg.CreateLog("Added Package output");
            File.WriteAllText("user_settings\\editor_directory.txt", unrealLocation);
            lg.CreateLog("Added Editor Directory");
            Console.ReadLine();
        }
        public static async Task Main(string[] args)
        {
            MainCode();
        }
        
    }
}
