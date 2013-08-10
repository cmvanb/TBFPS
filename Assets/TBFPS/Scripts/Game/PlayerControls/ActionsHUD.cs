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
	
		// public vars
		
		// private vars
		private bool m_HUDVisible;
		
		// constructor
		
		// singleton callbacks
		
		// unity callbacks
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
			m_HUDVisible = true;
		}
		
		private void HideHUD()
		{
			m_HUDVisible = false;
		}
	}
}