using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "CardSpell")]
public class CardSpell : CardData
{


    public int powerSpell;

    public enum SpellType
    {
        Naida = BaseCardType.Naida,
        Evil = BaseCardType.Evil,
        Knight = BaseCardType.Knight
    }

    public SpellType spellType;

    public override BaseCardType getCardType()
    {
        switch (spellType)
        {
            case SpellType.Naida:
                return BaseCardType.Naida;
            case SpellType.Evil:
                return BaseCardType.Evil;
            case SpellType.Knight:
                return BaseCardType.Knight;
            default:
                throw new System.ArgumentOutOfRangeException("Unknown creature type!");
        }
    }


    public override void PlayCard(PlayerBase playerBase)
    {
        playerBase.setPower(this);
        Debug.Log("Play spell name is " + name);
    }

    public override int getPowerCard()
    {
        return powerSpell;
    }

    public override bool isCountCost(PlayerBase player)
    {
        return player.spellCostUpdate(getCostCard());
    }

    public override int getAddPowerCard(int power)
    {
        return power += getPowerCard();
    }

    
}
