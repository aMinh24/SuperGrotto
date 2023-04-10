using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFly : MonoBehaviour
{
    
    private Vector3 []Point = new Vector3[2];
    [SerializeField]
    private Rigidbody2D rb;
    private int currentPoint = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Point[0] = new Vector3(rb.position.x, rb.position.y);
        Point[1] = new Vector3(Point[0].x, Point[0].y+0.75f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Point[0]) < 0.1f)
        {
            currentPoint = 1;
        }
        if (Vector3.Distance(transform.position, Point[1]) < 0.1f)
        {

            currentPoint = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, Point[currentPoint], 0.75f*Time.deltaTime);
    }
}
