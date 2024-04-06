using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioDeteccion : MonoBehaviour
{
    public Transform player;
    public Image panelImage; // Referencia al componente de imagen del panel
    public float maxAlpha = 0.8f; // El valor máximo de alpha al que quieres que llegue el panel
    public float alphaChangeSpeed = 0.5f; // La velocidad a la que cambia el alpha del panel
    public string sceneToLoad; // El nombre de la escena a la que quieres cambiar

    private bool playerDetected = false;

    void Update()
    {
        if (playerDetected)
        {
            // Incrementar gradualmente el alpha del panel hasta alcanzar maxAlpha
            if (panelImage != null)
            {
                panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, Mathf.MoveTowards(panelImage.color.a, maxAlpha, alphaChangeSpeed * Time.deltaTime));
            }
            else
            {
                Debug.LogError("Imagen del panel no asignada.");
            }

            // Si el alpha llega al máximo, cargar la nueva escena
            if (panelImage != null && panelImage.color.a == maxAlpha)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else
        {
            // Disminuir gradualmente el alpha del panel hasta llegar a 0
            if (panelImage != null)
            {
                panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, Mathf.MoveTowards(panelImage.color.a, 0f, alphaChangeSpeed * Time.deltaTime));
            }
            else
            {
                Debug.LogError("Imagen del panel no asignada.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("InvisiblePlayer"))
        {
            playerDetected = false;
        }
    }

}
