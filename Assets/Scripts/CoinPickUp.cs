using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {


[SerializeField] AudioClip coinPickUpSFX;
[SerializeField] int pointsForCoinPickup;

// By odtwarzac muzyke dodaj to co ponizej jako skrypt nadrzedny do obiektu
//kolizyjnego nastepnie dodaj do niego audiosourca pustego
public void OnTriggerEnter2D(Collider2D collision)
		{
				FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
				//AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
				Destroy(gameObject);
		}
}
