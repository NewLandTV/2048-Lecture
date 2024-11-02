using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    private Point[] points;

    private void Awake()
    {
        points = GetComponentsInChildren<Point>();
    }

    public Vector2 GetRandomPoint()
    {
        int r;

        do
        {
            r = Random.Range(0, points.Length);
        } while (points[r].Collision);

        return points[r].transform.position;
    }
}
