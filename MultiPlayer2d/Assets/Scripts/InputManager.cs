using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Joystick joystick;
    public float horizontalInput, verticalInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput= joystick.Vertical;
    }
}
