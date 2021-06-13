using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public GameObject playerCamera,circleSprite,triangleSprite;
    public float moveSpeed, jumpForce;
    public bool hasFlag;
    public string playerName;
    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.isMine)
        {
            
            playerCamera.SetActive(true);
            playerName = PhotonNetwork.playerName;
           // playerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            circleSprite.GetComponent<SpriteRenderer>().color = Color.green;
            triangleSprite.GetComponent<SpriteRenderer>().color = Color.red;
            playerName= photonView.owner.name;
        }
        
    }
    void Start()
    {
        if (photonView.isMine)
        {
            print("PlayerHello");
            playerCamera.SetActive(true);
          
            // playerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            circleSprite.GetComponent<SpriteRenderer>().color = Color.green;
            triangleSprite.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveInputHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float moveInputVertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        if (photonView.isMine)
        {
            CheckInput(moveInputHorizontal, moveInputVertical);
        }
    }
    void CheckInput(float moveInputHorizontal, float moveInputVertical)
    {
        var move = new Vector3(moveInputHorizontal, moveInputVertical);
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
