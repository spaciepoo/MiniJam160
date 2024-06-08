using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    private Transform footLocation;
    private PlayerCamera playerCamera;

    public float jumpSpeed = 5f;
    public float moveSpeed = 5f;

    void Start() {

        rb = GetComponent<Rigidbody>();
        footLocation = transform.Find("Foot");
        playerCamera = GetComponent<PlayerCamera>();

    }

    void Update() {

        Move();
        Jump();

    }

    void Move() {

        Vector3 moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));

        Vector3 newVelocity = Quaternion.AngleAxis(playerCamera.GetRotation().x - 90, Vector3.up) * moveSpeed;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;

    }

    void Jump() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            Debug.Log("Space");
            RaycastHit hit;

            if (Physics.Raycast(footLocation.position, Vector3.down, out hit, 0.1f)) {
                Debug.Log("rayhit");
                Vector3 newVelocity = rb.velocity;
                newVelocity.y = jumpSpeed;
                rb.velocity = newVelocity;
            }

        }

    }
}
