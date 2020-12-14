using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ColorPicker", menuName = "Game/Color Picker")]
public class ColorPickerSO : ScriptableObject
{
    public string Name;
    [SerializeField] private Material targetMaterial;
    [SerializeField] private string cMetallicKey = "_Metallic";
    [SerializeField] private string cSmoothKey = "_Glossiness";
    [SerializeField] private string cColorKey = "_BaseColor";

    [SerializeField] private Slider hueSlider, valueLightnessSlider, saturationSlider, metallicSlider, smoothnessSlider;

    [SerializeField] private bool useHDR = true;

    private float hue, saturation, colourValue;

    public void SetDefault()
    {
        this.InitColorSliderPositions();
        this.InitMetallicSliderPosition();
        this.InitSmoothnessSliderPosition();
    }

    public void UpdateColor()
    {
        Color color = Color.HSVToRGB(hue, saturation, colourValue, useHDR);
        targetMaterial.SetColor(cColorKey, color);
    }

    public void SetHue(float val)
    {
        hue = val;
        this.UpdateColor();
    }

    public void SetSaturation(float val)
    {
        saturation = val;
        this.UpdateColor();
    }

    public void SetColorValue(float val)
    {
        colourValue = val;
        this.UpdateColor();
    }

    public void SetMetallicValue(float val)
    {
        targetMaterial.SetFloat(cMetallicKey, val);
    }

    public void SetSmoothnessValue(float val)
    {
        targetMaterial.SetFloat(cSmoothKey, val);
    }

    private void InitColorSliderPositions()
    {
        Color materialStartColour = targetMaterial.GetColor(cColorKey);
        Color.RGBToHSV(materialStartColour, out float h, out float s, out float v);

        hueSlider.value = h;
        saturationSlider.value = s;
        valueLightnessSlider.value = v;
    }

    private void InitSmoothnessSliderPosition()
    {
        smoothnessSlider.value = targetMaterial.GetFloat(cSmoothKey);
    }

    private void InitMetallicSliderPosition()
    {
        metallicSlider.value = targetMaterial.GetFloat(cMetallicKey);
    }

}
