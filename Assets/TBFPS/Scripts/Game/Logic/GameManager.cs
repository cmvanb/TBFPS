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
		
		private List<PlayerEntity> m_players;
		
		private PlayerEntity m_activePlayer;
		
		// singleton callbacks
		public override void Init() 
		{
			base.Init();
			
			m_players = new List<PlayerEntity>();
			
			SetGameState(GameState.LIMBO);
		}
		
		// unity callbacks
		void Update()
		{
			UpdateGameState();
		}
						
		// public methods
		public void SetGameState(GameState newState)
		{
			m_currentGameState = newState;
			
			EnterGameState(newState);
		}
		
		// private methods
		private void FindPlayers()
		{
			PlayerEntity[] scenePlayers = Object.FindObjectsOfType(typeof(PlayerEntity)) as PlayerEntity[];
			
			if (scenePlayers.Length > 0)
			{
				m_players.AddRange(scenePlayers);
			}
			else
			{
				DebugUtil.LogWarning("Couldn't find any player entities in the scene!");
			}
		}
		
		private void EnterGameState(GameState enteredState)
		{
			switch (enteredState)
			{
			case GameState.NONE:
				break;
				
			case GameState.LIMBO:
				// show start of game GUI
				
				// this should be in Update 
				FindPlayers();
				
				if (m_players.Count > 0)
				{
					m_activePlayer = m_players[0];
				}
				
				if (m_activePlayer.IsLocalPlayer)
				{
					SetGameState(GameState.LOCAL_PLAYER_TURN);
				}
				else
				{
					SetGameState(GameState.OTHER_PLAYER_TURN);
				}
				break;
				
			case GameState.LOCAL_PLAYER_TURN:
				// start active player turn
				
				// not allowed to move right away
				m_activePlayer.PlayerMovementComponent.enabled = false;
				break;
				
			case GameState.OTHER_PLAYER_TURN:
				Debug.LogError("Not implemented.");
				break;
				
			case GameState.GAME_OVER:
				Debug.LogError("Not implemented.");
				break;
			}
		}
		
		private void UpdateGameState()		
		{
			switch (m_currentGameState)
			{
			case GameState.NONE:
				break;
				
			case GameState.LIMBO:
				// wait for input from start of game GUI, then start game with active player
				break;
				
			case GameState.LOCAL_PLAYER_TURN:
				// update active player turn
				break;
				
			case GameState.OTHER_PLAYER_TURN:
				break;
				
			case GameState.GAME_OVER:
				break;
			}
		}
	}
}