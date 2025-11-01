using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float followspeed = 2f;
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(Target.position.x,Target.position.y, -1f);
        transform.position = Vector3.Slerp(transform.position,newpos,followspeed*Time.deltaTime);
    }
}
