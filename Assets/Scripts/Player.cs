using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rd;
    public WorldStatus worldStatus;
    public Material mat;
    public bool allowHorizontalMove = true;
    public bool allowVerticalMove = true;
    public float force = 3.0f;
    public float speed = 3.0f;
    public float resist = 0.96f;

    public GameObject horizontalArrow;
    public GameObject verticalArrow;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        horizontalArrow.SetActive(allowHorizontalMove);
        verticalArrow.SetActive(allowVerticalMove);
    }

    void FixedUpdate() {
        mat.SetFloat("_TimeValue", worldStatus.time);
    }

    void Update()
    {
        if(worldStatus.goalApproach) return;
        Vector2 f = Vector2.zero;
        if(allowHorizontalMove) f.x = Input.GetAxis("Horizontal") * force;
        if(allowVerticalMove) f.y = Input.GetAxis("Vertical") * force;

        rd.AddForce(f);
        Vector2 v = rd.velocity;
        v.x = Mathf.Min(speed, Mathf.Max(-speed, v.x));
        v.y = Mathf.Min(speed, Mathf.Max(-speed, v.y));
        rd.velocity = v * resist;
    }
}
