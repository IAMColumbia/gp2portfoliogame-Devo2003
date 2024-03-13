using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float distance =10;
    public float angle = 30;
    public float height = 1.0f;
    public Color MeshColor = Color.red;
    public int RayCount = 30;

    public int RaySize = 30;

    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
    }

    Mesh CreateShapeMesh()
    {
        Mesh mesh = new Mesh();

        int numTriangles = 8;
        int numVerticies = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVerticies];
        int[] traingles = new int[numVerticies];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;

        int vert = 0;
        //left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;
        //right side

        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        //far side
        vertices[vert++] = bottomLeft;
        vertices[vert++] = bottomRight;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = topLeft;
        vertices[vert++] = bottomLeft;


        //top
        vertices[vert++] = topCenter;
        vertices[vert++] = topLeft;
        vertices[vert++] = topRight;

        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomLeft;

        for (int i = 0; i < numVerticies; ++i)
        {
            traingles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = traingles;
        mesh.RecalculateNormals();
        return mesh;

    }


    private void OnValidate()
    {
        mesh = CreateShapeMesh();
    }

    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = MeshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
    }

    
    public void RayCast()
    {
        int PlayerLayer = 1 << LayerMask.NameToLayer("Player");

        // Direction of the ray 
        Vector3 forwardDirection = transform.forward;

        // Origin point of the ray 
        Vector3 rayOrigin = transform.position;

        // Cast rays for each vertex mesh
        for (int i = 0; i < RayCount; i++)
        {
            float currentAngle = Mathf.Lerp(-angle / 2f, angle / 2f, i / (float)(RayCount - 1));
            Vector3 rayDirection = Quaternion.Euler(0, currentAngle, 0) * forwardDirection * RaySize;

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, distance, PlayerLayer))
            {
                Debug.DrawLine(rayOrigin, hit.point, Color.blue); // display the blue rays where the capsule was spotted from
                Debug.Log("Hit player: " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(rayOrigin, rayDirection * distance, Color.red); // display the search rays
            }
        }
    }
}
