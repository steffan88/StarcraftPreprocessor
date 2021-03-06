﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarcraftParser
{
    class ScEvent
    {
        public string Filename { get; set; }
        //public string Mapname { get; set; }
        public int Time { get; set; }
        public int Playerid { get; set; }
        //public string Player { get; set; }
        public Race Race { get; set; }
        public int Score { get; set; }
        public string Unit { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Gas { get; set; }
        public int Minerals { get; set; }
        public int WorkerCount { get; set; }

        public override bool Equals(object obj)
        {
            ScEvent e = (ScEvent)obj;

            if (Filename == e.Filename &&
                Playerid == e.Playerid &&
                Race == e.Race &&
                Score == e.Score &&
                Unit == e.Unit &&
                X == e.X &&
                Y == e.Y &&
                Minerals == e.Minerals &&
                Gas == e.Gas &&
                WorkerCount == e.WorkerCount &&
                Time == e.Time)
                return true;
            else
                return false;
        }
    }
}
