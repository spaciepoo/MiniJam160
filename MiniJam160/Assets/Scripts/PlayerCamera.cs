using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private Vector2 cameraRotation = Vector2.zero;
    private Transform playerCamera;

    public float sensitivity = 2.5f;

    void Start() {

        playerCamera = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update() {

        PlayerLook();

        MouseLockToggle();

    }

    void MouseInput() {

        cameraRotation.x = cameraRotation.x + Input.GetAxis("Mouse X") * sensitivity;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y + Input.GetAxis("Mouse Y") * sensitivity, -90f, 90f);

    }

    void PlayerCameraRotation() {

        playerCamera.localRotation = Quaternion.Euler(-cameraRotation.y, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, cameraRotation.x, 0f);

    }

    void PlayerLook() {

        if (Cursor.lockState == CursorLockMode.Locked) {
            MouseInput();
            PlayerCameraRotation();
        }

    }

    void MouseLockToggle() {

        if (Input.GetKeyDown(KeyCode.Tab)) {
            Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
        }

    }

    public Vector2 GetRotation() {
        return cameraRotation;
    }
}
