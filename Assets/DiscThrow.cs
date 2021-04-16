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
    private bool discGrabbed = false;
    private bool discReturned = false;
    public float discReturnDelay = 3f;
    private float discReturnCountdown;

    public GameObject throwingHand;

    // Start is called before the first frame update
    void Start()
    {
        disc = gameObject;
        trailMaterial = disc.GetComponent<TrailRenderer>().material;
        grabInteractable = GetComponent<XRGrabInteractable>();
        discReturnCountdown = discReturnDelay;

        //Listeners
        //grabInteractable.onSelectEntered.AddListener(Grabbed);
        //grabInteractable.onSelectExited.AddListener(Released);

    }

    public void Released(XRBaseInteractor arg0) {
        Debug.Log("Disc Released. Enabling Trail");
        disc.GetComponent<TrailRenderer>().enabled = true;
        discGrabbed = false;
        discReturned = false;
        //add rotation
    }

    public void Grabbed(XRBaseInteractor arg0) {
        Debug.Log("Grabbed Disc. Disabling Trail!");
        discGrabbed = true;
        discReturned = true;
        disc.GetComponent<TrailRenderer>().enabled = false;
        discReturnCountdown = discReturnDelay;
    }


    // Update is called once per frame
    void Update()
    {
        if (!discGrabbed && !discReturned) {
                discReturnCountdown -= Time.deltaTime;
            if (discReturnCountdown <= 0) {
                ReturnDisc();
            }
        }
    }

    private void ReturnDisc() {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.position = Vector3.MoveTowards(transform.position, throwingHand.transform.position, .35f);
    }
    
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("Hit Surface. Changing material base color!");
        Color newColor = UnityEngine.Random.ColorHSV(0f, 1f, .5f, 1f, .5f, 1f);
        trailMaterial.SetColor("_BaseColor", newColor);
    }


}
