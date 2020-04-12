using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetechController : MonoBehaviour
{
    public bool useController;
    public int controllerNum;

    void Update()
    {
        PlayerCamera playerCam = GetComponentInChildren<PlayerCamera>();
        controllerNum = playerCam.playerNum;
        if (Input.GetMouseButtonDown(0) ||
            Input.GetMouseButtonDown(1) ||
            Input.GetMouseButtonDown(2))
        {
            Debug.Log("Not Using Controller");
            useController = false;
        }
        if (Input.GetAxisRaw("MouseX") != 0.0f ||
            Input.GetAxisRaw("MouseY") != 0.0f)
        {
            Debug.Log("Not Using Controller");
            useController = false;
        }
        if (Input.GetAxis("ControllerLook" + controllerNum + "X") != 0.0f ||
            Input.GetAxis("ControllerLook" + controllerNum + "Y") != 0.0f)
        {
            Debug.Log("Using Controller");
            useController = true;
        }
        if (Input.GetKey(KeyCode.JoystickButton0) ||
            Input.GetKey(KeyCode.JoystickButton1) ||
            Input.GetKey(KeyCode.JoystickButton2) ||
            Input.GetKey(KeyCode.JoystickButton3) ||
            Input.GetKey(KeyCode.JoystickButton4) ||
            Input.GetKey(KeyCode.JoystickButton5) ||
            Input.GetKey(KeyCode.JoystickButton6) ||
            Input.GetKey(KeyCode.JoystickButton7) ||
            Input.GetKey(KeyCode.JoystickButton8) ||
            Input.GetKey(KeyCode.JoystickButton9) ||
            Input.GetKey(KeyCode.JoystickButton10))
        {
            Debug.Log("Using Controller");
            useController = true;
        }
    }
}
