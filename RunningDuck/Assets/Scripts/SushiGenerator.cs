using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiGenerator : MonoBehaviour
{
    public GameObject sushi1;

    public float distanceBetweenSushi;

	public void SpawnSushi(Vector3 startPosition)
    {
        
        Instantiate(sushi1);
        sushi1.transform.position = startPosition;
        sushi1.SetActive(true);

        //Instantiate(sushi2);
        //sushi2.transform.position =  new Vector3(startPosition.x - distanceBetweenSushi,
        //    startPosition.y,startPosition.z);
        //sushi2.SetActive(true);

        //Instantiate(sushi3);
        //sushi3.transform.position = new Vector3(startPosition.x - distanceBetweenSushi,
        //    startPosition.y, startPosition.z);
        //sushi3.SetActive(true);
    }

}
