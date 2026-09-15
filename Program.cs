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
                    Console.WriteLine("\t"+versenyek[i].Date + ": " + versenyek[i].Position + ". hely");
                }
            }
            int counterEngine = 0;
            int counterSpunOff = 0;
            int counterAccident = 0;
            int counterGearbox = 0;
            int counterHidraulics = 0;
            int counterCollision = 0;
            int counterSuspension = 0;

            for (int i = 0; i < versenyek.Count; i++)
            {
                if (versenyek[i].Status == "Engine")
                {
                    counterEngine++;
                }
                else if (versenyek[i].Status == "Spun off")
                {
                    counterSpunOff++;
                }
                else if (versenyek[i].Status == "Accident")
                {
                    counterAccident++;
                }
                else if (versenyek[i].Status == "Gearbox")
                {
                    counterGearbox++;
                }
                else if (versenyek[i].Status == "Hydraulics")
                {
                    counterHidraulics++;
                }
                else if (versenyek[i].Status == "Collision")
                {
                    counterCollision++;
                }
                else if (versenyek[i].Status == "Suspension")
                {
                    counterSuspension++;
                }
            }
            if (counterEngine >= 2)
            {
                Console.WriteLine("Engine: {0}", counterEngine);
            }
            if (counterSpunOff >= 2)
            {
                Console.WriteLine("Spun Off: {0}", counterSpunOff);
            }
            
            if(counterAccident >= 2)
            {
                Console.WriteLine("Accident: {0}", counterAccident);
            }
            
            if(counterGearbox >= 2)
            {
                Console.WriteLine("Gearbox: {0}", counterGearbox);
            }
            
            if(counterHidraulics >= 2)
            {
                Console.WriteLine("Hydraulics: {0}", counterHidraulics);
            }
            
            if(counterCollision >= 2)
            {
                Console.WriteLine("Collision: {0}", counterCollision);
            }

            if (counterSuspension >= 2)
            {
                Console.WriteLine("Suspension: {0}", counterSuspension);
            }
        }
    }
}
