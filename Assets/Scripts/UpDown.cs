using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float maxSpeed;
    private float speed;
    private float newY;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        newY = Mathf.Sin(Time.time * speed) * height;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
