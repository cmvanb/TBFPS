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
	public class PlayerEntity : Entity
	{
		// events
		
		// inspector vars
		[SerializeField]
		private bool m_isLocalPlayer;
		public bool IsLocalPlayer { get { return m_isLocalPlayer; } }
		
		[SerializeField]
		private PlayerMovement m_playerMovementComponent;
		public PlayerMovement PlayerMovementComponent { get { return m_playerMovementComponent; } }
	
		// public vars
		
		// private vars
		
		// constructor
		
		// singleton callbacks
		
		// unity callbacks
		
		// public methods
		
		// private methods
	}
}