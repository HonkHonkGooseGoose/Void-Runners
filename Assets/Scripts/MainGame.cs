using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    System.Random rnd = new System.Random();
    int numLoadedObstacles;

    float floorLevel = -2f; // Y position of the floor
    public List<float> lengths = new List<float>();
    public List<string> loadedObstacles = new List<string>();

    List<string> obstacleList = new List<string>()
    {
        //"pranav1","pranav2","pranav3","pranav4",

        "ryan1","ryan2","ryan3","ryan4",
        "ryan4","ryan6","ryan7","ryan8",
        "ryan9","ryan10","ArthurObstacle-mars",
        "ArthurObstacle2-metal","ArthurObstacle3-moon",
        "ArthurObstacle4-ALL","ArthurObstacle6",

        //"ArthurObstacleSimple5","maria 2", "maria1", "maria3"
        //"pranav1", "pranav2", "pranav3", "pranav4" 

    };

    // Track where the next obstacle should begin (world-space X)
    float nextSpawnX = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numLoadedObstacles = 5;

        for (int j = 0; j < numLoadedObstacles; j++)
        {
            string newObstacle = PickRandomObstacle();
            AddObstacle(newObstacle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = transform.Find("Player").position.x; // Get the player's X position          
        int currentIdx = GetObjectIndex(playerX, lengths);

        // if the player is past the second segment
        if (currentIdx > 1)                               
        {
            RemoveObstacle(loadedObstacles[0]);
            string newObstacle = PickRandomObstacle();
            AddObstacle(newObstacle);
        }
    }

    string PickRandomObstacle()
    {
        string selectedObstacle;
        do
        {
            int i = rnd.Next(obstacleList.Count);
            selectedObstacle = obstacleList[i];
        } while (loadedObstacles.Contains(selectedObstacle));

        return selectedObstacle;
    }


    void AddObstacle(string obstacleName)
    {
        loadedObstacles.Add(obstacleName);

        SceneManager.LoadSceneAsync(obstacleName, LoadSceneMode.Additive).completed += (AsyncOperation op) =>
        {
            Scene sc = SceneManager.GetSceneByName(obstacleName);            

            // Find the obstacle container inside the loaded scene
            foreach (GameObject root in sc.GetRootGameObjects())
            {
                if (root.name != "ObstacleContainer") continue;

                // Locate start/end anchors
                Transform startTf = root.transform.Find("Start");
                Transform endTf = root.transform.Find("End");

                if (startTf == null || endTf == null)
                {
                    Debug.LogError($"Start/End anchors missing in '{obstacleName}'");
                    return;
                }

                float segLength = Vector2.Distance(startTf.position, endTf.position);

                // Shift entire obstacle so that its Start meets nextSpawnX
                float xOffset = nextSpawnX - startTf.position.x;
                float yOffset = floorLevel - startTf.position.y; // Get the difference in y axis from floor to keep it aligned
                root.transform.position += new Vector3(xOffset, yOffset, 0f);


                // Update bookkeeping
                lengths.Add(segLength);
                nextSpawnX += segLength;
                return;
            }

            Debug.LogError($"ObstacleContainer not found in scene '{obstacleName}'");
        };
    }

    
    void RemoveObstacle(string obstacleName)
    {
        SceneManager.UnloadSceneAsync(obstacleName);

        loadedObstacles.RemoveAt(0);
        float removedLen = lengths[0];
        lengths.RemoveAt(0);
        nextSpawnX -= removedLen;
    }

    
    static int GetObjectIndex(float playerPosition, List<float> lengths)
    {
        int index = 0;
        float remainingDistance = playerPosition;

        while (index < lengths.Count)
        {
            remainingDistance -= lengths[index];
            if (remainingDistance < 0f)
                return index;
            index++;
        }
        return index;
    }
}