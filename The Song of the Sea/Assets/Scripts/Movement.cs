using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Components

    Camera mainCam;

    // Scripts

    BoundsChecker boundsChecker;

    // Movement Variables

    Vector3 targetPos;
    bool shouldWalk;
    public float walkSpeed;

    private void Start()
    {
        // Components

        mainCam = Camera.main.GetComponent<Camera> ();

        // Scripts

        boundsChecker = GetComponent<BoundsChecker> ();
    }

    private void Update()
    {
        if (Input.GetMouseButton (0)) UpdateTargetPosition ();

        if (ShouldWalk ())
        {
            AdjustWalkSpeed ();
            Walk ();
        }
    }

    bool ShouldWalk ()
    {
        return DistanceFromTarget () > 0.75f;
    }

    float DistanceFromTarget ()
    {
        return Vector2.Distance (transform.position, targetPos);
    }

    void Walk ()
    {
        transform.Translate (MoveAmount () * Time.deltaTime * walkSpeed);
    }

    void UpdateTargetPosition ()
    {
        targetPos = ClickPosition ();
    }

    Vector3 MoveAmount ()
    {
        Vector3 amount = new Vector3 (VectorX (), VectorY (), 0);

        float absX = Mathf.Abs (amount.x);
        float absY = Mathf.Abs (amount.y);

        float signX = Mathf.Sign (amount.x);
        float signY = Mathf.Sign (amount.y);

        if (absX > absY)
        {
            amount.y = signY * (absY / absX);
            amount.x = signX * (absX / absX);
        }
        else if (absY > absX)
        {
            amount.x = signX * (absX / absY);
            amount.y = signY * (absY / absY);
        }

        return amount;
    }

    float VectorX ()
    {
        return -(transform.position.x - targetPos.x);
    }

    float VectorY ()
    {
        return -(transform.position.y - targetPos.y);
    }

    Vector3 ClickPosition ()
    {
        return mainCam.ScreenToWorldPoint (Input.mousePosition);
    }

    void AdjustWalkSpeed ()
    {
        if (DistanceFromTarget () > 1 && walkSpeed < 1)
        {
            walkSpeed += 2f * Time.deltaTime;
        }
        else if (DistanceFromTarget () < 4 && walkSpeed > 0)
        {
            walkSpeed -= 2f * Time.deltaTime;
        }
    }
}
