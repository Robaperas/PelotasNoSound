using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerControler : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource moviendo;
    private AudioSource golpe;
    private AudioSource[] sources;
    

    public float speed = 5.0f;
    private float instspeed = 0;
    private float newpitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sources = GetComponents<AudioSource>();
        moviendo = sources[0];
        golpe = sources[1];
        
    }
    void FixedUpdate() 
    {
        instspeed = rb.velocity.magnitude;
        if(instspeed > 0)
        {
             newpitch = (float)(1 + 0.5f * (1 - Mathf.Exp(-1*instspeed)));
            moviendo.pitch = newpitch;
            if(!moviendo.isPlaying) moviendo.Play();
        }
        else{
            if(moviendo.isPlaying) moviendo.Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter(Collision collision)
    {
        golpe.Play();
    }
}
