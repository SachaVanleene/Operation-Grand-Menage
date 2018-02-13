using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager_ZombieCitySpawner : MonoBehaviour
{

    [SerializeField] GameObject zombieNormalPrefab;
    [SerializeField] GameObject zombieCracheurPrefab;
    private GameObject[] zombieNormalSpawns;
    private GameObject[] zombieCracheurSpawns;
    private int counter;
    public int numberOfZombiesNormal = 2;
    public int numberOfZombiesCracheur = 1;
    private int maxNumberofZombiesNormal = 10;
    private int maxNumberofZombiesCracheur = 10;
    private float waveRateZombieNormal = 15;
    private float waveRateZombieCracheur = 15;
    private bool isSpawnActivated = true;

    public float timer;

    /*public override void OnStartServer()
    {
        zombieNormalSpawns = GameObject.FindGameObjectsWithTag("ZombieNormalSpawnCity");
        //zombieCracheurSpawns = GameObject.FindGameObjectsWithTag("ZombieCracheurSpawnCity");
        zombieCracheurSpawns = FindComponentInChildWithTag(gameObject, "ZombieCracheurSpawnCity");
        
        //StartCoroutine(ZombieNormalSpawner());
        //StartCoroutine(ZombieCracheurSpawner());
        CommenceSpawn();
    }*/

    public void Start()
    {
        zombieNormalSpawns = GameObject.FindGameObjectsWithTag("ZombieNormalSpawnCity");
        //zombieCracheurSpawns = GameObject.FindGameObjectsWithTag("ZombieCracheurSpawnCity");
        zombieCracheurSpawns = Helper.FindComponentInChildWithTag(this.gameObject, "ZombieCracheurSpawnCity");

        //StartCoroutine(ZombieNormalSpawner());
        //StartCoroutine(ZombieCracheurSpawner());
        CommenceSpawn();

       // timer = 0f;
    }

   


    void CommenceSpawn()
    {
            for (int i = 0; i < zombieNormalSpawns.Length; i++)
            {
                for (int j = 0; j < numberOfZombiesNormal; j++)
                {
                    //int randomindex = Random.Range(0, zombieNormalSpawns.Length);
                    //SpawnZombies(zombieNormalSpawns[randomindex].transform.position, zombieNormalPrefab);
                    SpawnZombies(zombieNormalSpawns[i].transform.position, zombieNormalPrefab);
               }
            }

            for (int i = 0; i < zombieCracheurSpawns.Length; i++)
            {
                for (int j = 0; j < numberOfZombiesCracheur; j++)
                {
                    Debug.LogError("Spawning cracheur");
                    //int randomindex = Random.Range(0, zombieCracheurSpawns.Length);
                    //SpawnZombies(zombieCracheurSpawns[randomindex].transform.position, zombieCracheurPrefab);
                    SpawnZombies(zombieCracheurSpawns[i].transform.position, zombieCracheurPrefab);
                }
            }
    }

    public void SpawnZombies(Vector3 spawnPos, GameObject prefab)
    {
        //counter++;
        GameObject zombie = GameObject.Instantiate(prefab, spawnPos, Quaternion.identity) as GameObject;
        //Instantiate(zombie);
        NetworkServer.Spawn(zombie);
        zombie.GetComponent<Zombie_ID>().zombieID = "Zombie" + counter;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waveRateZombieCracheur)
        {
            timer = 0f;
            CommenceSpawn();
        }
    }


    
}


