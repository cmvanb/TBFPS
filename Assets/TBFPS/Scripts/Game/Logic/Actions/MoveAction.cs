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
	public class MoveAction : Action
	{
		#region private vars
		#endregion
		
		// constructor
		public MoveAction(PlayerEntity playerEntity) : base(playerEntity)
		{
		}
		
		// singleton callbacks
		
		// unity callbacks
		
		// public methods
		public override void Start()
		{
			DebugUtil.Log(this.GetType().Name + " started");
			
			m_playerEntity.PlayerMovementComponent.enabled = true;
			
			m_playerEntity.PlayerMovementComponent.OnMovementCompleted += Finish;
		}
		
		public override void Update()
		{
		}
		
		public override void Finish()
		{
			DebugUtil.Log(this.GetType().Name + " finished");
			
			m_playerEntity.PlayerMovementComponent.OnMovementCompleted -= Finish;
			
			m_playerEntity.PlayerMovementComponent.enabled = false;
			
			base.Finish();
		}
		
		// private methods
	}
}