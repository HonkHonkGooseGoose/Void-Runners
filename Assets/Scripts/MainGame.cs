using System;
using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;

public class MainGame : MonoBehaviour
{

    int maxLoadedObstacles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLoadedObstacles = 4;    
    }

    // Update is called once per frame
    void Update()
    {
        //static int obsticalSelect(Array Obstical)
        //{

        //}
        Console.WriteLine("Update");
        
    }

     private static ArrayList generateObstacles(List<string> obstacleList, int playerPosition, ArrayList<string> loadedObsticle)
    {
        int expectedObsticle;
        int expectedPlayerPosition = 2;
        int difference = playerPosition - expectedPlayerPosition;
        System.Random select = new System.Random();
        if (difference == 0)
        {
            return loadedObsticle;
        }
        else
        {
            for (int i = 0; i < difference; i++)
            {
                expectedObsticle = select.Next(0, obstacleList.Length - 1);
                loadedObsticle.Add(obstacleList[expectedObsticle]);
                loadedObsticle.RemoveAt(0);
            }
            return loadedObsticle;
        }
    }

}
