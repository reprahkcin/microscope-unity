using UnityEngine;
using UnityEngine.UI;

public class blurScript : MonoBehaviour
{
    void Start()
    {
        Image img = this.gameObject.GetComponent<Image>();
        img.material.SetFloat("_Size", -6f);
    }
    public void ChangeSize(float adj)
    {
        Image img = this.gameObject.GetComponent<Image>();
        img.material.SetFloat("_Size",adj);
    }
}
