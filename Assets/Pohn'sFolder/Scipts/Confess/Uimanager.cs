using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uimanager : Singleton<Uimanager>
{
    public SpriteRenderer tens;
    public SpriteRenderer ones;
    public Sprite[] number;
    public int count;
    // Update is called once per frame
    void Update()
    {
        tens.sprite = number[count / 10];
        ones.sprite = number[count % 10];
    }
}
