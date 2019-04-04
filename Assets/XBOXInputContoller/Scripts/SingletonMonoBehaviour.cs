// These codes are licensed under CC0.
// http://creativecommons.org/publicdomain/zero/1.0/deed.ja
//
// Original author: tsubaki
// https://gist.github.com/tsubaki/e0406377a1b014754894

using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
	protected static T instance;
	public static T Instance {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T));
				
				if (instance == null) {
					Debug.LogWarning (typeof(T) + "is nothing");
				}
			}
			
			return instance;
		}
	}
	
	protected void Awake()
	{
#if NET_2_0 || NET_2_0_SUBSET || NET_STANDARD_2_0
#error Set .NET Version to 4.6 or later.
#else
        CheckInstance();
#endif
	}
	
	protected bool CheckInstance()
	{
		if( instance == null)
		{
			instance = (T)this;
			return true;
		}else if( Instance == this )
		{
			return true;
		}

		Destroy(this);
		return false;
	}
}
