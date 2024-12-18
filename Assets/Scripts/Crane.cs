using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    private Vector3 hookPosition;
    public float moveSpeed = 0.1f;
    public float minY = -5f;
    public float maxY = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    public Transform hook;
    public float rotationSpeed = 50f;

    private HookTrigger hookTrigger;

    private void Start()
    {
        hookPosition = hook.localPosition;
        hookTrigger = hook.GetComponent<HookTrigger>();
    }

    void Update()
    {
        // Handle hook movement via gamepad triggers
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float LT = Input.GetAxis("XRI_Left_Trigger");
        float RT = Input.GetAxis("XRI_Right_Trigger");

        if (horizontal > 0f)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (horizontal < 0f)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        if (LT > 0f)
        {
            hookPosition.z -= moveSpeed;
        }
        if (RT > 0f)
        {
            hookPosition.z += moveSpeed;
        }

        hookPosition.y = Mathf.Clamp(hookPosition.y, minY, maxY);
        hookPosition.z = Mathf.Clamp(hookPosition.z, minZ, maxZ);
        hook.localPosition = hookPosition;

        if (vertical > 0f)
        {
            hookPosition.y -= moveSpeed;
        }

        if (vertical < 0f)
        {
            hookPosition.y += moveSpeed;
        }

        hookPosition.y = Mathf.Clamp(hookPosition.y, minY, maxY);
        hookPosition.z = Mathf.Clamp(hookPosition.z, minZ, maxZ);
        hook.localPosition = hookPosition;

        if (Input.GetButtonDown("PickUpButton") || Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pick up crate");
        }

        if (Input.GetButtonDown("DropButton") || Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Drop crate");
        }
    }
}
