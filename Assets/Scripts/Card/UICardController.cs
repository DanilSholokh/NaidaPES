using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UICardController : MonoBehaviour
{

    [SerializeField] TMP_Text nameCardText;
    [SerializeField] TMP_Text powerCardText;
    [SerializeField] Transform faceDamageTransform;

    [SerializeField] GameObject prefabFaceDamageObject;

    [SerializeField] Image imagePlayer;
    [SerializeField] Image imageType;

    [SerializeField] Sprite naydaTypeSprite;
    [SerializeField] Sprite evilTypeSprite;
    [SerializeField] Sprite knighteTypeSprite;

    [SerializeField] GameObject backCard;

    private CardData cardData;


    public void initIUdata(CardData data)
    {
        cardData = data;

        nameCardText.text = cardData.getNameDataCard();
        imagePlayer.sprite = cardData.getSpriteDataCard();

        createFaceDamageObject();
        setTypePlayerCard();

    }

    public void activeCardBack()
    {
        backCard.SetActive(true);
    }

    private void createFaceDamageObject()
    {

        if (cardData is CardCreature cardCreature)
        {
            for (int i = 0; i < cardCreature.faceDamage; i++)
            {
                Instantiate(prefabFaceDamageObject, faceDamageTransform);
            }

            powerCardText.text = cardCreature.getPowerCard().ToString();

        }


    }

    private void setTypePlayerCard()
    {
        switch (cardData.getCardType())
        {
            case CardData.BaseCardType.Naida:
                imageType.sprite = naydaTypeSprite;
                break;
            case CardData.BaseCardType.Evil:
                imageType.sprite = evilTypeSprite;
                break;
            case CardData.BaseCardType.Knight:
                imageType.sprite = knighteTypeSprite;
                break;
            default:
                Debug.Log("Not founde sprite type");
                break;
        }
    }




}
