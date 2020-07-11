using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamaraMovement : MonoBehaviour
{
   public Transform target;

   public Vector3 Offset;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.position=new Vector3(transform.position.x, target.position.y,target.position.z)+Offset;
    }
}
