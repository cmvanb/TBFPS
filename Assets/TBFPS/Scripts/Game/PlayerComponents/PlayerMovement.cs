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
	public class PlayerMovement : MonoBehaviour
	{
		#region events
		public delegate void MovementCompletedHandler();
		public event MovementCompletedHandler OnMovementCompleted;
		#endregion
		
		#region inspector vars
		[SerializeField]
		private Transform m_playerBody;
		
		[SerializeField]
		private CharacterController m_characterController;
		
		[SerializeField]
		private float m_maxSpeed;
		
		[SerializeField]
		private float m_acceleration;
		
		[SerializeField]
		private float m_deceleration;
		
		/// <summary>
		/// The maximum distance the player is allowed to move in the current action.
		/// </summary>
		[SerializeField]
		private float m_maxDistance;
		#endregion
		
		#region private vars
		private Vector3 m_inputVector;
		
		private Vector3 m_lastInputVector;
		
		private Vector3 m_movementVector;
		
		private Vector3 m_previousPosition;
		
		private float m_speed;
		
		/// <summary>
		/// The movement progress expressed as a value between 0f and 1f. When this reaches 1f the movement action is complete.
		/// </summary>
		private float m_movementProgress;
		
		private float m_distanceMoved;
		#endregion
		
		#region unity callbacks
		void OnEnable()
		{
			Reset();
		}
		
		void Update()
		{
			UpdateInput();
			
			UpdateSpeed();
			
			UpdateMovement();
			
			Move();
			
			UpdateMovementProgress();
		}
		#endregion
		
		#region private methods
		private void UpdateInput()
		{
			float inputX = Input.GetAxisRaw("Horizontal") * Time.timeScale;
			float inputZ = Input.GetAxisRaw("Vertical") * Time.timeScale;
			
			m_inputVector = new Vector3(inputX, 0f, inputZ);
			m_inputVector.Normalize();
			
			if (m_inputVector.sqrMagnitude > 0f)
			{
				m_lastInputVector = m_inputVector;
			}
		}
		
		private void UpdateSpeed()
		{
			// if input vector is bigger than 0f we are receiving movement input
			if (m_inputVector.sqrMagnitude > 0f)
			{
				m_speed = Mathf.MoveTowards(m_speed, m_maxSpeed, m_acceleration);			
			}
			else
			{
				m_speed = Mathf.MoveTowards(m_speed, 0f, m_deceleration);
			}
		}		
		
		private void UpdateMovement()
		{
			m_movementVector = m_playerBody.TransformDirection(m_lastInputVector) * m_speed * Time.deltaTime;
		}
		
		private void Move()
		{
			m_previousPosition = m_playerBody.position;
			
			m_characterController.Move(m_movementVector);
			
			m_distanceMoved += Vector3.Distance(m_previousPosition, m_playerBody.position);
		}
		
		private void UpdateMovementProgress()
		{
			m_movementProgress = m_distanceMoved / m_maxDistance;
			
			if (m_movementProgress > 1f)
			{
				if (OnMovementCompleted != null)
				{
					OnMovementCompleted();
				}
			}			
		}
		
		private void Reset()
		{
			m_previousPosition = m_playerBody.position;
			
			m_speed = 0f;
			
			m_movementProgress = 0f;
			
			m_distanceMoved = 0f;
		}
		#endregion
	}
}