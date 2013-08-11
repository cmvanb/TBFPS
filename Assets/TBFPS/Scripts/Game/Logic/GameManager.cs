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
	
		#region private vars
		private GameState m_currentGameState = GameState.NONE;
		
		private List<PlayerEntity> m_players;
		
		private PlayerEntity m_activePlayer;
		
		private Action m_currentAction;
		
		private int m_actionPointsPerTurn = 2;
		#endregion
		
		// singleton callbacks
		public override void Init() 
		{
			base.Init();
			
			m_players = new List<PlayerEntity>();
		}
		
		// unity callbacks
		void Start()
		{
			SetGameState(GameState.LIMBO);
		}
		
		void Update()
		{
			UpdateGameState();
		}
						
		// public methods
		public void SetGameState(GameState newState)
		{
			m_currentGameState = newState;
			
			DebugUtil.Log(this.GetType().Name + " changed game state to " + m_currentGameState.ToString());
			
			EnterGameState(newState);
		}
		
		public void ActionsHUDSelectedAction(int index)
		{
			if (index == 0)
			{
				DebugUtil.Log(this.GetType().Name + " selected move action");
			
				StartAction(new MoveAction(m_activePlayer));
			}
			else if (index == 1)
			{
				DebugUtil.Log(this.GetType().Name + " selected attack action");
			}
			else if (index == 2)
			{
				DebugUtil.Log(this.GetType().Name + " selected cover action");
			}
			
			m_activePlayer.LocalActionsHUD.enabled = false;
			
			m_activePlayer.ActionPoints -= 1;
		}
		
		// private methods
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
					
					foreach (PlayerEntity player in m_players)
					{
						if (player != m_activePlayer)
						{
							if (player.IsLocalPlayer)
							{
								player.LocalActionsHUD.enabled = false;
							}
						}
					}
				}
				
				if (m_activePlayer.IsLocalPlayer)
				{
					SetGameState(GameState.LOCAL_PLAYER_TURN);
				}
				else
				{
					SetGameState(GameState.OTHER_PLAYER_TURN);
				}
				
				m_activePlayer.ActionPoints = m_actionPointsPerTurn;
				break;
				
			case GameState.LOCAL_PLAYER_TURN:
				// not allowed to move right away
				m_activePlayer.PlayerMovementComponent.enabled = false;
				
				// listen for actions
				m_activePlayer.LocalActionsHUD.OnSelectedAction += ActionsHUDSelectedAction;
				break;
				
			case GameState.OTHER_PLAYER_TURN:
				// not allowed to move right away
				m_activePlayer.PlayerMovementComponent.enabled = false;
				break;
				
			case GameState.GAME_OVER:
				DebugUtil.LogError("Not implemented.");
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
				if (m_currentAction != null)
				{
					m_currentAction.Update();
				}
				break;
				
			case GameState.OTHER_PLAYER_TURN:
				break;
				
			case GameState.GAME_OVER:
				break;
			}
		}
		
		private void StartAction(Action action)
		{
			m_currentAction = action;
			
			m_currentAction.Start();
			
			m_currentAction.OnActionCompleted += FinishAction;
		}
		
		private void FinishAction(Action actionCompleted)
		{			
			m_currentAction.OnActionCompleted -= FinishAction;
			
			m_currentAction = null;

			if (m_activePlayer.ActionPoints <= 0)
			{
				// end turn
			}
			else
			{
				m_activePlayer.LocalActionsHUD.enabled = true;
			}
		}
		
		private void EndTurn()
		{
		}
		
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
	}
}