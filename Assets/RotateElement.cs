using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateElement : MonoBehaviour
{
        // Update is called once per frame
    public float rotationSpeed = 1.0f;
    void Update()
    {
        transform.Rotate(0, 0, 1);
    }
}
