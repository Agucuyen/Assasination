using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Cameras;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public GameObject Patron;
    public GameObject KameraObjesi;
        
    public void Kazandin()
    {
        KameraObjesi.GetComponent<FreeLookCam>().enabled = false;
        Patron.GetComponent<Animator>().Play("Patron_kaybetme");        
        WinPanel.SetActive(true);

    }
    public void Kaybettin()
    {
        KameraObjesi.GetComponent<FreeLookCam>().enabled = false;
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void yenidenoyna()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

    }
    public void Anamenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
