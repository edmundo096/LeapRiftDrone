using UnityEngine;
using System.Collections;
using LMWidgets;

public class SliderDataModel : DataBinderSlider {
    [SerializeField]
    float sliderValue = 0; //Data model

    override protected void setDataModel(float value) {
        sliderValue = value;
    }

    override public float GetCurrentData() {
        return sliderValue;
    }
}
