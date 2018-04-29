﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{
    public PlayerControl player;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;


	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<PlayerControl>();
        lastPlayerPosition = player.transform.position;

	}
	
	// Update is called once per frame
	void Update () 
    {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove,transform.position.y,transform.position.z);

        lastPlayerPosition = player.transform.position;
	}
}
