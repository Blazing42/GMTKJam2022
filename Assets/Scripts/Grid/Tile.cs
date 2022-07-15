using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile 
{
    //co-ordinates of the tile so it knows where it is on the tilemap
    public int x;
    public int y;

    //reference to the tilegrid that it is attached to, which floor/level
    private Grid<Tile> tileGrid;


    //constructor for the tiles
    public Tile(Grid<Tile> tileGrid, int x, int y)
    {
        this.tileGrid = tileGrid;
        this.x = x;
        this.y = y;
    }
}
