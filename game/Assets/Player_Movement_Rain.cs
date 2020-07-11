using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Rain : MonoBehaviour
{
    public Rigidbody PlayerRB;
    float velocity=50;
  
    bool IsTurning;


    public float TurningValue=10f;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
        transform.rotation= Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,-(TurningValue),0),0.35f);

         PlayerRB.velocity= new Vector3(-10,0,PlayerRB.velocity.z);

        IsTurning=true;
        }
        if(Input.GetKey(KeyCode.D)){
             transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,TurningValue,0),.35f);

              PlayerRB.velocity= new Vector3(10,0,PlayerRB.velocity.z);

             IsTurning=true;
        }

        if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)){
        IsTurning=false;
        }


        if (!IsTurning)
        {
              PlayerRB.velocity= Vector3.Slerp(PlayerRB.velocity, transform.forward+new Vector3(0,0,velocity),0.1f);

              transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,0,0),0.1f);
        }
    }
void FixedUpdate()
{
   PlayerRB.velocity= transform.forward+ new Vector3(PlayerRB.velocity.x,0,velocity);

}
 

}
