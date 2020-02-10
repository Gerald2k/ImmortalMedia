using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bullet;
    GameManager myGameManager;
    public GameObject parent;
    Vector2 whereToSpawn;
    public int timeToWait = 1;
    int amountSpawned = 0;
    bool waiting = false;
    float bulletX;
    float bulletY;

    IEnumerator Timer(int timeForTimer)
    {
        int timeLeft;
        timeLeft = timeForTimer;
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(0.3f);
            timeLeft--;
        }
        waiting = false;
    }


    void Start()
    {
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting == false)
        {
            waiting = true;
            bulletX = parent.transform.position.x + parent.transform.localScale.x / 5;
            bulletY = parent.transform.position.y + parent.transform.localScale.y / 6;
            whereToSpawn = new Vector2(bulletX, bulletY);

            // Actually spawn bullet
            Instantiate(bullet, whereToSpawn, Quaternion.identity, parent.transform);

            //Increase amount spawned
            amountSpawned++;

            // Start timer 
            StartCoroutine(Timer(timeToWait));
        }
    }
}
