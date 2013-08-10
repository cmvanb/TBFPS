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
	public class PlayerEntity : Entity
	{
		// events
		
		// inspector vars
		[SerializeField]
		private bool m_isLocalPlayer;
		public bool IsLocalPlayer { get { return m_isLocalPlayer; } }
		
		[SerializeField]
		private MouseLook m_mouseLookComponent;
		public MouseLook MouseLookComponent { get { return m_mouseLookComponent; } }
		
		[SerializeField]
		private PlayerMovement m_playerMovementComponent;
		public PlayerMovement PlayerMovementComponent { get { return m_playerMovementComponent; } }
	
		// public vars
		private ActionsHUD m_localActionsHUD;
		public ActionsHUD LocalActionsHUD { get { return m_localActionsHUD; } }
		
		// private vars
		
		// constructor
		
		// singleton callbacks
		
		// unity callbacks
		void Awake()
		{
			if (m_isLocalPlayer)
			{
				m_localActionsHUD = Object.FindObjectOfType(typeof(ActionsHUD)) as ActionsHUD;
				
				if (m_localActionsHUD != null)
				{
					m_localActionsHUD.LocalPlayer = this;
				}
				else
				{
					DebugUtil.LogError("Could not find local player's ActionsHUD");
				}
			}
		}
		
		// public methods
		
		// private methods
	}
}