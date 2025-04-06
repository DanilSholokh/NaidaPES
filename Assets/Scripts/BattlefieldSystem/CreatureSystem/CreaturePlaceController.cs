using UnityEngine;

public class CreaturePlaceController : MonoBehaviour
{

    [SerializeField] private Transform placePlayer;   
    [SerializeField] private Transform placeEnemy;

    [SerializeField] private CardCreature currentCreatureDataPlayer;
    [SerializeField] private CardCreature currentCreatureDataEnemy;


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
        currentCreatureDataPlayer = creature;
    
    }


    public void setCreatureDataEnemy(CardCreature creature)
    {
        currentCreatureDataPlayer = creature;

    }








}  
