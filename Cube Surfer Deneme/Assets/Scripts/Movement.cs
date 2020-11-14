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
    [SerializeField]
    float xAxis;
    [SerializeField]
    float zAxis;
    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        if (playerManager.isRotated == false) {
           // Debug.Log("Burdasin");
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
        zAxis = transform.position.z;
        // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (playerManager.isRotated == true)
        {
            if (playerManager.llevelState == 1)
            {
                //when grounded it will be moving forward
                if (playerManager.pplayerState == 1)
                {
                    
                    transform.position += Vector3.right * movSpeed * Time.fixedDeltaTime;

                }
                if (isTouching)
                {

                    zAxis += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
                    //sinirlari belirledim
                    if (zAxis < 182.5f)
                    {
                        zAxis = 182.5f;
                    }
                    if (zAxis > 188.5f)
                    {
                        zAxis = 188.5f;
                    }
                }
                transform.position = new Vector3(transform.position.x, transform.position.y,zAxis);

            }
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
