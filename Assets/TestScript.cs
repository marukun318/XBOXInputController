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

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        uint pad = inputController.Poll();      // パッド入力

        
    }
}
