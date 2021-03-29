using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public Color colorStart = Color.red;
    public Color colorEnd = Color.blue;
    public float duration = 1.0f;
    Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void Update() {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        print("update color");
    }
}
