using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    private Rigidbody rb;

    [SerializeField] bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = playerManager.collectedObjMat;

        playerManager.collidedList.Add(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        //grounda degerse
        if (other.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
    }
    void Grounded()
    {
        isGrounded = true;
        //grounde degince state degistir
        playerManager.pplayerState = 1;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this, 1);
    }

}
