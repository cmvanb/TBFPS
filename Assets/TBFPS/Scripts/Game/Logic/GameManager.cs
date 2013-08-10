/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-10
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;
using Casper.Framework;

namespace Casper.TBFPS
{
	public sealed class GameManager : Singleton<GameManager>
	{
		// events
	
		// public vars
		
		// private vars
		private GameState m_currentGameState = GameState.NONE;
		
		// singleton callbacks
		public override void Init() 
		{
			base.Init();
		}
		
		// unity callbacks
		void Update()
		{
			UpdateGameState();
		}
						
		// public methods
		
		// private methods
		private void UpdateGameState()		
		{
			switch (m_currentGameState)
			{
			case GameState.NONE:
				break;
				
			case GameState.LIMBO:
				break;
				
			case GameState.LOCAL_PLAYER_TURN:
				break;
				
			case GameState.OTHER_PLAYER_TURN:
				break;
				
			case GameState.GAME_OVER:
				break;
			}
		}
	}
}