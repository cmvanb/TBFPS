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
	public class ActionsHUD : MonoBehaviour
	{
		// events
		
		// inspector vars
		[SerializeField]
		private GameObject m_radialMenuElement;
		
		[SerializeField]
		private GameObject m_selectionArrowPivot;
		
		// constants
		private readonly float c_minMouseDistanceForSelection = Screen.height / 21f; // 50 pixels on a 1680x1050 res
	
		// public vars
		private PlayerEntity m_localPlayer;
		public PlayerEntity LocalPlayer { get { return m_localPlayer; } set { m_localPlayer = value; } }
		
		private int m_selectedActionIndex;
		public int SelectedActionIndex { get { return m_selectedActionIndex; } }
		
		// private vars
		private bool m_HUDActive;
		
		private Vector2 m_mouseCenterPoint;
		
		// constructor
		
		// singleton callbacks
		
		// unity callbacks
		void Awake()
		{
			m_selectedActionIndex = -1;
			
			HideHUD();
		}
		
		void Update()
		{
			if (!m_HUDActive
				&& Input.GetMouseButtonDown(0))
			{
				ShowHUD();
				
				m_mouseCenterPoint = Input.mousePosition;
			}
			
			if (m_HUDActive
				&& Input.GetMouseButtonUp(0))
			{
				// did we select something? if so do something
				
				HideHUD();
			}
			
			if (m_HUDActive)
			{
				CalculateSelection();
			}
		}
		
		// public methods
		
		// private methods
		private void CalculateSelection()
		{
			// if mouse distance from center point is bigger than x, calc angle and show arrow
			if (Vector2.Distance(m_mouseCenterPoint, Input.mousePosition) > c_minMouseDistanceForSelection)
			{
				// get angle
				float angle = MathUtil.AngleBetweenTwoPoints(m_mouseCenterPoint, Input.mousePosition) * Mathf.Rad2Deg;
				 
				if (Mathf.Abs(Mathf.DeltaAngle(angle, 90f)) < 60f)
				{
					m_selectedActionIndex = 0;
				}
				
				if (Mathf.Abs(Mathf.DeltaAngle(angle, 210f)) < 60f)
				{
					m_selectedActionIndex = 1;
				}
				
				if (Mathf.Abs(Mathf.DeltaAngle(angle, 330f)) < 60f)
				{
					m_selectedActionIndex = 2;
				}
			
				if (!m_selectionArrowPivot.activeSelf)
				{
					m_selectionArrowPivot.SetActive(true);
				}
				
				m_selectionArrowPivot.transform.eulerAngles = new Vector3(0f, 0f, angle - 90f);
			}
			else
			{
				if (m_selectionArrowPivot.activeSelf)
				{
					m_selectionArrowPivot.SetActive(false);
				}
				
				m_selectedActionIndex = -1;
			}
		}
		
		private void ShowHUD()
		{
			m_radialMenuElement.SetActive(true);
			
			if (m_localPlayer)
			{
				m_localPlayer.MouseLookComponent.enabled = false;
			}
			
			m_selectedActionIndex = -1;
			
			m_HUDActive = true;
		}
		
		private void HideHUD()
		{
			m_radialMenuElement.SetActive(false);
			m_selectionArrowPivot.SetActive(false);
			
			if (m_localPlayer)
			{
				m_localPlayer.MouseLookComponent.enabled = true;
			}
			
			m_HUDActive = false;
		}
	}
}