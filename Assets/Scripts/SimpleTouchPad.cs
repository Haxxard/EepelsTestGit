using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    public float smoothing;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;

    void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }

    // Sormi osuu näyttöön
    public void OnPointerDown(PointerEventData data)
    {
        // Onko näyttöä painettu?
        if (!touched)
        {
            // On.
            touched = true;
            pointerID = data.pointerId;     // 
            origin = data.position;
        }
    }

    // Sormea raahataan näytöllä
    public void OnDrag(PointerEventData data)
    {
        // 
        if (data.pointerId == pointerID)
        {
            Vector2 currentPosition = data.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
        }
    }

    // Sormi on irti näytöstä
    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            direction = Vector3.zero;
            touched = false;
        }
    }

    public Vector2 GetDirection()
    {
        // Liike on pehmeää (smooth)
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
