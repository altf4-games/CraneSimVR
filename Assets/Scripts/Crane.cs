using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    private Vector3 hookPosition;
    public float moveSpeed = 0.1f;
    public float minY = -5f;
    public float maxY = 5f;

    public Transform hook;
    public float rotationSpeed = 50f;

    private void Start()
    {
        hookPosition = hook.localPosition;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0f)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (horizontal < 0f)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        if (vertical > 0f)
        {
            hookPosition.y -= moveSpeed;
        }

        if (vertical < 0f)
        {
            hookPosition.y += moveSpeed;
        }

        hookPosition.y = Mathf.Clamp(hookPosition.y, minY, maxY);
        hook.localPosition = hookPosition;
    }
}
