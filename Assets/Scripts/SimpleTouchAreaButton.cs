using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleTouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 startPos, endPos, direction;

    private bool touched;
    private int pointerID;

    void Awake()
    {
        touched = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        // Onko vielä kosketettu ampumisaluetta?
        if (!touched)
        {
            // Ei, mutta nyt on
            touched = true;
            pointerID = data.pointerId;
            startPos = gameObject.transform.position;

        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        // 
        if (data.pointerId == pointerID)
        {
            touched = false;
            startPos = gameObject.transform.position;
            direction = startPos - endPos;
        }
    }


}
