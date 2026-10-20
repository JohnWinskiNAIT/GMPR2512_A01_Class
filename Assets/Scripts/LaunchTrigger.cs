using UnityEngine;

public class LaunchTrigger : MonoBehaviour
{
    [SerializeField] PlayerControl playerInput;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInput.canLaunch = true;
        playerInput.flippersActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInput.canLaunch = false;
    }
}
