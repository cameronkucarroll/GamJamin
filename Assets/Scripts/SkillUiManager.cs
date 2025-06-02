using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GamJamin;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class SkillUiManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private EnemyManager enemyManager;

    public CreatureDataLoader creatureData1;
    public CreatureDataLoader creatureData2;



    public GameObject skillPanel;
    public Button[] skillButtons;


    public void Awake()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        enemyManager = FindFirstObjectByType<EnemyManager>();


    }

    public void ShowSkills(int creatureOnFeild)
    {
        Creature creature1 = null;
        Creature creature2 = null;


        if (playerManager.creaturesOnFeild.Count == 1)
        {
            creature1 = playerManager.creaturesOnFeild[0].GetComponent<CreatureDataLoader>().creatureData;


;
        }
        else if (playerManager.creaturesOnFeild.Count == 2)
        {
            creature1 = playerManager.creaturesOnFeild[0].GetComponent<CreatureDataLoader>().creatureData;
            creature2 = playerManager.creaturesOnFeild[1].GetComponent<CreatureDataLoader>().creatureData;
            

        }


            skillPanel.SetActive(true);

        if (creature1 != null && creatureOnFeild == 1)
        {



            for (int i = 0; i < skillButtons.Length; i++)
            {
                if (i < creature1.creatureSkills.Count)
                {
                    Skill skill = creature1.creatureSkills[i];
                    TextMeshProUGUI buttonText = skillButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                    buttonText.text = skill.skillName;

                    skillButtons[i].onClick.RemoveAllListeners();

                    skillButtons[i].onClick.AddListener(() => UseSkill(skill, creatureData1));
                }
                else
                {

                    skillButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "----";
                    skillButtons[i].onClick.RemoveAllListeners();
                }
            }
        }
        else if (creature2 != null && creatureOnFeild == 2)
        {

            for (int i = 0; i < skillButtons.Length; i++)
            {


               if (i < creature2.creatureSkills.Count)
               {
                    Skill skill = creature2.creatureSkills[i];
                    TextMeshProUGUI buttonText = skillButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                    buttonText.text = skill.skillName;

                    skillButtons[i].onClick.RemoveAllListeners();

                    skillButtons[i].onClick.AddListener(() => UseSkill(skill, creatureData2));
               }
               else
               {

                    skillButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "----";
                    skillButtons[i].onClick.RemoveAllListeners();
               }

            }
        }
        else if (creature1 == null)
        {
            Debug.Log("there are no Summons out");
        }
        else if (creature1 != null && creature2 == null)
        {
            Debug.Log("there is no second Summon");
        }
    }
    public void UseSkill(Skill skill, CreatureDataLoader creature) 
    {
        Debug.Log("Clicked Skill :" + skill.skillName);
        skill.Use(creature);
    }
}

