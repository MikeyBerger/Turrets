using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{

    public float Timer;
    public float Limit;
    public int Score;
    public int HiScore;
    public Transform[] Spawners;
    public Transform []Enemies;
    public int RandSpawner;
    private int RandEnemy;
    public Text ScoreText;
    public Text HiScoreText;


    IEnumerator LowerLimit()
    {
        yield return new WaitForSeconds(10);
        if (Limit == 300)
        {
           Limit = 300;
        }
        else
        {
           Limit = Limit - .1f;
        }
    }
    //private PlayerScript PS;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        HiScore = PlayerPrefs.GetInt("HiScore");
        // PS = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        RandEnemy = Random.Range(1, 4);
        Timer++;
        SpawnEnemy();
        StartCoroutine(LowerLimit());

        if (Score > HiScore)
        {
            HiScore = Score;
            PlayerPrefs.SetInt("HiScore", HiScore);
        }


        ScoreText.text = "Score: " + Score.ToString();
        HiScoreText.text = "HighScore: " + HiScore.ToString();
    }

    void SpawnEnemy()
    {
        if (Timer >= Limit && RandEnemy == 1)
        {
            RandSpawner = Random.Range(1, 6);
            Instantiate(Enemies[0], Spawners[RandSpawner].position, Spawners[RandSpawner].rotation);
            Timer = 0;
        }
        else if (Timer >= Limit && RandEnemy == 2)
        {
            RandSpawner = Random.Range(1, 6);
            Instantiate(Enemies[1], Spawners[RandSpawner].position, Spawners[RandSpawner].rotation);
            Timer = 0;
        }
        else if (Timer >= Limit && RandEnemy == 3)
        {
            RandSpawner = Random.Range(1, 6);
            Instantiate(Enemies[2], Spawners[RandSpawner].position, Spawners[RandSpawner].rotation);
            Timer = 0;
        }
        else if (Timer >= Limit && RandEnemy == 4)
        {
            RandSpawner = Random.Range(1, 6);
            Instantiate(Enemies[3], Spawners[RandSpawner].position, Spawners[RandSpawner].rotation);
            Timer = 0;
        }
    }
}
