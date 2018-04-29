using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=yiXlPP8jOvs&index=4&list=PLiyfvmtjWC_XmdYfXm2i1AQ3lKrEPgc9-
public class PlatformGenerator : MonoBehaviour 
{
    public GameObject thePlatform;
    public Transform generatePoint;
    public float distanceBetween;
   
    private float platformWidth;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private SushiGenerator sushiGenerator;
    //public ObjectPool objPool;

    //public float distanceBetweenMin;
    //public float distanceBetweenMax;


    // Use this for initialization
    void Start () 
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        sushiGenerator = FindObjectOfType<SushiGenerator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(transform.position.x <generatePoint.position.x)
        {
            heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);

            if (heightChange>maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange<minHeight)
            {
                heightChange = minHeight; 
            }

            

            //distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween,
                transform.position.y,transform.position.z);

            

            Instantiate(thePlatform, transform.position, transform.rotation);

            sushiGenerator.SpawnSushi(new Vector3(transform.position.x,
                transform.position.y +1f, transform.position.z));
        }
	}
}
