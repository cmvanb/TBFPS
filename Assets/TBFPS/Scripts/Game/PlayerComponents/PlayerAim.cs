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
	public class PlayerAim : MonoBehaviour
	{
		#region events
		public delegate void ShotFiredHandler();
		public event ShotFiredHandler OnShotFired;
		#endregion
		
		#region inspector vars
		[SerializeField]
		private Weapon m_weapon;
		#endregion
	
		#region public vars
		#endregion
		
		#region private vars
		private bool m_aiming;
		
		private bool m_fired;
		#endregion
		
		#region constructor
		#endregion
		
		#region singleton callbacks
		#endregion
		
		#region unity callbacks
		void Update()
		{
			if (!m_fired)
			{
				UpdateInput();
			}
		}
		
		void OnEnable()
		{
			m_aiming = false;
			
			m_fired = false;
		}
		
		void OnDisable()
		{
			m_weapon.Lower(0.5f);
		}
		#endregion
		
		#region public methods
		#endregion
		
		#region private methods
		private void UpdateInput()
		{
			if (Input.GetMouseButtonDown(1))
			{
				if (!m_aiming)
				{
					m_aiming = true;
					
					m_weapon.Aim();
				}
			}	
			
			if (Input.GetMouseButtonUp(1))
			{
				if (m_aiming)
				{
					m_aiming = false;
					
					m_weapon.Lower(0f);
				}
			}
			
			if (m_aiming)
			{
				if (Input.GetMouseButtonDown(0))
				{
					m_weapon.Fire();
					
					m_fired = true;
					
					if (OnShotFired != null)
					{
						OnShotFired();
					}
				}
			}
		}
		#endregion
	}
}