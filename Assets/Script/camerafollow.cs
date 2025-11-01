using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public float followspeed = 0f;
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(Target.position.x, -1f);
        transform.position = Vector3.Slerp(transform.position,newpos,followspeed*Time.deltaTime);
    }
}
