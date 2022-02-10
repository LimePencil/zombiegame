using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(player.position.x,player.position.y,this.transform.position.z),smoothSpeed*Time.deltaTime);
    }
}
