using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject wayPoint1;
    public GameObject wayPoint2;
    public float speed = 50;
    bool wayPointRight;
    // Start is called before the first frame update
    void Start()
    {
        wayPointRight = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (wayPointRight)
            {
                Debug.Log("wayPointRihgt ; " + wayPointRight);
                transform.position = Vector2.MoveTowards(transform.position, wayPoint1.transform.position, speed * Time.deltaTime);
            }
            else
            {
                Debug.Log("wayPointRihgt ; " + wayPointRight);
                transform.position = Vector2.MoveTowards(transform.position, wayPoint2.transform.position, speed * Time.deltaTime);
            }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wayPoint"))
        {
            if (wayPointRight)
            {
                wayPointRight = false;
                Flip();
            }
            else
            {
                wayPointRight = true;
                Flip();
            }
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.

        // Multiply the player's x local scale by -1.
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
