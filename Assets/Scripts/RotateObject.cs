using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
    public float xAngle, yAngle, zAngle = 0;
    public float rotSpeed = 1;

    private void Update() {

        gameObject.transform.Rotate(xAngle*rotSpeed, yAngle*rotSpeed, zAngle*rotSpeed, Space.Self);
    }
}
