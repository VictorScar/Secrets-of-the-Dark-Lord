using SODL.Cells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SODL.Core
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] Cell[] prefabs;
        [SerializeField] Map map;


        void Awake()
        {
            string[,] levelData = ReadLevel();

            int width = levelData.GetLength(0);
            int height = levelData.GetLength(1);


            map.cells = new Cell[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int id = int.Parse(levelData[x, y]);

                    Cell cell = Instantiate(prefabs[id], new Vector3(x, 0.0f, y), Quaternion.identity, transform);
                    cell.coord = new Vector2Int(x, y);
                    map.cells[x, y] = cell;
                }

            }

            foreach (var cell in map.cells)
            {
                cell.Init(map);
            }


        }

        private static void PrintLevelData(string[,] levelData)
        {
            int width = levelData.GetLength(0);
            int height = levelData.GetLength(1);
            string printLevelData = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    printLevelData += levelData[x, y];
                }
                printLevelData += "\n";
            }
            Debug.Log(printLevelData);
        }


        string[,] ReadLevel()
        {
            string[,] levelData = null;
            TextAsset levelAsset = Resources.Load<TextAsset>("Levels/Level");
            string levelText = levelAsset.text;
            string[] lines = levelText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                string[] elements = line.Split(',');
                int width = elements.Length;

                if (levelData == null)
                {

                    levelData = new string[width, lines.Length];
                }

                for (int x = 0; x < width; x++)
                {
                    levelData[x, y] = elements[width - 1 - x];
                }

            }

            return levelData;

        }


    }
}