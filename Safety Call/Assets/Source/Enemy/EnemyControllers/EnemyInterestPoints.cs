using System.Collections.Generic;
using UnityEngine;

public class EnemyInterestPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    public Transform GetPoint(int index)
    {
        return _points[index];
    }

    public Transform GetRandomPoint()
    {
        return _points[Random.Range(0, _points.Count - 1)];
    }
}
