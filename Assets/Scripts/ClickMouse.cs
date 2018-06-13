using UnityEngine;
using System.Collections;

public class ClickMouse : MonoBehaviour
{

    private bool    modeOn;
    private int     currentPosition;
    private int     CntZeros;
    private string  strZeros;
    private Vector3 v3Pos;
    private int     threshold = 9;

    private void Awake()
    {
        modeOn = false;
        currentPosition = 0;
        CntZeros = 3;
        strZeros = "000";
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            modeOn = true;
        }
        if (modeOn)
        {
            OnMouseDrag();
            if (currentPosition == 101)
            {
                currentPosition = 0; 
            }
            else if (currentPosition == 0)
            {
                currentPosition = 100; 
            }
            ImageRefresh();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            modeOn = false;
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
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Cochenec_rendu_anim" + strZeros + currentPosition.ToString());
    }

        void OnMouseDrag() 
        {
        var v3 = Input.mousePosition - v3Pos;
        v3.Normalize();
        var f = Vector3.Dot(v3, Vector3.up);
        if (Vector3.Distance(v3Pos, Input.mousePosition) < threshold) {
             Debug.Log("No movement");
        return;
        }
 
        if (f >= 0.5) {
            Debug.Log("Up");
        }
        else if (f <= -0.5) {
            Debug.Log("Down");
        }
        else {
            f = Vector3.Dot(v3, Vector3.right);
            if (f >= 0.5) {
                Debug.Log("Right");
                currentPosition--;
            }
            else {
                 Debug.Log("Left");
                 currentPosition++;
                }
            }
        v3Pos = Input.mousePosition;
     }
}
