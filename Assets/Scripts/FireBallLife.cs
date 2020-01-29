using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallLife : MonoBehaviour
{

    CircleCollider2D boxHitBall;
    Rigidbody2D myRigidBody;

    public Transform fireball_attackPos;
    public LayerMask fireball_whatIsEnemies;
    public float fireball_attackRangeX;
    public float fireball_attackRangeY;
    public int fireball_damage;





    void Start()
    {
          boxHitBall = this.GetComponent<CircleCollider2D>();
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
      if(boxHitBall.IsTouchingLayers(LayerMask.GetMask("Ground"))){
        DestroyObject(gameObject);
        return;}
    }
    private void HitEnemy(){
      if(boxHitBall.IsTouchingLayers(LayerMask.GetMask("Enemy"))){
       DestroyObject(gameObject);

        Hit_FireBall();
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


public void Hit_FireBall(){
			Debug.Log("FIREBALL DMG:" + fireball_damage.ToString());
			Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(fireball_attackPos.position, new Vector2(fireball_attackRangeX, fireball_attackRangeY),0,fireball_whatIsEnemies);
			for (int i=0; i < enemiesToDamage.Length; i++){
			enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(fireball_damage);
			}
		}

void OnDrawGizmosSelected(){
	Gizmos.color = Color.red;
	Gizmos.DrawWireCube(fireball_attackPos.position, new Vector3(fireball_attackRangeX, fireball_attackRangeY,1));
}





}
