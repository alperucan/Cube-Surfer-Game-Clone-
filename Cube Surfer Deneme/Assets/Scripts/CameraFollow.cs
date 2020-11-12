using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerManager playerManager;
    public Transform target;

    [SerializeField] float speed;
    [SerializeField] Vector3 offset;


    void LateUpdate()
    {
        //Camera Ayarlari
        if (playerManager.llevelState == 1)
        {
            Vector3 desiredPos = target.position + offset;
            //Lerp 2 vectoru yaklastirir!
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, speed);
            transform.position = new Vector3(transform.position.x, transform.position.y, smoothedPos.z);

        }
    }

}
