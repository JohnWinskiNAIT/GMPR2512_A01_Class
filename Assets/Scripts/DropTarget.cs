using UnityEngine;

public class DropTarget : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] BoxCollider2D collide;

    [SerializeField] bool autoReset;
    [SerializeField] float resetTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rend.color = Color.gray;
        collide.enabled = false;

        if (autoReset)
        {
            Invoke("DelayReset", resetTime);
        }
    }
    
    public void ResetTarget(float resetTime)
    {
        Invoke("DelayReset", resetTime);
    }

    public bool IsTargetActive()
    {
        return collide.enabled;
    }

    void DelayReset()
    {
        rend.color = Color.white;
        collide.enabled = true;
    }
}
