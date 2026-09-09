using UnityEngine;

public class CircleBumper : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] GameObject outerCircle;
    float timeStamp;
    [SerializeField] float delayTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeStamp + delayTime && rend.color == Color.white)
        {
            rend.color = Color.black;
            outerCircle.transform.localScale = new Vector3(2.2f, 2.2f, 0);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timeStamp = Time.time;
        rend.color = Color.white;
        outerCircle.transform.localScale = new Vector3(2.5f, 2.5f, 0);
    }
}
