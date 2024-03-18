using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float speed = 3.0f;
    [SerializeField] private int powerUpID = 0;
    [SerializeField] private AudioClip[] PowerUpSounds = null;

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
                if (powerUpID == 0)
                {
                    // i = 0;
                    H.DblShotPowerUp();
                } else if (powerUpID == 1)
                {
                    // i = 1;
                    H.TrplShotPowerUp(); // STILL NEED TO WRITE THIS AND CHANGE SCRIPTS
                } else if (powerUpID == 2)
                {
                    // i = 2;
                    H.SpeedBoostPowerUp();
                } else if (powerUpID == 3)
                {
                    // i = 3;
                    H.SlowPowerUp();
                } else if (powerUpID == 4)
                {
                    // i = 4;
                    H.LifePowerUp();
                } else if (powerUpID == 5) {
                    // i = 5;
                    H.ShieldPowerUp();
                }
            }
            AudioSource.PlayClipAtPoint(PowerUpSounds[powerUpID], Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject); // if inside the if statement, only the player can destroy it?
        } else // destory if any collisions other than the player are made
        {
            Destroy(this.gameObject);
        }
        Debug.Log("triggered by " + collision.name);
    }

}
