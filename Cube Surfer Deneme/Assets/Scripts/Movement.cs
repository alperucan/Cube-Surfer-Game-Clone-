using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float movSpeed = 8;
    [SerializeField] float controlSpeed = 3;
    [SerializeField]
    public bool isTouching;
    float xAxis;
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        if (playerManager.llevelState == 1)
        {
            //when grounded it will be moving forward
            if (playerManager.pplayerState == 1)
            {
                transform.position += Vector3.forward * movSpeed * Time.fixedDeltaTime;

            }
            if (isTouching)
            {

                xAxis += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
                //sinirlari belirledim
                if (xAxis > 3f)
                {
                    xAxis = 3f;
                }
                if (xAxis < -3f)
                {
                    xAxis = -3f;
                }
            }
            transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        }

    }
    void GetInput()
    {
        //mousea basarsa
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }

    }

}
