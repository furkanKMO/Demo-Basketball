using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragManager : MonoBehaviour
{
    private Vector3 endPos;
    private Camera Cam;
    private LineRenderer lR;
    private Vector3 rawPosition;
      private float cameraOffset = 10f;
    [SerializeField] AnimationCurve aC;

    void Start()
    {
        if (lR == null)
        {

            lR = gameObject.GetComponent<LineRenderer>();
        }

        Cam = Camera.main;
        lR.enabled = true;
       
    }

    void Update()
    {
        

        if (!generalManager.isThrown)
        {


            if (Input.GetMouseButtonDown(0))
            {

                
                lR.positionCount = 2;
                lR.SetPosition(0, this.gameObject.transform.position);
                lR.useWorldSpace = true;
                lR.widthCurve = aC;
                lR.numCapVertices = 10;

            }
            if (Input.GetMouseButton(0))
            {
                endPos = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraOffset));
                rawPosition = endPos;
               
                rawPosition.x = rawPosition.x * -3;
                rawPosition.y = rawPosition.y * -3;
                rawPosition.z = rawPosition.z * 3;

                lR.SetPosition(1, endPos);

                generalManager.desiredForce = rawPosition;
            }
            //if (Input.GetMouseButtonUp(0))
            //{
            //    lR.enabled = false;
            // for some reasons wont work second time;
            //}
        }
        else
        {
            lR.enabled = false;
        }


        }
    
}
