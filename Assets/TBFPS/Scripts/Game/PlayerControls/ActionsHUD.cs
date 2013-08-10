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
	public class ActionsHUD : MonoBehaviour
	{
		// events
		
		// inspector vars
		[SerializeField]
		private GameObject m_radialMenuElement;
	
		// public vars
		private PlayerEntity m_localPlayer;
		public PlayerEntity LocalPlayer { get { return m_localPlayer; } set { m_localPlayer = value; } }
		
		// private vars
		private bool m_HUDVisible;
		
		// constructor
		
		// singleton callbacks
		
		// unity callbacks
		void Awake()
		{
			HideHUD();
		}
		
		void Update()
		{
			if (!m_HUDVisible
				&& Input.GetMouseButtonDown(0))
			{
				ShowHUD();
			}
			
			if (m_HUDVisible
				&& Input.GetMouseButtonUp(0))
			{
				// did we select something? if so do something
				
				HideHUD();
			}
		}
		
		// public methods
		
		// private methods
		private void ShowHUD()
		{
			m_radialMenuElement.SetActive(true);
			
			if (m_localPlayer)
			{
				m_localPlayer.MouseLookComponent.enabled = false;
			}
			
			m_HUDVisible = true;
		}
		
		private void HideHUD()
		{
			m_radialMenuElement.SetActive(false);
			
			if (m_localPlayer)
			{
				m_localPlayer.MouseLookComponent.enabled = true;
			}
			
			m_HUDVisible = false;
		}
	}
}