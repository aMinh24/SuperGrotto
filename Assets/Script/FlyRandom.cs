using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRandom : MonoBehaviour
{
    [SerializeField]
    private GameObject waypoint;
    [SerializeField]
    private float movingSpeed = 5f;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float radius = 6;
    private Vector2 targetPosition;

    [SerializeField]
    private float detectionRadius = 10f; // bán kính phát hiện nhân vật player
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        targetPosition = randomVect();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // Kiểm tra xem nhân vật player có ở trong bán kính phát hiện hay không
        if (distance <= detectionRadius)
        {
            // Di chuyển đối tượng đến vị trí của nhân vật player
            transform.position = Vector2.MoveTowards(transform.position, player.position, movingSpeed * Time.deltaTime);
            if (transform.position.x < player.position.x) spriteRenderer.flipX = true;
            if ( transform.position.x > player.position.x) spriteRenderer.flipX = false;

        }
        else
        {
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = randomVect();
            }
            if (transform.position.x < targetPosition.x ) spriteRenderer.flipX = true;
            if (transform.position.x >= targetPosition.x) spriteRenderer.flipX = false;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movingSpeed * Time.deltaTime);
        }
        
    }
    private Vector2 randomVect()
    {
        Vector2 rv = new Vector2();
        rv = Random.insideUnitSphere*radius;
        rv += (Vector2)waypoint.transform.position;        
        return rv;
    }
}
