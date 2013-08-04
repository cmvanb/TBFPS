/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-04
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using Casper.Framework.Core;

namespace Casper.TBFPS
{
	public class GameAppLayer : AppLayer 
	{
		// private methods
		protected override void EnteredState(AppLayerState enteredState)
		{
			switch (enteredState)
			{
			case AppLayerState.TRANSITIONING_ON:
				// load game
				
				// decide what level we are loading -> get level ID from level manager
				
				// load level prefab from resources
				
				// finished loading level data -> 
				
				break;
				
			case AppLayerState.ACTIVE:
				// enable GUI
				
				break;
				
			case AppLayerState.PAUSED:
				// disable GUI
				
				break;
				
			case AppLayerState.TRANSITIONING_OFF:
				// disable GUI
				// start GUI transitions
				
				break;
				
			case AppLayerState.NULL:
				// unload game
				
				break;
			}
			
			base.EnteredState(enteredState);
		}
	}
}