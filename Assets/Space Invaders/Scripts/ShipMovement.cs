using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    InputAction moveAction, rotateAction, fireAction;

    [SerializeField] float movementSpeed = 5, rotateSpeed = 500, minRotation = -25, maxRotation = 25, shipHeight, shipWidth;
    [SerializeField] float bulletSpeed = 5, fireRate = 0.2f, timeStamp;
    [SerializeField] int ammo = 5;
    [SerializeField] List<GameObject> bullets;
    [SerializeField] GameObject topBoundry, bottomBoundry, leftBoundry, rightBoundry;

    [SerializeField] GameObject weaponLocation, bullet;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Ship/Move");
        rotateAction = InputSystem.actions.FindAction("Ship/Rotate");
        fireAction = InputSystem.actions.FindAction("Ship/Fire");

        shipHeight = GetComponent<Collider2D>().bounds.extents.y;
        shipWidth = GetComponent<Collider2D>().bounds.extents.x;
    }

    private void Start()
    {
        for(int i = 0;  i < ammo; i++)
        {
            bullets.Add(Instantiate(bullet, Vector3.zero, Quaternion.identity));
            bullets[i].SetActive(false);
        }
    }

    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
        fireAction.Enable();

        fireAction.performed += FireButtonPressed;
        fireAction.canceled += FireButtonReleased;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
        fireAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();

        transform.Translate(moveDirection.normalized * movementSpeed * Time.deltaTime, Space.World);

        if (transform.position.y < bottomBoundry.transform.position.y + shipHeight/2)
        {
            transform.position = new Vector3(transform.position.x, bottomBoundry.transform.position.y + shipHeight/2, transform.position.z); 
        }

        if (transform.position.y > topBoundry.transform.position.y - shipHeight / 2)
        {
            transform.position = new Vector3(transform.position.x, topBoundry.transform.position.y - shipHeight / 2, transform.position.z);
        }

        if (transform.position.x > rightBoundry.transform.position.x + shipWidth / 2)
        {
            transform.position = new Vector3(rightBoundry.transform.position.x + shipWidth / 2, transform.position.y, transform.position.z);
        }

        if (transform.position.x < leftBoundry.transform.position.x - shipWidth / 2)
        {
            transform.position = new Vector3(leftBoundry.transform.position.x - shipWidth / 2, transform.position.y, transform.position.z);
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

    void FireButtonPressed(InputAction.CallbackContext context)
    {
        if (Time.time > timeStamp + fireRate)
        {
            timeStamp = Time.time;

            bool found = false;

            for (int i = 0; i < bullets.Count && !found; i++)
            {
                if (bullets[i].activeSelf == false)
                {
                    found = true;
                    bullets[i].transform.position = weaponLocation.transform.position;
                    bullets[i].transform.rotation = weaponLocation.transform.rotation;

                    bullets[i].SetActive(true);

                    bullets[i].GetComponent<Rigidbody2D>().linearVelocity = bullets[i].transform.up * bulletSpeed;
                }
            }
        }
        
    }

    void FireButtonReleased(InputAction.CallbackContext context)
    {

    }
}
