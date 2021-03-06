﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StarcraftParser
{
    enum Race : int
    {
        Protoss = 0,
        Terran = 1,
        Zerg = 2,
    }

    class Parser
    {
        public List<ScGame> Parse(string file)
        {
            string[] raw = File.ReadAllLines(file);
            Dictionary<long, ScGame> games = new Dictionary<long, ScGame>();

            Dictionary<string, int> terranUnits = new Dictionary<string, int>();

            foreach (string str in raw)
            {
                string line = str.Replace('\"', ' ');
                string[] split = line.Split(',');

                // Rå strings fra dette event, splittet op i de forskellige elementer
                string idStr = split[0];
                string timeStr = split[1];
                string playerStr = split[2];
                string raceStr = split[3];
                string scoreStr = split[4];
                string unitStr = split[5];
                string xStr = split[6];
                string yStr = split[7];
                string mineralsStr = split[8];
                string gasStr = split[9];
                string workerCountStr = split[10];

                // De forskellige ting et event består af.
                long id;
                int time;
                Race race = Race.Protoss;
                int score;
                string unit;
                int x;
                int y;
                int minerals;
                int gas;
                int workerCount;

                id = long.Parse(idStr) * 2 + long.Parse(playerStr);

                switch (raceStr)
                {
                    case " Protoss ":
                        race = Race.Protoss;
                        break;
                    case " Terran ":
                        race = Race.Terran;
                        break;
                    case " Zerg ":
                        race = Race.Zerg;
                        break;
                    default:
                        throw new Exception(raceStr + "is not a race in Starcraft");
                }

                time = int.Parse(timeStr);
                score = int.Parse(scoreStr);
                unit = unitStr.Trim();
                x = int.Parse(xStr);
                y = int.Parse(yStr);
                minerals = int.Parse(mineralsStr);
                gas = int.Parse(gasStr);
                workerCount = int.Parse(workerCountStr);

                ScEvent ev = new ScEvent() { Gas = gas, Minerals = minerals, Race = race, Score = score, Time = time, Unit = unit, WorkerCount = workerCount, X = x, Y = y };

                if (games.ContainsKey(id) == true)
                {
                    games[id].Events.Add(ev);
                }
                else
                {
                    games.Add(id, new ScGame() { Race = race });
                    games[id].Events.Add(ev);
                }

                if (race == Race.Terran)
                {
                    if (terranUnits.ContainsKey(unit) == false)
                        terranUnits.Add(unit, 0);
                }
            }

            List<ScGame> gamesList = new List<ScGame>();

            foreach (KeyValuePair<long, ScGame> game in games)
            {
                gamesList.Add(game.Value);
            }

            return gamesList;
        }
    }
}
