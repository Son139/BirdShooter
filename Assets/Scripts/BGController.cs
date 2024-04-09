using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : Singleton<BGController>
{
    public Sprite[] sprites;

    public SpriteRenderer bgImage;

    //Ghi de phuong thuc Awake cua Singleton
    public override void Awake()
    {
        // Khong giu lai doi tuong bgcontroller khi load lai scene moi
        MakeSingleton(false);
    }
    //Ghi de phuong thuc Start cua Singleton
    public override void Start()
    {
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if (bgImage != null && sprites !=null && sprites.Length > 0)
        {
            int randomIdx = Random.Range(0, sprites.Length);

            if (sprites[randomIdx] != null)
            {
                bgImage.sprite = sprites[randomIdx];
            }
        }
    }
}
