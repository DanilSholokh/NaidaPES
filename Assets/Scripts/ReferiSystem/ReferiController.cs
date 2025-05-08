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



    private StatsPlayersData stats;
    //private 



    public void prepareGame(GameManager gameManager)
    {
        this.gameManager = gameManager;

        stats = GetComponent<StatsPlayersData>();

        spellBarDataEnemy = new PlayerSpellBarData();
        spellBarDataPlayer = new PlayerSpellBarData();

        creatureDataEnemy = new PlayerCreatureData();
        creatureDataPlayer = new PlayerCreatureData();


    }




    public void PlayerStartTurn()
    {
        creatureDataPlayer.refreshToZeroPowerCreature();
        getRefreshPlayerPower();

    }

    public void PlayerEndTurn()
    {
        //calculate who win battle
        //anim battle AIPlayer attack Player creature defens



    }

    public void AiPlayerStartTurn()
    {
        creatureDataEnemy.refreshToZeroPowerCreature();
        getRefreshEnemyPower();



    }

    public void AiPlayerEndTurn()
    {
        //calculate who win battle
        //anim battle Player attack AIPlayer creature defens
    
        
    
    }


    




    public int getPowerStatusPlayer() // for get check power status
    {
        return stats.PlayerPower;
    }

    public int getPowerStatusEnemy()
    {  return stats.PlayerPower;}    

    public int getRefreshPlayerPower() // if change power status
    {
        stats.PlayerPower = spellBarDataPlayer.getPowerSpells() + creatureDataPlayer.Power;
        fieldManager.uiFieldController.changePlayerPowerText(stats.PlayerPower);

        return stats.PlayerPower;
    
    }


    public int getRefreshEnemyPower()
    {
        stats.EnemyPower = spellBarDataEnemy.getPowerSpells() + creatureDataEnemy.Power;
        fieldManager.uiFieldController.changeEnemyPowerText(stats.EnemyPower);

        return stats.addEnemyPower(stats.EnemyPower);

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
        fieldManager.addSpellBarPlayer(spell, gameManager.currentPlayer, spellBarDataPlayer);
        getRefreshPlayerPower();
    }

    public void setSpellPowerStatusEnemy(CardData spell)
    {
        fieldManager.addSpellBarEnemy(spell, gameManager.currentPlayer, spellBarDataEnemy);
        getRefreshEnemyPower();
    }


    public bool isCheckCardOnField(Vector3 positionCard)
    {
        return fieldManager.isfieldPlayCard(positionCard);
    }


}
