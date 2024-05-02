using UnityEngine;

[System.Serializable]
public class Plot
{
    [Header("Settings")]
    public string Name;
    public Transform PlotTransform;
    public Vector3 offset;
    public GameObject Prefab;
    public bool empty = true;
    public int Price = 500;
}
