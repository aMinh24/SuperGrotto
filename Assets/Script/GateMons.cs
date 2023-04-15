using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMons : MonoBehaviour
{
    [SerializeField]
    private Transform point;
    [SerializeField]
    private GameObject Monster;
    [SerializeField]
    private bool flag = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")&& flag)
        {
            StartCoroutine(creatMons());
        }
    }
    private IEnumerator creatMons()
    {
        flag = false;
        Instantiate(Monster, point.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(Monster, point.position, Quaternion.identity);
    }
}
