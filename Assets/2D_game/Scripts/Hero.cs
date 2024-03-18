using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hero : MonoBehaviour
{
    private SpriteRenderer spr;
    // private Color sprColor = Color.white;

    [SerializeField] private float speed = 5.0f;
    private float fireRate1 = 0.5f;
    private float canFire1 = 0.05f;
    private float fireRate2 = 1.0f;
    private float canFire2 = 0.05f;
    [SerializeField] private bool canDblShot = false;
    [SerializeField] private bool canTrplShot = false;

    [SerializeField] private int lives = 3;

    System.Random random = new System.Random();

    [SerializeField] private GameObject Dagger1Prefab = null;
    [SerializeField] private GameObject Dagger2Prefab = null;

    [SerializeField] private GameObject DoubleShotPrefab = null;
    [SerializeField] private GameObject TripleShotPrefab = null;
    private bool dblCalled = false;
    private bool trplCalled = false;

    [SerializeField] private GameObject heroDeath = null;
    [SerializeField] private GameObject heroExplosion = null;

    [SerializeField] private bool canShield = false;
    [SerializeField] private GameObject heroShield = null;

    private AudioSource DaggerSound = null;
    [SerializeField] AudioClip DamageSound = null;
    [SerializeField] AudioClip DeathSound = null;

    private UIManager UI = null;

    private SpawnManager SM = null;

    private GameManager GM = null;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        transform.position = new Vector3(-4.04f, 0f, 0f);

        UI = GameObject.Find("Canvas").GetComponent<UIManager>();

        lives = 3;
        UI.UpdateLives(lives);

        SM = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (SM != null)
        {
            SM.StartSpawnRoutine();
        }

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        DaggerSound = GetComponent<AudioSource>();

        Debug.Log("Hello World!");

    } // end start

    // Update is called once per frame
    void Update()
    {
        if (!GM.paused)
        {
            Move();

            Bounds();

            Throw();
        }
    } // end update

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(random.Next(-8, -4), random.Next(-3, 4), 0);
        }
    } // end move

    void Bounds()
    {
        if (transform.position.y > 3.3f)
        {
            transform.position = new Vector3(transform.position.x, -2.18f, 0);
        } else if (transform.position.y < -2.18f)
        {
            transform.position = new Vector3(transform.position.x, 3.3f, 0);
        }

        if (transform.position.x > -3.9f)
        {
            transform.position = new Vector3(-3.9f, transform.position.y, 0);
        } else if (transform.position.x < -7.48f)
        {
            transform.position = new Vector3(-7.48f, transform.position.y, 0);
        }
    } // end bounds

    private void Throw()
    {
        if (canShield)
        {
            // press space bar to fire weapon 1
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (Time.time > canFire1)
                {

                    DaggerSound.Play();

                    if (canDblShot == false)
                    {
                        Instantiate(Dagger1Prefab, transform.position + new Vector3(0.4f, 0.8f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(DoubleShotPrefab, transform.position + new Vector3(0.4f, 0.8f, 0), Quaternion.identity);
                    }
                    canFire1 = Time.time + (fireRate1 * 2);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (Time.time > canFire2)
                {

                    DaggerSound.Play();

                    if (canTrplShot == false)
                    {
                        Instantiate(Dagger2Prefab, transform.position + new Vector3(0.3f, 0.2f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(TripleShotPrefab, transform.position + new Vector3(0.4f, 0.8f, 0), Quaternion.identity);
                    }
                    canFire2 = Time.time + (fireRate2 * 2);
                }
            }
        } else
        {
            // press space bar to fire weapon 1
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (Time.time > canFire1)
                {

                    DaggerSound.Play();

                    if (canDblShot == false)
                    {
                        Instantiate(Dagger1Prefab, transform.position + new Vector3(0.4f, 0.8f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(DoubleShotPrefab, transform.position + new Vector3(0.4f, 0.8f, 0), Quaternion.identity);
                    }
                    canFire1 = Time.time + fireRate1;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (Time.time > canFire2)
                {

                    DaggerSound.Play();

                    if (canTrplShot == false)
                    {
                        Instantiate(Dagger2Prefab, transform.position + new Vector3(0.3f, 0.2f, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(TripleShotPrefab, transform.position + new Vector3(0.4f, 0.8f, 0), Quaternion.identity);
                    }
                    canFire2 = Time.time + fireRate2;
                }
            }
        }
    }

    public void setDblShot(bool dblShot)
    {
        canDblShot = dblShot;
    }

    public void setTrplShot(bool trplShot)
    {
        canTrplShot = trplShot;
    }

    public IEnumerator DblShotPowerDown()
    {
        while (dblCalled)
        {
            // trplCalledAgain = false;
            // canTrplShot = true;
            yield return new WaitForEndOfFrame();
            if (canDblShot == false)
            {
                canDblShot = true;
                dblCalled = false;
            }
        }
        yield return new WaitForSeconds(3.0f);
        canDblShot = false;
    }

    public void DblShotPowerUp()
    {
        //if statement here to check whether canShot is true;
        if (canDblShot == true)
        {
            dblCalled = true;
            // StartCoroutine(TrplShotPowerDown());
        }
        canDblShot = true;

        StartCoroutine(DblShotPowerDown());
    }

    public IEnumerator TrplShotPowerDown()
    {
        while (trplCalled)
        {
            // trplCalledAgain = false;
            // canTrplShot = true;
            yield return new WaitForEndOfFrame();
            if (canTrplShot == false)
            {
                canTrplShot = true;
                trplCalled = false;
            }
        }
        yield return new WaitForSeconds(3.0f);
        canTrplShot = false;
    }

    public void TrplShotPowerUp()
    {
        //if statement here to check whether canShot is true;
        if (canTrplShot == true)
        {
            trplCalled = true;
            // StartCoroutine(TrplShotPowerDown());
        }
        canTrplShot = true;

        StartCoroutine(TrplShotPowerDown());
    }

    public void SpeedBoostPowerUp()
    {
        speed = 10.0f;

        StartCoroutine(SpeedBoostPowerDown());
    }

    private IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(3.0f);

        speed = 5.0f;
    }

    public void SlowPowerUp()
    {
        speed = 2.5f;

        StartCoroutine(SlowPowerDown());
    }

    private IEnumerator SlowPowerDown()
    {
        yield return new WaitForSeconds(3.0f);

        speed = 5.0f;
    }

    public void ShieldPowerUp()
    {
        canShield = true;
        heroShield.SetActive(true);
    }

    public void Damage() // call this centipede damage
    {
        if (!canShield) {
            spr.color = UnityEngine.Random.ColorHSV();
            lives--;
            UI.UpdateLives(lives);
            AudioSource.PlayClipAtPoint(DamageSound, Camera.main.transform.position);
        } else
        {
            canShield = false;
            heroShield.SetActive(false);
        }

        if (lives < 1) 
        {
            spr.color = UnityEngine.Random.ColorHSV();

            GM.gameOver = true;

            AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position);

            UI.ShowGameOverScreen();
            // animation
            Instantiate(heroDeath, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    public void TurtleDamage()
    {
        if (!canShield)
        {
            spr.color = UnityEngine.Random.ColorHSV();
            lives--;
            UI.UpdateLives(lives);
            AudioSource.PlayClipAtPoint(DamageSound, Camera.main.transform.position);
        } else
        {
            canShield = false;
            heroShield.SetActive(false);
        }

        if (lives < 1)
        {
            spr.color = UnityEngine.Random.ColorHSV();

            GM.gameOver = true;

            AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position);

            UI.ShowGameOverScreen();

            Instantiate(heroExplosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    public void LifePowerUp()
    {
        lives++;
        if (lives <= 2)
        {
            spr.color = UnityEngine.Random.ColorHSV();
        }
    }

} // end class
