using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject wayPointRefab;

    private static List<Transform> points;

    public static List<Transform> Points 
    { 
        get { return points; } 
    }

    public void Initialize(List<Vector2Int> generatedPath)
    {
        points = new List<Transform>();

        int indexPathNode = 1;

        while (indexPathNode != generatedPath.Count - 1)
        {
            if (generatedPath[indexPathNode - 1].x != generatedPath[indexPathNode + 1].x 
                && generatedPath[indexPathNode - 1].y != generatedPath[indexPathNode + 1].y)
            {
                points.Add(Instantiate(wayPointRefab,
                               new Vector3(generatedPath[indexPathNode].y * 5, (float)2.5, generatedPath[indexPathNode].x * 5),
                               new Quaternion(0, 0, 0, 1), this.transform).transform);
            }

            indexPathNode++;
        }

        points.Add(Instantiate(wayPointRefab,
                           new Vector3(generatedPath[indexPathNode].y * 5, (float)2.5, generatedPath[indexPathNode].x * 5),
                           new Quaternion(0, 0, 0, 1), this.transform).transform);
    }

}