using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public string[] items = {"Boots","Helmet","Energy","Heart","Saphire"};
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var item in items)
        {
            if (collision.CompareTag(item))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
