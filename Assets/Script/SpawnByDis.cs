using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByDis : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0f;
    public float limitDis = 100f;
    public float respawnDis = 160f;
    private void FixedUpdate()
    {
        this.GetDistance();
        this.Spawning();
    }
    protected void Spawning()
    {
        if (this.currentDis < this.limitDis) return;
        Vector3 pos = transform.position;
        pos.x += this.respawnDis;
        transform.position = pos;
    }   
    protected virtual void GetDistance()
    {
        this.currentDis = this.player.position.x - transform.position.x;
    }
}
