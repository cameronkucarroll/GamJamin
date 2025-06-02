using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private EnemyManager enemyManager;

    private void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        enemyManager = FindFirstObjectByType<EnemyManager>();
    }
    public void HurtPlayerCreature(int creatureSlot, int creatureDamage, int skillDamage)
    {
        if (playerManager.creaturesOnFeild != null)
        {
            playerManager.creaturesOnFeild[creatureSlot].GetComponent<CreatureDataLoader>().creatureCurrentHealth -= (creatureDamage + skillDamage);
        }
        else if (playerManager.creaturesOnFeild != null && playerManager.creaturesOnFeild[creatureSlot] == null)
        {
            Debug.Log("There is no creature here");
        }

    }
    public void HurtEnemyCreature(int creatureSlot, int creatureDamage, int skillDamage)
    {
        if (enemyManager.enemiesOnFeild != null)
        {
            enemyManager.enemiesOnFeild[creatureSlot].GetComponent<CreatureDataLoader>().creatureCurrentHealth -= (creatureDamage + skillDamage);
        }
    }
}
