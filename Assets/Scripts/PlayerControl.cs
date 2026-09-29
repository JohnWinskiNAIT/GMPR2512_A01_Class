using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D ball;
    [SerializeField] HingeJoint2D leftFlipper, rightFlipper;
    [SerializeField] GameObject launcher, upperLimit, lowerLimit;

    public bool canLaunch;
    [SerializeField] float launcherSpeedDown, launcherSpeedUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canLaunch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && canLaunch)
        {
            ball.constraints = RigidbodyConstraints2D.None;
            canLaunch = false;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            launcher.transform.Translate(Vector2.down * Time.deltaTime * launcherSpeedDown);

            if (launcher.transform.position.y < lowerLimit.transform.position.y)
            {
                launcher.transform.position = new Vector2(launcher.transform.position.x ,lowerLimit.transform.position.y);
            }
        }
        else
        {
            float distance = Vector2.Distance(launcher.transform.position, upperLimit.transform.position);
            launcher.transform.Translate(Vector2.up * Time.deltaTime * launcherSpeedUp);

            if (launcher.transform.position.y > upperLimit.transform.position.y)
            {
                launcher.transform.position = new Vector2(launcher.transform.position.x, upperLimit.transform.position.y);
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }

        if (Keyboard.current.aKey.isPressed)
        {
            leftFlipper.useMotor = true;
        }
        else
        {
            leftFlipper.useMotor = false;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            rightFlipper.useMotor = true;
        }
        else
        {
            rightFlipper.useMotor = false;
        }
    }
}
