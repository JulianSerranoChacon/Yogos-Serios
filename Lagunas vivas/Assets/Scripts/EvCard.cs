using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvCard : MonoBehaviour
{
    #region parameters
    const double TamMax = 0.41;
    const double TamMin = 0.01;
    const float framesMov = 15;

    CardManager mCardManager;
    public void setCardMan(CardManager cm) {  mCardManager = cm; }
    Constants.EVENTOS_ENUM mEvento = Constants.EVENTOS_ENUM.LISTAPRUEBA;
    int mpos;
    public void setPos(int p) { mpos = p;}
    public void addPos() { mpos++; }
    public void restPos() { mpos--; }

    bool big;
    [SerializeField] SpriteRenderer mImag;
    #endregion

    void Start()
    {
        big = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<Transform>().localScale = new Vector3((float)TamMin, (float)TamMin, (float)TamMin);
        int i = Random.Range(1,Constants.NUM_EVENTOS+1);
        if (i > 3)
        {
            if (i == 4)
            {
                i += Random.Range(0, 2);
            }
            else
            {
                i++;
                if (i == 6)
                {
                    i += Random.Range(0, 2);
                }
                else
                {
                    i++;
                    if (i == 8)
                    {
                        i += Random.Range(0, 2);
                    }
                    else
                    {
                        i++;
                        if (i == 10)
                        {
                            i += Random.Range(0, 2);
                        }
                        else
                        {
                            i++;
                            if (i == 12)
                            {
                                i += Random.Range(0, 2);
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
            }
        }            

        mEvento = (Constants.EVENTOS_ENUM)i;

        mImag.sprite = GameManager.Instance.getIconEv((int)mEvento);

        Peek(true);
    }


    public void Peek(bool a)
    {
        if(big != a)
        {
            GetComponent<Animator>().enabled = false;
            StartCoroutine(goUpDown(a));
        }        
    }
    IEnumerator goUpDown(bool a)
    {
        float tim = 0.2f / framesMov;
        Transform mT = GetComponent<Transform>();
        double mP = mT.localScale.y;
        double dP;
        if (a) dP = TamMax;
        else dP = TamMin;
        double mov = (dP - mP) / framesMov;
        for (int i = 0; i < framesMov; i++)
        {
            yield return new WaitForSeconds(tim);
            mT.localScale = mT.localScale + new Vector3((float)mov, (float)mov, (float)mov);
        }
        if(a)GetComponent<Animator>().enabled = true;
        big = a;
    }
    IEnumerator die()
    {        
        yield return new WaitForSeconds(1.0f);        
        Destroy(gameObject);
    }
    public void Click()
    {
        if (mCardManager.CanBeCliked())
        {
            mCardManager.CardCliked(mpos);
            Peek(false);
            GameManager.Instance.setEvent(Constants.EVENTOS[(int)mEvento]);
            StartCoroutine(die());
        }
    }
}
