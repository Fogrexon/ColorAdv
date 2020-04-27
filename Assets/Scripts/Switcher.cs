using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public int[] swtichList;

    WorldStatus worldStatus;
    EventManager eventManager;
    Material material;

    void Start() {
        GameObject g = GameObject.FindWithTag("GameController");
        worldStatus = g.GetComponent<WorldStatus>();
        eventManager = g.GetComponent<EventManager>();
        material = GetComponent<Renderer>().material;
    }

    void FixedUpdate(){
        if(worldStatus.worldColorChange > 0){
            material.color = worldStatus.worldColors[swtichList[worldStatus.worldColorIndex]];
        }
        material.SetFloat("_TimeValue", worldStatus.time);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            eventManager.changeColor(swtichList[worldStatus.worldColorIndex]);
        }
    }
}
