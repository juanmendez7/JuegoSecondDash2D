using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaMenu : MonoBehaviour
{

    public GameObject PausePanel1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Pause()
    {
        PausePanel1.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel1.SetActive(false);
        Time.timeScale = 1;
    }
}
