using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask _bgLayerMask;
    [SerializeField] private bool _canBeShowed;
    
    Vector3 _origin = Vector3.zero;
    
    private MeshRenderer _meshRenderer;
    private Mesh _mesh;
    private float _startingAngle;
    private float _fov = 60f;
    private int rayCount = 20;
    private float angle = 0;
    private float angleIncrease = 0;
    private float viewDistance = 10f;
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
    }

    private void FixedUpdate()
    {
        FindEnemy();
    }

    private void FindEnemy()
    {
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 vertex;
            Vector3[] vertices = new Vector3[rayCount + 1 + 1];
            vertices[0] = _origin;
            RaycastHit2D raycastHit2D =
                Physics2D.Raycast(vertices[0], GetVectorFromAngle(angle), viewDistance, _bgLayerMask);
            if (raycastHit2D.collider != null && raycastHit2D.collider.GetComponent<EnemyVisibility>() != null)
            {
                 raycastHit2D.collider.GetComponent<EnemyVisibility>().ShowEnemy();
                print("None");
            }
            angle -= angleIncrease;
        }
    }
    
    
    public void HideTriangle()
    {
        _meshRenderer.enabled = false;
    }

    public void DrawTriangle()
    {
        _meshRenderer.enabled = true;
        angle = _startingAngle;
        angleIncrease = _fov / rayCount;
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangle = new int[rayCount * 3];

        vertices[0] = _origin;
        
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D =
                Physics2D.Raycast(vertices[0], GetVectorFromAngle(angle), viewDistance, _bgLayerMask);
            if (raycastHit2D.collider == null)
            {
                vertex = _origin + GetVectorFromAngle(angle) * viewDistance;
                print("None");
            }
            else
            {
                print(raycastHit2D.collider.gameObject.name);
                vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangle[triangleIndex + 0] = 0;
                triangle[triangleIndex + 1] = vertexIndex - 1;
                triangle[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        _mesh.vertices = vertices;
        _mesh.triangles = triangle;
        _mesh.uv = uv;
    }
    public void SetOrigin(Vector3 origin)
    {
        this._origin = origin;
    }

    public void SetAimDestination(Vector3 destination)
    {
        _startingAngle = GetAngleFromVector(destination) - _fov / 2f;
    }
    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = MathF.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0f) n += 360f;
        return n;
    }
}
