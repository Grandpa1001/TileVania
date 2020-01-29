using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
  [Tooltip ("Jednostka gry co sekunde")]
  [SerializeField] float scrollRate = 0.2f;

     void Update()
     {
       float yMove = scrollRate * Time.deltaTime;
         transform.Translate(new Vector2(0f, yMove));
     }
}
