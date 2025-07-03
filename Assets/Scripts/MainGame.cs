using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainGame : MonoBehaviour
{
    System.Random rnd = new System.Random();
    int maxLoadedObstacles;
    public List<float>  lengths         = new List<float>();
    public List<string> loadedObstacles = new List<string>();

    public List<string> obstacleList = new List<string>()
    {
        "pranav1","pranav2","pranav3","pranav4",
        "ryan1","ryan2","ryan3","ryan4",
        "maria1","maria2","maria3"
    };

    // Track where the next obstacle should begin (world-space X)
    float nextSpawnX = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //maxLoadedObstacles = 4;
        //string newObstacle = PickRandomObstacle();
        //AddObstacle(newObstacle);
        //float length = transform.Find(newObstacle).GetComponent<Obstacle>().length;
        //nextSpawnX -= length;


        for (int j = 0; j < maxLoadedObstacles; j++)
        {
            string newObstacle = PickRandomObstacle();
            AddObstacle(newObstacle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = transform.position.x;              // script is on the player
        int currentIdx = GetObjectIndex(playerX, lengths);

        if (currentIdx > 0)                                // player left first segment
        {
            RemoveObstacle(loadedObstacles[0]);
            string newObstacle = PickRandomObstacle();
            AddObstacle(newObstacle);
        }
    }

    string PickRandomObstacle()
    {
        string selected;
        do
        {
            selected = obstacleList[rnd.Next(obstacleList.Count)];
        } while (loadedObstacles.Contains(selected));

        return selected;
    }


    void AddObstacle(string obstacleName)
    {
        loadedObstacles.Add(obstacleName);

        SceneManager.LoadSceneAsync(obstacleName, LoadSceneMode.Additive)
                    .completed += (AsyncOperation op) =>
        {
            Scene sc = SceneManager.GetSceneByName(obstacleName);

            // Find the obstacle container inside the loaded scene
            foreach (GameObject root in sc.GetRootGameObjects())
            {
                if (root.name != "ObstacleContainer") continue;

                // Locate start/end anchors
                Transform startTf = root.transform.Find("Start");
                Transform endTf   = root.transform.Find("End");

                if (startTf == null || endTf == null)
                {
                    Debug.LogError($"Start/End anchors missing in '{obstacleName}'");
                    return;
                }

                float segLength = Vector2.Distance(startTf.position, endTf.position);

                // Shift entire obstacle so that its Start meets nextSpawnX
                float offset = nextSpawnX - startTf.position.x;
                root.transform.position += new Vector3(offset, 0f, 0f);

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

        nextSpawnX -= removedLen;                           // track shrinks by that length
    }

    
    static int GetObjectIndex(float playerPosX, List<float> segLengths)
    {
        int idx = 0;
        float remaining = playerPosX;

        while (idx < segLengths.Count)
        {
            remaining -= segLengths[idx];
            if (remaining < 0f) return idx;
            idx++;
        }
        return idx;
    }
}