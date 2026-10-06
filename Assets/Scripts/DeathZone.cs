using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject ballSpawn, playerInput;
    [SerializeField] float spawnDelay = 2.0f;
    Rigidbody2D ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();

        DeactivateBall();
    }

    void DeactivateBall()
    {
        if (ball != null)
        {
            // Stop the ball's velocity before repositioning it.
            ball.linearVelocity = Vector3.zero;
            ball.angularVelocity = 0;
            ball.transform.rotation = Quaternion.identity;
            ball.gameObject.transform.position = ballSpawn.transform.position;

            //ball.constraints = RigidbodyConstraints2D.FreezePositionX;
            //ball.constraints = RigidbodyConstraints2D.FreezePositionY;

            ball.gameObject.SetActive(false);

            Invoke("ReactivateBall", spawnDelay);
        }
    }

    void ReactivateBall()
    {
        ball.gameObject.SetActive(true);        
    }
}
