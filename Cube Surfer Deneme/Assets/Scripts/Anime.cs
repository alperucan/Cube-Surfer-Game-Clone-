using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    Animator anim;
    [SerializeField]
    Transform target;
    
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerManager.llevelState == 0)
        {
            
            gameObject.transform.position = new Vector3(target.position.x+1f,transform.position.y,target.position.z);
            anim.SetInteger("Jump",1);
        }
    }
}
