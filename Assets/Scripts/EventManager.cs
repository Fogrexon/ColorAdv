using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public float timeScale = 1.0f;

    float approachRate = 0.02f;
    public Transform player;
    public Transform goal;

    bool goaled = false;

    WorldStatus ws;
    
    void Start()
    {
        ws = GetComponent<WorldStatus>();
        changeColor(0);
    }

    void approaching() {
        Vector3 pos = player.position + (goal.position - player.position) * approachRate;
        player.position = pos;
        timeScale = 0.3f;
        if((goal.position - player.position).magnitude < 0.03) {
            ws.goaled = true;
            timeScale = 0.0f;
        }
    }

    public void changeColor(int index){
        ws.worldColorIndex = index;
        ws.targetColor = ws.worldColors[index];
        ws.worldColorChange = 30;
    }

    void Update()
    {
        if(ws.goaled){
            if(Input.GetKeyDown(KeyCode.Return)){
                SceneManager.LoadScene(ws.nextScene);
            }
            return;
        };
        if(ws.goalApproach) approaching();
        ws.time += timeScale * Time.deltaTime;

        if(ws.worldColorChange < 0) return;
        ws.worldColor += (ws.targetColor - ws.worldColor) * 0.1f;
        if(ws.worldColorChange==1) ws.worldColor = ws.targetColor;
        ws.worldColorChange --;
    }
}
