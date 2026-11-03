using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float moveDirection = 1, moveSpeed = 3.0f, moveDelay = 0.5f, timeStamp;

    [SerializeField] float bulletSpeed = 5, fireRate = 2.0f, fireStamp;
    [SerializeField] int ammo = 5;
    [SerializeField] List<GameObject> bullets, aliens;

    [SerializeField] GameObject bullet;
    Vector2 weaponLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < ammo; i++)
        {
            bullets.Add(Instantiate(bullet, Vector3.zero, Quaternion.identity));
            bullets[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);

        if (Time.time > fireStamp + fireRate)
        {
            fireStamp = Time.time;

            bool found = false;
            for (int i = 0; i < aliens.Count && !found; i++)
            {
                if (aliens[i].activeSelf == true)
                {
                    found = true;
                    weaponLocation = aliens[i].transform.position + Vector3.down;
                }
            }

            found = false;
            for (int i = 0; i < bullets.Count && !found; i++)
            {
                if (bullets[i].activeSelf == false)
                {
                    found = true;
                    bullets[i].transform.position = weaponLocation;
                    bullets[i].transform.rotation = Quaternion.identity;

                    bullets[i].SetActive(true);

                    bullets[i].GetComponent<Rigidbody2D>().linearVelocity = -bullets[i].transform.up * bulletSpeed;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ShipBullet")
        {
            collision.otherCollider.gameObject.SetActive(false);
        }     
        if (collision.transform.tag == "Boundry" && Time.time > timeStamp + moveDelay)
        {
            timeStamp = Time.time;
            moveDirection = -moveDirection;
        }
    }
}
