using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishObstacle : MonoBehaviour
{
    public int colorIndex = 0;
    int prevIndex = 0;
    WorldStatus worldStatus;
    BoxCollider2D boxCollider;
    void Start()
    {
        worldStatus = GameObject.FindWithTag("GameController").GetComponent<WorldStatus>();
        prevIndex = worldStatus.worldColorIndex;
        GetComponent<Renderer>().material.color = worldStatus.worldColors[colorIndex];
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update(){
        if(prevIndex != worldStatus.worldColorIndex){
            prevIndex = worldStatus.worldColorIndex;
            boxCollider.enabled = !(colorIndex == worldStatus.worldColorIndex);
        }
        if((colorIndex == worldStatus.worldColorIndex) && worldStatus.worldColorChange <= 0) {
            Destroy(gameObject);
        }
    }
}
