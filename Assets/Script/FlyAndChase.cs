using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAndChase : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // tốc độ di chuyển của đối tượng
    [SerializeField]
    private float detectionRadius = 5f; // bán kính phát hiện nhân vật player
    public bool isChasing = false;
    private Transform player; // transform của nhân vật player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Tính khoảng cách giữa đối tượng và nhân vật player
        float distance = Vector3.Distance(transform.position, player.position);

        // Kiểm tra xem nhân vật player có ở trong bán kính phát hiện hay không
        if (distance <= detectionRadius)
        {
            // Di chuyển đối tượng đến vị trí của nhân vật player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            isChasing = true;
            
        }
        else isChasing= false;
    }
}
