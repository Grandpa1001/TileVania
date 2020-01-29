using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowLife : MonoBehaviour
{
  CircleCollider2D boxHitArrow;
  Rigidbody2D myRigidBody;

  public Transform arrow_attackPos;
  public LayerMask arrow_whatIsEnemies;
  public float arrow_attackRangeX;
  public float arrow_attackRangeY;
  public int arrow_damage;



  void Start()
  {
        boxHitArrow = this.GetComponent<CircleCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
  }


  void Update()
  {
      HitGround();
      HitEnemy();
      FlipSprite();
  }


  private void HitGround()
  {
    if(boxHitArrow.IsTouchingLayers(LayerMask.GetMask("Ground"))){
      myRigidBody.velocity= Vector2.zero;
      return;}
  }
  private void HitEnemy(){
    if(boxHitArrow.IsTouchingLayers(LayerMask.GetMask("Enemy"))){
      Hit_Arrow();
      DestroyObject(gameObject);
      //FindObjectOfType<Enemy>().ProcessEnemyDeath();
      return;}
    }



  private void FlipSprite(){
bool fireBallHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
if (fireBallHasHorizontalSpeed)
{
  transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x), 1f);
}
}

public void Hit_Arrow(){
			Debug.Log("ARROW hit" + arrow_damage.ToString());
			Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(arrow_attackPos.position, new Vector2(arrow_attackRangeX, arrow_attackRangeY),0,arrow_whatIsEnemies);
			for (int i=0; i < enemiesToDamage.Length; i++){
			enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(arrow_damage);
			}
		}

void OnDrawGizmosSelected(){
	Gizmos.color = Color.red;
	Gizmos.DrawWireCube(arrow_attackPos.position, new Vector3(arrow_attackRangeX, arrow_attackRangeY,1));
}

}
