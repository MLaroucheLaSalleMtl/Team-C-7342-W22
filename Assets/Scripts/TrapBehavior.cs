using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{

    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    [SerializeField] float playerTimerStart = 2.0f; //How long until the player takes damage next in seconds
    float playerCooldownTimer = 0.0f;

    [SerializeField] float trapDamage = 20.0f;

    bool playerIsDamaged = false;

    void DamageTimer()
    {
        playerCooldownTimer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && playerCooldownTimer >= 2.0f)
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(trapDamage);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5, ForceMode2D.Impulse); //Sends player upward when they are damaged
            playerCooldownTimer = playerTimerStart;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DamageTimer();
    }
}
