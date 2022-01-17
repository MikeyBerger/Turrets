using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public float Timer;
    public float Limit;
    public Transform[] Spawners;
    public Transform []Enemies;
    public int RandSpawner;
    private int RandEnemy;
    public bool P2;
    public bool P3;
    public bool P4;
    private PlayerScript PS;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        RandEnemy = Random.Range(1, 4);
        Timer++;
        SpawnEnemy();
        RegisterPlayers();

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

    void RegisterPlayers()
    {
        if (PS.PI.playerIndex == 3)
        {
            Debug.Log("3 Players Present!!");
        }
    }
}
