using UnityEngine;
using UnityEngine.UI;

public class EffectControls : MonoBehaviour
{
    public GameObject camera;
    public GameObject light_button;
    public GameObject info_button;

    public Sprite button_on;
    public Sprite button_off;
    public Slider brightness;

    private float cam_x = 0;
    private float cam_y = 10;
    private float cam_z = 0;

    private bool lampIsOn = false;
    private bool infoIsOn = true;

    void Start()
    {
        //button_on = Resources.Load<Sprite>("UI_atlas_7");
        //button_off = Resources.Load<Sprite>("UI_atlas_10");
        SimpleBoxBlur blurScript = camera.GetComponent<SimpleBoxBlur>();
        blurScript.DownRes = -4;
        blurScript.Iterations = -6;
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", -1);
        camera.transform.position = new Vector3(0,10,0);
    }

    public void ToggleInfo()
    {
        if (infoIsOn)
        {
            infoIsOn = false;
            info_button.GetComponent<Image>().sprite = button_off;

        }
        else
        {
            infoIsOn = true;
            info_button.GetComponent<Image>().sprite = button_on;
        }
    }

    public void ToggleLamp()
    {
        if (lampIsOn)
        {
            lampIsOn = false;
            light_button.GetComponent<Image>().sprite = button_off;
            gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", -1);
            brightness.value = -1;
        }
        else
        {
            lampIsOn = true;
            light_button.GetComponent<Image>().sprite = button_on;
        }
    }

    public void ChangeBrightness(float f)
    {
        if (lampIsOn)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", f);
        }
        else
        {
            gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", -1);
            brightness.value = -1;
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
