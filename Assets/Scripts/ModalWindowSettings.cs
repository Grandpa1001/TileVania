using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ModalWindowSettings : MonoBehaviour
{

  private GameObject UIModalWindow;
  private GameObject GameSession;


    void Start()
    {
              UIModalWindow = GameObject.Find("CanvasModalSelectLevel");
              UIModalWindow.SetActive(false);
    }

    public void OpenWindowModalNow(){
        UIModalWindow.SetActive(true);
    }
    public void LoadChooseLevel(string choose){
      SceneManager.LoadScene("Level_"+choose);
      }
      public void CloseWindowModalNow(){
          UIModalWindow.SetActive(false);
      }

}
