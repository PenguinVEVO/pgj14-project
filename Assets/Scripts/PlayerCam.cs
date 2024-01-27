using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float pitchUp;
    public float pitchDown;
	Camera p_Camera;

    public Transform orientation;
	private inventoryController invController;
	private mainControllerScript mainController;

    float xRotation;
    float yRotation;

    private void Start()
    {
        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		p_Camera = transform.gameObject.GetComponent<Camera>();
		invController = GameObject.Find("FED").GetComponent<inventoryController>();
		mainController = GameObject.Find("FED").GetComponent<mainControllerScript>();
    }

    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * 0.01f * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * 0.01f * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, pitchDown, pitchUp);

        // Rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
		
		if (Input.GetMouseButtonDown(0))
		{
		   Vector3 mousePosition = Input.mousePosition;
		   Ray ray = p_Camera.ScreenPointToRay(mousePosition);
		   if (Physics.Raycast(ray, out RaycastHit hit))
		   {
			   hit.collider.gameObject.SendMessage("move");
			   hit.collider.gameObject.SendMessage("rotate");
			   if (hit.collider.gameObject.name == "rebreather")
			   {
					invController.getRebreather();
					DestroyImmediate(hit.collider.gameObject);
			   }
			   if (hit.collider.gameObject.name == "flares")
			   {
					invController.getFlare();
					DestroyImmediate(hit.collider.gameObject);
			   }
			   if (hit.collider.gameObject.name == "fuel")
			   {
					invController.getFuelRod();
					DestroyImmediate(hit.collider.gameObject);
					mainController.warnPlayer();
			   }
		   }
		}
    }

}
