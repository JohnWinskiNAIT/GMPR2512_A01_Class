using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float moveDirection = 1, moveSpeed = 3.0f, moveDelay = 0.5f, dropDistance = 0.5f, timeStamp;

    [SerializeField] float bulletSpeed = 5, fireRate = 2.0f, fireStamp;
    [SerializeField] int ammo = 5;
    [SerializeField] List<GameObject> bullets, aliens, bottomRow;

    [SerializeField] GameObject bullet;
    Vector2 weaponLocation;

    LayerMask alienMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alienMask = LayerMask.GetMask("Alien");
        for (int i = 0; i < ammo; i++)
        {
            bullets.Add(Instantiate(bullet, Vector3.zero, Quaternion.identity));
            bullets[i].SetActive(false);
        }
        CreateBottomRow();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);

        if (Time.time > fireStamp + fireRate)
        {
            fireStamp = Time.time;

            bool found = false;
            int rand = Random.Range(0, bottomRow.Count);

            weaponLocation = bottomRow[rand].transform.position + Vector3.down;
  
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
            CreateBottomRow();
        }     
        if (collision.transform.tag == "Boundry" && Time.time > timeStamp + moveDelay)
        {
            timeStamp = Time.time;
            moveDirection = -moveDirection;
            transform.position += Vector3.down * dropDistance;
        }
    }

    void CreateBottomRow()
    {
        bottomRow.Clear();
        foreach (GameObject alien in aliens)
        {
            if (alien.activeSelf == true)
            {
                RaycastHit2D hit = Physics2D.Raycast(alien.transform.position + Vector3.down, Vector2.down, 3.0f);
                if (hit.collider == null)
                {
                    bottomRow.Add(alien);
                }
                else
                {
                    //Debug.Log(hit.collider.name);
                }
            }            
        }
    }
}
