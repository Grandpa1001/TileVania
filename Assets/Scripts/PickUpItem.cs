using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

[SerializeField] AudioClip swordPickUpSFX;
private GameObject UI;
public bool Sword;
public bool Fire;
public bool Bow;

// By odtwarzac muzyke dodaj to co ponizej jako skrypt nadrzedny do obiektu
//kolizyjnego nastepnie dodaj do niego audiosourca pustego
public void OnTriggerEnter2D(Collider2D collision)
		{
			if(Sword){
      UI = GameObject.Find("GameSession/Joystick canvas/Button_Sword");
      UI.SetActive(true);
			//	FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
			//	AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
				Destroy(gameObject);
			}
			if(Fire){
			UI = GameObject.Find("GameSession/Joystick canvas/Button_FireBall");
			UI.SetActive(true);
			//	FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
			//	AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
				Destroy(gameObject);
			}
			if(Bow){
			UI = GameObject.Find("GameSession/Joystick canvas/Button_Arrow");
			UI.SetActive(true);
			//	FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
			//	AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
				Destroy(gameObject);
			}


			}
		}
