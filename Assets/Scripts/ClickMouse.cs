using UnityEngine;
using System.Collections;

public class ClickMouse : MonoBehaviour
{

    private bool    modeOn;
    private int     currentPosition;
    private int     CntZeros;
    private string  strZeros;
    private Vector3 v3Pos;
    private Vector2 v2Pos;
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
        #if UNITY_EDITOR
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

     #else
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            modeOn = true;
        }
        if (modeOn)
        {
            OnTouchDrag();
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
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
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

        void OnTouchDrag() 
        {
        var v2 = Input.GetTouch(0).position - v2Pos;
        v2.Normalize();
        var f = Vector2.Dot(v2, Vector2.up);
        if (Vector2.Distance(v2Pos, Input.GetTouch(0).position) < threshold) {
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
            f = Vector2.Dot(v2, Vector2.right);
            if (f >= 0.5) {
                Debug.Log("Right");
                currentPosition--;
            }
            else {
                 Debug.Log("Left");
                 currentPosition++;
                }
            }
        v2Pos = Input.GetTouch(0).position;
     }

     #endif
}
