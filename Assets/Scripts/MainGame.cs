using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;
using NUnit.Framework;

public class MainGame : MonoBehaviour
{
    System.Random rnd = new System.Random();
    int maxLoadedObstacles;


    public List<string> obstacleList = new List<string>()
    {
      "pranav1",
      "pranav2",
      "pranav3",
      "pranav4",
      "ryan1",
      "ryan2",
      "ryan3",
      "ryan4",
      "maria1",
      "maria2",
      "maria3",

    };

    public List<int> lengths;

    public List<string> loadedObstacles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLoadedObstacles = 4;

        // fill the loaded obstacles with the first 4 obstacles by using PickRandomScene and then adding them
        for (int j = 0; j < maxLoadedObstacles; j++)
        {
            loadedObstacles.Add(PickRandomObstacle());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // static int obsticalSelect(Array Obstical)
        // {

        // }
        Console.WriteLine("Update");

    }

    private void GenerateObstacles(int playerPosition)
    {
        int expectedObsticle;
        int expectedPlayerPosition = 2;
        int difference = playerPosition - expectedPlayerPosition;
        System.Random select = new System.Random();
        if (difference == 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < difference; i++)
            {
                string newObstacle = PickRandomObstacle();
                AddObstacle(newObstacle);
                RemoveObstacle(loadedObstacles[0]);
            }
            
        }
    }

    private string PickRandomObstacle()
    {

        string selectedObstacle = "";
        do
        {
            int i = rnd.Next(0, obstacleList.Count);
            selectedObstacle = obstacleList[i];

        } while (loadedObstacles.Contains(selectedObstacle));
        // Pick a random scene from the obstacleList and return the name of the obstacle if it is not in loadedObstacles already

        // while a object hasnt been picked

        // pick a random string from obstacleList

        // check if it isn't in loadedObstacles


        return selectedObstacle;
    }

    private void AddObstacle(string obstacleName)
    {
        // Add the obstacle to the loadedObstacles list

        // Add the obstacle to the scene

        // get the length of the obstacle and add it to the lengths list
        loadedObstacles.Add(PickRandomObstacle());


    }


    private void RemoveObstacle(string obstacleName)
    {
        // Remove the obstacle from the loadedObstacles list

        // Remove the obstacle from the scene

        // remove the length of the obstacle from the lengths list
        loadedObstacles.RemoveAt(0);

    }


    private static int GetObjectIndex(int playerPosition, List<int> lengths)
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
