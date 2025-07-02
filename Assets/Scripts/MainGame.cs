using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;
using NUnit.Framework;

public class MainGame : MonoBehaviour
{
    
    int maxLoadedObstacles;


    public List<string> obstacleList = new List<string>()
    {
      "pranav1",
      "pranav2",
      "pranav3",
      "pranav4",

    };

    public List<int> lengths;

    public List<string> loadedObstacles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLoadedObstacles = 4;

        // fill the loaded obstacles with the first 4 obstacles by using PickRandomScene and then adding them

    }

    // Update is called once per frame
    void Update()
    {
        // static int obsticalSelect(Array Obstical)
        // {

        // }
        Console.WriteLine("Update");

    }

    private static List<string> generateObstacles(List<string> obstacleList, int playerPosition, List<string> loadedObstacle)
    {
        int expectedObsticle;
        int expectedPlayerPosition = 2;
        int difference = playerPosition - expectedPlayerPosition;
        System.Random select = new System.Random();
        if (difference == 0)
        {
            return loadedObstacle;
        }
        else
        {
            for (int i = 0; i < difference; i++)
            {
                expectedObsticle = select.Next(0, obstacleList.Count - 1);
                loadedObstacle.Add(obstacleList[expectedObsticle]);
                loadedObstacle.RemoveAt(0);
            }
            return loadedObstacle;
        }
    }

    private List<int> PickRandomScene()
    {

        // Pick a random scene from the obstacleList and add it to the loadedObstacles list if it is not in loadedObstacles already
        
    }

    private void AddObstacle(string obstacleName)
    {
        // Add the obstacle to the loadedObstacles list

        // Add the obstacle to the scene

        // get the length of the obstacle and add it to the lengths list


    }


    private void RemoveObstacle(string obstacleName)
    {
        // Remove the obstacle from the loadedObstacles list

        // Remove the obstacle from the scene

        // remove the length of the obstacle from the lengths list
    }


    private static int getObjectIndex(int playerPosition, List<int> lengths)
    {
        int index = 0;
        int remaningDistance = playerPosition;
        while (index < lengths.Count)
        {
            remaningDistance -= lengths[index];
            if (remaningDistance < 0)
                return index;
            index++;
        }
        return index;
    }
}
