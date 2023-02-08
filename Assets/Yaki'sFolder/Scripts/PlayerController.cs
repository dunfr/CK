using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject stage1;
    public GameObject stage2;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    int playerLayer, groundLayer;
    bool hasJumped;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !hasJumped)
        {
            hasJumped = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

       //Stop Speed
       if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

       //Ignore Layer collision
        if (rigid.velocity.y > 0)
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        else
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);

    }

    void FixedUpdate()
    {
        //Move By Controller
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed*(-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Move to Next Stage
        if (collision.CompareTag("Finish"))
        {
            if (stage1.activeSelf)
            {
                stage1.SetActive(false);
                stage2.SetActive(true);
            }
            else
            {
                Debug.Log("Game Clear!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            hasJumped = false;
        }
    }
}
