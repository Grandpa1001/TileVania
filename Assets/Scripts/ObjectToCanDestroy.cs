using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToCanDestroy : MonoBehaviour
{

    public int object_health;
    private int maxStartHealth;
    public GameObject object_bloodEffect;
    private BoxCollider2D myBoxCollider;
    Animator objAnimator;
    // Start is called before the first frame update
    void Start()
    {
      myBoxCollider = GetComponent<BoxCollider2D>();
      objAnimator = GetComponent<Animator>();
      maxStartHealth = object_health;
    }

    // Update is called once per frame
    void Update()
    {
        CheckObjectLife();
    }


    private void CheckObjectLife(){

      if(object_health <maxStartHealth *.3){
        objAnimator.SetTrigger("Hit25");
      }
      if(object_health <maxStartHealth *.5){
        objAnimator.SetTrigger("Hit50");
      }
      if(object_health <maxStartHealth *.8){
        objAnimator.SetTrigger("Hit75");
      }
      if(object_health <= 0){
        Destroy(gameObject);
      }
  }

  public void TakeDamage(int damage){
//uruchom muzyke przyjmowania obrazen
//enemy_dazedTime = enemy_startDazedTime;
//Instantiate(enemy_bloodEffect, transform.position, Quaternion.identity);
object_health -= damage;
Debug.Log("Pegs ["+object_health.ToString() +"] i otrzymalem ["+damage.ToString());
  }



}
