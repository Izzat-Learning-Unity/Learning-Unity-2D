using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;//temp position of the camera

    [SerializeField]
    private float minX,maxX;
    // Start is called before the first frame update
    void Start()
    {//need to add a player  tag to the player

      player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()//is being called after all calculations in update() are finished
    {
        if(!player)
            return;

        tempPos = transform.position;//curent position of camera
        tempPos.x = player.position.x;

        if(tempPos.x < minX)
            tempPos.x = minX;

        

        if(tempPos.x > maxX)
            tempPos.x = maxX;
        
        
        transform.position = tempPos;
    }
}
