using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Create physics variable
    Rigidbody2D myRigidBody2D;
    PlayerScript playerScript;
    //changeable speed from unity
    public float speed = 2.0f;
    public float escapeSpeed = 4.0f;
    public int health = 30;
    public int enemyRetreatTime = 1;
    

    IEnumerator enemyRetreat(int timeForTimer)
    {
        int timeLeft;
        timeLeft = timeForTimer;
        while (timeLeft > 0)
        {
            myRigidBody2D.velocity += Vector2.right * escapeSpeed;
            yield return new WaitForSeconds(timeLeft);
            timeLeft--;
        }
    }
    void Start()
    {
        // get physics of enemy
        myRigidBody2D = GetComponent<Rigidbody2D>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make enemies 'run' left
        myRigidBody2D.velocity += Vector2.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            // When the enemy collides with the player remove enemy health
            playerScript.p1Health -= 10;
        }
        else if (coll.gameObject.tag == "Enemy")
        {
            // If two enemies collide
        }
        else if(coll.gameObject.tag == "Projectile")
        {
            //Reduce health
            health -= 10;

            //Enemy Retreat
            StartCoroutine(enemyRetreat(enemyRetreatTime));
             // POSSIBLE RETREAT?
            if (health < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
