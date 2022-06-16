using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_script : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)]
    [Tooltip("Значение находится в диапазоне от 0 до 5")]
    [Header("Custom color")]
    private Color myColor;
    [SerializeField] MeshRenderer GO;      


    void OnGUI()
    {
        myColor = RGBASlider(new Rect(10, 30, 200, 20), myColor);  
        GO.material.color = myColor; 
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText) 
    {
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); 
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); 
        return sliderValue; // Возвращаем значение слайдера
    }
    Color RGBASlider(Rect screenRect, Color rgba)
    {
        rgba.r = LabelSlider(screenRect, rgba.r, 0.0f, 1.0f, "Red");

        screenRect.y += 20;
        rgba.g = LabelSlider(screenRect, rgba.g, 0.0f, 1.0f, "Green");

        screenRect.y += 20;
        rgba.b = LabelSlider(screenRect, rgba.b, 0.0f, 1.0f, "Blue");

        screenRect.y += 20;
        rgba.a = LabelSlider(screenRect, rgba.a, 0.0f, 1.0f, "Alpha");

        return rgba;
    }

}
