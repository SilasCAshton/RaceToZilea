using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridMovementScript : MonoBehaviour
{
    public void moveUpRight(ref int x, ref int y)
    {
        x++;
        y += (x % 2);
    }
    public void moveUpLeft(ref int x, ref int y)
    {
        x--;
        y += (x % 2);
    }
    public void moveRight(ref int x, ref int y)
    {
        x += 2;
    }
    public void moveLeft(ref int x, ref int y)
    {
        x -= 2;
    }
    public void moveDownRight(ref int x, ref int y)
    {
        x++;
        y += (x % 2) - 1;
    }
    public void moveDownLeft(ref int x, ref int y)
    {
        x--;
        y += (x % 2) - 1;
    }

    public int findDistanceBetween(int startingX, int startingY, int targetX, int targetY)
    {
        int changeInX = Math.Abs(startingX - targetX), changeInY = Math.Abs(startingY - targetY);
        if (startingY == targetY && startingX == targetX)
        {
            return 0;
        }
        else if (startingY == targetY)
        {
            return (changeInX + (changeInX % 2)) / 2;
        }
        else if (startingX == targetX)
        {
            return changeInY * 2;
        }
        else
        {
            int lowerX, higherX;
            if (startingY < targetY)
            {
                lowerX = startingX;
                higherX = targetX;
            }
            else
            {
                lowerX = targetX;
                higherX = startingX;
            }
            int height = (2 * changeInY) + ((higherX % 2) - (lowerX % 2));
            if (height >= changeInX)
            {
                return height;
            }
            else
                return height + (changeInX - height + (changeInX % 2)) / 2;
        }
    }
}
    

