﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectDMJ
{
    class DataManager
    {
        public static string pathDataFile = "Games.csv";
        public void CheckIfDataFileExists(List<Games> gameLibrary, string path)
        {
            if(!File.Exists(path))
            {
                DownloadOnlineDataFile(gameLibrary);
                WriteDataFile(gameLibrary, path);
            }
            else
            {
                ReadFile(gameLibrary, path);
            }
        }

        public void DownloadOnlineDataFile(List<Games> gameLibrary)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string download = wc.DownloadString("https://raw.githubusercontent.com/JensVanGelder/ProjectDMJ/master/Games.csv");
            string[] gameLines = downloaded.Split('\n');
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string gameLine = lines[i];
                string[] data = gameLine.Split(',');
                Games game = new Games()
                {
                    Name = data[0],
                    Developer = data[1],
                    Genre = data[2],
                    ReleaseDate = Convert.ToInt32(data[3])
                };
                gameLibrary.Add(game);
            }
        }
                
        public void ReadFile(List<Games> gameLibrary)
        {
            string[] lines = File.ReadAllLines("Games.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                string gameLine = lines[i];
                string[] data = gameLine.Split(',');
                Games game = new Games()
                {
                    Name =  data[0],
                    Developer = data[1],
                    Genre = data[2],
                    ReleaseDate = Convert.ToInt32(data[3])
                };
                gameLibrary.Add(game);
            }
        }

        public void WriteDataFile(List<Games> gameLibrary, string path)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("Name,Developer,Genre,ReleaseDate");
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                writer.WriteLine(gameLibrary[i].PrintInfo());
            }
        }
                
    }
}