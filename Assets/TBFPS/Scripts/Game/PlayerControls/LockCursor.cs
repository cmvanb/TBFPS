/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-10
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;

namespace Casper.TBFPS
{
	public class LockCursor : MonoBehaviour
	{
		// events
	
		#region public vars
		#endregion
		
		#region private vars
		#endregion
		
		// unity callbacks
		void Awake()
		{
			Screen.lockCursor = true;
		}
		
		void Update()
		{
			// unity already handles this in editor and webplayer
			#if !UNITY_EDITOR && !UNITY_WEBPLAYER
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				Screen.lockCursor = false;
			}
			#endif		
			
			// if we click in the game lock the cursor again
			if (Input.GetMouseButtonUp(0))
			{
				Screen.lockCursor = true;
			}
		}
		
		// public methods
		
		// private methods
	}
}