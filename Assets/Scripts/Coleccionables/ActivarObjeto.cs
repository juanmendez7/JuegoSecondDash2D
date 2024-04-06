using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    public bool Adentro2;
    public GameObject OsoAviso;

    public GameObject AyudaOso;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            Adentro2 = true;
            OsoAviso.SetActive(true);

        }

    }


    void Update()
    {
        if(Adentro2 == true && Input.GetKeyDown(KeyCode.X))
        {
            AyudaOso.gameObject.SetActive(true);
            OsoAviso.gameObject.SetActive(false);
        }
    }
}
