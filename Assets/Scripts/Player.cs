using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class Player : MonoBehaviour {


//config Player
[Header("Player")]
[SerializeField] float runSpeed = 5f;
[SerializeField] float jumpSpeed = 5f;
[SerializeField] float climbSpeed = 5f;
[SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

//State
bool isAlive = true;

//Cached component refenreces
Rigidbody2D myRigidBody;
Animator myAnimator;
CapsuleCollider2D myBodyCollider2D;
BoxCollider2D myFeet;
float gravityScaleAtStart;

//Skills
[Header("Ustawienia FireBall")]
public GameObject fireball_projectile;
public Vector2 fireball_velocity;
//public KeyCode fireball_button;
bool canShoot = true;
public Vector2 offset = new Vector2(0.4f, 0.1f);
public float cooldownTime = 1;
public float nextFireTime = 0;

[Header("Ustawienia Łuku")]
public GameObject bow_projectile;
public Vector2 bow_velocity;
//public KeyCode bow_button;
public Vector2 bow_offset = new Vector2(0.4f, 0.1f);
public float bow_cooldownTime = 1;
public float bow_nextFireTime = 0;

[Header("Ustawienia Miecza")]
public float sword_startTimeBtwAttack;
public Transform sword_attackPos;
public LayerMask sword_whatIsEnemies;
public float sword_attackRangeX;
public float sword_attackRangeY;
public int sword_damage;
private float sword_timeBtwAttack;
public float timeDelayCheckLayers;
private float timeLocalCheckLayers;


//Message then methods
	void Start () {
 		myRigidBody = GetComponent<Rigidbody2D>();
 		myAnimator = GetComponent<Animator>();
		myBodyCollider2D = GetComponent<CapsuleCollider2D>();
		myFeet = GetComponent<BoxCollider2D>();
		gravityScaleAtStart = myRigidBody.gravityScale;

		timeLocalCheckLayers = 0f;

	}

	// Update is called once per frame
	void Update () {
		if(!isAlive){return;}
		Run();
		ClimbLadder();
		FlipSprite();
		Jump();
		Die();
		CooldownFireBall();
		CooldownBowShot();
		Hit_Sword();
	}

private void Run(){
	float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");// value is between -1 to +1
	Vector2 playerVelocity = new Vector2(controlThrow*runSpeed, myRigidBody.velocity.y);
	myRigidBody.velocity = playerVelocity;
	bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
	myAnimator.SetBool("Run", playerHasHorizontalSpeed);

}

private void ClimbLadder(){
	if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Climb"))){
		if(myAnimator != null && myAnimator.isActiveAndEnabled){
		myAnimator.SetBool("Climb", false);
		myRigidBody.gravityScale = gravityScaleAtStart;
		return;}
	}
	float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
	Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow*climbSpeed);
	myRigidBody.velocity = climbVelocity;
	myRigidBody.gravityScale = 0f;
	bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
	myAnimator.SetBool("Climb", playerHasVerticalSpeed);
}

private void Jump(){
	if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}
	if (CrossPlatformInputManager.GetButtonDown("Jump")){
		Debug.Log("skok");
		Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
		myRigidBody.velocity += jumpVelocityToAdd;
	}
}

private void Die(){
//wartosc czasowa i nastepnie dodawana  my opoznic kolejne sprawdzenie
		if(myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")) &&  timeLocalCheckLayers == 0){
		timeLocalCheckLayers = timeDelayCheckLayers;
		//myAnimator.SetTrigger("Die");
		StartCoroutine(Knockback(1f,deathKick,transform.position));
		FindObjectOfType<GameSession>().ProcessPlayerDeath();
		}
		if(timeLocalCheckLayers> 0){
		timeLocalCheckLayers-=Time.deltaTime;
		} else { timeLocalCheckLayers =0;}
}

		private void FlipSprite(){
bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
	if (playerHasHorizontalSpeed)
	{
		transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x), 1f);
	}
}


//FIREBALL SKILL METHOD
IEnumerator Canshoot(){
			canShoot = false;
		  yield  return new WaitForSeconds(cooldownTime);
			//CooldownFireBall();
			canShoot = true;
}
private void CooldownFireBall(){
	if (Time.time > nextFireTime){
			if(CrossPlatformInputManager.GetButtonDown("Fire3") && canShoot){
				UseFireBall();
			nextFireTime = Time.time + cooldownTime;}
	}
}
	private void UseFireBall(){
	float controlThrow = transform.localScale.x;
	myAnimator.SetTrigger("FireBall");
			Debug.Log("fireball");
	FindObjectOfType<UI_CooldownSkill>().FireBallCooldown(cooldownTime);
	GameObject go = (GameObject)  Instantiate(fireball_projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
	go.GetComponent<Rigidbody2D>().velocity = new Vector2(controlThrow * fireball_velocity.x, fireball_velocity.y);
}

//BOW SKILL METHOD
private void CooldownBowShot(){
	if (Time.time > bow_nextFireTime){
			if(CrossPlatformInputManager.GetButtonDown("Fire2") && canShoot){
				UseBowShot();
			bow_nextFireTime = Time.time + bow_cooldownTime;}
	}
}
private void UseBowShot(){
	float controlThrow = transform.localScale.x;
	myAnimator.SetTrigger("Arrow");
	FindObjectOfType<UI_CooldownSkill>().ArrowCooldown(bow_cooldownTime);
	GameObject go = (GameObject)  Instantiate(bow_projectile, (Vector2)transform.position + bow_offset * transform.localScale.x, Quaternion.identity);
	go.GetComponent<Rigidbody2D>().velocity = new Vector2(controlThrow * bow_velocity.x, bow_velocity.y);
}



public void Hit_Sword(){
	if(sword_timeBtwAttack <=0){
		//then you can sword_attackPos
		if(CrossPlatformInputManager.GetButtonDown("Fire1")){
			//dodaj animacje trzęsienia się
			Debug.Log("SWORD hit"+ sword_damage.ToString());
			myAnimator.SetTrigger("Sword");

			Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(sword_attackPos.position, new Vector2(sword_attackRangeX, sword_attackRangeY),0,sword_whatIsEnemies);
			for (int i=0; i < enemiesToDamage.Length; i++){
			enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(sword_damage);
			}
		}
		sword_timeBtwAttack = sword_startTimeBtwAttack;

	}else {
		sword_timeBtwAttack -=Time.deltaTime;
	}
}
void OnDrawGizmosSelected(){
	Gizmos.color = Color.red;
	Gizmos.DrawWireCube(sword_attackPos.position, new Vector3(sword_attackRangeX, sword_attackRangeY,1));
}

public IEnumerator Knockback(float knockDur, Vector2 knockbackPwr,  Vector3 knockbackDir){
float timer = 0;
while ( knockDur > timer){
timer+=Time.deltaTime;
myAnimator.SetTrigger("Damage");
		//stac i patrzec w prawo
		if(myRigidBody.velocity.x == 0 && transform.localScale.x > 0 && myRigidBody.velocity.y == 0){
			//float newknockbackPwrx = -knockbackPwr.x;
			myRigidBody.velocity = new Vector2 (0, 0);
			Debug.Log("stoje i patrze w prawo");
			myRigidBody.AddForce(new Vector3(0, knockbackDir.y + knockbackPwr.y,transform.position.z));
			}
			//stac i patrzec w lewo
		if(myRigidBody.velocity.x == 0 && transform.localScale.x < 0 && myRigidBody.velocity.y == 0){
			myRigidBody.velocity = new Vector2 (0, 0);
			myRigidBody.AddForce(new Vector3(0, knockbackDir.y + knockbackPwr.y,transform.position.z));
			Debug.Log("stoje i patrze w lewo");
			}
			//w powietrzu
			if(myRigidBody.velocity.y != 0){
				//myRigidBody.velocity = new Vector2 (0, 0);
				Debug.Log("Podrzucam");
				myRigidBody.AddForce(new Vector3(0, knockbackDir.y + knockbackPwr.y,transform.position.z));
				}
//TODo dodanie pozostalych 4 warunkow
//myRigidBody.velocity = new Vector2 (0, 0);
//myRigidBody.AddForce(new Vector3(knockbackDir.x * knockbackPwr.x, knockbackDir.y * knockbackPwr.y,transform.position.z));
	/*
			if(transform.localScale.x > 0){
			float newDeathKickX = deathKick.x;
			Vector2 deathKick2 = new Vector2 (-newDeathKickX, deathKick.y);
			myRigidBody.velocity = deathKick2;
			}else {
				myRigidBody.velocity = deathKick;
			}
			*/



}
	yield return 0;
}



}
