using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectedObjController : MonoBehaviour
{
    PlayerManager playerManager;

   

    //  GameObject lastGameObject;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;

            rb.constraints = RigidbodyConstraints.FreezeAll;

            GetComponent<Renderer>().material = playerManager.collectedObjMat;

        }

    }
    void FixedUpdate()
    {
        if (playerManager.lives <= 0)
        {
            playerManager.llevelState = 0;
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("zero if");
        if (other.gameObject.CompareTag("CollectibleObj"))
        {
          // Debug.Log("First if");
            if (!playerManager.collidedList.Contains(other.gameObject))
            {
                //Debug.Log("SEc if: " +playerManager.collectedPoolTransform.position.y);
                other.gameObject.tag = "Player";

                playerManager.collidedList.Add(other.gameObject);

                playerManager.collectedPoolTransform.position = new Vector3(playerManager.collectedPoolTransform.position.x, playerManager.collectedPoolTransform.position.y + 1f, playerManager.collectedPoolTransform.position.z);

                other.transform.localPosition = new Vector3(playerManager.collectedPoolTransform.position.x, 0, playerManager.collectedPoolTransform.position.z);
                other.transform.parent = playerManager.collectedPoolTransform;
               
                other.transform.parent = playerManager.collectedPoolTransform;
                other.gameObject.AddComponent<CollectedObjController>();
                playerManager.lives++;
                playerManager.down++;
             
            }
        }

        if (other.gameObject.CompareTag("WallBlock"))
        {
            //Debug.Log("First if");
            if (!playerManager.collidedList.Contains(other.gameObject))
            {
                other.gameObject.tag = "null";
                Destroy(gameObject, 0.15f);
                playerManager.collidedList.Remove(gameObject);
                playerManager.collectedPoolTransform.position = new Vector3(playerManager.collectedPoolTransform.position.x, playerManager.collectedPoolTransform.position.y - 1f, playerManager.collectedPoolTransform.position.z);
                //  Debug.Log("wallBlock: " + playerManager.collectedPoolTransform.position.y);
                playerManager.lives--;
                return;
            }
        }
        if (other.gameObject.CompareTag("LavaBlock"))
        {
            if (!playerManager.collidedList.Contains(other.gameObject))
            {
                other.gameObject.tag = "null";
                Destroy(gameObject, 0.15f);
                playerManager.collidedList.Remove(gameObject);
                playerManager.collectedPoolTransform.position = new Vector3(playerManager.collectedPoolTransform.position.x, playerManager.collectedPoolTransform.position.y - 1f, playerManager.collectedPoolTransform.position.z);
                // Debug.Log("lavaBlock: " + playerManager.collectedPoolTransform.position.y);
                playerManager.lives--;

                return;
            }

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            if (!playerManager.collidedList.Contains(other.gameObject))
            {
                other.gameObject.tag = "null";
                Destroy(gameObject, 0.15f);
                playerManager.collidedList.Remove(gameObject);
                playerManager.collectedPoolTransform.position = new Vector3(playerManager.collectedPoolTransform.position.x, playerManager.collectedPoolTransform.position.y - 1f, playerManager.collectedPoolTransform.position.z);
                //   Debug.Log("Finish: " + playerManager.collectedPoolTransform.position.y);
                playerManager.lives--;
                return;
            }

        }
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.tag = "null";
            Destroy(other.gameObject);
            playerManager.coins++;
            playerManager.uIManager.UpdateCoinDisplay(playerManager.coins);

        }

        if (other.gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("Completed!!!");
            playerManager.llevelState = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }


}
