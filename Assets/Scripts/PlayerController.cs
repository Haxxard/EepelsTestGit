using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Aluksen nopeus
    //public float speed;
    //public Boundary boundary;

    private Rigidbody2D rbody;

    // Äänet
    //AudioSource audioSource;

    // Mobiilikosketusta varten
    public SimpleTouchPad touchPad;
    //public SimpleTouchAreaButton areaButton;

    // Start is called before the first frame update
    void Start()
    {
        //Aluksen fysiikkamoottori
        rbody = GetComponent<Rigidbody2D>();
        //Äänilähde
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Haetaan suunta
        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, direction.y, 0);
        //rbody.velocity = movement * speed;
    }
}
