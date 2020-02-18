using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    GameManager myGameManager;
    // Game objects - prefabs and parent of player set in unity
    //public GameObject enemy;
    public GameObject enemyType1;
    public GameObject enemyType2;
    public GameObject enemyType3;
    public GameObject parent;

    // Default variable values and variable types
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate;
    int amountSpawned = 0;
    public int timeToWait = 2;
    bool waiting = false;
    List<GameObject> prefabList = new List<GameObject>();

    // Timer to deal with time between individual enemy spawns
    IEnumerator Timer(int timeToWait)
    {
        //int timeLeft;
        //timeLeft = timeForTimer;
        while (timeToWait > 0)
        {
            yield return new WaitForSeconds(timeToWait);
            timeToWait--;
        }
        waiting = false;
        timeToWait = 2;
    }

    // Runs once at start
    private void Start()
    {
        // Find game manager and add prefabs to list
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        prefabList.Add(enemyType1);
        prefabList.Add(enemyType2);
        prefabList.Add(enemyType3); 
    }
    private void Update()
    {
        // Start round is checked then game runs
        if(myGameManager.startRound == true)
        {
            if(amountSpawned < 10)
            {
                if(waiting == false)
                {
                    // Enemy is random prefab
                    int prefabIndex = UnityEngine.Random.Range(0, 3);

                    // Start wait for next spawn - possibly irrelevant
                    waiting = true;

                    // Set random location of enemy spawn
                    randX = UnityEngine.Random.Range(8, 15);
                    randY = UnityEngine.Random.Range(1, -2);
                    whereToSpawn = new Vector2(randX, randY);

                    // Actually spawn enemy
                    Instantiate(prefabList[prefabIndex], whereToSpawn, Quaternion.identity, parent.transform);

                    //Increase amount spawned
                    amountSpawned++;

                    // Start timer
                    StartCoroutine(Timer(timeToWait));
                } 
            }
            else
            {
                // Stop the round spawning
                myGameManager.startRound = false;

                // Reset the amount so its 0 for next wave
                amountSpawned = 0;
            }
        } 
    }
}

// bomb tag code
/*if (Time.time > nextSpawn && amountSpawned < 10)
    {
        // Next enemy spawn time
        nextSpawn = Time.time + spawnRate;
        // Spawn location
        randX = UnityEngine.Random.Range(12, 19);
        randY = UnityEngine.Random.Range(1, -2);
        whereToSpawn = new Vector2(randX, randY);

        // Spawn enemy at location and increment amount of enemies
        Instantiate(enemy, whereToSpawn, Quaternion.identity, parent.transform);
        amountSpawned++;
    }
    else
    {
        myGameManager.startRound = false;
    }*/

/*GameObject enemy = new GameObject();
public List<GameObject> enemies = new List<GameObject>();
private static int round = 1;

// Start is called before the first frame update
void Start()
{

}

void Update()
{

}

public void Spawn()
{
    GameObject g = GameObject.Find("enemy");
    enemies.AddComponent(Type int);
    enemy.AddComponent(health));
    enemies.Add(new Enemy(50, 2, 10, 0));
    enemies.Add(new Enemy(50, 2, 10, 0));
    enemies.Add(new Enemy(50, 2, 10, 0));
    enemies.Add(new Enemy(50, 2, 10, 0));
    enemies.Add(new Enemy(20, 1, 10, 0));
    enemies.Add(new Enemy(20, 1, 10, 0));
    enemies.Add(new Enemy(20, 1, 10, 0));
    enemies.Add(new Enemy(20, 1, 10, 0));
    foreach (GameObject aenemy in enemies)
        if (round == 1)
        {
            transform.localPosition = new Vector3(UnityEngine.Random.Range(12, 19), UnityEngine.Random.Range(-2, 1), 0);
            Instantiate(enemy, transform.localPosition, Quaternion.identity);
        }
        else if (round == 2)
        {
            enemies.Add(new Enemy(150, 4));
            enemies.Add(new Enemy(150, 4));
        }
}*/
/*public class Enemy 
{
public Enemy (int health, int type, int xPosition, int yPosition)
{
    Health = health;
    Type = type;
    XPosition = xPosition;
    YPosition = yPosition;
}

public int Health { get; set; }
public int Type { get; set; }
public int XPosition { get; set; }
public int YPosition { get; set; }

}*/

