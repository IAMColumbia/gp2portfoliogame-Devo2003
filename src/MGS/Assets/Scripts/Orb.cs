using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    //public GameObject orbPrefab;
    //public Transform plane;
    //public List<Transform> obstacles;

    //public int OrbNums = 5;
    //public List<GameObject> objects = new List<GameObject>();

    public OrbState state;

    //public int 

    public enum OrbState { Normal, Collected }
    // Start is called before the first frame update
    void Start()
    {
        state = OrbState.Normal;
        //SpawnOrbs();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case OrbState.Normal:
                break;
            case OrbState.Collected:
                Destroy(this.gameObject);
                break;
        }


    }

    //public void SpawnOrbs()
    //{
    //    for (int i = 0; i < OrbNums; i++)
    //    {
    //        Vector3 randPosition = GenerateRandPosition();
    //        GameObject newOrb = Instantiate(orbPrefab, randPosition, Quaternion.identity);
    //        //newOrb.transform.parent = this.transform;
    //    }
    //}

    //private Vector3 GenerateRandPosition()
    //{
    //    //Random rand = new Random();
    //    Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(plane.position.x - plane.localScale.x / 2, plane.position.x + plane.localScale.x / 2),
    //                                         plane.position.y,
    //                                         UnityEngine.Random.Range(plane.position.z - plane.localScale.z / 2, plane.position.z + plane.localScale.z / 2));

    //    // Check if the random position collides with any obstacles
    //    while (PositionCollidesWithObstacles(randomPosition))
    //    {
    //        randomPosition = new Vector3(UnityEngine.Random.Range(plane.position.x - plane.localScale.x / 2, plane.position.x + plane.localScale.x / 2),
    //                                     plane.position.y,
    //                                     UnityEngine.Random.Range(plane.position.z - plane.localScale.z / 2, plane.position.z + plane.localScale.z / 2));
    //    }

    //    return randomPosition;
    //}

    //// Check if a position collides with any obstacles
    //bool PositionCollidesWithObstacles(Vector3 position)
    //{
    //    foreach (Transform obstacle in obstacles)
    //    {
    //        Collider obstacleCollider = obstacle.GetComponent<Collider>();
    //        if (obstacleCollider.bounds.Contains(position)) // Check if the position is within the bounds of the obstacle's collider
    //        {
    //            return true; // Position collides with obstacle
    //        }
    //    }
    //    return false; // Position doesn't collide with any obstacles
    //}
    public void Collect()
    {
        this.state = OrbState.Collected;
    }

}
