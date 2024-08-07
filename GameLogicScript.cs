using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    public GameObject FOWTile;
    public GameObject MapGrid;
    public GameObject GridMovementSystem;  
    public int gameBoardWidth = 9, gameBoardHeight = 3;
    public List<XYCordSystem> testList;

    int x = 0;
    // Start is called before the first frame update
    void Start()
    {   
    

    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public void updateFOWVisability(List<List<GameObject>> FOWGrid, List<XYCordSystem> PlayerList)
    {
        Debug.Log("Inside updateFOW");
        for (int x = 0; x < gameBoardWidth; x++)
        {
            for (int y = 0; y < gameBoardHeight; y++)
            {
                FOWGrid[x][y].GetComponent<FOWScript>().turnOnRenderer();
            }
        }

        for (int x = 0; x < PlayerList.Count; x++)
        {
            turnOffSuroundingTiles(FOWGrid, PlayerList[x]);
        }
    }

    public void turnOffSuroundingTiles(List<List<GameObject>> FOWGrid, XYCordSystem tile)
    {
        int tempX = tile.x;
        int tempY = tile.y;
        int tempSight = tile.sight;
        for (int x = 0; x < gameBoardWidth; x++)
        {
            for (int y = 0; y < gameBoardHeight; y++)
            {
                
                if (GridMovementSystem.GetComponent<GridMovementScript>().findDistanceBetween(tempX, tempY, x, y) <= tempSight)
                {
                    FOWGrid[x][y].GetComponent<FOWScript>().turnOffRenderer();                     
                }

            }
        }
    }
   
}

//Temperary class to test the Fog of War system.
public class XYCordSystem
{
    public int x, y, sight;
    public XYCordSystem(int x, int y, int sight)
    {
        this.x = x;
        this.y = y;
        this.sight = sight;
    }

}

