using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CooldownSkill : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Ustawienia Arrow")]
    public Image arrow_imageCooldown;
    private float arrow_cooldown;
    bool arrow_isCooldown;


    [Header("Ustawienia FireBall")]
    public Image fireball_imageCooldown;
    private float fireball_cooldown;
    bool fireball_isCooldown;


    // Update is called once per frame
    void Update()
    {
    FireballUpdate();
    ArrowUpdate();
    }

    public  void FireBallCooldown(float cooldown){
      fireball_isCooldown = true;
      fireball_cooldown = cooldown;
    }
    public  void ArrowCooldown(float cooldown){
      arrow_isCooldown = true;
      arrow_cooldown = cooldown;
    }



    private void FireballUpdate(){
      if(fireball_isCooldown){
        fireball_imageCooldown.fillAmount +=1/fireball_cooldown * Time.deltaTime;
        if(fireball_imageCooldown.fillAmount >=1){
          fireball_imageCooldown.fillAmount =0;
          fireball_isCooldown = false;
        }
      }
    }

    private void ArrowUpdate(){
      if(arrow_isCooldown){
        arrow_imageCooldown.fillAmount +=1/arrow_cooldown * Time.deltaTime;
        if(arrow_imageCooldown.fillAmount >=1){
          arrow_imageCooldown.fillAmount =0;
          arrow_isCooldown = false;
        }
      }
    }




    }
