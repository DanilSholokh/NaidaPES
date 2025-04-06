using Assets.Scripts.BattlefieldSystem;
using UnityEngine;

public class ReferiController : MonoBehaviour
{

    [SerializeField] FieldManager fieldManager;
    [SerializeField] CreaturePlaceController creaturePlace;

    private GameManager gameManager;

    

    private PlayerSpellBarData spellBarDataPlayer;
    private PlayerSpellBarData spellBarDataEnemy;

    private PlayerCreatureData creatureDataPlayer;
    private PlayerCreatureData creatureDataEnemy;



    public StatsPlayersData stats;
    //private 



    public void prepareGame(GameManager gameManager)
    {
        this.gameManager = gameManager;

        spellBarDataEnemy = new PlayerSpellBarData();
        spellBarDataPlayer = new PlayerSpellBarData();

        creatureDataEnemy = new PlayerCreatureData();
        creatureDataPlayer = new PlayerCreatureData();


    }



    public int getRefreshPlayerPower()
    {
        int sumPowerPlayer = spellBarDataPlayer.getPowerSpells() + creatureDataPlayer.Power;
        fieldManager.uiFieldController.changePlayerPowerText(sumPowerPlayer);

        return stats.addPlayrePower(sumPowerPlayer);
    
    }


    public int getRefreshEnemyPower()
    {
        int sumPowerPlayer = spellBarDataEnemy.getPowerSpells() + creatureDataEnemy.Power;
        fieldManager.uiFieldController.changeEnemyPowerText(sumPowerPlayer);

        return stats.addEnemyPower(sumPowerPlayer);

    }



    public void setCreaturePowerStatusPlayer(CardData card)
    {
        if (card is CardCreature creatureData)
        {
            creaturePlace.setCreatureDataPlayer(creatureData);

            creatureDataPlayer.refreshToZeroPowerCreature();
            creatureDataPlayer.addPowerCreature(creatureData.getPowerCard());

            getRefreshPlayerPower();

        }
    }

    public void setCreaturePowerStatusEnemy(CardData card)
    {
        if (card is CardCreature creatureData)
        {
            creaturePlace.setCreatureDataEnemy(creatureData);

            creatureDataEnemy.refreshToZeroPowerCreature();
            creatureDataEnemy.addPowerCreature(creatureData.getPowerCard());

            getRefreshEnemyPower();

        }
    }


    public void setSpellPowerStatusPlayer(CardData spell)
    {
        if (spell is CardSpell spellData)
        {
            fieldManager.addSpellBarPlayer(spell, gameManager.currentPlayer, spellBarDataPlayer);
            getRefreshPlayerPower();
        }
    }

    public void setSpellPowerStatusEnemy(CardData spell)
    {
        if (spell is CardSpell spellData)
        {
            fieldManager.addSpellBarEnemy(spell, gameManager.currentPlayer, spellBarDataEnemy);
            getRefreshEnemyPower();
        }
    }


    public bool isCheckCardOnField(Vector3 positionCard)
    {
        return fieldManager.isfieldPlayCard(positionCard);
    }


}
