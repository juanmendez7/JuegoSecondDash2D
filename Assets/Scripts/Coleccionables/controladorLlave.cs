using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorLlave : MonoBehaviour
{

    public bool Adentro;

    public Canvas activarCanvas;

    public GameObject llave;

     public Animator puertaAnimator;

        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Adentro = true;
            Debug.Log("estamos dentro");
            activarCanvas.gameObject.SetActive(true);
        }
    }


       void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Adentro = false;
            Debug.Log("Estamos fuera");
            activarCanvas.gameObject.SetActive(false);
        }
    }


        void Update(){
        if(Adentro == true && Input.GetKeyDown(KeyCode.C))
        {

            Destroy(this.gameObject);

            Debug.Log("llave recogida");

             if (puertaAnimator != null)
            {
                puertaAnimator.SetBool("AbrirPuerta", true);
            }
            
        }
    }
    



}
