using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*cute fact: this script cancels out the moving AI of the EnemyChaseScript, so I can have both of them on the
 patrolling bunnies but the bug jumps while the bunny only patrols but still does damage to the player. It works!*/
public class enemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;

    }

    // Update is called once per frame
    void Update()
    {
        // 1. Calculate Velocity (Keeping gravity)
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        // 2. Check for Switch
        float distance = Vector2.Distance(transform.position, currentPoint.position);

        if (distance < 1.0f)
        {
            if (currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
            else // Use 'else' so it doesn't immediately flip back to Point B
            {
                currentPoint = pointB.transform;
            }
        }
    }
}
