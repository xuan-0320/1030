using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float cameraHeight = 15f;
    public float smoothSpeed = 8f;

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition = target.position + new Vector3(0f, cameraHeight, 0f);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}