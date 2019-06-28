using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{


    
    void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.transform.Rotate(0,10*Time.deltaTime,0);
        }
    }
}
