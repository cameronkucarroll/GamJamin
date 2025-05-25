using JetBrains.Annotations;
using UnityEngine;
using GamJamin;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerManager : MonoBehaviour
{


    public GameObject creaturesPrefab;

    public Transform creaturePlacement;

    public List<Creature> playerCreaturesInventory; // the players creature inventory



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {

        SendOutCreature(1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendOutCreature(int creatureInventoryIndex)
    {
        // instantiates the creature at a set position
        GameObject newplayerCreature = Instantiate(creaturesPrefab, creaturePlacement);



        // sets the instanitaed creatures data by going into the instantiated components CreatureDataLoader Script and setting creature data to the data in the inventory
        newplayerCreature.GetComponent<CreatureDataLoader>().creatureData = playerCreaturesInventory[creatureInventoryIndex];
        newplayerCreature.GetComponent<CreatureDataLoader>().UpdateCreatureDataVisuals();
    }
}
