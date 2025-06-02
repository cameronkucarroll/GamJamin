using NUnit.Framework;
using UnityEngine;
using GamJamin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    private TileManager tileManager;
    private SystemMessageUpdater messageUpdater;

    public GameObject creaturesPrefab;

    public bool allEnemiesOut = false;





    public List<Creature> enemyCreaturePool; // list of creatures the enemy can Instantiate 
    public List<GameObject> enemiesOnFeild = new List<GameObject>();
    public Transform enemyTile1Transform;
    public Transform enemyTile2Transform;
    public Transform enemyTile3Transform;

    private void Awake()
    {
        tileManager = FindFirstObjectByType<TileManager>();
        messageUpdater = FindFirstObjectByType<SystemMessageUpdater>();
    }

    private void Update()
    {

    }

    public void SpawnEnemyCreature(int creatureInventoryIndex)
    {
        if (tileManager.enemyTile1IsFull == false && tileManager.enemyTile2IsFull == false && tileManager.enemyTile3IsFull == false)
        {
            // instantiates the creature at a set position
            GameObject newplayerCreature = Instantiate(creaturesPrefab, enemyTile1Transform);



            // sets the instanitaed creatures data by going into the instantiated components CreatureDataLoader Script and setting creature data to the data in the inventory
            newplayerCreature.GetComponent<CreatureDataLoader>().creatureData = enemyCreaturePool[creatureInventoryIndex];
            newplayerCreature.GetComponent<CreatureDataLoader>().isEnemy = true;
            newplayerCreature.GetComponent<CreatureDataLoader>().currentSlotIndex = 1;

            newplayerCreature.GetComponent<CreatureDataLoader>().UpdateCreatureDataVisuals();
            messageUpdater.UpdateSystemMessage("Enemy appeared!"); // sets the board message

            // sets the summon spot to full
            tileManager.enemyTile1IsFull = true;

            // assign the Instantitated objects to a list
            enemiesOnFeild.Add(newplayerCreature);
        }
        else if (tileManager.enemyTile1IsFull == true && tileManager.enemyTile2IsFull == false && tileManager.enemyTile3IsFull == false)
        {
            // instantiates the creature at a set position
            GameObject newplayerCreature = Instantiate(creaturesPrefab, enemyTile2Transform);



            // sets the instanitaed creatures data by going into the instantiated components CreatureDataLoader Script and setting creature data to the data in the inventory
            newplayerCreature.GetComponent<CreatureDataLoader>().creatureData = enemyCreaturePool[creatureInventoryIndex];
            newplayerCreature.GetComponent<CreatureDataLoader>().isEnemy = true;
            newplayerCreature.GetComponent<CreatureDataLoader>().currentSlotIndex = 2;
            newplayerCreature.GetComponent<CreatureDataLoader>().UpdateCreatureDataVisuals();
            messageUpdater.UpdateSystemMessage("Enemy appeared!"); // sets the board message

            // sets the summon spot to full
            tileManager.enemyTile2IsFull = true;

            // assign the Instantitated objects to a list
            enemiesOnFeild.Add(newplayerCreature);
        }
        else if (tileManager.enemyTile1IsFull == true && tileManager.enemyTile2IsFull == true && tileManager.enemyTile3IsFull == false)
        {
            // instantiates the creature at a set position
            GameObject newplayerCreature = Instantiate(creaturesPrefab, enemyTile3Transform);



            // sets the instanitaed creatures data by going into the instantiated components CreatureDataLoader Script and setting creature data to the data in the inventory
            newplayerCreature.GetComponent<CreatureDataLoader>().creatureData = enemyCreaturePool[creatureInventoryIndex];
            newplayerCreature.GetComponent<CreatureDataLoader>().UpdateCreatureDataVisuals();
            newplayerCreature.GetComponent<CreatureDataLoader>().isEnemy = true;
            newplayerCreature.GetComponent<CreatureDataLoader>().currentSlotIndex = 3;
            messageUpdater.UpdateSystemMessage("Enemy appeared!"); // sets the board message

            // sets the summon spot to full
            tileManager.enemyTile3IsFull = true;

            // assign the Instantitated objects to a list
            enemiesOnFeild.Add(newplayerCreature);
        }
        else
        {
            return;
        }
    }
}
