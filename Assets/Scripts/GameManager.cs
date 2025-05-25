using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playerTurnUiManager;


    public TextMeshProUGUI stageCounterText;
    public TextMeshProUGUI turnCounterText;
    public int stageNumber = 1;
    public int turn = 0;
    public bool isPlayerTurn;
    public bool isEnemyTurn;
    public bool didEnemyTakeTurn = false; // so enemy script does not repeat in update method

    
    void Start()
    {
        stageCounterText.text = $"Stage: {stageNumber}";
        turnCounterText.text = $"Turn: {turn}";
        playerTurnUiManager = GameObject.Find("PlayerTurnUiManager");
    }

    private void FixedUpdate()
    {

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
            Debug.Log("it is the players turn");
            RunPlayerManager();
        }
        else if (!isPlayerTurn)
        {
            playerTurnUiManager.SetActive(false);
        }
         if (isEnemyTurn && didEnemyTakeTurn == false)
        {
            Debug.Log("it is the enemys turn");
            StartCoroutine(RunEnemyManager()); // starts the functions time
            didEnemyTakeTurn = true;
        }
    }

    public void OnStartRun()
    {
        Debug.Log("Run Started!");
        stageNumber = 1;
        turn = 1;
        
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
        Debug.Log("The enemy is deciding");

        yield return new WaitForSeconds(3);

        Debug.Log("The enemy ends the round");

        EndTurn();
    }

    
}
