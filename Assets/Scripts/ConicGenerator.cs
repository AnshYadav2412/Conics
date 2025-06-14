using UnityEngine;
using System.Collections.Generic;

public class ConicGenerator : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private List<GameObject> points;
    [SerializeField] private Transform parent;
    private Vector3 drawPos = Vector3.zero;
    [SerializeField] float radius = 5f;
    [SerializeField] int resolution = 20;
    [SerializeField] float baseRadius = 5f;
    [SerializeField] float height = 10f;
    [SerializeField] Vector3 centre = Vector3.zero;
    [SerializeField] float length = 5f;
    [SerializeField] float breadth = 5f;

    private void Start()
    {

    }


    public void CreateCone()
    {
        Clear();
        float slantHeight = Mathf.Sqrt(baseRadius * baseRadius + height * height);
        for (int i = 0; i < slantHeight; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                float phi = Mathf.Atan2(height, baseRadius);
                float tempHeight = i * Mathf.Sin(phi);
                float tempRadius = Mathf.Sqrt(i * i - tempHeight * tempHeight);
                float theta = 2 * j * Mathf.PI / resolution;
                drawPos = new Vector3(Mathf.Sin(theta) * tempRadius, i - height/2, Mathf.Cos(theta) * tempRadius);
                DrawPoint(drawPos);
            }
        }
    }
    public void CreateDisk()
    {
        Clear();
        DrawPoint(Vector3.down * 2);
        for (int i = 1; i < radius; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                float theta = 2 * j * Mathf.PI / resolution;
                drawPos = new Vector3(Mathf.Sin(theta) * i, -2, Mathf.Cos(theta) * i);
                DrawPoint(drawPos);
            }
        }
    }
    public void CreateCylinder()
    {
        Clear();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                float theta =2 * j * Mathf.PI / resolution;
                drawPos = new Vector3(Mathf.Sin(theta) * radius, i - height / 2, Mathf.Cos(theta) * radius);
                DrawPoint(drawPos);
            }
        }
    }
    public void CreateSphere()
    {
        Clear();
        for (int i = 0; i < resolution; i++)
        {
            float theta = i * Mathf.PI / resolution;
            for (int j = 0; j < resolution; j++)
            {
                float phi = 2 * j * Mathf.PI / resolution;

                float x = radius * Mathf.Sin(theta) * Mathf.Cos(phi);
                float y = radius * Mathf.Cos(theta);
                float z = radius * Mathf.Sin(theta) * Mathf.Sin(phi);

                DrawPoint(new Vector3(x, y, z));
            }
        }
    }
    private void DrawPoint(Vector3 position)
    {
        GameObject motif = Instantiate(point, position, point.transform.rotation, parent);
        TrailRenderer trail = GetComponent<TrailRenderer>();
        points.Add(motif);
    }
    public void CreateCuboid()
    {
        Clear();
        for (int i = 0; i <= height; i++)
        {
            for (int j = 0; j <= length; j++)
            {
                drawPos = new Vector3(j - length/2, i - height/2, breadth / 2);
                DrawPoint(drawPos);
            }
            for (int j = 0; j <= length; j++)
            {
                drawPos = new Vector3(j - length / 2, i - height / 2, -breadth / 2);
                DrawPoint(drawPos);
            }
        }
        for (int i = 0; i <= height; i++)
        {
            for (int j = 0; j < breadth; j++)
            {
                drawPos = new Vector3(length / 2, i - height / 2, j - breadth / 2);
                DrawPoint(drawPos);
            }
            for (int j = 0; j < breadth; j++)
            {
                drawPos = new Vector3(-length / 2, i - height / 2,j - breadth / 2);
                DrawPoint(drawPos);
            }
        }
        for (int i = 0; i <= breadth; i++)
        {
            for (int j = 0; j < length; j++)
            {
                drawPos = new Vector3(j - length / 2,height / 2, i - breadth / 2);
                DrawPoint(drawPos);
            }
            for (int j = 0; j < length; j++)
            {
                drawPos = new Vector3(j - length / 2,- height / 2, i - breadth / 2);
                DrawPoint(drawPos);
            }
        }
    }
    public void Clear()
    {
        // Destroy all the instantiated point GameObjects
        foreach (GameObject obj in points)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        // Clear the list after destruction
        points.Clear();
    }

}
