using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid 
{
    public Grid<Tile> tileGrid;

    //method to create a new tilemap using the grid class 
    public TileGrid(int width, int height, float cellsize, Vector3 originPosition)
    {
        tileGrid = new Grid<Tile>(width, height, cellsize, originPosition, true, (Grid<Tile> tileg, int x, int y) => new Tile(tileg, x, y));
    }
}
