using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvCard : MonoBehaviour
{
    #region parameters
    const double maxP = 8.76;
    const double minP = -8.76;
    const double altura = -3.8;
    const double oculto = -6.68;
    const float framesMov = 10;

    CardManager mCardManager;
    public void setCardMan(CardManager cm) {  mCardManager = cm; }
    Constants.EVENTOS_ENUM mEvento = Constants.EVENTOS_ENUM.LISTAPRUEBA;
    int mpos;
    public void setPos(int p) { mpos = p;}
    public void addPos() { mpos++; }
    public void restPos() { mpos--; }

    [SerializeField] SpriteRenderer mImag;
    #endregion

    void Start()
    {
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
    }

    public void goToPos()
    {
        StartCoroutine(movement());
    }
    IEnumerator movement()
    {
        float tim = 0.2f / framesMov;
        Transform mT = GetComponent<Transform>();
        double mP = mT.position.x;
        double dP = (((maxP-minP)/(mCardManager.getNumCards()+1)) * mpos )+minP;        
        double mov = (dP - mP) / framesMov;
        for (int i = 0; i < framesMov; i++)
        {
            yield return new WaitForSeconds(tim);
            mT.position = mT.position + new Vector3((float)mov,0,0);
        }
    }

    public void Peek(bool a)
    {
        StartCoroutine(goUpDown(a));
    }
    IEnumerator goUpDown(bool a)
    {
        float tim = 0.2f / framesMov;
        Transform mT = GetComponent<Transform>();
        double mP = mT.position.y;
        double dP;
        if (a) dP = altura;
        else dP = oculto;
        double mov = (dP - mP) / framesMov;
        for (int i = 0; i < framesMov; i++)
        {
            yield return new WaitForSeconds(tim);
            mT.position = mT.position + new Vector3(0, (float)mov, 0);
        }
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(5.0f);
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
