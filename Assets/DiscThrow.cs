using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiscThrow : MonoBehaviour
{
    private Material trailMaterial;
    private GameObject disc;
    private XRGrabInteractable grabInteractable = null;

    // Start is called before the first frame update
    void Start()
    {
        disc = gameObject;
        trailMaterial = disc.GetComponent<TrailRenderer>().material;
        grabInteractable = GetComponent<XRGrabInteractable>();
   
        //Listeners
        grabInteractable.onSelectEntered.AddListener(Grabbed);
        grabInteractable.onSelectExited.AddListener(Released);
    }

    private void Released(XRBaseInteractor arg0) {
        print("released. Enabling Trail");
        disc.GetComponent<TrailRenderer>().enabled = true;
    }

    private void Grabbed(XRBaseInteractor arg0) {
        Debug.Log("Grabbed Disc");
    }


    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnCollisionEnter(Collision collision) {
        print("hit");
        Color newColor = UnityEngine.Random.ColorHSV(0f, 1f, .5f, 1f, .5f, 1f);
        trailMaterial.SetColor("_BaseColor", newColor);
    }
}
