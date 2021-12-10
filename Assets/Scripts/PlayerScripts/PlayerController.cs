using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    CharacterController player;
    [SerializeField]
    Camera camera;
    [SerializeField]
    Transform weaponsCamera;
    PlayerVitals playerVitals;
    [HideInInspector]
    public float moveFB;
    [HideInInspector]
    public float strafe;
    float rotationX;
    float rotationY;
    #endregion

    #region Public Variables
    public float verticalVelocity;
    public float maximumSpeed;
    public float currentSpeed;
    public float baseSpeed;
    public float verticalSensitivity;
    public float horizontalSensitivity;
    public float jumpForce;
    public float gravity;
    public bool isCrouch;
    public PreferredSensitivity preferredSensitivity;
    #endregion

    #region Monobehavior
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerVitals = GetComponent<PlayerVitals>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Physics.IgnoreLayerCollision(11, 10);
        preferredSensitivity = FindObjectOfType<PreferredSensitivity>();
    }

    void LateUpdate()
    {
        PlayerMovement();
        Crouch();
        PlayerVitalInfo();
        weaponsCamera.rotation = camera.transform.rotation;
    }
    void Update()
    {
        verticalSensitivity = preferredSensitivity.preferredMouseLookSensitivity;
        horizontalSensitivity = preferredSensitivity.preferredMouseLookSensitivity;
    }
    void FixedUpdate()
    {
        Gravity();
        if (player.height < 1.8f && !isCrouch)
        {
            player.height = player.height + 10.0f * Time.deltaTime;
            player.center = new Vector3(0, 0, 0);
        }
        if (player.height > 1.8f)
        {
            player.height = 1.8f;
        }
    }
    #endregion

    #region Custom
    void PlayerMovement()
    {
        moveFB = Input.GetAxis("Vertical") * currentSpeed;
        strafe = Input.GetAxis("Horizontal") * currentSpeed;

        rotationX = Input.GetAxisRaw("Mouse X") * horizontalSensitivity;
        rotationY -= Input.GetAxisRaw("Mouse Y") * verticalSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        Vector3 movement = new Vector3(strafe, 0, moveFB);
        Vector3 Jump = new Vector3(0, verticalVelocity, 0);
        movement = movement.normalized * Time.deltaTime * currentSpeed;
        transform.Rotate(0, rotationX, 0);
        camera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        movement = transform.rotation * movement;

        if (Input.GetKey(KeyCode.Space) && verticalVelocity == 0)
        {
            verticalVelocity += Mathf.Sqrt(jumpForce * -2f * gravity);
            isCrouch = false;
        }

        player.Move(movement);
        player.Move(Jump * Time.deltaTime);
    }

    void Gravity()
    {
        if (player.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        if (verticalVelocity > 0.5)
        {
            player.slopeLimit = 90;
        }
        else player.slopeLimit = 60;
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isCrouch)
        {
            isCrouch = true;
            player.height = 0.5f;
            player.center = Vector3.down * (1 - player.height) / 8.0f;
            currentSpeed = currentSpeed / 5f;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouch)
        {
            isCrouch = false;
            currentSpeed = baseSpeed;
        }
    }

    void PlayerVitalInfo()
    {

    }
    #endregion
}
