using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
public static SaveManager Instance { set;get;}
  public SaveState state;



  private void Awake(){
    DontDestroyOnLoad(gameObject);
    Instance = this;
    Load();

    Debug.Log(HelperScript.Serialize<SaveState>(state));


  }
  //save the whole state of this saveState script to the player pref
public void Save(){
    PlayerPrefs.SetString("save", HelperScript.Serialize<SaveState>(state));

}

public void Load(){
  if(PlayerPrefs.HasKey("app")){
    state = HelperScript.Deserialize<SaveState>(PlayerPrefs.GetString("app"));
    Debug.Log("Załadowano istniejacy");
  }else{
    state = new SaveState();
    Save();
    Debug.Log("Nie znaleziono zapisu");
  }
}





}
