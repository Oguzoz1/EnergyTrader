using UnityEngine;

public class SquareGizmos : MonoBehaviour
{
    public Color Color = Color.green;
    private void OnDrawGizmos()
    {
        float size = transform.localScale.x;
        UnityEngine.Gizmos.color = Color.red;

        Vector3 halfSize = Vector3.one * size * 0.5f;
        Vector3 objTransform = transform.position;

        Vector3 p0 = objTransform + new Vector3(-halfSize.x, 0, -halfSize.z);
        Vector3 p1 = objTransform + new Vector3(halfSize.x, 0, -halfSize.z);
        Vector3 p2 = objTransform + new Vector3(halfSize.x, 0, halfSize.z);
        Vector3 p3 = objTransform + new Vector3(-halfSize.x, 0, halfSize.z);

        UnityEngine.Gizmos.DrawLine(p0, p1);
        UnityEngine.Gizmos.DrawLine(p1, p2);
        UnityEngine.Gizmos.DrawLine(p2, p3);
        UnityEngine.Gizmos.DrawLine(p3, p0);
    }

    private LineRenderer lineRenderer;

    void Start()
    {
        Color = Color.green;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color; ;
        lineRenderer.endColor = Color; ;
        lineRenderer.loop = true;
        UpdateSquare();
    }

    void Update()
    {
        // You can update the square if needed, for example, if the size changes.
        UpdateSquare();
    }

    void UpdateSquare()
    {
        float size = transform.localScale.x;
        Vector3 halfSize = Vector3.one * size * 0.5f;

        Vector3 p0 = transform.position + new Vector3(-halfSize.x, 0, -halfSize.z);
        Vector3 p1 = transform.position + new Vector3(halfSize.x, 0, -halfSize.z);
        Vector3 p2 = transform.position + new Vector3(halfSize.x, 0, halfSize.z);
        Vector3 p3 = transform.position + new Vector3(-halfSize.x, 0, halfSize.z);

        lineRenderer.positionCount = 5;
        lineRenderer.SetPositions(new Vector3[] { p0, p1, p2, p3, p0 });
    }

    public void UpdateColor(Color color)
    {
        Color = color;
        lineRenderer.startColor = Color;
        lineRenderer.endColor = Color;
        UpdateSquare();
    }
}
