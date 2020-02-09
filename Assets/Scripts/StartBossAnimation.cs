using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossAnimation : MonoBehaviour
{
    public GameObject boss;

  public void OnTriggerEnter2D(Collider2D collision)
  		{
            FindObjectOfType<LevelSettings>().TurnOffUIChange();
            boss.GetComponent<Animator>().SetTrigger("Enter");

            Destroy(gameObject);

  			}
}
