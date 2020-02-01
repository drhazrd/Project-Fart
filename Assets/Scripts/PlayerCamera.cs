using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float gamepadSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public bool useController;
    public bool Player1, Player2, Player3, Player4;
    float camMoveX;
    float camMoveY;
    public int playerNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (Player1)
            playerNum = 1;
        if (Player2)
            playerNum = 2;
        if (Player3)
            playerNum = 3;
        if (Player4)
            playerNum = 4;

    }

    // Update is called once per frame
    void Update()
    {
        SetController();
         
        if (!useController)
        {
            camMoveX = Input.GetAxis("MouseX") * mouseSensitivity * Time.deltaTime;
            camMoveY = Input.GetAxis("MouseY") * mouseSensitivity * Time.deltaTime;
        }
        else
        {
            camMoveX = Input.GetAxis("ControllerLook" + playerNum + "X") * gamepadSensitivity * Time.deltaTime;
            camMoveY = Input.GetAxis("ControllerLook" + playerNum + "Y") * gamepadSensitivity * Time.deltaTime;
        }
        xRotation -= camMoveY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * camMoveX);
    }
    public void SetController()
    {
        if (Player1)
        {
            Player2 = false;
            Player3 = false;
            Player4 = false;
        }
        if (Player2)
        {
            Player1 = false;
            Player3 = false;
            Player4 = false;
        }
        if (Player3)
        {
            Player1 = false;
            Player2 = false;
            Player4 = false;
        }
        if (Player4)
        {
            Player1 = false;
            Player2 = false;
            Player3 = false;
        }
    }
}