using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCostDeck : MonoBehaviour
{
    // ======== Count Deck
    [SerializeField] private int sizeDeck = 20;
    [SerializeField] private int maxDrawCount = 1;
    [SerializeField] private int currentDrawCount = 0;


    public int getSizeDeck()
    { return sizeDeck; }

    public void setSizeDeck(int sizeDeck) { this.sizeDeck = sizeDeck; }

    public int getCurrentDrawCount()
    {
        return currentDrawCount;
    }

    public void setDrawCount(int drawCount)
    {
        currentDrawCount = drawCount;
    }

    public int getMaxDrawCount()
    {
        return maxDrawCount;
    }

    public void setMaxDrawCount(int maxDrawCount) { this.maxDrawCount = maxDrawCount; }



}
