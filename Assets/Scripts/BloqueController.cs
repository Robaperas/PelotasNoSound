using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueController : MonoBehaviour
{
    private AudioSource golpe;
    private float newpitch = 0;
    private float bloquesize;
    // Start is called before the first frame update
    void Start()
    {
        golpe = GetComponent<AudioSource>();
        bloquesize = transform.localScale.x * transform.localScale.y * transform.localScale.z;
        newpitch = (float)(1 + 0.5f * ( Mathf.Exp(-1*bloquesize)));
        golpe.pitch = newpitch;       
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
