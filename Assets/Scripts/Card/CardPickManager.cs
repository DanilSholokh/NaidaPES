using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPickManager : MonoBehaviour
{



    private PlayerCardLibrary playerCard;  
    private DeckLibrary deckManager; 


    public void createPickCard(PlayerCardLibrary playerCard, CardManager cardManager, DeckLibrary deckManager, int id)
    {
        this.playerCard = playerCard;
        this.deckManager = deckManager;



    }


}
