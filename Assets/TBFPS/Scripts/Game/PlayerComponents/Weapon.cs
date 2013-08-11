/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-11
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEngine;
using System.Collections.Generic;

namespace Casper.TBFPS
{
	public class Weapon : MonoBehaviour
	{
		#region events
		#endregion
		
		#region inspector vars
		[SerializeField]
		private GameObject m_weaponObject;
		
		[SerializeField]
		private Vector3 m_loweredPosition;
		
		[SerializeField]
		private Vector3 m_loweredEulerAngles;
		
		[SerializeField]
		private Vector3 m_aimedPosition;
		
		[SerializeField]
		private Vector3 m_aimedEulerAngles;
		
		[SerializeField]
		private Vector3 m_firedPosition;
		
		[SerializeField]
		private Vector3 m_firedEulerAngles;
		
		[SerializeField]
		private float m_timeToLower;
		
		[SerializeField]
		private float m_timeToAim;
		
		[SerializeField]
		private float m_timeToFire;
		
		[SerializeField]
		private GameObject m_bulletPrefab;
		
		[SerializeField]
		private GameObject m_muzzleFlashPrefab;
		#endregion
	
		#region public vars
		#endregion
		
		#region private vars
		#endregion
		
		#region constructor
		#endregion
		
		#region singleton callbacks
		#endregion
		
		#region unity callbacks
		#endregion
		
		#region public methods
		public void Lower(float delay)
		{
			iTween.MoveTo(m_weaponObject, iTween.Hash("position", m_loweredPosition, "time", m_timeToLower, "islocal", true, "delay", delay));
			iTween.RotateTo(m_weaponObject, iTween.Hash("rotation", m_loweredEulerAngles, "time", m_timeToLower, "islocal", true, "delay", delay));
		}
		
		public void Aim()
		{
			iTween.MoveTo(m_weaponObject, iTween.Hash("position", m_aimedPosition, "time", m_timeToAim, "islocal", true));
			iTween.RotateTo(m_weaponObject, iTween.Hash("rotation", m_aimedEulerAngles, "time", m_timeToAim, "islocal", true));
		}
		
		public void Fire()
		{
			// recoil animation
			iTween.MoveTo(m_weaponObject, iTween.Hash("position", m_firedPosition, "time", m_timeToFire, "islocal", true));
			iTween.RotateTo(m_weaponObject, iTween.Hash("rotation", m_firedEulerAngles, "time", m_timeToFire, "islocal", true));
			
			// return to aim animation
			iTween.MoveTo(m_weaponObject, iTween.Hash("position", m_aimedPosition, "time", m_timeToAim, "islocal", true, "delay", m_timeToFire));
			iTween.RotateTo(m_weaponObject, iTween.Hash("rotation", m_aimedEulerAngles, "time", m_timeToAim, "islocal", true, "delay", m_timeToFire));
			
			// instantiate muzzle flash
			GameObject muzzleFlash = Object.Instantiate(m_muzzleFlashPrefab) as GameObject;
			muzzleFlash.transform.position = m_weaponObject.transform.position;
			muzzleFlash.transform.rotation = m_weaponObject.transform.rotation;
			muzzleFlash.transform.Translate(muzzleFlash.transform.forward * 10f);
			
			Debug.DrawLine(m_weaponObject.transform.position, muzzleFlash.transform.position, Color.yellow);
			
			// instantiate bullet at muzzle
			GameObject bullet = Object.Instantiate(m_bulletPrefab) as GameObject;
			bullet.transform.position = m_weaponObject.transform.position;
			bullet.transform.rotation = m_weaponObject.transform.rotation;			
		}
		#endregion
		
		#region private methods
		#endregion
	}
}