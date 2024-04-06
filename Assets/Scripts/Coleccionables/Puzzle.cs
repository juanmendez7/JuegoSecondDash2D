using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
   
    public bool Adentro1;

    public Canvas activarCanvas1;


public GameObject Texto1;
    

    

      

       public GameObject puzzleRealX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {


            Adentro1 = true;
            Debug.Log("estamos dentro");
            activarCanvas1.gameObject.SetActive(true);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Adentro1 = false;
            Debug.Log("Estamos fuera");
            activarCanvas1.gameObject.SetActive(false);
        }
    }


        void Update(){
        if(Adentro1 == true && Input.GetKeyDown(KeyCode.X))
        {

            puzzleRealX.SetActive(true);
            Texto1.SetActive(false);
            
        }
    }

}
