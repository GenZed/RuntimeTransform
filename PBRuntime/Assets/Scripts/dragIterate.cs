using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragIterate : MonoBehaviour
{
    Vector3 mousePositionOffset;

    private Vector3 GetMouseWorldPos()
    {
        // capture mouse position & return Worldpoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        
    }
}
