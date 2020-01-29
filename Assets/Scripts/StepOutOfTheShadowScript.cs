using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepOutOfTheShadowScript : MonoBehaviour
{


  public Texture shadow;
  public float target = 0;
  public float duration = 1;
  private float alpha = 1;

  void Start()
  {
  //  shadow  = GetComponent<Texture>();
  }
  void Update(){
      if(duration < 0){
          duration = 0.001f;
      }
      alpha = Mathf.MoveTowards(alpha, target, (1 / duration) * Time.deltaTime);

      if(alpha == 0){
        Destroy(gameObject);
      }
  }

  void OnGUI()
  {
      GUI.color = new Color(0, 0, 0, alpha);
      GUI.depth = 0;
      GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), shadow);
      GUI.color = Color.clear;
  }


}









  /*
    // Start is called before the first frame update
    public Image shadow;
    public float target = 0;
    public float duration = 1;
    private float alpha = 1;

    void Start()
    {
      shadow  = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.Mouse0))
    {
        shadow.color = new Color(0f,0f,0f,0f);
    }

    if(duration < 0){
        duration = 0.001f;
    }
    alpha = Mathf.MoveTowards(alpha, target, (1 / duration) * Time.deltaTime);



    }
} */
