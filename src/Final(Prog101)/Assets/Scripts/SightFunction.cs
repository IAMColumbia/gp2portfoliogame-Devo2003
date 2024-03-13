using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightFunction : MonoBehaviour
{
    public float fieldOfView = 60f;
    public float maxDistance = 10f;

    private MeshRenderer coneMeshRenderer;

    void Start()
    {
        coneMeshRenderer = GetComponentInChildren<MeshRenderer>();
        if (coneMeshRenderer == null)
        {
            Debug.LogError("Cone mesh renderer not found in children!");
        }
    }

    void Update()
    {
        UpdateCone();
    }

    void UpdateCone()
    {
        // Set cone mesh properties based on camera's field of view and distance
        coneMeshRenderer.transform.localScale = new Vector3(maxDistance, Mathf.Tan(Mathf.Deg2Rad * (fieldOfView * 0.5f)) * maxDistance * 2, maxDistance);
    }
}
