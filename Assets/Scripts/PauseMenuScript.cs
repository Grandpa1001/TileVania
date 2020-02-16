using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    private GameObject UIPauseMenu;
    // Start is called before the first frame update
    void Start()
    {
      UIPauseMenu = GameObject.Find("GameSession/PauseMenu/PauseCanvas");
      UIPauseMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToMainMenu(){
      SceneManager.LoadScene("Main Menu");
      UIPauseMenu.SetActive(false);
      Time.timeScale = 1;
      FindObjectOfType<LevelSettings>().TurnONUIChange();
      }

      public void ExitGameView(){
      	SceneManager.LoadScene("Level_EndScreen");
        UIPauseMenu.SetActive(false);
        Time.timeScale = 1;
      }

    public void OpenPauseMenu(){
        UIPauseMenu.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<LevelSettings>().TurnOffUIChange();
    }
    public void ContinueGamePauseMenu(){
        UIPauseMenu.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<LevelSettings>().TurnONUIChange();
    }
}
