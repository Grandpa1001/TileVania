using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemy_health;
    public float enemy_speed;
    public GameObject enemy_bloodEffect;
    public float enemy_startDazedTime;

    private Animator enemy_anim;
    private float enemy_dazedTime;
    private Rigidbody2D myRigidBody;
    private CapsuleCollider2D myCapsuleCollider;

    void Start()
    {
      enemy_anim = GetComponent<Animator>();
      myRigidBody = GetComponent<Rigidbody2D>();
      myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    	void Update ()
      {
      CheckEnemyLife();
      CheckEnemyDazed();
      }

      private void CheckEnemyLife(){
        if(enemy_health <=0){
          Destroy(gameObject);
        }FindGround();
      }


      private void CheckEnemyDazed(){
        if(enemy_dazedTime <= 0){enemy_speed = 1;
        }else{  enemy_speed =0;
                enemy_dazedTime -=Time.deltaTime;
              }
            }


      public void TakeDamage(int damage){
  //uruchom muzyke przyjmowania obrazen
    enemy_dazedTime = enemy_startDazedTime;
    Instantiate(enemy_bloodEffect, transform.position, Quaternion.identity);
    enemy_health -= damage;
    Debug.Log("Enemy ["+enemy_health.ToString() +"] i otrzymalem ["+damage.ToString());
      }


      bool IsFacingRight(){return transform.localScale.x > 0;}

      private void FindGround(){
      if(IsFacingRight()){
      	myRigidBody.velocity = new Vector2(enemy_speed, 0f);
        }else
      			myRigidBody.velocity = new Vector2(-enemy_speed, 0f);
          }

      	private void OnTriggerExit2D(Collider2D collision){
      		if(myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
              myRigidBody.velocity= Vector2.zero;
      	     }transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)),1f);
           }

}
