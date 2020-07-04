using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeVerticalMove : MonoBehaviour
{
    public WorldStatus worldStatus;
    public float start = 0f;
    public float range = 5f;
    public float speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Sin(worldStatus.time * Mathf.PI * 2.0f * speed + start) * range;
        transform.position = pos;
    }
}
