using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawnScript : MonoBehaviour
{
    public GameObject normalTilePrefab;
    public GameObject goodTilePrefab;
    public GameObject badTimePrefab;
    public Transform startTile;

    public int gridWidth = 5;
    public int gridHeight = 5;
    public float tileSize;

    public float tileSpacing = 1.2f;
    public float goodTileChance = 0.2f;
    public float badTileChance = 0.2f;

    public Transform[,] gridArray;

    void Start()
    {
        Renderer tileRenderer = normalTilePrefab.GetComponent<Renderer>();
        tileSize = tileRenderer.bounds.size.x * tileSpacing;
        
        gridArray = new Transform[gridWidth, gridHeight];
        
        SpawnGrid();
    }
    GameObject GetRandomTile()
    {
        float rand = Random.value;

        if (rand < goodTileChance)
        {
            return goodTilePrefab;
        }
        else if (rand < badTileChance + goodTileChance)
        {
            return badTimePrefab;
        }
        else
        {
            return normalTilePrefab;
        }
    }

    public void SpawnGrid()
    {
        
        Vector3 startPosition = startTile.position;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (x == 0 && y == 0) continue;

                Vector3 spawnPosition = startPosition + new Vector3(x * tileSize, 0, y * tileSize);
                GameObject tilePrefab = GetRandomTile();

                GameObject tile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
                gridArray[x, y] = tile.transform;
            }
        }
    }

    public Transform[,] GetGridArray()
    {
        return gridArray;
    }
}
