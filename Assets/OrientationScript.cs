using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationScript : MonoBehaviour
{
    [SerializeField] public Transform orientation;
    [SerializeField] public Transform arm;
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private Vector3 oriented = new(0,0,0);

    private float xRotation = 0f;
    private float yRotation = 0f;
    public Vector2 mouseDelta { get; private set; }

    private void Awake()
    {
        orientation = transform.Find("Orientation");
        arm = transform.Find("Arm");
    }

    private void Update()
    {


        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
        mouseDelta = new Vector2(mouseX, mouseY);

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //arm.rotation = Quaternion.Euler(xRotation, yRotation, 0);

    }
}
