using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleUIManager : Singleton<PuzzleUIManager>
{
    public int pointsToEnd;
    public int currentPoints;
    public bool stage1;
    public GameObject clearText;
    void Start()
    {
        if (stage1 == false)
        {
            clearText = GameObject.Find("ClearText");
            clearText.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(currentPoints>= pointsToEnd)
        {
            if (stage1)
            {
                SceneManager.LoadScene("PuzzleStage2");
            }
            else
            {
                clearText.SetActive(true);
            }
        }
    }
    public void AddPoints()
    {
        currentPoints++;
    }
}
