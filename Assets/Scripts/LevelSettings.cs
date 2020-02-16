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
  private GameObject UIPauseMenu;


  public int StartScreen;
  public int MainMenu;
  public int Poziom_1_1;
  public int Poziom_1_2;
  public int Poziom_1_3;
  public int Poziom_1_4;
  public int Poziom_2_1;
  public int Poziom_2_2;
  public int Poziom_2_3;
  public int Poziom_2_4;
  public int Poziom_3_1;
  public int Poziom_3_2;
  public int Poziom_3_3;
  public int Poziom_3_4;
  public int Poziom_TEST;
//..
  public  int EndScreen;

  public bool TurnOffUIAll = false;

    void Start()
    {

      KnobUI = GameObject.Find("GameSession/Joystick canvas/Knob");
      KnobBackgroundUI = GameObject.Find("GameSession/Joystick canvas/KnobBackground");
      JumpUI = GameObject.Find("GameSession/Joystick canvas/Button_Jump");
      FireBallUI = GameObject.Find("GameSession/Joystick canvas/Button_FireBall");
      BowUI = GameObject.Find("GameSession/Joystick canvas/Button_Arrow");
      SwordUI= GameObject.Find("GameSession/Joystick canvas/Button_Sword");
      UI_Canvas = GameObject.Find("GameSession/UI_Canvas");
      UIPauseMenu = GameObject.Find("GameSession/Joystick canvas/PauseMenu");
    }

public void TurnOffUIChange(){TurnOffUIAll = true;}
public void TurnONUIChange(){TurnOffUIAll = false;}

void Update(){
CheckWhatLevelIsNow();


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



void CheckWhatLevelIsNow(){
  numberCurrentLevel =  SceneManager.GetActiveScene().buildIndex;

  if(TurnOffUIAll){
    UI_Canvas.SetActive(false);
    KnobUI.SetActive(false);
    KnobBackgroundUI.SetActive(false);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(false);
    JumpUI.SetActive(false);
    UIPauseMenu.SetActive(false);
    }else{

  if(numberCurrentLevel == StartScreen ){
    UI_Canvas.SetActive(false);
    KnobUI.SetActive(false);
    KnobBackgroundUI.SetActive(false);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(false);
    JumpUI.SetActive(false);
    UIPauseMenu.SetActive(false);
    }


  if(numberCurrentLevel == MainMenu ){
    UI_Canvas.SetActive(false);
    KnobUI.SetActive(false);
    KnobBackgroundUI.SetActive(false);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(false);
    JumpUI.SetActive(false);
    UIPauseMenu.SetActive(false);
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
    UIPauseMenu.SetActive(true);
  }
    //Drugi Poziom Miecz
  if(numberCurrentLevel == Poziom_1_2){

    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    UIPauseMenu.SetActive(true);
    //SwordUI.SetActive(false); do zdobycia w tym poziomie
  }

  if(numberCurrentLevel == Poziom_1_3){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_1_4){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    BowUI.SetActive(false);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_2_1){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    UIPauseMenu.SetActive(true);
    //BowUI.SetActive(false); do zdobycia na tym poziomie
    SwordUI.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_2_2){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    BowUI.SetActive(true);
    UIPauseMenu.SetActive(true);
    SwordUI.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_2_3){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    BowUI.SetActive(true);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_2_4){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(false);
    BowUI.SetActive(true);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_3_1){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
  //  FireBallUI.SetActive(false); do zdobycia na tym poziomie
    BowUI.SetActive(true);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_3_2){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(true);
    BowUI.SetActive(true);
    UIPauseMenu.SetActive(true);
    SwordUI.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_3_3){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(true);
    BowUI.SetActive(true);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }
  if(numberCurrentLevel == Poziom_3_4){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(true);
    BowUI.SetActive(true);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }

  if(numberCurrentLevel == Poziom_TEST){
    UI_Canvas.SetActive(true);
    KnobUI.SetActive(true);
    KnobBackgroundUI.SetActive(true);
    JumpUI.SetActive(true);
    FireBallUI.SetActive(true);
    BowUI.SetActive(true);
    SwordUI.SetActive(true);
    UIPauseMenu.SetActive(true);
  }

}

}

}
