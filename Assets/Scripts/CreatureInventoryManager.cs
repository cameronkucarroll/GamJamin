using UnityEngine;
using TMPro;
using GamJamin;

public class CreatureInventoryManager : MonoBehaviour
{
    public PlayerManager playerManager;
    private SystemMessageUpdater systemMessage;

    public GameObject creatureInventoryPrefab;
    private GameManager gameManager;

    // each inventory slots text
    public TMP_Text creatureNameSlot1;
    public TMP_Text creatureNameSlot2;
    public TMP_Text creatureNameSlot3;
    public TMP_Text creatureNameSlot4;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        gameManager = FindFirstObjectByType<GameManager>();
        systemMessage = FindFirstObjectByType<SystemMessageUpdater>();
    }

    private void Start()
    {
        UpdateCreatureInventoryData();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.hasBeenUpdate)
        {
            UpdateCreatureInventoryData();
        }
    }

    public void UpdateCreatureInventoryData()
    {
        // sets the names for the creatures in the inventory
        creatureNameSlot1.text = playerManager.playerCreaturesInventory[0].name;
        creatureNameSlot2.text = playerManager.playerCreaturesInventory[1].name;
        creatureNameSlot3.text = playerManager.playerCreaturesInventory[2].name;
        creatureNameSlot4.text = playerManager.playerCreaturesInventory[3].name;

        // if the creature slot names are null, set the creatures name to empty

        if (creatureNameSlot1 == null)
        {
            creatureNameSlot1.text = "Empty";
        }
        if (creatureNameSlot2 == null)
        {
            creatureNameSlot2.text = "Empty";
        }
        if (creatureNameSlot3 == null)
        {
            creatureNameSlot3.text = "Empty";
        }
        if (creatureNameSlot4 == null)
        {
            creatureNameSlot4.text = "Empty";
        }
    }
    

    // methods for summoning the creatuers in the slot
    public void SummonCreatureSlot1()
    {
        if (playerManager.playerCreaturesInventory[0] == null)
        {
            // if there is no creature or the creature is already out
            Debug.Log("Cannot play summon");
            systemMessage.UpdateSystemMessage("Cannot Summon Creature");
        }
        else
        {
            playerManager.SendOutCreature(0);
            creatureInventoryPrefab.SetActive(false);
        }
    }
    public void SummonCreatureSlot2()
    {
        if (playerManager.playerCreaturesInventory[1] == null)
        {
            // if there is no creature or the creature is already out
            Debug.Log("Cannot play summon");
            systemMessage.UpdateSystemMessage("Cannot Summon Creature");
        }
        else
        {
            playerManager.SendOutCreature(1);
            creatureInventoryPrefab.SetActive(false);
        }

    }
    public void SummonCreatureSlot3()
    {
        if (playerManager.playerCreaturesInventory[2] == null)
        {
            // if there is no creature or the creature is already out
            Debug.Log("Cannot play summon");
            systemMessage.UpdateSystemMessage("Cannot Summon Creature");
        }
        else
        {
            playerManager.SendOutCreature(2);
            creatureInventoryPrefab.SetActive(false);
        }

    }
    public void SummonCreatureSlot4()
    {
        if (playerManager.playerCreaturesInventory[3] == null)
        {
            // if there is no creature or the creature is already out
            Debug.Log("Cannot play summon");
            systemMessage.UpdateSystemMessage("Cannot Summon Creature");
        }
        else
        {
            playerManager.SendOutCreature(3);
            creatureInventoryPrefab.SetActive(false);
        }
    }
}
