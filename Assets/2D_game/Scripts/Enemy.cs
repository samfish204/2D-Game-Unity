using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float speed = 2.5f;
    [SerializeField] private int enemyID = 0;
    [SerializeField] private GameObject turtleDeath = null;
    [SerializeField] private GameObject centipedeDeath = null;

    private UIManager UI = null;
    private GameManager GM = null;
    // private AudioSource DeathSound = null;
    [SerializeField] private AudioClip DeathSound = null;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        // DeathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameOver)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -8.6f)
        {
            float yPos = Random.Range(-2.6f, 2.6f);

            transform.position = new Vector3(8.0f, yPos, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dagger1")
        {
            if (collision.transform.parent == null) // plain dagger1
            {
                Destroy(collision.gameObject);
            } else 
            {
                Destroy(collision.transform.parent.gameObject); // double shot
            }
        } else if (collision.tag == "Dagger2")
        {
            if (collision.transform.parent == null) // plain dagger2
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.transform.parent.gameObject); // triple shot
            }
        } else if (collision.tag == "Player")
        {
            Hero H = collision.GetComponent<Hero>();

            if (H != null)
            {
                if (enemyID == 1)
                {
                    H.Damage();
                } else if (enemyID == 0)
                {
                    H.TurtleDamage();
                }
            }
        }

        // turn on animation for each enemy
        if (enemyID == 0)
        {
            Instantiate(turtleDeath, transform.position, Quaternion.identity);
            UI.UpdateScore(10);
        } else if (enemyID == 1)
        {
            Instantiate(centipedeDeath, transform.position, Quaternion.identity);
            UI.UpdateScore(20);
        }

        // DeathSound.Play();
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, 0.5f);

        Destroy(this.gameObject);
    }
}
