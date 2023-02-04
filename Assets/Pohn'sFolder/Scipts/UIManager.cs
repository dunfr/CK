using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject catchText;
    public Text scoreText;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        catchText = GameObject.Find("Catch");
        GameObject scoreGameobject = GameObject.Find("Score");
        scoreText = scoreGameobject.GetComponent<Text>();
        catchText.SetActive(false);
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
        score++;
    }
    private IEnumerator CatchTextSpwan()
    {
        catchText.SetActive(true);
        yield return new WaitForSeconds(.5f);
        catchText.SetActive(false);
        StopCoroutine("CatchTextSpwan");
    }
}
