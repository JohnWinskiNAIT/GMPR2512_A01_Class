using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    InputAction moveAction, rotateAction, fireAction;

    [SerializeField] float movementSpeed = 5, rotateSpeed = 500, minRotation = -25, maxRotation = 25, shipHeight, shipWidth;
    [SerializeField] GameObject topBoundry, bottomBoundry, leftBoundry, rightBoundry;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Ship/Move");
        rotateAction = InputSystem.actions.FindAction("Ship/Rotate");

        shipHeight = GetComponent<Collider2D>().bounds.extents.y;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();

        transform.Translate(moveDirection.normalized * movementSpeed * Time.deltaTime);

        if (transform.position.y < bottomBoundry.transform.position.y + shipHeight/2)
        {
            transform.position = new Vector3(transform.position.x, bottomBoundry.transform.position.y + shipHeight/2, transform.position.z); 
        }
        #endregion

        #region Rotation
        float rotateDirection = rotateAction.ReadValue<float>();

        transform.Rotate(0,0,rotateDirection * rotateSpeed * Time.deltaTime);

        Vector3 angles = transform.eulerAngles;

        if (angles.z > 180f)
        {
            angles.z -= 360f;
        }

        angles.z = Mathf.Clamp(angles.z, minRotation, maxRotation);
        transform.eulerAngles = angles;
        #endregion
    }
}
