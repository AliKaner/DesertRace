using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class Gas : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private PathFollower pathFollower;
    [SerializeField] private Speedometer speedometer;

    public float maxSpeed;
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
            pathFollower.speed -= acceleration*5; 
            speedometer.RefreshText(pathFollower.speed);
        }
    }
}
