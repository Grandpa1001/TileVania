using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickUp : MonoBehaviour {


[SerializeField] AudioClip swordPickUpSFX;
private GameObject SwordUI;

// By odtwarzac muzyke dodaj to co ponizej jako skrypt nadrzedny do obiektu
//kolizyjnego nastepnie dodaj do niego audiosourca pustego
public void OnTriggerEnter2D(Collider2D collision)
		{
      SwordUI = GameObject.Find("GameSession/Joystick canvas/Button_Sword");
      SwordUI.SetActive(true);
			//	FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
			//	AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
				Destroy(gameObject);
		}
}
