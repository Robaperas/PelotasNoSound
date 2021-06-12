using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueController : MonoBehaviour
{
    //Creamos una variable para la fuente de sonido del golpe
    private AudioSource golpe;
    //Creamos una variable para el pitch del sonido del bloque
    private float newpitch = 0;
    //creamos una variable para el tamaño del del bloque
    private float bloquesize;
    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la variable golpe con la fuente de sonido asociada al objeto bloque
        golpe = GetComponent<AudioSource>();
        //Calculamos el volumen del bloque
        bloquesize = transform.localScale.x * transform.localScale.y * transform.localScale.z;
        
        /*Calculamos el pitch que depende del tamaño del bloque
            cuando el tamaño del bloque se acerque a 0 el pitch será 2
            cuando el tamaño del bloque > 28 el pitch será aproximadamente 0 y por tanto no sonará
            el bloque de mayor tamaño mide 24*/
                        /*newpitch = (float)(1 + 0.5f * ( Mathf.Exp (-1*bloquesize)));
                        //newpitch = (float)(1.8f - (1 -(3/(1+(bloquesize)))));
                    //newpitch = (float)(1 +3f/(1.2*(bloquesize+3)));*/
        newpitch = (float)(2 -0.07f*bloquesize);
        golpe.pitch = newpitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnCollisionEnter(Collision collision)
    {
        //Cuando detecta una colision con otro objeto, reproduce el sonido del golpe
        golpe.Play();
    }
}
