using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catchball : Singleton<Catchball>
{
    public SpriteRenderer TestImage;
    public Sprite[] TestSprite;
    public int hp = 10;
    public void ChangeImage()
    {
        if (hp >= 0)
        {
            TestImage.sprite = TestSprite[hp];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
