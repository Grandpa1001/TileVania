using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class platform : MonoBehaviour
{
private float waitTime;
private float waitTime2;

 [Header("Poruszanie")]
public bool moving;
public float speed;
public int startingPoint;
public Transform[] points;

private int i;
private PlatformEffector2D effector;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        if(moving == true){
        transform.position = points[startingPoint].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moving == true){


            if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if(i==points.Length)
                {
                    i=0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);


        }


        if(waitTime >0){
          waitTime -= Time.deltaTime;
        }

        if(waitTime2 >0){
          waitTime2 -= Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            if(waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
                waitTime2 = 0.2f;
            }
        }
        if(effector.rotationalOffset ==180f && waitTime2 <= 0){

                effector.rotationalOffset = 0f;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
        // Debug.Log ("pojawia sie kolizja");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }


}
