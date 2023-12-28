using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_skin_change : MonoBehaviour
{
    public void CL_1()
    {
        PlayerPrefs.SetString("Body", "Body");
        PlayerPrefs.SetString("Bottom", "CL_1_BOTTOM");
        PlayerPrefs.SetString("EyeLsh", "Eyelashes");
        PlayerPrefs.SetString("Eye", "Eyes");
        PlayerPrefs.SetString("Top", "CL_1_TOP");
        PlayerPrefs.SetString("Shoe", "Shoes");
        PlayerPrefs.SetString("MAT", "CLOTH_1");
    }

    public void CL_2()
    {
        PlayerPrefs.SetString("Body", "CL_2_BODY");
        PlayerPrefs.SetString("Bottom", "CL_2_BOTTOM");
        PlayerPrefs.SetString("EyeLsh", "CL_2_EYE_LASH");
        PlayerPrefs.SetString("Eye", "CL_2_EYE");
        PlayerPrefs.SetString("Top", "NA");
        PlayerPrefs.SetString("Shoe", "NA");
        PlayerPrefs.SetString("MAT", "CLOTH_2");
    }

    public void CL_base()
    {
        PlayerPrefs.SetString("Body", "Body");
        PlayerPrefs.SetString("Bottom", "Bottoms");
        PlayerPrefs.SetString("EyeLsh", "Eyelashes");
        PlayerPrefs.SetString("Eye", "Eyes");
        PlayerPrefs.SetString("Top", "Tops");
        PlayerPrefs.SetString("Shoe", "Shoes");
        PlayerPrefs.SetString("MAT", "Player");
    }
}
