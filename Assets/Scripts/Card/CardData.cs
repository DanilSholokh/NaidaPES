using UnityEngine;


// данні про карту (`)(.)
public abstract class CardData : ScriptableObject
{

    public int id;


    public string name; 
    public Sprite spriteCard;

    public int cost;

    public enum BaseCardType
    {
        Naida,
        Evil,
        Knight

    }

    public abstract BaseCardType getCardType();
    public abstract void PlayCard();
    public abstract int getPowerCard();
    public abstract bool isCountCost(PlayerBase player);


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


}
