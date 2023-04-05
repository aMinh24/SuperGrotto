using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waypoints;
    [SerializeField]
    //private Rigidbody2D rigidbody;
    private int currentWaypoint = 0;
    [SerializeField]
    private float movingSpeed = 5f;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float detectionRadius = 10f; // bán kính phát hiện nhân vật player
    private Transform player;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Kiểm tra xem nhân vật player có ở trong bán kính phát hiện hay không
        if (distance <= detectionRadius)
        {
            // Di chuyển đối tượng đến vị trí của nhân vật player
            transform.position = Vector3.MoveTowards(transform.position, player.position, movingSpeed * Time.deltaTime);
            if (transform.position.x < player.position.x) spriteRenderer.flipX = true;
            if (transform.position.x > player.position.x) spriteRenderer.flipX = false;
        }
        else
        {
            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 0.1f)
            {
                currentWaypoint++;
            }
            if (currentWaypoint >= waypoints.Count)
            {
                currentWaypoint = 0;
            }
            if (transform.position.x < waypoints[currentWaypoint].transform.position.x) spriteRenderer.flipX = true;
            if (transform.position.x >= waypoints[currentWaypoint].transform.position.x) spriteRenderer.flipX = false;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, movingSpeed * Time.deltaTime);
        }
    }
}
