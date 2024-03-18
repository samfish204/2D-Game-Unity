using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrpl : MonoBehaviour
{
    private float speed = 3.0f;

    private GameManager GM = null;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameOver)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Hero H = collision.GetComponent<Hero>();

            if (H != null)
            {
                H.TrplShotPowerUp();
            }
            Destroy(this.gameObject); // if inside the if statement, only the player can destroy it?
        }
        else // destory if any collisions other than the player are made
        {
            Destroy(this.gameObject);
        }
        Debug.Log("triggered by " + collision.name);
    }
    // boolean to track whether powerup has been called in each double and triple?
}
