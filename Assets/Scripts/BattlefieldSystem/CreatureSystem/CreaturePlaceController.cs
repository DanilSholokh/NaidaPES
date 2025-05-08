using UnityEngine;

public class CreaturePlaceController : MonoBehaviour
{

    [SerializeField] private Transform placePlayer;   
    [SerializeField] private Transform placeEnemy;

    [SerializeField] private CardCreature currentCreaturePlayer;
    [SerializeField] private CardCreature currentCreatureEnemy;


    public Transform getPositionCreaturePlayer()
    {
        return placePlayer;
    }

    public Transform getPositionCreatureEnemy()
    {
        return placeEnemy;
    }


    public void setCreatureDataPlayer(CardCreature creature)
    { 
        currentCreaturePlayer = creature;
    
    }


    public void setCreatureDataEnemy(CardCreature creature)
    {
        currentCreaturePlayer = creature;

    }








}  
