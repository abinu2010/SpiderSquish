using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleColour();
        }
    }
    private void ToggleColour()
    {
        Renderer tileRenderer = GetComponent<Renderer>();
        if (tileRenderer != null)
        {
            if (tileRenderer.material.color == Color.green)
            {
                tileRenderer.material.color = Color.red;
            }
            else
            {
                tileRenderer.material.color = Color.green;
            }
        }
    }
}
