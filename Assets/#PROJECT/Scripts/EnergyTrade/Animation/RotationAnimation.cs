using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public Vector3 rotation;

    private void Start()
    {
        rotationSpeed = Random.Range(30f, 60f);
    }
    void Update()
    {
        RotateObject();
    }
    void RotateObject()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, rotationStep);
    }
}
