using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject Boom;
    public CinemachineCollisionImpulseSource cinemachineImpulseSource;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (PlayerMovement.side)
        {
            spriteRenderer.flipX = true;
            rb.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
        }
        else
        {
            spriteRenderer.flipX = false;
            rb.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Map"))
        {
            Destroy(gameObject);
            GameObject BoomSkill;
            Boom = Resources.Load("SKILLHIT/" + DataManager.Instance.PlayerData.skillName) as GameObject;
            BoomSkill = Instantiate(Boom, transform.position, Quaternion.identity);
            cinemachineImpulseSource.enabled = true;
            cinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(Audio.SE_SKILLHIT);
            }
            Destroy(BoomSkill,0.7f);
        }
    }
}
