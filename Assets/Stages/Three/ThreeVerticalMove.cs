using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeVerticalMove : MonoBehaviour
{
    public WorldStatus worldStatus;
    public float range = 5f;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Sin(worldStatus.time * speed) * range;
        transform.position = pos;
    }
}
