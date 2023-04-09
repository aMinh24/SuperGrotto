using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypointsRight : MonoBehaviour
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
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField] LayerMask jumpableGround;
    void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        boxCollider= GetComponent<BoxCollider2D>();
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
            if (IsGround())
            transform.position = Vector2.MoveTowards(transform.position, player.position, movingSpeed * Time.deltaTime);
            if (transform.position.x < player.position.x) spriteRenderer.flipX = false;
            if (transform.position.x > player.position.x) spriteRenderer.flipX = true;
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
            if (transform.position.x < waypoints[currentWaypoint].transform.position.x) spriteRenderer.flipX = false;
            if (transform.position.x >= waypoints[currentWaypoint].transform.position.x) spriteRenderer.flipX = true;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, movingSpeed * Time.deltaTime);
        }

    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
