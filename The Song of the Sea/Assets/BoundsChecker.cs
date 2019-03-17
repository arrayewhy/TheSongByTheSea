using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    // Bounds Variables

    public string boundaryType;

    public bool withinBounds;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == boundaryType) withinBounds = true;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.tag == boundaryType) withinBounds = false;
    }
}
