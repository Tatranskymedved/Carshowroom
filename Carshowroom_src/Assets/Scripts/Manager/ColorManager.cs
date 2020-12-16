using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ColorManager : MonoBehaviour
{
    [Header("Keys for manipulating material")]
    [SerializeField] private string cMetallicKey = "_Metallic";
    [SerializeField] private string cSmoothKey = "_Glossiness";
    [SerializeField] private string cColorKey = "_Color";

    [Space()]
    public List<ColorPickerSO> colorPickerList;
    private ColorPickerSO selectedColorPickerSO;

    [Header("UI Elements")]
    [SerializeField] private Slider hueSlider;
    [SerializeField] private Slider valueSlider;
    [SerializeField] private Slider saturationSlider;//, metallicSlider, smoothnessSlider;
    [SerializeField] private Image resultImage;
    [SerializeField] private TMP_Dropdown dropdown;

    public void Start()
    {
        OnSelectedColorPickerChanged(0);
        UpdateColor();
    }

    public void OnEnable()
    {
        if (dropdown != null)
        {
            if (colorPickerList != null && colorPickerList.Count > 0)
            {
                dropdown.ClearOptions();
                dropdown.AddOptions(colorPickerList.Select(cp => cp.Name).ToList());
            }
            dropdown.onValueChanged.AddListener(OnSelectedColorPickerChanged);
        }
        if (hueSlider != null)
            hueSlider.onValueChanged.AddListener(OnHueSliderValueChanged);
        if (valueSlider != null)
            valueSlider.onValueChanged.AddListener(OnValueSliderValueChanged);
        if (saturationSlider != null)
            saturationSlider.onValueChanged.AddListener(OnSaturationSliderValueChanged);
    }

    public void OnDisable()
    {
        if (dropdown != null)
            dropdown.onValueChanged.RemoveListener(OnSelectedColorPickerChanged);
        if (hueSlider != null)
            hueSlider.onValueChanged.RemoveListener(OnHueSliderValueChanged);
        if (valueSlider != null)
            valueSlider.onValueChanged.RemoveListener(OnValueSliderValueChanged);
        if (saturationSlider != null)
            saturationSlider.onValueChanged.RemoveListener(OnSaturationSliderValueChanged);
    }

    public void SetDefault()
    {
        this.InitColorSliderPositions();
        //this.InitMetallicSliderPosition();
        //this.InitSmoothnessSliderPosition();
    }

    public void UpdateColor()
    {
        if (selectedColorPickerSO == null || selectedColorPickerSO.targetMaterial == null) return;

        Color color = Color.HSVToRGB(selectedColorPickerSO.hue, selectedColorPickerSO.saturation, selectedColorPickerSO.colorValue, selectedColorPickerSO.useHDR);
        //selectedColorPickerSO.targetMaterial.mainTexture
        selectedColorPickerSO.targetMaterial.SetColor(cColorKey, color);
        selectedColorPickerSO?.UpdateResultImageWithColor(resultImage);
    }

    public void SetHue(float val)
    {
        if (selectedColorPickerSO == null) return;

        selectedColorPickerSO.hue = val;
        this.UpdateColor();
    }

    public void SetSaturation(float val)
    {
        if (selectedColorPickerSO == null) return;

        selectedColorPickerSO.saturation = val;
        this.UpdateColor();
    }

    public void SetColorValue(float val)
    {
        if (selectedColorPickerSO == null) return;

        selectedColorPickerSO.colorValue = val;
        this.UpdateColor();
    }

    public void SetMetallicValue(float val)
    {
        if (selectedColorPickerSO == null || selectedColorPickerSO.targetMaterial == null) return;

        selectedColorPickerSO.targetMaterial.SetFloat(cMetallicKey, val);
        selectedColorPickerSO?.UpdateResultImageWithColor(resultImage);
    }

    public void SetSmoothnessValue(float val)
    {
        if (selectedColorPickerSO == null || selectedColorPickerSO.targetMaterial == null) return;

        selectedColorPickerSO.targetMaterial.SetFloat(cSmoothKey, val);
        selectedColorPickerSO?.UpdateResultImageWithColor(resultImage);
    }

    private void InitColorSliderPositions()
    {
        float h, s, v;
        if (selectedColorPickerSO == null || selectedColorPickerSO.targetMaterial == null)
        {
            h = s = v = 0f;
        }
        else
        {
            Color materialStartColour = selectedColorPickerSO.targetMaterial.GetColor(cColorKey);
            Color.RGBToHSV(materialStartColour, out h, out s, out v);
        }

        hueSlider.value = h;
        saturationSlider.value = s;
        valueSlider.value = v;
        selectedColorPickerSO?.UpdateResultImageWithColor(resultImage);
    }

    private void OnSelectedColorPickerChanged(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < colorPickerList.Count)
        {
            selectedColorPickerSO = colorPickerList[selectedIndex];
            selectedColorPickerSO?.GetHSVFromMaterial();
            selectedColorPickerSO?.UpdateResultImageWithColor(resultImage);
            selectedColorPickerSO?.UpdateHueSlider(hueSlider);
            selectedColorPickerSO?.UpdateSaturationSlider(saturationSlider);
            selectedColorPickerSO?.UpdateLightnessSlider(valueSlider);
        }
    }

    private void OnHueSliderValueChanged(float value)
    {
        SetHue(value);
    }
    private void OnValueSliderValueChanged(float value)
    {
        SetColorValue(value);
    }
    private void OnSaturationSliderValueChanged(float value)
    {
        SetSaturation(value);
    }
}
