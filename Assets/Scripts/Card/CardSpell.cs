using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "CardSpell")]
public class CardSpell : CardData
{


    public int powerUp;

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

    public void setSpellCardData()
    {

    }

    public override void PlayCard()
    {
        Debug.Log("Play spell name is " + name);
    }
}
