using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anamenukontrol : MonoBehaviour
{
    public GameObject EminmisinPanel;
    void Start()
    {
        
    }

    public void OyunaBasla()
    {
        SceneManager.LoadScene(1);

    }
    public void cikis()
    {
        EminmisinPanel.SetActive(true);
    }

    public void cikisCevap(string cevap)
    {
        switch (cevap)
        {
            case "evet":                
                Application.Quit();
                break;

            case "hayir":
                EminmisinPanel.SetActive(false);
                break;

        }

    }
}
