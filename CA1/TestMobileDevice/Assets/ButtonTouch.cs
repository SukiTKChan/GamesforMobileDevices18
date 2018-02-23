using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTouch : MonoBehaviour
{
    public Text btnText = null;
    
	// Use this for initialization
	void Start ()
    {
      
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
    public void changeColorDeSelect()
    {
        GetComponent<Image>().color = Color.white;
    }

    public void changeColorSelect()
    {
        GetComponent<Image>().color = Color.grey;
        btnText.text = "button tapped";
    }
}
