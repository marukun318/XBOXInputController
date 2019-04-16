using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    private XBOXInputController inputController;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Wait for initialization of InputController
        do
        {
            yield return null;
        }
        while (inputController.IsReady == false);

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        // Check: Be sure to call in this order
        uint pad = inputController.Poll();              // パッド入力
        uint pad_trg = inputController.Trigger();       // パッドトリガ入力

        // Check pad operation with pad and pad_trg values
        // Button
        if ((pad_trg & XBOXInputController.PAD_BUTTON_RB) != 0)
        {
            Debug.Log("RB");
        }
        if ((pad_trg & XBOXInputController.PAD_BUTTON_LB) != 0)
        {
            Debug.Log("LB");
        }
        if ((pad_trg & XBOXInputController.PAD_BUTTON_A) != 0)
        {
            Debug.Log("A Button");
        }
        if ((pad_trg & XBOXInputController.PAD_BUTTON_B) != 0)
        {
            Debug.Log("B Button");
        }
        if ((pad_trg & XBOXInputController.PAD_BUTTON_X) != 0)
        {
            Debug.Log("X Button");
        }
        if ((pad_trg & XBOXInputController.PAD_BUTTON_Y) != 0)
        {
            Debug.Log("Y Button");
        }
        if ((pad_trg & XBOXInputController.PAD_BUTTON_MENU) != 0)
        {
            Debug.Log("MENU Button");
        }
        if ((pad_trg & XBOXInputController.PAD_BUTTON_VIEW) != 0)
        {
            Debug.Log("VIEW Button");
        }

        // Directional Key
        if ((pad_trg & XBOXInputController.PAD_UP) != 0)
        {
            Debug.Log("UP");
        }
        else
        if ((pad_trg & XBOXInputController.PAD_DOWN) != 0)
        {
            Debug.Log("DOWN");
        }

        //
        if ((pad_trg & XBOXInputController.PAD_LEFT) != 0)
        {
            Debug.Log("LEFT");
        }
        else
        if ((pad_trg & XBOXInputController.PAD_RIGHT) != 0)
        {
            Debug.Log("RIGHT");
        }
        
    }
}
