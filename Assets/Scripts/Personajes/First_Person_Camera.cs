using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Person_Camera : MonoBehaviour
{
    public float mouseSense;
    public Transform playerTransform;

    private float mouseYRotation;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        mouseYRotation -= mouseY;
        mouseYRotation = Mathf.Clamp(mouseYRotation, -90, 90);

        transform.localEulerAngles = Vector3.right * mouseYRotation;
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
