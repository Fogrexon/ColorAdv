using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public WorldStatus worldStatus;

    Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
    }

    void FixedUpdate() {
        mat.SetFloat("_TimeValue", worldStatus.time);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            worldStatus.goalApproach = true;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }
}
