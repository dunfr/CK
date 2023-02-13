using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hpbar : MonoBehaviour
{
    public SpriteRenderer TestImage; 
    public Sprite[] TestSprite;
    private int hp=10;
    public void ChangeImage()
    {
        if (hp >= 0)
        {
            TestImage.sprite = TestSprite[hp];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hp--;
            ChangeImage();
        }
    }
}
