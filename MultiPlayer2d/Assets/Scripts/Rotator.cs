using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : Photon.MonoBehaviour
{
    //public Joystick joystick;
    public InputManager inputManager;
    public PhotonView photonView;
    [SerializeField]
    Vector3 _lookAtPosition;
    void Start()
    {
        inputManager = (InputManager)FindObjectOfType(typeof(InputManager));
    }
    // Update is called once per frame
    void Update()
    {
        if(photonView.isMine)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(-inputManager.horizontalInput, inputManager.verticalInput) * Mathf.Rad2Deg);
        }
        
    }
}
