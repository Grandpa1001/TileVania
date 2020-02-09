using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ModalWindowSettings : MonoBehaviour
{

  private GameObject UIModalWindow;
  private GameObject ModalL_1_2;
  private GameObject GameSession;


    void Start()
    {

              UIModalWindow = GameObject.Find("CanvasModalSelectLevel");
              ModalL_1_2 = GameObject.Find("Modal/Modal_Level_1_2");
              UIModalWindow.SetActive(false);
              //bLVL11= true;
            //  dbLVL12= FindObjectOfType<GameSession>().GetComponent<LevelSettings>().bLVL12;;
            //  if(!dbLVL12){ModalL_1_2.SetActive(false);}else{ModalL_1_2.SetActive(true);}
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
