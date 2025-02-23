﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    [Header("Reference to the Scriptable Object")]
    public JoelRespawn joelRespawn;
    public bool overrideRespawnPosition;

    private void Awake()
    {
        if (!overrideRespawnPosition)
        {
            transform.position = new Vector3(joelRespawn.GetX(), joelRespawn.GetY(), 0);
        }
    }
}
