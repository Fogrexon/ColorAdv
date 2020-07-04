using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : MonoBehaviour
{
    public WorldStatus worldStatus;
    bool flag = false;
    public bool fadeIn = true;
    public bool startFade = false;
    public float duration = 1f;
    float restTime;

    CanvasGroup canvasGroup;

    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!flag && (worldStatus.goaled || startFade)) {
            flag = true;
            restTime = duration;
            PlayerPrefs.SetInt("OpenedStage" , int.Parse(GameObject.FindWithTag("GameController").GetComponent<WorldStatus>().nextScene));
        }
        if(flag && restTime > 0){
            restTime -= Time.deltaTime;
            canvasGroup.alpha = fadeIn ? 1.0f - restTime / duration : restTime / duration;
            
        }
    }
}
