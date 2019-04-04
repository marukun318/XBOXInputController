// These codes are licensed under CC0.
// http://creativecommons.org/publicdomain/zero/1.0/deed.ja

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private XBOXInputController inputController;

    // Start is called before the first frame update
    IEnumerator Start()
    {
#if NET_2_0 || NET_2_0_SUBSET || NET_STANDARD_2_0
#error Set .NET Version to 4.6 or later
#endif
        inputController = XBOXInputController.Instance;

        yield break;
    }
  
}
