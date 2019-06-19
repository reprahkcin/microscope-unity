using UnityEngine;

public class EffectControls : MonoBehaviour
{
    public GameObject camera;

    void Start()
    {
        SimpleBoxBlur blurScript = camera.GetComponent<SimpleBoxBlur>();
        blurScript.DownRes = -4;
        blurScript.Iterations = -6;
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", -1);
    }

    public void ChangeBrightness(float f)
    {
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", f);
    }

    public void CoarseFocus(float adj)
    {
        SimpleBoxBlur blurScript = camera.GetComponent<SimpleBoxBlur>();
        blurScript.DownRes = (int)Mathf.Round(adj);

    }
    public void FineFocus(float adj)
    {
        SimpleBoxBlur blurScript = camera.GetComponent<SimpleBoxBlur>();
        blurScript.Iterations = (int)Mathf.Round(adj);

    }


}
