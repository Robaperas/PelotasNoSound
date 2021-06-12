using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerControler : MonoBehaviour
{
    private Rigidbody rb;
    //Creamos una variable para asociar la fuente de sonido cuando el objeto bouncer se está moviendo
    private AudioSource moviendo;
    //Creamos un variable para asociar la fuente de sonido cuando el objeto bouncer golpea con algo
    private AudioSource golpe;
    //Creamos una lista de fuentes de sonido que están asociadas al objeto bouncer
    private AudioSource[] sources;
    
    /*Creamos una variable pública que define la velocidad del objeto bouncer igual a 5
    Al ser una variable publica el valor se puede moodificar desde el interfaz de Unity*/
    public float speed = 5.0f;
    //Creamos una variable donde guardar la velocidad del objeto Bouncer
    private float instspeed = 0;
    //Creamos una variable donde guardar el valor del Pitch de bouncer
    private float newpitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el componente rigidbody asociado al objeto Bouncer
        rb = GetComponent<Rigidbody>();
        //Inicializamos la lista de sonidos asociadas al objeto bouncer
        sources = GetComponents<AudioSource>();
        //asociamos a la variable moviendose la primera fuente de sonido de la lista
        moviendo = sources[0];
        //asociamos a la variable golpte la segunda fuente de sonido de la lista
        golpe = sources[1];
        
    }
    void FixedUpdate() 
    {
        /*obtenemos la velocidad instantanea del objeto
        si el objeto se está moviendo, si la velocidad > 0, se calcula el nuevo pitch que depende de la velocidad
        y si la fuente de sonido no está sonando, la hace sonar
        si el objeto esta parado, deja de sonar la fuente de sonido*/
        instspeed = rb.velocity.magnitude;
        if(instspeed > 0)
        {
            /*Calculamos el pitch que depende de la velocidad
            cuando la velocidad se acerque a 0 el pitch será aproximadamente 1
            cuando la velocidad sea muy grande el pitch será aproximadamente 1,5*/

             //newpitch = (float)(1 + 0.5f * (1 - Mathf.Exp(-1*instspeed)));
             newpitch = (float)(1 + 0.5f * (1 - (1/(1+instspeed))));
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
        //Cuando detecta un choque con otro objeto emitimos el sonido del golpe
        golpe.Play();
    }
}
