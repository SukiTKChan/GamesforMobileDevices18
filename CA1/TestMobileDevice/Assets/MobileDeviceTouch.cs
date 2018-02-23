using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileDeviceTouch : MonoBehaviour
{
    Touch t;
    Touch t2;

    Touch[] touches;

    private Vector3 objectInitialSize;
    Vector3 originRot;

    RaycastHit rayCastHitInfo;
    Ray r;

    private float startingDistance;
    private float currentDistance;
    private float distanceToSelectedObject;
    private float timer = 0;
    

    private bool scale = false;
    private bool moved = false;
    private bool rotate = false;


    bool hasHitItem;
    bool guiBtnTapped= false;

    private Touchable currentlySelectedObject;
    Touchable possibleItem;

    private ButtonTouch btnTouch;

    private Quaternion startRotation;
    Quaternion diffAngle;

  

    // Use this for initialization
    void Start ()
    {
        Input.gyro.enabled = true;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        

        #region accelerometer on selected object
        //if (currentlySelectedObject)
        //{
        //    currentlySelectedObject.transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
        //}

        #endregion

        #region gyroscope on camera
        //Camera.main.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, 0);
        #endregion

        foreach (Touch touch in Input.touches)
        {
            touches = Input.touches;
            t = touches[0];

            r = Camera.main.ScreenPointToRay(t.position);
            Debug.DrawRay(r.origin, 100 * r.direction);
            hasHitItem = (Physics.Raycast(r, out rayCastHitInfo));

            if (hasHitItem)
            {
                possibleItem = rayCastHitInfo.collider.gameObject.GetComponent<Touchable>();
            }
            else
            {
                possibleItem = null;
            }

            

           if (t.phase == TouchPhase.Began)
            {
                
                #region Tap
                
                timer = 0;
                moved = false;
                scale = false;
                rotate = false;
                //Debug.Log("Tap");
                #endregion

                #region Drag Object
                if (Input.touchCount == 1 && currentlySelectedObject)
                {
                   
                    distanceToSelectedObject = Vector3.Distance(currentlySelectedObject.transform.position, Camera.main.transform.position);
                }

                #endregion

                #region Scale Object
                if (Input.touchCount == 2 && currentlySelectedObject && !wasShort())
                {
                    //Debug.Log("Scaling");
                    t = touches[0];
                    t2 = touches[1];
                   
                    startingDistance = Vector3.Distance(t.position,t2.position);
                    objectInitialSize = currentlySelectedObject.transform.localScale;
                }
                #endregion

                //#region rotate Object
                //if (Input.touchCount == 2 && currentlySelectedObject)
                //{
                //    t = touches[0];
                //    t2 = touches[1];
                //    startRotation = 
                //}
                //#endregion

                //#region other gesture
                //if (Input.touchCount == 2 && currentlySelectedObject && wasShort())
                //{
                //    Destroy(currentlySelectedObject);
                //}
                //#endregion

                if (btnTouch)
                {
                    btnTouch.GetComponent<ButtonTouch>();
                    Debug.Log("btn touch");
   
                }
                
               
            }

            if (t.phase == TouchPhase.Moved)
            {
                moved = true;

                #region Drag Object
                //Debug.Log("Object moving");

                if (possibleItem != currentlySelectedObject)
                {
                    currentlySelectedObject.DeSelect();
                    currentlySelectedObject = possibleItem;
                    //currentlySelectedObject.Select();
                }

                currentlySelectedObject.transform.position = r.origin + distanceToSelectedObject * r.direction;
                
                #endregion

                #region Scale Object
                if (Input.touchCount == 2 && currentlySelectedObject && !wasShort())
                {

                    scale = true;
                    t = touches[0];
                    t2 = touches[1];

                    currentDistance = Vector3.Distance(t.position, t2.position);
                    currentlySelectedObject.transform.localScale = objectInitialSize * currentDistance / startingDistance;
                    
                }
                #endregion

                //#region Rotate Object
                //if (currentlySelectedObject && Input.touchCount == 2 && !wasShort())
                //{
                //    rotate = true;
                //    t = touches[0];
                //    t2 = touches[1];
                //    currentlySelectedObject.transform.rotation = startRotation * 
                //        Quaternion.RotateTowards(Camera.main.transform.forward, diffAngle);

                //}
                //#endregion
            }

            if ((t.phase == TouchPhase.Ended) && !moved && wasShort())
            {
                
                if (currentlySelectedObject)
                {
                    currentlySelectedObject.DeSelect();
                   
                    currentlySelectedObject = null;
                }

                if (Physics.Raycast(r, out rayCastHitInfo))
                {
                    currentlySelectedObject = rayCastHitInfo.collider.gameObject.GetComponent<Touchable>();

                    if (currentlySelectedObject)
                    {
                        currentlySelectedObject.Select();
                    }
                    else
                    {
                        currentlySelectedObject.DeSelect();
                        currentlySelectedObject = null;
                    }

                }
                
                //if(currentlySelectedObject != null)
                //{
                    
                //}
            }

        }

    }


    private bool wasShort()
    {
        return timer < 0.1f;
    }
    
    private void OnGUI()
    {
        if (guiBtnTapped)
        {
            GUI.color = Color.red;
        }
        
        if(GUI.Button(new Rect(15, 15, 100, 50), "Tap here"))
        {
            guiBtnTapped = true;
            
        }

        
        
    }
}
