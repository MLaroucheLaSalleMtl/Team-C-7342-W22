using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/
    public SpriteRenderer head;
    public SpriteRenderer body;

    //List of all the sprites for both the body and the head
    public List<Sprite> headSprites;
    public List<Sprite> bodySprites;

    PlayerHealthManager health;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<PlayerHealthManager>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void HealthSpriteChange(float health)
    {
        if(health <= 100 && health > 75)
        {
            head.sprite = body.sprite = headSprites[4];
        }
        else
        if (health <= 75 && health > 50)
        {
            head.sprite = body.sprite = headSprites[3];
        }
        else
        if (health <= 50 && health > 25)
        {
            head.sprite = body.sprite = headSprites[2];
        }
        else
        if (health <= 25 && health > 0)
        {
            head.sprite = body.sprite = headSprites[1];
        }
        else
        if (health == 0)
        {
            head.sprite = body.sprite = headSprites[0];
        }
    }

    void FlipSprite()
    {
        if (rigid.velocity.x > 0.1)
        {
            head.flipX = false;
            body.flipX = false;
        }
        else
        if (rigid.velocity.x < -0.1)
        {
            head.flipX = true;
            body.flipX = true;
        }

    }

    void FixedUpdate()
    {
        HealthSpriteChange(health.playerHealth);
        FlipSprite();
    }
}
