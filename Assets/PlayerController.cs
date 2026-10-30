using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [Header("移動速度")]
    public float moveSpeed = 5f;
    [Header("場地範圍")]
    public float limitX = 8.5f;
    public float limitZ = 8.5f;
    private Rigidbody rb;
    private Vector3 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal, 0f, vertical).normalized;
    }
    void FixedUpdate()
        {
            Vector3 next = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
            next.x = Mathf.Clamp(next.x, -limitX, limitX);
            next.z = Mathf.Clamp(next.z, -limitZ, limitZ);
            rb.MovePosition(next);
        }

    }
