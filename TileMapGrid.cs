using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TileMapGrid : MonoBehaviour
{
    public GameObject BoardTile, FOWTile;    
    public List<List<GameObject>> HexGrid; 
    public List<List<GameObject>> FOWPlayer1;

    int mapHeight = 3, mapWidth = 9;
    float scale = 0.6f, height, width;
    

    void Start()
    {
        height = (3 * 1.1547f) * scale;
        width = (2 * 1f) * scale; 
        HexGrid = new List<List<GameObject>>();
        for (int x = 0; x < mapWidth; x++)
        {
            HexGrid.Add(new List<GameObject>()); 
        }

        FOWPlayer1 = new List<List<GameObject>>();
        for (int x = 0; x < mapWidth; x++)
        {
            FOWPlayer1.Add(new List<GameObject>());
        }
        createHexGridSystem();

        createFOW(6);        
    }



    void createHexGridSystem()
    {
        float tempX = 0;
        float tempY = 0;          
        
        for (int x = 0; x < mapWidth; x += 2)                                                             
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3 tilePosition = new Vector3(tempX, tempY, 0);
                HexGrid[x].Add(Instantiate(BoardTile, tilePosition, transform.rotation));
                HexGrid[x][y].name = "Tile(" + x + "," + y + ")";
                tempY += height;
            }
            tempY = 0;
            tempX += width;
        }
        tempX = width / 2;
        tempY = height / 2;
        for (int x = 1; x < mapWidth; x += 2)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3 tilePosition = new Vector3(tempX, tempY, 0);
                HexGrid[x].Add(Instantiate(BoardTile, tilePosition, transform.rotation));
                HexGrid[x][y].name = "Tile(" + x + "," + y + ")";
                tempY += height;
            }
            tempY = height / 2;
            tempX += width;
        }
    }

    void createFOW(int layer)
    {
        float tempX = 0;
        float tempY = 0;

        for (int x = 0; x < mapWidth; x += 2)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3 tilePosition = new Vector3(tempX, tempY, -1);
                FOWPlayer1[x].Add(Instantiate(FOWTile, tilePosition, transform.rotation));
                FOWPlayer1[x][y].name = "FOW(" + x + "," + y + ")";
                FOWPlayer1[x][y].layer = layer;

                tempY += height;
            }
            tempY = 0;
            tempX += width;
        }
        tempX = width / 2;
        tempY = height / 2;
        for (int x = 1; x < mapWidth; x += 2)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3 tilePosition = new Vector3(tempX, tempY, -1);
                FOWPlayer1[x].Add(Instantiate(FOWTile, tilePosition, transform.rotation));
                FOWPlayer1[x][y].name = "FOW(" + x + "," + y + ")";
                FOWPlayer1[x][y].layer = layer;
                tempY += height;
            }
            tempY = height / 2;
            tempX += width;
        }
    }


}





