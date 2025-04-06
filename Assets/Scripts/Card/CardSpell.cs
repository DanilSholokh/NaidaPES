using UnityEngine;




[CreateAssetMenu(fileName = "New CardData", menuName = "CardSpell")]
public class CardSpell : CardData
{


    public int powerSpell;
    [SerializeField] private int countTurn;

    [SerializeField]
    public RaceType raceType;

    public override RaceCardType getCardType()
    {
        return (RaceCardType)raceType;
    }

    [SerializeField]
    public BaceType baceType;

    public override BaceCardType getBaceType()
    {
        return (BaceCardType)baceType;
    }

    public override void PlayCard(PlayerBase playerBase)
    {
        playerBase.setPowerSpells(this);
        Debug.Log("Play spell name is " + name);
    }



    public int isHitTurn()
    {
        // every end turn trigger
        return countTurn--;
    }



    public override int getPowerCard()
    {
        return powerSpell;
    }

    public override bool isCountCost(PlayerBase player)
    {
        return player.spellCostUpdate(getCostCard());
    }

    public override bool isCostPowerThanEnemyField(int powerCreatureEnemy)
    {
        return true;
    }

    
}
