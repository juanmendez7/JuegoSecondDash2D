    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Invisbilidad : MonoBehaviour
{

   public float invisibleOpacity = 0.2f; // Opacidad cuando el personaje está invisible
    private float originalOpacity; // Opacidad original del sprite
    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI invisibilityCountdownText;
    public TextMeshProUGUI cooldownCountdownText;
    private bool isCountingDownInvisibility = false;
    private bool isCountingDownCooldown = false;
    private bool canBecomeInvisible = true; // Controla si el personaje puede volverse invisible
    private float invisibilityCountdownTimer = 0f;
    private float cooldownCountdownTimer = 0f;

     private string originalTag;
     private Animator animator;

    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
        originalOpacity = spriteRenderer.color.a; // 
         originalTag = gameObject.tag;
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

if (isCountingDownInvisibility)
        {
            invisibilityCountdownTimer -= Time.deltaTime;
            if (invisibilityCountdownTimer <= 0f)
            {
                isCountingDownInvisibility = false;
                RestoreOriginalOpacity();
                RestoreOriginalTag();
                invisibilityCountdownText.gameObject.SetActive(false);
                StartCooldown();
            }
            else
            {
                invisibilityCountdownText.text = Mathf.CeilToInt(invisibilityCountdownTimer).ToString(); // Actualiza el texto del contador
            }
        }

        if (isCountingDownCooldown)
        {
            cooldownCountdownTimer -= Time.deltaTime;
            if (cooldownCountdownTimer <= 0f)
            {
                isCountingDownCooldown = false;
                cooldownCountdownText.gameObject.SetActive(false);
                canBecomeInvisible = true; // Restablece la capacidad de volverse invisible
            }
            else
            {
                cooldownCountdownText.text = Mathf.CeilToInt(cooldownCountdownTimer).ToString(); // Actualiza el texto del contador
            }
        }

        // Verifica si se presiona la tecla "X" y si el personaje puede volverse invisible
        if (Input.GetKeyDown(KeyCode.Z) && canBecomeInvisible)
        {

            ChangeTag("InvisiblePlayer");

            
            StartCoroutine(PlayInvisibilityAnimation());
            // Cambia la opacidad del sprite del personaje
            StartCoroutine(ChangeOpacityWithTimer(invisibleOpacity, 5f));
            canBecomeInvisible = false; // Desactiva la capacidad de volverse invisible hasta que se complete el contador
        }
    }


    IEnumerator ChangeOpacityWithTimer(float targetOpacity, float duration)
    {
        isCountingDownInvisibility = true;
        invisibilityCountdownTimer = duration;
        invisibilityCountdownText.gameObject.SetActive(true);

        // Cambia la opacidad del sprite del personaje
        ChangeOpacity(targetOpacity);

        // Espera durante 'duration' segundos
        yield return new WaitForSeconds(duration);

        // Restaura la opacidad original
        RestoreOriginalOpacity();
    }

     void ChangeOpacity(float opacity)
    {
        Color newColor = spriteRenderer.color;
        newColor.a = opacity;
        spriteRenderer.color = newColor;
    }

     void RestoreOriginalOpacity()
    {
        ChangeOpacity(originalOpacity);
        StartCooldown();
    }

        void StartCooldown()
    {
        isCountingDownCooldown = true;
        cooldownCountdownTimer = 10f; // 10 segundos de enfriamiento
        cooldownCountdownText.gameObject.SetActive(true);
    }

        void ChangeTag(string newTag)
    {
        gameObject.tag = newTag;
    }

    void RestoreOriginalTag()
    {
        gameObject.tag = originalTag;
    }

       IEnumerator PlayInvisibilityAnimation()
    {
        // Aquí debes llamar a tu animación de invisibilidad. 
        // Por ejemplo, si estás usando animaciones de Unity:
        // GetComponent<Animator>().SetTrigger("Invisibility");
        animator.SetBool("Invisible", true);

        // Espera hasta que la animación termine
        yield return new WaitForSeconds(5f); // Cambia 0.5f al tiempo que dure tu animación de invisibilidad

        animator.SetBool("Invisible", false);
        // Aquí puedes agregar código para volver a la animación original una vez que la invisibilidad haya terminado
        // Por ejemplo, si estás usando animaciones de Unity:
        // GetComponent<Animator>().SetTrigger("ReturnToNormal");
    }
}
