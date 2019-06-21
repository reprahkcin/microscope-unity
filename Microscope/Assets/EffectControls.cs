using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class EffectControls : MonoBehaviour
{
    public GameObject slideCamera;
    public GameObject microscopeCamera;
    public GameObject light_button;
    public GameObject info_button;

    public int activeObjective = 1;
    public GameObject[] objectives;

    public Sprite button_on;
    public Sprite button_off;

    public Slider brightness;

    private float cam_x = 0;
    private float cam_y = 10;
    private float cam_z = 0;

    private bool lampIsOn = false;
    private bool infoIsOn = true;

    private float[] zoomFloats;

    void Start()
    {
        zoomFloats = new[] {10, 7, 3, 0.5f};
        SimpleBoxBlur blurScript = slideCamera.GetComponent<SimpleBoxBlur>();
        blurScript.DownRes = -4;
        blurScript.Iterations = -6;
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", -1);
        slideCamera.transform.position = new Vector3(0,10,0);
        SwitchActiveObjective(0);
    }


    public void SwitchActiveObjective(int obj)
    {
        foreach (GameObject button in objectives)
        {
            button.GetComponent<Image>().sprite = button_off;
        }

        objectives[obj].GetComponent<Image>().sprite = button_on;
        Vector3 pos = slideCamera.transform.position;
        slideCamera.transform.position = new Vector3(pos.x,zoomFloats[obj],pos.z);
    } 

    public void ToggleInfo()
    {
        if (infoIsOn)
        {
            infoIsOn = false;
            info_button.GetComponent<Image>().sprite = button_off;
            microscopeCamera.SetActive(false);

        }
        else
        {
            infoIsOn = true;
            info_button.GetComponent<Image>().sprite = button_on;
            microscopeCamera.SetActive(true);
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
        SimpleBoxBlur blurScript = slideCamera.GetComponent<SimpleBoxBlur>();
        blurScript.DownRes = (int)Mathf.Round(adj);

    }
    public void FineFocus(float adj)
    {
        SimpleBoxBlur blurScript = slideCamera.GetComponent<SimpleBoxBlur>();
        blurScript.Iterations = (int)Mathf.Round(adj);

    }

    public void TranslateX(float adj)
    {
        cam_x = adj;
        Vector3 pos = slideCamera.transform.position;
        slideCamera.transform.position = new Vector3(cam_x, pos.y, pos.z);
    }

    public void TranslateY(float adj)
    {
        cam_z = adj;
        Vector3 pos = slideCamera.transform.position;
        slideCamera.transform.position = new Vector3(pos.x, pos.y, cam_z);
    }

}
