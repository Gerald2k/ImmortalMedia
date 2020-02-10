using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // If enemy then remove door collider to let thru
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(coll.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
