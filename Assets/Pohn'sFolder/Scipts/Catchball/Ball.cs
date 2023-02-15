using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Singleton<Ball>
{
    public GameObject Grandfa;
    public GameObject Grandma;
    public GameObject perfectBar;
    public float ballSpeed;
    private float GrandfaX;
    private float GrandmaX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    private float timer;
    private float waitingTime;
    public bool isgrandfaThrowing;
    public bool isgrandmaThrowing;
    public bool isCatch;
    public bool isOuch;

    // Start is called before the first frame update
    void Start()
    {
        Grandfa = GameObject.Find("GfGlove");
        Grandma = GameObject.Find("GmGlove");
        perfectBar = GameObject.Find("PerfactBar");
        timer = 0.0f;
        waitingTime = .5f;
        isgrandfaThrowing = false;
        isgrandmaThrowing = false;
        perfectBar.SetActive(false);
        isOuch = false;

    }

    // Update is called once per frame
    void Update()
    {
        GrandfaX = Grandfa.transform.position.x;
        GrandmaX = Grandma.transform.position.x;

        if (transform.position == Grandma.transform.position)
        {
            if (!isCatch && !isOuch)
            {
                UIManager.Instance.Aouch();
                isOuch = true;
            }
            if (isgrandfaThrowing)
            {
                timer = 0.0f;
            }
        }
        if (transform.position == Grandfa.transform.position)
        {
            isCatch = false;
            isOuch = false;
            if (!isgrandmaThrowing)
            {
                timer += Time.deltaTime;
            }
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                isgrandmaThrowing = true;
                isgrandfaThrowing = false;
            }
            if (isgrandmaThrowing)
            {
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
        if (collision.tag == "Glove" && isgrandmaThrowing == true && !isCatch)
        {
            UIManager.Instance.Catch();
            isCatch = true;
        }
    }
}
