using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{

bool IsStopEveryThing=false;

    #region Thunder
    public GameObject WarningSign;
    public GameObject ThunderPrefab;

    public Transform target;

    public float Z_Offset;


    public float X1;
     public float X2;

    public float Timer;
    float _Timer;

    float RandomTimer;

    #endregion
    
    #region Rain

public Player_Movement player_Movement;
public Player_Movement_Rain player_Movement_Rain;
    bool CanRain;

    float RainTime=10f;

    float _Raintime=10f;
    #endregion
    void Start()
    {
        _Timer=Timer;

        RandomTimer=Random.Range(1,3);

        CanRain= (Random.value>0.5f);
    }

   
    void Update()
    {
        if(IsStopEveryThing)return;

       if(!CanRain)StartCoroutine(ThunderFunc());

       StartCoroutine(ThunderRandom());

       StartCoroutine(ThunderRandom());

RainTime-=Time.deltaTime;
if(RainTime<0){ CanRain= (Random.value>0.5f); RainTime =_Raintime;}

       if(CanRain)
       {
        StartRain();
       }
       else
       {
           StopRain();
       }
    }

    IEnumerator ThunderFunc(){

   Timer-=Time.deltaTime;
    if(Timer<=0){  
    Timer=_Timer;

    Vector3 SpawnPoint =target.position+(Vector3.forward*Z_Offset);

      GameObject  WarningObj=Instantiate(WarningSign,SpawnPoint,Quaternion.identity);
      WarningObj.transform.rotation=Quaternion.Euler(90,0,0);

       yield return new WaitForSeconds(1f);

       Debug.Log("Yes");
    }
    }

    IEnumerator ThunderRandom(){
    RandomTimer-=Time.deltaTime;
    if(RandomTimer<=0)
    {
     Vector3 SpawnPoint=new Vector3(Random.Range(X1,X2),0,target.position.z+Z_Offset);

     GameObject  WarningObj=Instantiate(WarningSign,SpawnPoint,Quaternion.identity);
     WarningObj.transform.localScale=new Vector3(0.5f,0.5f,1);
      WarningObj.transform.rotation=Quaternion.Euler(90,0,0);


    RandomTimer=Random.Range(1,3);
     yield return null;
    }}

void StartRain()
{
if(player_Movement_Rain.enabled==false)player_Movement_Rain.enabled=true;

if(player_Movement.enabled==true)player_Movement.enabled=false;
}

void StopRain()
{
if(player_Movement_Rain.enabled==true)player_Movement_Rain.enabled=false;

if(player_Movement.enabled==false)player_Movement.enabled=true;
}

public void StopEveryThing()
{
IsStopEveryThing=false;
}

public void StartEveryThing()
{
IsStopEveryThing=true;
}

}
