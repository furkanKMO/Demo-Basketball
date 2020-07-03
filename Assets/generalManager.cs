using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class generalManager : MonoBehaviour
{
   
    private LineRenderer lR;
    private int segment =10;
    public static Vector3 desiredForce;
    public static bool isThrown = false;
    private Rigidbody rB;
    private bool basket = false;
  
    [SerializeField] AnimationCurve aC;
    
    void Start()
    {
        if (lR == null)
        {
          
            lR = gameObject.GetComponent<LineRenderer>();
        }
        lR.enabled = true;
        
        rB = gameObject.GetComponent<Rigidbody>();
        rB.useGravity = false;
        lR.positionCount = segment;
    }

    void Update()
    {
       
            if (desiredForce != Vector3.zero)
            {

                visualize(desiredForce);
            }
            if (Input.GetMouseButtonUp(0))
            {
                rB.useGravity = true;
                if (!isThrown)
                {
                    rB.velocity = desiredForce;
                    isThrown = true;
                }

                lR.enabled = false;
            }

        
    }
    void visualize(Vector3 vo)
    {
        for (int i = 0; i < segment; i++)
        {
            Vector3 pos = calculatePosInTime(vo, i / (float)segment);
            lR.SetPosition(i, pos);
          
        }
    }



    Vector3 calculatePosInTime(Vector3 vo,float time) 
    {
        time = time * 3;
        Vector3 vXz = vo;
        vXz.y = 0f;
        Vector3 result = this.transform.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + this.transform.position.y;
        result.y = sY;
        return result;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        respawnManager.basketCount =respawnManager.basketCount+1;
      
        respawnManager.score += 1 * respawnManager.scoreMultipler;
        respawnManager.scoreMultipler += 1;
        basket = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag =="Floor")
        {

            if (basket)
            {
                respawnManager.currentBall -= 1;
                if (respawnManager.currentBall == 0)
                {
                    if (respawnManager.basketCount >= 3)
                    {
                        
                        uiManager.win = true;
                    }
                    else
                    {

                        
                        uiManager.lose = true;
                    }
                }
                else
                {
                    respawnManager.respawn1 = true;

                }
                Destroy(this.gameObject);
            }
            else
            {
                respawnManager.scoreMultipler = 1;
                respawnManager.currentBall -= 1;
                if (respawnManager.currentBall == 0)
                {
                    if (respawnManager.basketCount >= 3)
                    {
                        

                        uiManager.win = true;
                    }
                    else
                    {

                        

                        uiManager.lose = true;
                    }
                }
                else
                {
                    respawnManager.respawn1 = true;


                }
                Destroy(this.gameObject);
            }
           



        }
    }
}
