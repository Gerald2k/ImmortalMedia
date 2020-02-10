using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    public float speed = 0.5f;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        myRigidbody2D.velocity += Vector2.right * speed;

        Destroy(gameObject, 3.0f);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            // Destroy self
            Destroy(gameObject);

            Destroy(coll.gameObject);

        }
        else if (coll.gameObject.tag == "Player")
        {
            // When the player shoots the other player

        }
        else if (coll.gameObject.tag == "Door" || coll.gameObject.tag == "Wall")
        {
            // When the player shoots the other player

        }
    }

    // up
}
