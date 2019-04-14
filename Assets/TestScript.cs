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
        //        StartCoroutine(InputControllerWaitReady());
        do
        {
            yield return null;
        }
        while (inputController.IsReady == false);

        yield break;
    }

/*
    // 初期化が終わるまで待つ    
    IEnumerator InputControllerWaitReady()
    {
        do
        {
            yield return null;
        }
        while (inputController.IsReady == false);
        
        yield break;
    }
 */

    // Update is called once per frame
    void Update()
    {
        // Check: Be sure to call in this order
        uint pad = inputController.Poll();              // パッド入力
        uint pad_trg = inputController.Trigger();       // パッドトリガ入力

        // Check pad operation with pad and pad_trg values

        
    }
}
