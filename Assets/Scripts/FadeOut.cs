using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float lifeTime = 1f;
    float remainTime;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        remainTime = lifeTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        remainTime -= Time.deltaTime;
        Color c = spriteRenderer.color;
        c.a = remainTime / lifeTime;
        spriteRenderer.color = c;
        if(remainTime < 0) Destroy(gameObject);
    }
}
