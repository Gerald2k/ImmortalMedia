using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Create physics variable
    Rigidbody2D myRigidBody2D;
    //changeable speed from unity
    public float speed = 2.0f;
    public float escapeSpeed = 4.0f;
    public int health = 30;
    bool enemyDied = true;

    void Start()
    {
        // get physics of enemy
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            health -= 10; 
            if (health < 1)
            {
                enemyDied = true;
                myRigidBody2D.velocity += Vector2.right * escapeSpeed;
                Destroy(gameObject);
            }
        }
        else if (coll.gameObject.tag == "Enemy")
        {
            // If two enemies collide
        }
    }
}
