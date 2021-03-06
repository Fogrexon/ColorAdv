﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    WorldStatus worldStatus;
    public Material nega;
    public Material player;
    public Material goal;
    public Material main;

    void changeColor() {
        Color negaColor = new Color(1f,1f,1f) - worldStatus.worldColor;
        negaColor.a = 1f;
        nega.SetColor("_Color", negaColor);
        player.SetColor("_Color", negaColor);
        goal.SetColor("_Color", negaColor);
        main.SetColor("_Color", worldStatus.worldColor);
    }

    void Start()
    {
        worldStatus = GetComponent<WorldStatus>();
        changeColor();
    }

    void Update()
    {
        if(worldStatus.worldColorChange >= 0) changeColor();
    }
}
