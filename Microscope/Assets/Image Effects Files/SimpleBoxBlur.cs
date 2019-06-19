using UnityEngine;
using System;

[ExecuteInEditMode]
public class SimpleBoxBlur : MonoBehaviour
{
    public Material BlurMaterial;
    [Range(-6, 6)]
    public int Iterations;
    [Range(-4, 4)]
    public int DownRes;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        int width = src.width >> Math.Abs(DownRes);
        int height = src.height >> Math.Abs(DownRes);

        RenderTexture rt = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(src, rt);

        for (int i = 0; i < Math.Abs(Iterations); i++)
        {
            RenderTexture rt2 = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(rt, rt2, BlurMaterial);
            RenderTexture.ReleaseTemporary(rt);
            rt = rt2;
        }

        Graphics.Blit(rt, dst);
        RenderTexture.ReleaseTemporary(rt);
    }

}
