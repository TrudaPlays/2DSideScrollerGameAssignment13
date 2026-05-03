using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] private Transform enemyStartPoint;
    [SerializeField] private Transform enemyEndPoint;
    [SerializeField] private float speed = 2f;
    private Vector3 enemyTargetPos;

    void Start()
    {
        enemyTargetPos = enemyEndPoint.position;
    }

    private void FixedUpdate() // FixedUpdate is better for physics objects
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyTargetPos, speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, enemyTargetPos) < 0.1f)
        {
           // enemyTargetPos = enemyTargetPos == enemyStartPoint.position ? enemyEndPoint.position : enemyStartPoint.position;
           if (enemyTargetPos == enemyStartPoint.position)
            {
                enemyTargetPos = enemyEndPoint.position;
            }else
            {
                enemyTargetPos = enemyStartPoint.position;
            }
        }
    }
}
