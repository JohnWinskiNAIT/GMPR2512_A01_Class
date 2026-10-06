using UnityEngine;

public class LaunchTrigger : MonoBehaviour
{
    [SerializeField] GameObject playerInput;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInput.GetComponent<PlayerControl>().canLaunch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInput.GetComponent<PlayerControl>().canLaunch = false;
    }
}
