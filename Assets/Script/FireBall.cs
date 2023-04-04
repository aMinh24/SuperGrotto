using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;
    [SerializeField] private float stMovingSpeed = 7f;
    [SerializeField] private float movingSpeed;

    void Update()
    {
        if (Vector2.Distance(Waypoints[1].transform.position, transform.position) < 0.1f)
        {
            transform.position = Waypoints[0].transform.position;
        }
        movingSpeed = stMovingSpeed + Vector2.Distance(Waypoints[0].transform.position, Waypoints[1].transform.position) / Vector2.Distance(Waypoints[1].transform.position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[1].transform.position, (movingSpeed) * Time.deltaTime);

    }
}
