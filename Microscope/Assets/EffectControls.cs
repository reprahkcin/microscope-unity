using UnityEngine;

public class EffectControls : MonoBehaviour
{
    public GameObject camera;

    private float cam_x = 0;
    private float cam_y = 10;
    private float cam_z = 0;

    private bool lampIsOn = false;

    void Start()
    {
        SimpleBoxBlur blurScript = camera.GetComponent<SimpleBoxBlur>();
        blurScript.DownRes = -4;
        blurScript.Iterations = -6;
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", -1);
        camera.transform.position = new Vector3(0,10,0);
    }

    public void ToggleLamp()
    {
        if (lampIsOn)
        {
            lampIsOn = false;
        }
        else
        {
            lampIsOn = true;
        }
    }

    public void ChangeBrightness(float f)
    {
        if (lampIsOn)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", f);
        }
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

    public void TranslateX(float adj)
    {
        cam_x = adj;
        camera.transform.position = new Vector3(cam_x, cam_y, cam_z);
    }

    public void TranslateY(float adj)
    {
        cam_z = adj;
        camera.transform.position = new Vector3(cam_x, cam_y, cam_z);
    }





}
