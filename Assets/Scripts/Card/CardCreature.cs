using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "CardCreature")]
public class CardCreature : CardData
{

    public int powerCard;
    public int faceDamage;



    public enum CreatureType
    {
        Naida = BaseCardType.Naida,
        Evil = BaseCardType.Evil,
        Knight = BaseCardType.Knight
    }

    public CreatureType creatureType;



    public override BaseCardType getCardType()
    {
        switch (creatureType)
        {
            case CreatureType.Naida:
                return BaseCardType.Naida;
            case CreatureType.Evil:
                return BaseCardType.Evil;
            case CreatureType.Knight:
                return BaseCardType.Knight;
            default:
                throw new System.ArgumentOutOfRangeException("Unknown creature type!");
        }
    }

    public override void PlayCard()
    {
        Debug.Log("Play card is name " + name);
        
    }
}
