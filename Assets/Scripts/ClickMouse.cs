using UnityEngine;
using System.Collections;

public class ClickMouse : MonoBehaviour
{
    private float   mousePosX;
    private float   currentMousePosX;
    private float   tmpMousePosX;
    private bool    modeOn;
    private int     currentPosition;
    private int     CntZeros;
    private string  strZeros;

    private void Awake()
    {
        modeOn = false;
        currentPosition = 0;
        CntZeros = 3;
        strZeros = "000";
        tmpMousePosX = 0;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mousePosX = Input.mousePosition.x;
            currentMousePosX = mousePosX;
            tmpMousePosX = Input.mousePosition.x;
            modeOn = true;
        }
        if (modeOn)
        {
            currentMousePosX = Input.mousePosition.x;
            tmpMousePosX = Input.mousePosition.x;
            if (!Mathf.Approximately(currentMousePosX, mousePosX))
            {
               if ((currentMousePosX - mousePosX) > 10)
                {
                    Debug.Log("Shit" + tmpMousePosX);
                    LeftOrRight();
                 /*   if (currentPosition == 101)
                    {
                        currentPosition = 0; 
                    }
                    else if (currentPosition == 0)
                    {
                        currentPosition = 100; 
                    } */
                    ImageRefresh();
                }
                tmpMousePosX = Input.mousePosition.x;
            }
        }
            if (Input.GetButtonUp("Fire1"))
            {
                mousePosX = Input.mousePosition.x;
                modeOn = false;
                //Garder la derniere image
            }
    }
    void    RefreshZeros(int currentPosition)
    {
        if (currentPosition > 10000)
            Debug.Log("Log Error");
        else if (currentPosition < 10) 
        {
            CntZeros = 3;
        }
        else if (currentPosition < 100)
            CntZeros = 2; 
        else if (currentPosition == 100)
        {
            CntZeros = 1; 
        }
    }

    void    ImageRefresh()
    {
       RefreshZeros(currentPosition);
                    if (CntZeros == 3)
                        strZeros = "000";
                    else if (CntZeros == 2)
                        strZeros = "00";
                    else if (CntZeros == 1)
                        strZeros = "0";
                    else if (CntZeros == 0)
                        strZeros = "";
                    mousePosX = Input.mousePosition.x;
                    currentMousePosX = mousePosX;
                    Debug.Log("Images/Cochenec_rendu_anim" + strZeros + currentPosition.ToString() + ".png");
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Cochenec_rendu_anim" + strZeros + currentPosition.ToString());
    }

    void    LeftOrRight()
    {
        Debug.Log("Turlute" + tmpMousePosX);
        Debug.Log("Turlute2" + Input.mousePosition.x);
        if (Mathf.Approximately(tmpMousePosX < Input.mousePosition.x) + 100)
        {
            currentPosition++;
        }
        else if (Mathf.Approximately(tmpMousePosX > Input.mousePosition.x) - 100)
        {
            currentPosition--;
        }
    }

}




