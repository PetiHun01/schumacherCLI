using System.Xml;

namespace schumacherCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Race> versenyek = [];
            var fs = new FileStream("schumacher.csv", FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs);

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                versenyek.Add(new Race(sor));
            }
            sr.Close();
            fs.Close();
            Console.WriteLine($"Az állomány {versenyek.Count} sort tartalmaz");

            Console.WriteLine("Magyar nagydíj helyezései: ");
            for (int i = 0; i < versenyek.Count; i++)
            {
                if (versenyek[i].Grandprix == "Hungarian Grand Prix" && versenyek[i].Position > 0)
                {
                    Console.WriteLine("\t"+versenyek[i].Date.Replace('-', '.') + ": " + versenyek[i].Position + ". hely");
                }
            }
            Dictionary<string, int> hibak = new();
            for (int i = 0; i < versenyek.Count; i++)
            {
                if (hibak.ContainsKey(versenyek[i].Status))
                {
                    hibak[versenyek[i].Status]++;
                }
                else
                {
                    hibak.Add(versenyek[i].Status, 1);
                }
            }
            Console.WriteLine("Hibastatisztika:");
            for (int i = 0; i < hibak.Count; i++)
            {
                Console.WriteLine($"\t{hibak.ElementAt(i).Key}: {hibak.ElementAt(i).Value}");
            }
            //foreach (var hiba in hibak)
            //{
            //    if(hiba.Value > 2 && hiba.Key != "Finished")
            //    {
            //        Console.WriteLine($"\t{hiba.Key}: {hiba.Value}");
            //    }
            //}
        }
    }
}
