using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public enum CamState { Rotating, Paused}
public class Cam : MonoBehaviour
{

    public float rotationSpeed = 100.0f;
    public float LeftRotationLimit = -45.0f;
    public float RightRotationLimit = 45.0f;
    public float PauseCamera = 1.0f;

    private Quaternion LeftDirectionLimit;
    private Quaternion RightDirectionLimit;
    private Quaternion OGRotation;

    private CamState camState = CamState.Rotating;

    private float pauseTimer = 0.0f;
    private bool rotationRight = true;

    // Start is called before the first frame update
    void Start()
    {
        OGRotation = transform.rotation;

        LeftDirectionLimit = OGRotation * Quaternion.Euler(0, LeftRotationLimit, 0);
        RightDirectionLimit = OGRotation * Quaternion.Euler(0, RightRotationLimit, 0);
    }

    

    // Update is called once per frame
    void Update()
    {
        switch (camState)
        {
            case CamState.Rotating:
                CamRotation();
                break;
            case CamState.Paused:
                CamPause();
                break;
        }
    }

    private void CamPause()
    {
        pauseTimer += Time.deltaTime;
        if (pauseTimer >= PauseCamera)
        {
            camState = CamState.Rotating;
        }
    }

    public void CamRotation()
    {
        Quaternion targetRotation = rotationRight ? RightDirectionLimit : LeftDirectionLimit;
        if (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }
        else
        {
            camState = CamState.Paused;
            pauseTimer = 0.0f;
            rotationRight = !rotationRight;
        }
    }
}
