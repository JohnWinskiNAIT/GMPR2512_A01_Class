using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D ball;

    public bool canLaunch;
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
    }
}
