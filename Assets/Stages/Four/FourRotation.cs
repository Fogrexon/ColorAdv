using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourRotation : MonoBehaviour
{
    public EventManager eventManager;
    public float speed = 0.5f;

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f), 360 * eventManager.timeScale * Time.deltaTime * speed);
    }
}
