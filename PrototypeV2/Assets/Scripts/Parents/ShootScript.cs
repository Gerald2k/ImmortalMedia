using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bullet;
    GameManager myGameManager;

    public GameObject parent;
    Vector2 whereToSpawn;
    float bulletInterval = 0.5f;
    bool waiting = false;
    float bulletX;
    float bulletY;

    void Start()
    {
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    IEnumerator BulletTimer()
    {
        // How many bullets to spawn over 1 second
        int timeLeft = 1;
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(bulletInterval);
            timeLeft--;
        }
        waiting = false;
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

            // Start timer - The 'timeToWait' variable makes no difference dont ask me why 
            StartCoroutine(BulletTimer());
        }
    }
}
