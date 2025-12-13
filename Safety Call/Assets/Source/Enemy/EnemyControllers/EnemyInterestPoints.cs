using System.Collections.Generic;
using UnityEngine;

public class EnemyInterestPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    public Vector3 GetPoint(int index)
    {
        return _points[index].position;
    }

    public Vector3 GetRandomPoint()
    {
        return _points[Random.Range(0, _points.Count - 1)].position;
    }
}
