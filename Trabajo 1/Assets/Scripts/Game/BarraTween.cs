using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraTween : MonoBehaviour
{
    //ATRIBUTOS
    
    public Image image;
    public float tweenTime;
    public Color beginColor, endColor;
    
    //METODOS

    public void Tween()
    {
        LeanTween.value(gameObject, 0.1f, 1, tweenTime)
            .setEasePunch()
            .setOnUpdate((value) =>
            {
                image.fillAmount = value;
                image.color = Color.Lerp(beginColor, endColor, value);
            });
    }
}
