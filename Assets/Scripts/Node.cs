﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    private Vector3 _position;
    private bool _set;
    public GameObject placeHolderAnimation;

    public bool GetSet()
    {
        return _set;
    }

    private void Awake()
    {
        _position = GetComponent<Transform>().position;
        _set = false;
    }

    public void AdjustPlaceHolderPosition(float xOffset, float yOffset) 
    {
        Vector3 placeHolderOffset = new Vector3(xOffset, yOffset, 0);
        Vector3 placeHolderPosition = _position + placeHolderOffset;
        Quaternion placeHolderRotation = new Quaternion(0, 0, 0, 0);
        Instantiate(placeHolderAnimation, placeHolderPosition, placeHolderRotation);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
