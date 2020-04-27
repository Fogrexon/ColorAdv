using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeIn : MonoBehaviour
{
    public WorldStatus worldStatus;
    bool flag = false;
    public float duration = 1f;
    float restTime;

    CanvasGroup canvasGroup;

    void Start() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!flag && worldStatus.goaled) {
            flag = true;
            restTime = duration;
        }
        if(flag && restTime > 0){
            restTime -= Time.deltaTime;
            canvasGroup.alpha = 1.0f - restTime / duration;
            
        }
    }
}
