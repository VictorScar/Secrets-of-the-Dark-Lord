using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    string path = "Assets/Levels/Level.csv";
    [SerializeField] Cell[] prefabs;
    [SerializeField] Map map;
    
    void Start()
    {

        string[,] levelData = ReadLevel();

        int width = levelData.GetLength(0);
        int height = levelData.GetLength(1);
        //float angle = 0f;

        map.cells = new Cell[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int id = int.Parse(levelData[x, y]);
                //if (id == 2 && levelData[x, y - 1] != null && levelData[x, y - 1] == "1")
                //{
                //    angle = 90f;
                //}
                //else angle = 0;
                Cell cell = Instantiate(prefabs[id], new Vector3(x, 0.0f, y), Quaternion.identity, transform);
                cell.coord = new Coord(x, y);
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

    // Update is called once per frame
    void Update()
    {

    }

    string[,] ReadLevel()
    {
        string[,] levelData = null;
        //string[,] invertlevelData = null;
        string[] lines = File.ReadAllLines(path);
        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            string[] elements = line.Split(',');
            string[] elementsInvert = new string[elements.Length];
            for (int i = elementsInvert.Length-1, j=0; j < elements.Length; i--, j++)
            {
                elementsInvert[i] = elements[j];
               
            }
            if (levelData == null)
            {
                levelData = new string[elements.Length, lines.Length];
            }
            for (int x = 0; x < elements.Length; x++)
            {
                levelData[x, y] = elementsInvert[x];
            }
        }

        return levelData;
        //return invertlevelData;
    }


}
