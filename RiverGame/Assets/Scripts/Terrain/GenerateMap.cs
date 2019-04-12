using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private GameObject[] rivers;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private GameObject endOfLevel;
    [SerializeField] private int amount;

    private int xOffset;
    private const int zOffset = 200;

    void Start()
    {
        //Create rivers
        for (int i = 0; i < amount; i++)
        {
            int pickRiver = Random.Range(0, 1);//rivers.Length);
            Instantiate(rivers[pickRiver],
                        new Vector3(xOffset,
                                    -1.5f,
                                    i * zOffset),
                        transform.rotation,
                        transform);

            if (pickRiver == 1) //Right bend river
            {
                xOffset += 50;
            }
            else if (pickRiver == 2) //Left bend river
            {
                xOffset -= 50;
            }


            //Enemy Spawner
            int placeSpawn = pickRiver > 0 ? 50 : Random.Range(-50, 50);
            Instantiate(enemySpawn,
                        new Vector3(xOffset,
                                    -1.5f,
                                    i * zOffset + placeSpawn),
                        transform.rotation,
                        transform);

            //Obstacle Spawner
            int obstacleAmount = Random.Range(5, 20);
            for (int j = 0; j < obstacleAmount; j++)
            {
                int zLen = i != 0 ? Random.Range(-100, 100) : Random.Range(-25, 100);
                int obstacle = Random.Range(0, 2);
                Instantiate(obstacles[obstacle],
                            new Vector3(xOffset + Random.Range(-30, 30),
                                        -1f,
                                        i * zOffset + zLen),
                            obstacles[obstacle].transform.rotation,
                            transform);
            }
        }
        //Finish Game
        Instantiate(endOfLevel,
                    new Vector3(xOffset,
                                -1f,
                                (amount - 1f) * zOffset - 25f),
                    transform.rotation,
                    transform);
    }
}
