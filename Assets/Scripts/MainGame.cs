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

     private static ArrayList GenrateObsitcals(List<string> obsticle, int playerPosition, ArrayList loadedObstical)
    {
        int expectedObstical;
        int numObstacle = 2;
        int diffrence = playerPosition - numObstacle;
        System.Random select = new System.Random();
        if (diffrence == 0)
        {
            return loadedObstical;
        }
        else
        {
            for (int i = 0; i < diffrence; i++)
            {
                expectedObstical = select.Next(0, obsticle.Length - 1);
                loadedObstical.Add(obsticle[expectedObstical]);
                loadedObstical.RemoveAt(0);
            }
            return loadedObstical;
        }
    }

}
