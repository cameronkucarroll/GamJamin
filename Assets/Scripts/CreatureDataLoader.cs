using UnityEngine;
using TMPro;
using GamJamin;

public class CreatureDataLoader : MonoBehaviour
{
    private EnemyManager enemyManager;
    private PlayerManager playerManager;
    private SkillManager skillManager;

    public GameObject creaturePrefab;
    public Creature creatureData;

    public int inSlot = 0;

    public TMP_Text creatureName;
    public int creatureMaxHealth;
    public int creatureCurrentHealth;
    public int creatureDamage;

    public bool isEnemy = false;
    public int currentSlotIndex = 0;

    private void Awake()
    {
        enemyManager = FindFirstObjectByType<EnemyManager>();
        playerManager = FindFirstObjectByType<PlayerManager>();
        skillManager = FindFirstObjectByType<SkillManager>();

    }

    private void Start()
    {
        UpdateCreatureDataVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        if (creatureCurrentHealth <= 0)
        {
            OnDefeated(isEnemy);
        }
    }

    public void UpdateCreatureDataVisuals()
    {
        creatureName.text = creatureData.name;
        creatureCurrentHealth = creatureData.health;
        creatureDamage = creatureData.damage;
    }

    public void OnDefeated(bool isEnemy)
    {
        if (isEnemy && enemyManager.enemiesOnFeild != null)
        {
            Destroy(creaturePrefab);
            enemyManager.enemiesOnFeild.Remove(creaturePrefab);
            

            
        }
        else if (!isEnemy && playerManager.creaturesOnFeild != null)
        {
            Destroy(creaturePrefab);
            playerManager.creaturesOnFeild.Remove(creaturePrefab);
            

        }
    }

    public void TakeDamage(int damage)
    {
        creatureCurrentHealth -= damage;
        Debug.Log($"{creatureData.name} took {damage}"); 
    }
        
    
}
