﻿using UnityEngine;
using System.Collections;

public class TerrainHeightMap : MonoBehaviour {
    private int width = 1024;  //  x, ширина мира
    private int length = 1024;  //  z, длина мира
    private int height = 256;  //  y, высота мира
    private float scale = 1.70f;  //  масштабирование, коэффициент при расчёте карты высот

    public int Width
    {
        get
        {
            return width;
        }
    }

    public int Length
    {
        get
        {
            return length;
        }
    }

    public int Height
    {
        get
        {
            return height;
        }
    }


    void Start () {
        Terrain terrain = GetComponent<Terrain>();  //  находим террейн
        //terrain.terrainData = GetTerrainData(terrain.terrainData);  //  присваиваем данные о террейне
    }
	

	void Update () {
	
	}

    private TerrainData GetTerrainData(TerrainData data)
    {
        data.size = new Vector3(width, height, length);  //  задаём размеры террейна
        data.heightmapResolution = width + 1;  //  задаём разрешение карты высот
        data.SetHeights(0, 0, GenerateHeightMap());  //  присваиваем карту высот
        return data;
    }

    private float[,] GenerateHeightMap()
    {
        float[,] result = new float[width, length];  //  создаем массив карты высот
        for (int x = 0; x < width; x++)
            for (int y = 0; y < length; y++)
                result[x, y] = Mathf.PerlinNoise((float)x / (float)width * scale, (float)y / (float)length * scale);
        //  присваиваем значения карте высот с использованием шума Перлина
        return result;
    }
}
