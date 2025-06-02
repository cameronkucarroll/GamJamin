using UnityEngine;
using GamJamin;
using System.Collections;
using System.Collections.Generic;

namespace GamJamin
{
    [CreateAssetMenu(fileName = "Skill", menuName = "New Skill")]
    public class Skill : ScriptableObject
    {
        private EnemyManager enemyManager;
        private PlayerManager playermanager;
        private SkillManager skillManager;


        public string skillName;
        public string skillDescription;
        public int skillDamage;

        public bool isAlly = true;


        private void Awake()
        {
            enemyManager = FindFirstObjectByType<EnemyManager>();
            playermanager = FindFirstObjectByType<PlayerManager>();
            skillManager = FindFirstObjectByType<SkillManager>();
        }
        public void Use(CreatureDataLoader creature)
        {
            Debug.Log("You used skill " + skillName);
            int totalDamage = creature.creatureDamage + skillDamage;
            CreatureDataLoader[] allCreatures = Object.FindObjectsByType<CreatureDataLoader>(FindObjectsSortMode.None);

            foreach (var target in allCreatures)
            {
                // Attack the opposite team!
                if (target.isEnemy != creature.isEnemy)
                {
                    target.TakeDamage(totalDamage);
                    break; // hit only one for now
                }
            }

        }
    }

}
