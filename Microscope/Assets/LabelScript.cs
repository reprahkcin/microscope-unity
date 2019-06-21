using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelScript : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] labels;
    public Material lineMaterial;
    private GameObject[] lines;
    public GameObject labelGroup;
    private LineRenderer line;
    private Color lineColor = Color.white;

    void Start()
    {
        lines = new GameObject[labels.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            lines[i] = new GameObject();
            lines[i].AddComponent<LineRenderer>();
            lines[i].GetComponent<LineRenderer>().material = lineMaterial;
            lines[i].GetComponent<LineRenderer>().startWidth = 1f;
            lines[i].GetComponent<LineRenderer>().endWidth = 1f;
            lines[i].GetComponent<LineRenderer>().SetPosition(0,labels[i].transform.position);
            lines[i].GetComponent<LineRenderer>().SetPosition(1, objects[i].transform.position);
            lines[i].transform.SetParent(labelGroup.transform, false);
        }

    }

    
    void Update()
    {
        
    }
}
