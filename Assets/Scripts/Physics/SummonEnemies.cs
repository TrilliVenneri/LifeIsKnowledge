﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SummonEnemies : MonoBehaviour {

    //Player GameObject
    private GameObject _target;

    //True if the player is in front of the stairs (Colliders are actually colliding)
    //False otherwise
    private bool _playerDetected;
    
    [Header("Enemy to spawn")]
    public GameObject enemy;

    public int amount;
    private GameObject currentEnemy;
    private bool _lastInput;
    private Transform _spawnPoint;

    private void Awake()
    {
        _target = GameObject.FindWithTag("Player");
        _playerDetected = false;
        _spawnPoint = transform.Find("RespawnPoint");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _target)
        {   
            _playerDetected = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == _target)
        {
            _playerDetected = false;
        }
    }

    private void Update()
    {
        bool _input = Input.GetAxis("Teleport") > 0.75f;

        if(_input && _playerDetected && !_lastInput)
        {
            Summon();
        }

        _lastInput = _input;
    }

    private void Summon()
    {
        currentEnemy = Instantiate(enemy, _spawnPoint.transform.position, Quaternion.identity);
        if (currentEnemy.GetComponent<DroneMovement>())
        {
            currentEnemy.GetComponent<DroneMovement>().foundTarget = true;
        }else if (currentEnemy.GetComponent<ScientistMovement>())
        {
            currentEnemy.GetComponent<ScientistMovement>().dronesAmount = amount;
        }
//        currentEnemy.GetComponent<DroneMovement>().foundTarget = true;
        Debug.Log(_spawnPoint.transform);
    }
    
    
}
