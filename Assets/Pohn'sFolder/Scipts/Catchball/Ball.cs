using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Grandfa ;
    public GameObject Grandma ;
    public float ballSpeed;
    private float GrandfaX;
    private float GrandmaX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    private float timer;
    private float waitingTime;
    private bool isgrandfaThrowing;
    private bool isgrandmaThrowing;

    // Start is called before the first frame update
    void Start()
    {
        Grandfa = GameObject.Find("Granfater");
        Grandma = GameObject.Find("Grandmother");
        timer = 0.0f;
        waitingTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        GrandfaX = Grandfa.transform.position.x;
        GrandmaX = Grandma.transform.position.x;

        if (transform.position == Grandma.transform.position)
        {
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                isgrandfaThrowing = true;
                isgrandmaThrowing = false;
                timer = 0.0f;
            }
        }
        if (transform.position == Grandfa.transform.position)
        {
            timer = 0.0f;
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                isgrandmaThrowing = true;
                isgrandfaThrowing = false;
                timer = 0.0f;
            }
        }
        if (isgrandfaThrowing)
        {
            GrandmaThrow();
        }
        if (isgrandmaThrowing)
        {
            GrandfaThrow();
        }
    }
    public static Quaternion quaternion(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
    private void GrandfaThrow()
    {
        dist = GrandmaX - GrandfaX;
        nextX = Mathf.MoveTowards(transform.position.x, GrandmaX, ballSpeed * Time.deltaTime);
        baseY = Mathf.Lerp(Grandfa.transform.position.y, Grandma.transform.position.y, (nextX - GrandfaX) / dist);
        height = 2 * (nextX - GrandfaX) * (nextX - GrandmaX) / (-0.25f * dist * dist);
        Vector3 movePostion = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = quaternion(movePostion - transform.position);
        transform.position = movePostion;
    }
    private void GrandmaThrow()
    {
        dist = GrandfaX - GrandmaX;
        nextX = Mathf.MoveTowards(transform.position.x, GrandfaX, ballSpeed * Time.deltaTime);
        baseY = Mathf.Lerp(Grandma.transform.position.y, Grandfa.transform.position.y, (nextX - GrandmaX) / dist);
        height = 2 * (nextX - GrandfaX) * (nextX - GrandmaX) / (-0.25f * dist * dist);
        Vector3 movePostion = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = quaternion(movePostion - transform.position);
        transform.position = movePostion;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Glove")
        {
            UIManager.Instance.Catch();
        }
    }
}
