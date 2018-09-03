﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private GameObject _laserPrefab;

    [SerializeField] private GameObject _trippleShotPrefab;

    [SerializeField] private float _fireRate = 0.25f;

    [SerializeField] private GameObject _ExplostionPrefab;

    [SerializeField] private int _lifes = 3;

    public float canFire = 0.0f;

    public bool isTrippleShot = false;

    public bool isHyperSpeedEnabled = false;


    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //Note: right mouse click on my computer seems a litte buggy
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();

        }


    }

    private void Shoot()
    {
        if (Time.time > canFire)
        {
            canFire = Time.time + _fireRate;

            if (isTrippleShot)
            {

                Instantiate(_trippleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }

        }

    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Checks to see if HyperSpeed is enabled and adjusts speed
        _speed = (isHyperSpeedEnabled) ? 10.0f : 5.0f;


        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x < -8.4f)
        {
            transform.position = new Vector3(8.4f, transform.position.y, 0);
        }

        else if (transform.position.x > 8.4f)
        {
            transform.position = new Vector3(-8.4f, transform.position.y, 0);
        }
    }


    public void Damage()
    {
        _lifes--;

        if (_lifes < 1)
        {
            Instantiate(_ExplostionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
            
    }

    public void TriplePowerShotOn()
    {
        isTrippleShot = true;
        StartCoroutine(TrippleShotPowerDownRoutine());
    }

    public void HyperSpeedOn()
    {
        isHyperSpeedEnabled = true;
        StartCoroutine(HyperSpeedPowerDownRoutine());

    }

    public IEnumerator TrippleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTrippleShot = false;
    }

    public IEnumerator HyperSpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        isHyperSpeedEnabled = false;
    }
}
