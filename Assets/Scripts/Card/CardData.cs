using UnityEngine;


// данні про карту (`)(.)
public abstract class CardData : ScriptableObject
{

    public int id;


    public string name; 
    public Sprite spriteCard;

    public int cost;

    public enum RaceCardType
    {
        Naida,
        Evil,
        Knight

    }

    public enum BaceCardType
    {
        Curse, // stay on Enemy
        Buffs, // stay on CurrentPlay (who played card)
        Supporte // same buffs

    }

    public abstract RaceCardType getCardType();
    public abstract BaceCardType getBaceType();
    public abstract void PlayCard(PlayerBase playerBase);
    public abstract int getPowerCard();
    public abstract bool isCountCost(PlayerBase player);
    public abstract bool isCostPowerThanEnemyField(int powerCreatureEnemy);

    public Sprite getSpriteDataCard()
    {
        return spriteCard;  
    }

    public string getNameDataCard()
    {
        return name;
    }

    public int getCostCard()
    {
        return cost;
    }

    public int getId()
    {
        return id;
    }


}
