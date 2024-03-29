﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public GameObject projectile;
    public Vector2 velocity;
    bool canShoot = true;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public float cooldown = 1f;


    void Start(){}
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.T) && canShoot){
      GameObject go = (GameObject)  Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
      go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);
}}

IEnumerator Canshoot(){
  canShoot = false;
  yield return new WaitForSeconds(cooldown);
  canShoot = true;
}


}
