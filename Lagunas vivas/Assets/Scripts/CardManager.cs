using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    #region parameters
    EvCard[] mEvCards;
    int mCardMax;
    public int getNumCards() { return mCardMax; }
    bool _canBeClicked = true;
    public bool CanBeCliked()
    {
        return _canBeClicked;
    }    
    #endregion
    [SerializeField] GameObject CardInstance;
    void Start()
    {
        GameManager.Instance.AssignCardManager(this);
        mCardMax = 0;
    }

    public void DrawCards(int num)
    {
        mEvCards = new EvCard[num];
        mCardMax = num;        
        for (int i=0; i < num; i++)
        {            
            GameObject aux = Instantiate(CardInstance, new Vector3(0,0,0),Quaternion.identity,GetComponent<Transform>());
            mEvCards[i] = aux.GetComponent<EvCard>();
            mEvCards[i].setCardMan(this);
            mEvCards[i].setPos(i+1);            
            mEvCards[i].goToPos();
            mEvCards[i].Peek(true);
        }
    }
    public void CardCliked(int a)
    {
        _canBeClicked = false;
        StopAllCoroutines();
        int i = 0;
        mCardMax--;
        while (i<mCardMax+1)
        {
            if (i + 1 < a)
            {                
                mEvCards[i].Peek(false);
            }
            if (i + 1 > a)
            {
                mEvCards[i - 1] = mEvCards[i];
                mEvCards[i].setPos(i);                
                mEvCards[i].Peek(false);
            }
            i++;
        }
    }
    public void EventFinished()
    {
        if (!_canBeClicked)
        {
            _canBeClicked = true;
            StopAllCoroutines();
            for (int i = 0; i <mCardMax; i++)
            {
                mEvCards[i].goToPos();
                mEvCards[i].Peek(true);
            }
            if(mCardMax <= 0)
            {
                GameManager.Instance.VisibleNextTurno();
            }           
        }
    }
}
