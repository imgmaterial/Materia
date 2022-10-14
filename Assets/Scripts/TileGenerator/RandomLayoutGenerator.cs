using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class RandomLayoutGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseTile;
    public int rows;
    public int columns;
    private int[,] grid;
    private NavMeshSurface[] navMeshTiles;
    void Start()
    {
        grid = new int[rows, columns];
        navMeshTiles = new NavMeshSurface[rows + columns];
        RandomGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetTiles();
        }
    }

    public void RandomGrid()
    {
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
            {
                float randomValue = Random.value;
                if (randomValue > 0.5f)
                {
                    grid[i, j] = 1;
                }
                
            }
            
    }

    public void SetTiles()
    {
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
            {
                if (grid[i, j] == 1)
                {
                    GameObject tile = Instantiate(baseTile, new Vector3(j*-10, -0.1f, i*10), Quaternion.identity);
                    NavMeshSurface tileSurface = tile.AddComponent<NavMeshSurface>();
                    navMeshTiles[i + j] = tileSurface;
                }
            }
        for (int i = 0; i < navMeshTiles.Length; i++)
        {
            if (navMeshTiles[i] != null)
            {
                navMeshTiles[i].BuildNavMesh();
            }
        }
    }

}
