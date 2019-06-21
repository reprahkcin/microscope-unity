using UnityEngine;

public class LabelScript : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] labels;
    public Material lineMaterial;
    private GameObject[] lines;
    public GameObject labelGroup;
    private LineRenderer line;
    [SerializeField] private float lineWidth = 0.25f;

    void Start()
    {
        lines = new GameObject[labels.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            lines[i] = new GameObject();
            lines[i].AddComponent<LineRenderer>();
            lines[i].GetComponent<LineRenderer>().material = lineMaterial;
            lines[i].GetComponent<LineRenderer>().startWidth = lineWidth;
            lines[i].GetComponent<LineRenderer>().endWidth = lineWidth;
            lines[i].GetComponent<LineRenderer>().SetPosition(0,labels[i].transform.position);
            lines[i].GetComponent<LineRenderer>().SetPosition(1, objects[i].transform.position);
            lines[i].GetComponent<LineRenderer>().numCornerVertices = 5;
            lines[i].transform.SetParent(labelGroup.transform, false);
        }

    }

 
}
