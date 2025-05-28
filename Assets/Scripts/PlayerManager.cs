using JetBrains.Annotations;
using UnityEngine;
using GamJamin;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerManager : MonoBehaviour
{


    public GameObject creaturesPrefab; // the creature prefab thats gonna be instantiated

    public Transform creaturePlacement; // where the creatures will go this will be set as a slot later

    public List<Creature> playerCreaturesInventory; // the players creature inventory

    public List<GameObject> creaturesOnFeild = new List<GameObject>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {



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

        // assign the Instantitated objects to a list
        creaturesOnFeild.Add(newplayerCreature);
    }

    public void RemoveCreaturesOnFeild(List<GameObject> creatures) // can use for enemy creatures and ally creatures // removes creatues
    {
        for (int i =0; i < creatures.Count; i++)
        {
            Destroy(creatures[i]);
            creatures.RemoveAt(i);
        }
    }
}
