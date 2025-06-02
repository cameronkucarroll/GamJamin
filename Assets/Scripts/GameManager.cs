using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playerTurnUiManager;
    public GameObject escMenu;
    private SkillManager skillManager;

    private GameObject mainUiComponents;
    public GameObject creatureInventoryManager;
    private PlayerManager playerManager;
    private SystemMessageUpdater systemMessage;
    private EnemyManager enemyManager;


    public TextMeshProUGUI stageCounterText;
    public TextMeshProUGUI turnCounterText;
    public int stageNumber = 1;
    public int turn = 0; 
    public bool isPlayerTurn;
    public bool isEnemyTurn;
    public bool didEnemyTakeTurn = false; // so enemy script does not repeat in update method
    public bool escMenuActive = false;
    public bool ifPlayerTurnMessagePlayed = false;
    public bool hasBeenUpdate = false; // sees if the creature inventory has been updated

    public bool playedFirstSummon = false;

    
    void Start()
    {
        stageCounterText.text = $"Stage: {stageNumber}";
        turnCounterText.text = $"Turn: {turn}";
        playerManager = FindFirstObjectByType<PlayerManager>();
        systemMessage = FindFirstObjectByType<SystemMessageUpdater>();
        enemyManager = FindFirstObjectByType<EnemyManager>();
        skillManager = FindFirstObjectByType<SkillManager>();


    }

    private void Update()
    {
        // round 1 (setup round)

        if (turn == 1 && stageNumber == 1)
        {
            systemMessage.UpdateSystemMessage("Pick your first Summon");
            creatureInventoryManager.SetActive(true);
            if (playedFirstSummon)
            {
                creatureInventoryManager.SetActive(false);
                EndTurn();
            }

        }
       
        // escape menu 
        if (Input.GetKeyDown(KeyCode.Escape) && escMenuActive == false)
        {
            escMenu.SetActive(true);
            escMenuActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escMenuActive == true)
        {
            escMenu.SetActive(false);
            escMenuActive = false;
        }



        // switch between the players turn and the enemys turn
        if (turn % 2 == 1 && turn != 0)
        {
            isPlayerTurn = true;
            isEnemyTurn = false;
        }
        else if (turn % 2 == 0 && turn != 0)
        {
            isPlayerTurn = false;
            isEnemyTurn = true;
        }
        // if its Players Turn
        if (isPlayerTurn)
        {
            
            RunPlayerManager();
            if (ifPlayerTurnMessagePlayed == false) // so the player message displayes only once
            {
                Debug.Log("it is the players turn");
                systemMessage.UpdateSystemMessage("What will you do...?");
                ifPlayerTurnMessagePlayed = true;
            }
        }
        else if (!isPlayerTurn)
        {
            playerTurnUiManager.SetActive(false);
        }
         if (isEnemyTurn && didEnemyTakeTurn == false)
        {
            Debug.Log("it is the enemys turn");
            systemMessage.UpdateSystemMessage("The Enemy is Acting...");
            StartCoroutine(RunEnemyManager()); // starts the functions time
            didEnemyTakeTurn = true;
            ifPlayerTurnMessagePlayed = false; // so the player message displays
        }
    }

    public void OnStartRun()
    {
        Debug.Log("Run Started!");
        stageNumber = 1;
        turn = 1;
        playerManager.RemoveCreaturesOnFeild(playerManager.creaturesOnFeild);
        playerManager.RemoveCreaturesOnFeild(playerManager.creaturesOnFeild);

    }
    public void EndTurn()
    {
        if (turn != 0)
        {
            turn += 1;
            turnCounterText.text = $"Turn: {turn}";
        }
    }
    public void RunPlayerManager()
    {
        turnCounterText.text = $"Turn: {turn}";
        playerTurnUiManager.SetActive(true); // makes the player controll ui pop up
        didEnemyTakeTurn = false; // makes it so the enemy can go
        
    }
    public IEnumerator RunEnemyManager() // means its a function that waits some time
    {
        enemyManager.SpawnEnemyCreature(0);

        yield return new WaitForSeconds(3);



        systemMessage.UpdateSystemMessage("Enemy ended its turn");

        yield return new WaitForSeconds(1);
        Debug.Log("The enemy ends the round");

        EndTurn();
    }
    public void CloseCreatureInventory() // closes creature inventory
    {
        creatureInventoryManager.SetActive(false);
        hasBeenUpdate = false;
    }

    public void OpenCreatureInventory()
    {
        creatureInventoryManager.SetActive(true); // open creatures inventory
        hasBeenUpdate = true;

        
    }


}
