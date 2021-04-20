using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleSpawner : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] spawnPoints;
    public float gameTime = 0;
    public Text gameText;
    private GameObject mole;
    public float moleTime;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        moleTime -= Time.deltaTime;
        gameTime -= Time.deltaTime;

        if(gameTime >= 10)
        {
            if (moleTime <= 0)
            {
                Destroy(mole);
                Spawn();
                moleTime = 2;
            }
        } else if (gameTime < 10)
        {
            if (moleTime <= 0)
            {
                Destroy(mole);
                Spawn();
                moleTime = 1;
            }
        }
        

        if(gameTime < 1)
        {
            Destroy(mole);
            gameTime = 0;
            moleTime = 0;
        }

        gameText.text = gameTime.ToString("f1");
    }

    public void Spawn()
    {
        mole = Instantiate(molePrefab) as GameObject;
        mole.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }
}
