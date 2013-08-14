/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-14
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;

namespace Casper.TBFPS
{
	public class Health : MonoBehaviour
	{
		#region events
		public delegate void DiedHandler();
		public event DiedHandler OnDied;
		
		public delegate void RespawnedHandler();
		public event RespawnedHandler OnRespawned;
		#endregion
		
		#region inspector vars
		[SerializeField]
		private float m_fullValue;
		#endregion
	
		#region public vars
		private float m_healthValue;
		public float HealthValue { get { return m_healthValue; } }
		
		public bool Dead { get { return m_healthValue <= 0f; } }
		#endregion
		
		#region unity callbacks
		void Start()
		{
			m_healthValue = m_fullValue;
		}
		#endregion
		
		#region public methods
		public void TakeDamage(float amount)
		{
			if (Dead)
			{
				return;
			}
			
			m_healthValue -= amount;
			
			if (Dead)
			{
				if (OnDied != null)
				{
					OnDied();
				}
			}
		}
		
		public void Respawn()
		{
			m_healthValue = m_fullValue;
			
			if (OnRespawned != null)
			{
				OnRespawned();
			}
		}
		#endregion
	}
}