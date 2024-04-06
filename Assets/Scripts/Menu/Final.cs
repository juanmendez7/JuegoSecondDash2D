using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
   public string sceneToLoad; // Nombre de la escena a la que quieres teletransportarte

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que entró en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Teletransportar al jugador a la escena especificada
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
