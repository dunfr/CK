using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Grandfa : MonoBehaviour
{
    public float speed;
    Vector3 moveVec;
    public Animator anime;
    public Rigidbody2D rigid;
    private float hAxis;
    private float vAxis;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;
        anime.SetBool("isWalk", moveVec != Vector3.zero);
        if (hAxis != 0.0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * hAxis, 1.0f, 1.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
