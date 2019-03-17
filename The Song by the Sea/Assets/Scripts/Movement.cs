using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Components

    Camera mainCam;

    // Movement Variables

    Vector3 targetPos;

    private void Start()
    {
        // Components

        mainCam = Camera.main.GetComponent<Camera> ();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            UpdateTargetPosition ();
        }
    }

    void UpdateTargetPosition ()
    {
        targetPos = ClickPosition ();
        print (targetPos);
    }

    void Move ()
    {
        transform.Translate(MoveAmount () * Time.deltaTime);
    }

    Vector3 MoveAmount ()
    {
        return new Vector3 (1, 0, 0);
    }

    Vector3 ClickPosition ()
    {
        return mainCam.ScreenToWorldPoint (Input.mousePosition);
    }

    float Gap ()
    {
        return 0;
    }
}
