using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelSettings : MonoBehaviour
{

  public int numberCurrentLevel;
  private GameObject FireBallUI;
  private GameObject BowUI;
  private GameObject SwordUI;
  private GameObject JumpUI;
  private GameObject KnobUI;
  private GameObject KnobBackgroundUI;
  private GameObject UI_Canvas;



  public int StartScreen;
  public int MainMenu;
  public int Poziom_1_1;
  public int Poziom_1_2;
//..
  public  int EndScreen;


    void Start()
    {

      KnobUI = GameObject.Find("GameSession/Joystick canvas/Knob");
      KnobBackgroundUI = GameObject.Find("GameSession/Joystick canvas/KnobBackground");
      JumpUI = GameObject.Find("GameSession/Joystick canvas/Button_Jump");
      FireBallUI = GameObject.Find("GameSession/Joystick canvas/Button_FireBall");
      BowUI = GameObject.Find("GameSession/Joystick canvas/Button_Arrow");
      SwordUI= GameObject.Find("GameSession/Joystick canvas/Button_Sword");
      UI_Canvas = GameObject.Find("GameSession/UI_Canvas");
    }

void Update(){
  numberCurrentLevel =  SceneManager.GetActiveScene().buildIndex;


  if(numberCurrentLevel == StartScreen ){
    UI_Canvas.SetActive(false);
    KnobUI.SetActive(false);
    KnobBackgroundUI.SetActive(false);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(false);
    JumpUI.SetActive(false);
    }

  if(numberCurrentLevel == MainMenu ){
    UI_Canvas.SetActive(false);
    KnobUI.SetActive(false);
    KnobBackgroundUI.SetActive(false);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(false);
    JumpUI.SetActive(false);
}

  // Pierwszy Poziom tutorial skoku
  if(numberCurrentLevel == Poziom_1_1){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(false);
  }

}

  public void StartFirstLevel(){
	SceneManager.LoadScene(Poziom_1_1);
}

public void StartNextLevel(){
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

public void LoadMainMenu(){
	//navi_MainMenu = GameObject.Find("GameSession").GetComponent<LevelSettings>().MainMenu;
	SceneManager.LoadScene(MainMenu);
}

public void ExitGame(){
Debug.Log("EndGame");
	 Application.Quit();
}

public void GotoExitGameView(){
	SceneManager.LoadScene(EndScreen);
}



}
