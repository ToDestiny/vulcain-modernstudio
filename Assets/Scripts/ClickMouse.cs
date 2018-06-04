using UnityEngine;
using System.Collections;

public class ClickMouse : MonoBehaviour
{
    private float mousePosX;
    private float currentMousePosX;
    private bool modeOn;
    private int currentPosition;

    private void Awake()
    {
        modeOn = false;
        currentPosition = 0;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mousePosX = Input.mousePosition.x;
            currentMousePosX = mousePosX;
            modeOn = true;
        }
        if (modeOn)
        {
            currentMousePosX = Input.mousePosition.x;
            if (!Mathf.Approximately(currentMousePosX, mousePosX))
            {
                if ((currentMousePosX - mousePosX) > 10)
                {
                    Debug.Log("Droite");
                    currentPosition++;
                    mousePosX = Input.mousePosition.x;
                    currentMousePosX = mousePosX;
                    Debug.Log("Images/Cochenec_rendu_anim000" + currentPosition.ToString() + ".png");
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Cochenec_rendu_anim000" + currentPosition.ToString());
                    // Changer l'image sur la droite
                }
            }
        }
            if (Input.GetButtonUp("Fire1"))
            {
                mousePosX = Input.mousePosition.x;
                modeOn = false;
                //Garder la derniere image
            }
    }
   
}




