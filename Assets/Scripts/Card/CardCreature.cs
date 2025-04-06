using DG.Tweening.Core.Easing;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "CardCreature")]
public class CardCreature : CardData
{

    public int powerCreature;
    public int faceDamage;



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
        playerBase.setPowerCreatures(this);
        Debug.Log("Plaing Card Creature" + name);
    }

    public override int getPowerCard()
    {
        return powerCreature;
    }

    public override bool isCountCost(PlayerBase player)
    {
        return player.creatureCostUpdate(getCostCard());
    }

    public override bool isCostPowerThanEnemyField(int powerCreatureEnemy)
    {
        return getPowerCard() > powerCreatureEnemy;
    }


}
