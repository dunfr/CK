using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfactBar : MonoBehaviour
{

    private bool isBar;
    public float currentPosition;
    public float speed;
    public float start;
    public float end;
    public Transform perfectBar;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.x;
        isBar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBar)
        {
            currentPosition += Time.deltaTime * speed;
            if (currentPosition <= start)
            {
                speed = 8;
            }
            else if (currentPosition >= end)
            {
                speed = -8;
            }
            transform.position = new Vector3(currentPosition, -3.825f, 0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isBar = false;
                Invoke("CountCheck", .1f);
            }
        }
    }
    void CountCheck()
    {
        if (count == 1)
        {
            UIManager.Instance.Aouch();
            isBar = true;
        }
        else if (count == 2)
        {
            UIManager.Instance.Aouch();
            isBar = true;
        }
        else if (count == 3)
        {
            Good();
        }
        else if (count == 4)
        {
            Perfect();
        }     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bad")
        {
            count = 1;
        }
        else if (collision.gameObject.tag == "common")
        {
            count = 2;
        }
        else if (collision.gameObject.tag == "good")
        {
            count = 3;
        }
        else if (collision.gameObject.tag == "perfect")
        {
            count = 4;
        }
    }
   
    private void Good()
    {
        UIManager.Instance.Good();
        Ball.Instance.perfectBar.SetActive(false);
        Ball.Instance.isgrandfaThrowing = true;
        Ball.Instance.isgrandmaThrowing = false;
        isBar = true;
    }
    private void Perfect()
    {
        UIManager.Instance.Perfect();
        perfectBar.localScale = new Vector3(perfectBar.localScale.x / 2, .5f, 1);
        Ball.Instance.perfectBar.SetActive(false);
        Ball.Instance.isgrandfaThrowing = true;
        Ball.Instance.isgrandmaThrowing = false;
        isBar = true;
    }
}
