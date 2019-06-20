using UnityEngine;

public class ToggleVis : MonoBehaviour
{
    public void toggle()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    } 
}
