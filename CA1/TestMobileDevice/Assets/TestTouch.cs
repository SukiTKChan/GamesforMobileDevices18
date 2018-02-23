using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour 
{
    Touch t;
    Touch t2;

    Touch[] touches;

    private float startingDistance;
    private float currentDistance;



    private Vector3 objectInitialSize;

    RaycastHit rayCastHitInfo;
    Ray r;

    private float distance;
    private float distanceToSelectedObject;
    private float timer = 0;


    private Transform toDrag;

    private bool scale = false;
    private bool moved = false;
    private bool rotate = false;
    bool hasHitItem;

    private Touchable currentlySelectedObject;
    Touchable possibleItem;

    private ButtonTouch btnTouch;

    private Quaternion startRotation;
    Quaternion diffAngle;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        foreach (Touch touch in Input.touches)
        {
            if(Input.touchCount>0)
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
                    if (Input.touchCount == 2 && currentlySelectedObject)
                    {
                        //Debug.Log("...");
                        t = touches[0];
                        t2 = touches[1];
                   
                        startingDistance = Vector3.Distance(t.position,t2.position);
                        objectInitialSize = currentlySelectedObject.transform.localScale;
                    }
                #endregion

                    //#region rotate Object
                    //if (Input.touchCount == 1 && currentlySelectedObject)
                    //{
                    //   // startRotation = 
                    //}
                    //#endregion

                    if (btnTouch)
                    {
                        btnTouch = GetComponent<ButtonTouch>();
                        Debug.Log("btn touch");
                    }
                


                }

                if (t.phase == TouchPhase.Moved)
                {
                    moved = true;

                    #region Drag Object
                    Debug.Log("Object moving");
                    if (possibleItem != currentlySelectedObject)
                    {
                        currentlySelectedObject.DeSelect();
                        currentlySelectedObject = possibleItem;
                        currentlySelectedObject.Select();
                    }
               
                    currentlySelectedObject.transform.position = r.origin + distanceToSelectedObject * r.direction;
                
                

                
                #endregion

                    #region Scale Object
                    if (Input.touchCount == 2 && currentlySelectedObject)
                    {

                        scale = true;
                        t = touches[0];
                        t2 = touches[1];

                        currentDistance = Vector3.Distance(t.position, t2.position);
                        currentlySelectedObject.transform.localScale = objectInitialSize * currentDistance / startingDistance; 
                    }
                    #endregion

                    //#region Rotate Object
                    //if (currentlySelectedObject && Input.touchCount == 1 && !wasShort())
                    //{
                    //    rotate = true;
                    
                    //    currentlySelectedObject.transform.rotation = startRotation * 
                    //        Quaternion.RotateTowards(Camera.main.transform.forward, diffAngle);

                    //}
                    //#endregion
                }

                if ((t.phase == TouchPhase.Ended) && !moved && wasShort())
                {
             

                    //de-select object if its tap
                
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
		
	}
    private bool wasShort()
    {
        return timer < 0.2f;
    }
}
