using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;//It should be public because it's going to be used elsewhere
    //at the same time I don't want it to be visible in the inspector

    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed,myBody.velocity.y);
        //velocity pushes players up down and left right depending on the values.
    }
}
