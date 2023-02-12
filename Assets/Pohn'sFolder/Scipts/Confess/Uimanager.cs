using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uimanager : Singleton<Uimanager>
{
    public SpriteRenderer tens;
    public SpriteRenderer ones;
    public SpriteRenderer timerTens;
    public SpriteRenderer timerOnes;
    public Sprite[] number;
    public float timer;
    private int time;
    public int count;
    // Update is called once per frame
    void Update()
    {
        tens.sprite = number[count / 10];
        ones.sprite = number[count % 10];
        time = Mathf.FloorToInt(timer);
        timerTens.sprite = number[time / 10];
        timerOnes.sprite = number[time % 10];
    }
}
