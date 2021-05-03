using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCam : MonoBehaviour
{
    public Transform start;
    public Transform end;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, end.position, Time.deltaTime / 5);
    }
}
