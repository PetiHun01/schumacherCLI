using System;
using System.Collections.Generic;
using System.Text;

namespace schumacherCLI
{
    internal class Race
    {
        string date;
        string grandprix;
        int position;
        int laps;
        int points;
        string team;
        string status;

        public string Date { get => date; set => date = value; }
        public string Grandprix { get => grandprix; set => grandprix = value; }
        public int Position { get => position; set => position = value; }
        public int Laps { get => laps; set => laps = value; }
        public int Points { get => points; set => points = value; }
        public string Team { get => team; set => team = value; }
        public string Status { get => status; set => status = value; }

        public Race(string sor)
        {
            var dbok = sor.Split(';');
            date = dbok[0];
            grandprix = dbok[1];
            position = Convert.ToInt32( dbok[2]);
            laps = Convert.ToInt32( dbok[3]);
            points = Convert.ToInt32(dbok[4]);
            team = dbok[5];
            status = dbok[6];
        }
    }
}
