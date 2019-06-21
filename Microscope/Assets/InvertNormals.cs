using UnityEngine;
using System.Linq;
[ExecuteAlways]
public class InvertNormals : MonoBehaviour
{
    private Mesh mesh;
    void Start()
    {
        mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}
