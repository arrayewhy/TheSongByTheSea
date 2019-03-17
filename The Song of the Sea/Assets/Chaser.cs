using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    // Scripts

    public BoundsChecker boundsChecker;

    // Linked Game Objects

    public Transform target;

    // Chase Variables

    Vector2 targetPos;
    float speed = 1f;

    void Update ()
    {
        if (boundsChecker.withinBounds) UpdateTargetPosition ();

        if (DistanceFromTarget () > 0.1f) Chase ();
    }

    void UpdateTargetPosition ()
    {
        targetPos = target.position;
    }

    void Chase ()
    {
        transform.Translate (MoveAmount () * Time.deltaTime * speed);
    }

    Vector2 MoveAmount ()
    {
        return new Vector2 (-(transform.position.x - targetPos.x), -(transform.position.y - targetPos.y));
    }

    float DistanceFromTarget ()
    {
        return Vector2.Distance (transform.position, targetPos);
    }
}
