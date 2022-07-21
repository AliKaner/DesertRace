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

    private bool _isNitroAvailable { get; set;}
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (pathFollower.speed < maxSpeed)
            {
                if (pathFollower.speed > maxSpeed - 10)
                {
                    //speedometer.TextColorChange(Color.red);
                }
                //speedometer.TextColorChange(Color.white);
                pathFollower.speed += acceleration;
                speedometer.RefreshText(pathFollower.speed);
            }
        }
        else if( pathFollower.speed >0)
        {
            pathFollower.speed -= acceleration*3; 
            speedometer.RefreshText(pathFollower.speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            KnockBack();
        }
    }
    public IEnumerator Nitro()
    {
        maxSpeed = 250;
        pathFollower.speed = 250;
        yield return new WaitForSeconds(1f);
        pathFollower.speed = 100;
        maxSpeed = 100;
        _isNitroAvailable = false;
    }

    private void KnockBack()
    {
        pathFollower.speed = -2;
    }
}
