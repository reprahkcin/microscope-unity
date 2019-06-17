using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Image_script : MonoBehaviour
{
    [SerializeField] private bool lampIsOn = false;
    [SerializeField] private float brightness;
    [SerializeField] private float x_axis;
    [SerializeField] private float y_axis;
    [SerializeField] private float coarseFocus;
    [SerializeField] private float fineFocus;
    [SerializeField] private float zoom1 = 0.25f;
    [SerializeField] private float zoom2 = 1f;
    [SerializeField] private float zoom3 = 2.25f;
    private bool isFocused_1 = false;
    private bool isFocused_2 = false;

    private float[] scales;

    void Update()
    {

    }

    public void ScaleSlide(int adj)
    {
        scales = new float[3] {zoom1,zoom2,zoom3};
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scales[adj], scales[adj]);

    }

    public void lampSwitch()
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

    public void AdjustBrightness(float adj)
    {
        brightness = adj;
    }

    public void AdjustXaxis(float adj)
    {
        x_axis = adj;
    }

    public void AdjustYaxis(float adj)
    {
        y_axis = adj;
    }


    public void AdjustFine(float adj)
    {
        fineFocus = adj;
    }
}
