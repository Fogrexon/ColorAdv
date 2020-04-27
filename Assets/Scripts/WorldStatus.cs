using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStatus : MonoBehaviour
{
    public Color[] worldColors;
    public Color worldColor;
    public int worldColorIndex= 0;
    public Color targetColor;
    public int worldColorChange = 2;
    public bool goalApproach = false;
    public bool goaled = false;

    public float time = 0.0f;

    public void Start(){
        worldColor = worldColors[worldColorIndex];
    }
    
}
