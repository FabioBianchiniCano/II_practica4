using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    private WebCamTexture webcam;

    // Start is called before the first frame update
    void Start() {
        if (webcam == null) 
            webcam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = webcam;

        if (!webcam.isPlaying)
            webcam.Play();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
