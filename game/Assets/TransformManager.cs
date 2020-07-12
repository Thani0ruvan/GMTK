using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransformManager : MonoBehaviour
{
   public Transform target;


float NextUpdatePos=1250;


float UpdatingPos=250;

float Destroytimer=60f;

 

 public GameObject LandPrefab;

 public Transform ReferenceTransform;


    // Update is called once per frame
    void Update()
    {
      if(target.position.z>=UpdatingPos)
      {
        Vector3 InstanPos=new Vector3(ReferenceTransform.transform.position.x,ReferenceTransform.transform.position.y,NextUpdatePos);

        GameObject Land=Instantiate(LandPrefab,InstanPos,Quaternion.identity);

       

        NextUpdatePos+=250;

        UpdatingPos+=250;

        Destroy(Land,Destroytimer);
      }

   
    }

    
}
