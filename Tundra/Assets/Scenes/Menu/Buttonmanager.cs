using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonmanager : MonoBehaviour
{
    public GameObject Sensslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Sensslider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Sensivity", 1);
    }

    public void Play(string level)
    {
        Application.LoadLevel(level);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options(GameObject optionspanel)
    {
        Debug.Log("Options");
        optionspanel.SetActive(true);
    }

    public void ChangeSens()
    {
        var sens = Sensslider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Sensivity", sens);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false); 
    }

    public void Resume(GameObject player)
    {
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible= false;
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<ActionScript>().PauseCanvas.SetActive(false);
    }
}
