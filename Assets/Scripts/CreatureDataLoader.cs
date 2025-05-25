using UnityEngine;
using TMPro;
using GamJamin;

public class CreatureDataLoader : MonoBehaviour
{
    public GameObject creaturePrefab;
    public Creature creatureData;

    public TMP_Text creatureName;

    
    void Start()
    {
        UpdateCreatureDataVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCreatureDataVisuals()
    {
        creatureName.text = creatureData.name;
    }
}
