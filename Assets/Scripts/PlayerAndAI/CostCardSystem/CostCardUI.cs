using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostCardUI : MonoBehaviour
{

    [SerializeField] Transform SpellSlotsGroup;
    [SerializeField] Transform CreatureSlotsGroup;

    [SerializeField] GameObject prefabSlotSpell;
    [SerializeField] GameObject prefabSlotCreatuer;

    private List<GameObject> SpellIcones = new List<GameObject>();
    private List<GameObject> CreatureIcones = new List<GameObject>();


    public Transform getSpelSlots()
    { return SpellSlotsGroup; }

    public Transform getCreatureSlots()
    { return CreatureSlotsGroup; }


    public void addCreatureSlots(int countCreature)
    {
        for (int i = 0; i < countCreature; i++)
        {
            GameObject slot = Instantiate(prefabSlotCreatuer, getCreatureSlots());
            CreatureIcones.Add(slot);
        }
    }

    public void addSpellSlots(int countSpells)
    {
        for (int i = 0; i < countSpells; i++)
        {
            GameObject slot = Instantiate(prefabSlotSpell, getSpelSlots());
            SpellIcones.Add(slot);
        }
    }

    public void removeSpellSlots()
    {
        if (SpellIcones.Count > 0)
        {
            GameObject slotPrefab = SpellIcones[0];
            SpellIcones.RemoveAt(0);
            Destroy(slotPrefab);
        }
    }

    public void removeCreatureSlots()
    {
        if (SpellIcones.Count > 0)
        {
            GameObject slotPrefab = CreatureIcones[0];
            CreatureIcones.RemoveAt(0);
            Destroy(slotPrefab);
        }
    }


    public void deleteAllSlots()
    {
        clearCounter(SpellIcones);
        clearCounter(CreatureIcones);

    }



    public void clearCounter(List<GameObject> listCounter)
    {
        foreach (GameObject obj in listCounter)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        listCounter.Clear();
    }

}
