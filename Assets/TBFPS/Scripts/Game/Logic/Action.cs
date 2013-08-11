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
	public abstract class Action
	{
		#region events
		public delegate void ActionCompletedHandler(Action actionCompleted);
		public event ActionCompletedHandler OnActionCompleted;
		#endregion
	
		#region private vars
		protected PlayerEntity m_playerEntity;
		#endregion
		
		// constructor
		public Action(PlayerEntity playerEntity)
		{
			m_playerEntity = playerEntity;
		}		
		
		// unity callbacks
		
		// public methods
		public abstract void Start();
		
		public abstract void Update();
		
		/// <summary>
		/// Finish this action. Triggers the OnActionCompleted event.
		/// </summary>
		public virtual void Finish()
		{
			if (OnActionCompleted != null)
			{
				OnActionCompleted(this);
			}
		}
		
		// private methods
	}
}