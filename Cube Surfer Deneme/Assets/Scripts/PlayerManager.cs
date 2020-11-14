using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Material collectedObjMat;

    public List<GameObject> collidedList;
    public Transform collectedPoolTransform;
    [SerializeField]
    public UIManager uIManager;
    [SerializeField]
    private Text _coinText;

    [SerializeField]
    public float down = 0f;
    [SerializeField]
    public int coins = 0;
    [SerializeField]
    public int lives = 1;
    [SerializeField]
    public int llevelState = 1;

    [SerializeField]
    public bool isRotated ;

    [SerializeField]
    public int pplayerState = 0;
    // Start is called before the first frame update

    public void Start()
    {
        isRotated = false;
    }
    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        //mousea basarsa
        if (Input.GetMouseButton(0))
        {
            pplayerState = 1;
        }
       

    }
}
