using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject ballSpawn, playerInput;
    Rigidbody2D ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();

        if (ball != null)
        {
            // Stop the ball's velocity before repositioning it.
            ball.linearVelocity = Vector3.zero;
            ball.angularVelocity = 0;
            ball.transform.rotation = Quaternion.identity;
            ball.gameObject.transform.position = ballSpawn.transform.position;

            ball.constraints = RigidbodyConstraints2D.FreezePositionX;
            ball.constraints = RigidbodyConstraints2D.FreezePositionY;

            playerInput.GetComponent<PlayerControl>().canLaunch = true;
        }
    }
}
