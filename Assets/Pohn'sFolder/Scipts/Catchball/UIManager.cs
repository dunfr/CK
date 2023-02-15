using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject catchText;
    public GameObject aouchText;
    public GameObject goodText;
    public GameObject perfectText;
    public Text scoreText;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        catchText = GameObject.Find("Catch");
        aouchText = GameObject.Find("Ouch");
        goodText = GameObject.Find("Good");
        perfectText = GameObject.Find("Perfect");
        GameObject scoreGameobject = GameObject.Find("Score");
        scoreText = scoreGameobject.GetComponent<Text>();
        catchText.SetActive(false);
        aouchText.SetActive(false);
        goodText.SetActive(false);
        perfectText.SetActive(false);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
    public void Catch()
    {
        StartCoroutine("CatchTextSpwan");
        Ball.Instance.perfectBar.SetActive(true);
    }
    public void Aouch()
    {
        StartCoroutine("AouchTextSpwan");
        Ball.Instance.perfectBar.SetActive(true);
        Catchball.Instance.hp -= 2;
        Catchball.Instance.ChangeImage();

    }
    public void Good()
    {
        StartCoroutine("GoodSpwan");
        Ball.Instance.perfectBar.SetActive(true);
        score++;
        Catchball.Instance.ChangeImage();

    }
    public void Perfect()
    {
        StartCoroutine("PerfectSpwan");
        Ball.Instance.perfectBar.SetActive(true);
        score++;
        Catchball.Instance.ChangeImage();

    }
    private IEnumerator CatchTextSpwan()
    {
        catchText.SetActive(true);
        yield return new WaitForSeconds(.5f);
        catchText.SetActive(false);
        StopCoroutine("CatchTextSpwan");
    }
    private IEnumerator AouchTextSpwan()
    {
        aouchText.SetActive(true);
        yield return new WaitForSeconds(.5f);
        aouchText.SetActive(false);
        StopCoroutine("AouchTextSpwan");
    }
    private IEnumerator GoodSpwan()
    {
        goodText.SetActive(true);
        yield return new WaitForSeconds(.5f);
        goodText.SetActive(false);
        StopCoroutine("GoodSpwan");
    }
    private IEnumerator PerfectSpwan()
    {
        perfectText.SetActive(true);
        yield return new WaitForSeconds(.5f);
        perfectText.SetActive(false);
        StopCoroutine("PerfectSpwan");
    }
}
