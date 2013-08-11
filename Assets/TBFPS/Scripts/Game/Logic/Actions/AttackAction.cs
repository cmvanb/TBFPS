/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-11
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;
using Casper.Framework;

namespace Casper.TBFPS
{
	public class AttackAction : Action
	{
		#region constructor
		public AttackAction(PlayerEntity playerEntity) : base(playerEntity)
		{
		}
		#endregion
		
		#region public methods
		public override void Start()
		{
			DebugUtil.Log(this.GetType().Name + " started");
			
			m_playerEntity.PlayerAimComponent.enabled = true;
			
			m_playerEntity.PlayerAimComponent.OnShotFired += Finish;
		}
		
		public override void Update()
		{
		}
		
		public override void Finish()
		{
			DebugUtil.Log(this.GetType().Name + " finished");
			
			m_playerEntity.PlayerAimComponent.OnShotFired -= Finish;
			
			m_playerEntity.PlayerAimComponent.enabled = false;
			
			base.Finish();
		}
		#endregion
	}
}