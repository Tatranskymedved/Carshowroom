using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ColorPicker", menuName = "Game/Color Picker")]
public class ColorPickerSO : ScriptableObject
{
    public string Name;
    
    public Material targetMaterial;
    public bool useHDR = true;
    public float hue, saturation, colorValue;

    public void GetHSVFromMaterial()
    {
        if (targetMaterial == null) return;

        Color.RGBToHSV(targetMaterial.color, out hue, out saturation, out colorValue);
    }

    public void UpdateResultImageWithColor(Image img)
    {
        if (targetMaterial == null) return;
        if (img == null) return;

        img.color = targetMaterial.color;
    }

    public void UpdateHueSlider(Slider slider)
    {
        if (targetMaterial == null) return;
        if (slider == null) return;

        slider.value = hue;
    }

    public void UpdateSaturationSlider(Slider slider)
    {
        if (targetMaterial == null) return;
        if (slider == null) return;

        slider.value = saturation;
    }

    public void UpdateLightnessSlider(Slider slider)
    {
        if (targetMaterial == null) return;
        if (slider == null) return;

        slider.value = colorValue;
    }
}
