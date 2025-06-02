using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GamJamin
{
    [CreateAssetMenu(fileName = "Creature" , menuName = "New Creature")]
    public class Creature : ScriptableObject
    {
        public string Name;
        public int health;
        public int damage;



        public List<Skill> creatureSkills;
    }



}
