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
	public enum GameState
	{
		NONE,
		LIMBO,
		LOCAL_PLAYER_TURN,
		OTHER_PLAYER_TURN,
		GAME_OVER,
	}
}