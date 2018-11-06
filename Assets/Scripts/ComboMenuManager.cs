﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMenuManager : MonoBehaviour {

    public static ComboMenuManager instance { get; private set; }

    public BinaryTree knifeBinaryTree;
    public GameObject rootNode;
    public GameObject leftArrow;
    public GameObject rightArrow;

    [Header("RootNode offset")]
    public float xOffsetNode;

    [Header("Arrows Offset and Rotation")]
    public float xOffsetArrow;
    public float yOffsetArrow;
    public float zRotationArrow;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        knifeBinaryTree = new BinaryTree();

        Vector3 rootNodeOffset = new Vector3(xOffsetNode, 0, 0);
        Vector3 rootNodePosition = this.GetComponent<Transform>().position + rootNodeOffset;
        Quaternion rootNodeRotation = Quaternion.Euler(0, 0, 0);

        Instantiate(rootNode, rootNodePosition, rootNodeRotation);
        InitChildren(rootNodePosition);
    }

    // Update is called once per frame
    void Update() {

    }


    //Instantiate the next branch of the tree
    public void InitChildren(Vector3 fatherPosition)
    {
        SetLeftArrow(fatherPosition);
        SetRightArrow(fatherPosition);
    }


    //Instantiate the Left Arrow in the correct position
    public void SetLeftArrow(Vector3 fatherPosition)
    {
        Vector3 leftArrowOffset = new Vector3(xOffsetArrow, yOffsetArrow, 0);
        Vector3 leftArrowPosition = fatherPosition + leftArrowOffset;
        Quaternion leftArrowRotation = Quaternion.Euler(0, 0, zRotationArrow);
        
        Instantiate(leftArrow, leftArrowPosition, leftArrowRotation);
    }

    //Instantiate the Right Arrow in the correct position w.r.t. the father node position
    public void SetRightArrow(Vector3 fatherPosition)
    {
        Vector3 rightArrowOffset = new Vector3(xOffsetArrow, -yOffsetArrow, 0);
        Vector3 rightArrowPosition = fatherPosition + rightArrowOffset;
        Quaternion rightArrowRotation = Quaternion.Euler(0, 0, -zRotationArrow);

        Instantiate(rightArrow, rightArrowPosition, rightArrowRotation);
    }
}
