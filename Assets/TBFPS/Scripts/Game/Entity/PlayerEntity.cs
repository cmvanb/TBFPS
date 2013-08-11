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
		
		#region inspector vars
		[SerializeField]
		private bool m_isLocalPlayer;
		public bool IsLocalPlayer { get { return m_isLocalPlayer; } }
		
		[SerializeField]
		private MouseLook m_mouseLookComponent;
		public MouseLook MouseLookComponent { get { return m_mouseLookComponent; } }
		
		[SerializeField]
		private PlayerMovement m_playerMovementComponent;
		public PlayerMovement PlayerMovementComponent { get { return m_playerMovementComponent; } }
		
		[SerializeField]
		private Transform m_cameraTransform;
		
		[SerializeField]
		private Transform m_playerModel;
		#endregion
		
		#region public vars
		private ActionsHUD m_localActionsHUD;
		public ActionsHUD LocalActionsHUD { get { return m_localActionsHUD; } }
		
		private int m_actionPoints;
		public int ActionPoints { get { return m_actionPoints; } set { m_actionPoints = value; } }
		#endregion
		
		#region private vars
		#endregion
		
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
				
				CameraManager.Instance.GuaranteeExists();
				
				if (CameraManager.Instance.GameCamera != null)
				{
					CameraManager.Instance.GameCamera.transform.parent = m_cameraTransform;
					CameraManager.Instance.GameCamera.transform.localPosition = Vector3.zero;
					CameraManager.Instance.GameCamera.transform.localRotation = Quaternion.identity;
				}
				else
				{
					DebugUtil.LogError("Could not find GameCamera");
				}
				
				m_mouseLookComponent.enabled = true;
				m_playerMovementComponent.enabled = false;
				
				LayerUtil.ChangeLayersRecursively(m_playerModel, "Player");
			}
			else
			{
				m_mouseLookComponent.enabled = false;
				m_playerMovementComponent.enabled = false;
			}
		}
		
		// public methods
		
		// private methods
	}
}