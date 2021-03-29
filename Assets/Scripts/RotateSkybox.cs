using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    // Rotational speed
    public float rotSpeed = 1;
    public Color colorStart = Color.red;
    public Color colorEnd = Color.blue;
    public float duration = 1.0f;

    Material skyMat;

    private void Start() {
        skyMat = RenderSettings.skybox;
    }
    // Rotate Skybox around y-axis.
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*rotSpeed);
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        Color color = Color.Lerp(colorStart, colorEnd, lerp);
        skyMat.SetColor("_Tint", color);
    }
}
