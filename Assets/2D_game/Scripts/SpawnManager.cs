using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager GM = null;

    [SerializeField] private GameObject[] Enemies = null;
    [SerializeField] private GameObject[] PowerUps = null;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawnRoutine() 
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            int rand = Random.Range(0, 2);
            float tRand = Random.Range(2.0f, 6.0f);
            float cRand = Random.Range(4.0f, 6.0f);
            float yPos = Random.Range(-2.6f, 2.6f);
            if (rand == 0)
            {
                yield return new WaitForSeconds(tRand);
                Instantiate(Enemies[0], new Vector3(8.0f, yPos, 0), Quaternion.identity);
            }
            else if (rand == 1)
            {
                yield return new WaitForSeconds(cRand);
                Instantiate(Enemies[1], new Vector3(8.0f, yPos, 0), Quaternion.identity);
            }
        }
    }

    IEnumerator PowerUpSpawn()
    {
        while (!GM.gameOver)
        {
            int rand = Random.Range(0, 6);
            int halfRand = Random.Range(0, 2);
            int thirdRand = Random.Range(0, 3);
            float randTime = Random.Range(5.0f, 9.0f);
            float xPos = Random.Range(-7.48f, -3.9f);
            if (rand == 0 && halfRand == 0)
            {
                yield return new WaitForSeconds(randTime);
                Instantiate(PowerUps[0], new Vector3(xPos, 4.5f, 0), Quaternion.identity);
            }
            else if (rand == 1 && thirdRand == 0)
            {
                yield return new WaitForSeconds(randTime);
                Instantiate(PowerUps[1], new Vector3(xPos, 4.5f, 0), Quaternion.identity);
            }
            else if (rand == 2 && halfRand == 1)
            {
                yield return new WaitForSeconds(randTime);
                Instantiate(PowerUps[2], new Vector3(xPos, 4.5f, 0), Quaternion.identity);
            }
            else if (rand == 3)
            {
                yield return new WaitForSeconds(randTime);
                Instantiate(PowerUps[3], new Vector3(xPos, 4.5f, 0), Quaternion.identity);
            }
            else if (rand == 4 && thirdRand == 1)
            {
                yield return new WaitForSeconds(randTime);
                Instantiate(PowerUps[4], new Vector3(xPos, 4.5f, 0), Quaternion.identity);
            }
            else if (rand == 5 && thirdRand == 2)
            {
                yield return new WaitForSeconds(randTime);
                Instantiate(PowerUps[5], new Vector3(xPos, 4.5f, 0), Quaternion.identity);
            }
        }
    }
}
