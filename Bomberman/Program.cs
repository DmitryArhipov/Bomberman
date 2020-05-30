﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bomberman
{
    static class Program
    {
        public static readonly string SlnPath = Directory.GetCurrentDirectory();
        
        public static string currentLevel;
        public static List<string> AllLevels = new List<string>();
        public static Queue<string> LevelsToPlay = new Queue<string>();
        private static readonly string MapsPath = Path.Combine(SlnPath, "Maps");
        private static readonly DirectoryInfo Maps = new DirectoryInfo(MapsPath);
        public static readonly string SavePath = Path.Combine(SlnPath, "Save");
        public static readonly string SoundsPath = Path.Combine(SlnPath, "Sounds");
        public static bool EnableSound = true;

        [STAThread]
        static void Main()
        {
            foreach (var level in Maps.GetFiles("*txt"))
            {
                using StreamReader sr = level.OpenText();
                AllLevels.Add(sr.ReadToEnd());
            }

            foreach (var level in AllLevels)
                LevelsToPlay.Enqueue(level);
                      
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartWindow()); 
        }
    }
}
