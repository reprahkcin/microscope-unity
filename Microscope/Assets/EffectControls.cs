using UnityEngine;

public class EffectControls : MonoBehaviour
{
    public GameObject camera;
    public float[] zoomLevels = new float[3]{18f,9f,0.5f};

    void Start()
    {
        SimpleBoxBlur blurScript = camera.GetComponent<SimpleBoxBlur>();
        blurScript.DownRes = -4;
        blurScript.Iterations = -6;
        gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", -1);
        camera.transform.position = new Vector3(-10,18,-10);
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

    public void TranslateX(float adj)
    {

    }

    public void TranslateY(float adj)
    {

    }

    public void Zoom(int level)
    {
        camera.transform.position = new Vector3(-10,zoomLevels[level],-10);
        //check that focus is dialed in
        //disable coarse focus on zoom level 2-3
        //SimpleBoxBlur blurScript = camera.GetComponent<SimpleBoxBlur>();
        //if (blurScript.DownRes == 0 && camera.transform.position.y == zoomLevels[0])
        //{
        //    camera.transform.position = new Vector3(0,zoomLevels[1], 0 );
        //}

        //if (blurScript.DownRes == 0 && camera.transform.position.y == zoomLevels[1])
        //{
        //    camera.transform.position = new Vector3(0,zoomLevels[2],0);
        //}
    }



}
