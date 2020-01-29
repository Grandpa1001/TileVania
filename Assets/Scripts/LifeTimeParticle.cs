using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeParticle : MonoBehaviour
{

public float destroyTime = 5;
void Update () {
   Destroy(gameObject, destroyTime);
 }



}
