using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;

public class ToggleDataBinder : DataBinderToggle {
  [SerializeField] 
  Text uiText;

  override public bool GetCurrentData() {
    if ( uiText.text.ToLower() == "true" ) {
      return true;
    }
    else {
      return false;
    }
  }

  override protected void setDataModel(bool value) { 
    if ( value == true ) { 
      uiText.text = "True";
    }
    else {
      uiText.text = "False";
    }
  }
}
