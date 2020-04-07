﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Platform Movement Type: show the platform is going ti move 
public enum MovementType {
    line,
    circular,
    zigzag
};

// Movment orientation (if is applicable)
public enum LineMovementOrientation {
    horizontal,
    vertical
}

public enum CircularMovementOrientation {
    clockwise,
    counterclockwise
}

public class MovingPlatform : MonoBehaviour
{

    // General vars
    [SerializeField]
    MovementType movementType;

    public float speed = 5f;
    Vector3 startPosition;

    // Line movement vars
    public LineMovementOrientation lineMovementOrientation; 
    public float lineDistance = 5f; 

    // Circle movement vars
    public CircularMovementOrientation circularMovementOrientation;
    float circleRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Set start position
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Manage how the platfomr have to move 
        switch (movementType) {
            case MovementType.line:
                moveInAStraightLine();
            break;
        }
    }


    // Move the platform in a straight line in movementOrientation
    public void moveInAStraightLine() 
    {
        // Get current coordenates 
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        // Calculating next position
        switch (lineMovementOrientation) {
            case LineMovementOrientation.horizontal:
                x = Mathf.Cos(Time.time * speed) * lineDistance;
            break;
            case LineMovementOrientation.vertical:
                y = Mathf.Sin(Time.time * speed) * lineDistance;
            break;
        }

        // Moving platform
        this.transform.position = new Vector3(x,y,z);

    }

}
