using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class Gas : MonoBehaviour
{
    [SerializeField] private PathFollower pathFollower;
    [SerializeField] private Speedometer speedometer;
    [Header("Settings")]
    [SerializeField] private float acceleration;
    public float maxSpeed;

    private bool _isNitroAvailable;
    
    private void Update()
    {
        SetSpeedometerColors();
        if (Input.GetMouseButton(0))
        {
            if (pathFollower.speed <= maxSpeed)
            {
                Acceleration(acceleration);
            }
        }
        else if( pathFollower.speed >1)
        {
            Acceleration(-acceleration*3);
        }
    }

    private void Acceleration(float _acceleration)
    {
        pathFollower.speed += _acceleration;
        speedometer.RefreshText();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            KnockBack();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nitro"))
        {
            StartCoroutine(Nitro());
        }
    }

    private IEnumerator Nitro()
    {
        _isNitroAvailable = true;
        pathFollower.speed = 250;
        speedometer.RefreshText();
        yield return new WaitForSeconds(1f);
        pathFollower.speed = maxSpeed-1;
        _isNitroAvailable = false;
    }
    private void KnockBack()
    {
        pathFollower.speed = -2;
    }
    private void SetSpeedometerColors()
    {
        if (_isNitroAvailable == true)
        {
            speedometer.SetSpeedometerColor(Color.blue);
            return;
        }
        if (pathFollower.speed > 70)
        {
            speedometer.SetSpeedometerColor(Color.red);
            return;
        }
        speedometer.SetSpeedometerColor(Color.white);
    }
}
