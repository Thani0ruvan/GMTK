using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformManager : MonoBehaviour
{
   public Transform target;

public RainManager rainManager;
    // Update is called once per frame
    void Update()
    {
        if(target.position.z>750f)
        {
         rainManager.StopEveryThing();
        
       StartCoroutine(ResetPos());

        }
    }

    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(3f);
        target.position=new Vector3 (target.position.x,target.position.y,0f);

        rainManager.StartEveryThing();
    }
}
