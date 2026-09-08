using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject ballSpawn;
    Rigidbody2D ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject.GetComponentInParent<Rigidbody2D>();

        if (ball != null)
        {
            ball.linearVelocity = Vector3.zero;
            ball.gameObject.transform.position = ballSpawn.transform.position;
        }
        
    }
}
