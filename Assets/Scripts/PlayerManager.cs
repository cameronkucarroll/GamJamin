using JetBrains.Annotations;
using UnityEngine;
using GamJamin;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    private TileManager tileManager;
    private SystemMessageUpdater messageUpdater;

    public GameObject creaturesPrefab; // the creature prefab thats gonna be instantiated

    public Transform playerTile1Transform; // where the creatures will go this will be set as a slot later
    public Transform playerTile2Transform;

    public List<Creature> playerCreaturesInventory; // the players creature inventory

    public List<GameObject> creaturesOnFeild = new List<GameObject>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {

        tileManager = FindFirstObjectByType<TileManager>();
        messageUpdater = FindFirstObjectByType<SystemMessageUpdater>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendOutCreature(int creatureInventoryIndex)
    {
        if (tileManager.tile1IsFull == false)
        {
            // instantiates the creature at a set position
            GameObject newplayerCreature = Instantiate(creaturesPrefab, playerTile1Transform);



            // sets the instanitaed creatures data by going into the instantiated components CreatureDataLoader Script and setting creature data to the data in the inventory
            newplayerCreature.GetComponent<CreatureDataLoader>().creatureData = playerCreaturesInventory[creatureInventoryIndex];
            newplayerCreature.GetComponent<CreatureDataLoader>().UpdateCreatureDataVisuals();

            // sets the summon spot to full
            tileManager.tile1IsFull = true;

            // assign the Instantitated objects to a list
            creaturesOnFeild.Add(newplayerCreature);
        }
        else if (tileManager.tile1IsFull == true && tileManager.tile2IsFull == false)
        {
            // instantiates the creature at a set position
            GameObject newplayerCreature = Instantiate(creaturesPrefab, playerTile2Transform);



            // sets the instanitaed creatures data by going into the instantiated components CreatureDataLoader Script and setting creature data to the data in the inventory
            newplayerCreature.GetComponent<CreatureDataLoader>().creatureData = playerCreaturesInventory[creatureInventoryIndex];
            newplayerCreature.GetComponent<CreatureDataLoader>().UpdateCreatureDataVisuals();

            // sets the summon spot to full
            tileManager.tile2IsFull = true;

            // assign the Instantitated objects to a list
            creaturesOnFeild.Add(newplayerCreature);
        }
        else if (tileManager.tile1IsFull && tileManager.tile2IsFull)
        {
            messageUpdater.UpdateSystemMessage("You have max summons out");
        }

    }

    public void RemoveCreaturesOnFeild(List<GameObject> creatures) // can use for enemy creatures and ally creatures // removes creatues
    {
        for (int i = 0; i < creatures.Count; i++)
        {
            Destroy(creatures[i]);
            creatures.RemoveAt(i);
            tileManager.tile2IsFull = false;
            tileManager.tile1IsFull = false;
        }
    }
}
