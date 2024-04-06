using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set; }

    public HUD hud;

    private int vidas = 3;



    void Awake(){
        if(Instance == null){
            Instance = this;
        } else{
            Debug.Log("Mas de un Game Manager");
        }
    }

    public void perderVida()
    {
        vidas -=1;
        hud.DesactivarVida(vidas);
        if(vidas == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public bool RecuperarVida(){
        if(vidas == 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }

}
