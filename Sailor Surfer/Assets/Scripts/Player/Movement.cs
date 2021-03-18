using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    [Header("Speed")]
    [SerializeField] private float horizontalSpeed = 10f;

    [Header("Borders")]
    [SerializeField] private BorderLimit borderSideLimit = BorderLimit.LIMIT_X;

    [SerializeField] private float minLimitX = -2f;
    [SerializeField] private float maxLimitX = 2f;

    [SerializeField] private float minLimitZ = -2f;
    [SerializeField] private float maxLimitZ = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") + joystick.Horizontal;

        Vector3 movement = transform.forward + (transform.right * moveHorizontal);

        if(borderSideLimit == BorderLimit.LIMIT_X)
        {
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, minLimitX, maxLimitX), rb.position.y, rb.position.z);
        }
        else if (borderSideLimit == BorderLimit.LIMIT_Z)
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, Mathf.Clamp(rb.position.z, minLimitZ, maxLimitZ));
        }
        else if (borderSideLimit == BorderLimit.LIMIT_BOTH)
        {
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, minLimitX, maxLimitX), rb.position.y, Mathf.Clamp(rb.position.z, minLimitZ, maxLimitZ));
        }
        

        rb.velocity = movement * horizontalSpeed;
    }

    public void SetLimit(float _minLimX, float _maxLimX, float _minLimZ, float _maxLimZ, BorderLimit _borderSideLimit)
    {
        borderSideLimit = _borderSideLimit;

        if (_borderSideLimit == BorderLimit.LIMIT_X)
        {
            minLimitX = _minLimX;
            maxLimitX = _maxLimX;
        }
        else if (_borderSideLimit == BorderLimit.LIMIT_Z)
        {
            minLimitZ = _minLimZ;
            maxLimitZ = _maxLimZ;
        }
        else if (_borderSideLimit == BorderLimit.LIMIT_BOTH)
        {
            minLimitX = _minLimX;
            maxLimitX = _maxLimX;

            minLimitZ = _minLimZ;
            maxLimitZ = _maxLimZ;
        }
    }

    public void DisableRigidBody()
    {
        Vector3 zeroVector = Vector3.zero;
        rb.velocity = zeroVector * 0f;
    }
}
