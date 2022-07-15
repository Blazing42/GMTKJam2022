using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    TileGrid testTileGrid;
    public int gridWidth;
    public int gridHeight;
    public int tileSize;
    public Vector3 gridOrigin;

    // Start is called before the first frame update
    void Start()
    {
        testTileGrid = new TileGrid(gridWidth, gridHeight, tileSize, gridOrigin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
