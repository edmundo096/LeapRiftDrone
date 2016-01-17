using UnityEngine;
using System.Collections;

public class HoverboradItemsListener : MonoBehaviour {

    public DroneController dronController;

    public Hover.Board.Items.HoverboardItem panelItem1;
    public Hover.Board.Items.HoverboardItem panelItem2;
    private Hover.Common.Items.ISelectableItem selItem1;
    private Hover.Common.Items.ISelectableItem selItem2;

    public float matchingTimeLimit = 3.0f;
    public float minimumTimeBetweeMatches = 2.0f;
    private float lastMatchTime;

    private float timeLastPi1Selection = 0f;
    private float timeLastPi2Selection = 0f;

    // Use this for initialization
    public void Start() {
        //ItemPanel[] itemPanels = GameObject.Find("Hoverboard")
        //    .GetComponentInChildren<HoverboardSetup>()
        //    .Panels
        //    .Select(x => x.GetPanel())
        //    .ToArray();

        //foreach (ItemPanel itemPanel in itemPanels) {
        //    foreach (IItemLayout itemLayout in itemPanel.Layouts) {
        //        foreach (Hover.Common.Items.IBaseItem item in itemLayout.Items) {
        //            ISelectableItem selItem = (item as ISelectableItem);

        //            if (selItem == null) {
        //                continue;
        //            }

        //            selItem.OnSelected += HandleItemSelected;
        //        }
        //    }
        //}

        //panelItem1.


        Hover.Common.Items.IBaseItem launchLandItem;

        launchLandItem = panelItem1.GetItem();
        selItem1 = (launchLandItem as Hover.Common.Items.ISelectableItem);
        if (selItem1 != null) {
            selItem1.OnSelected += HandleItemSelected;
        }

        launchLandItem = panelItem2.GetItem();
        selItem2 = (launchLandItem as Hover.Common.Items.ISelectableItem);
        if (selItem2 != null) {
            selItem2.OnSelected += HandleItemSelected;
        }

    }


    private void HandleItemSelected(Hover.Common.Items.ISelectableItem pItem) {

        // Assign the current time to the selected one.
        if (pItem == selItem1) {
            timeLastPi1Selection = Time.time;
        }
        else if (pItem == selItem2) {
            timeLastPi2Selection = Time.time;
        }

        // Check if the diff. of time between both is less or equal to the time limit.
        if (Mathf.Abs(timeLastPi1Selection - timeLastPi2Selection) <= matchingTimeLimit &&
            Mathf.Abs(Time.time - lastMatchTime) > minimumTimeBetweeMatches) {

            lastMatchTime = Time.time;

            // TakeOff or land.
            dronController.TakeOffOrLand();
            Debug.Log("Time matched");
        }

        //if (pItem.Label == "^") {
        //    return;
        //}

        //if (pItem.Label.Length == 1) {
        //    vEnviro.AddLetter(pItem.Label[0]);
        //    vTextField.AddLetter(pItem.Label[0]);
        //    return;
        //}

        //if (pItem.Label.ToLower() == "back") {
        //    vEnviro.RemoveLatestLetter();
        //    vTextField.RemoveLatestLetter();
        //}

        //if (pItem.Label.ToLower() == "enter") {
        //    vTextField.ClearLetters();
        //}
    }
    
}
