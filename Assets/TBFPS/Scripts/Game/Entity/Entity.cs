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
	public class Entity : MonoBehaviour
	{
		// events
		
		#region inspector vars
		[SerializeField]
		protected string m_name;
		public string Name { get { return m_name; } }
		#endregion
		
		#region private vars
		#endregion
		
		// constructor
		
		// singleton callbacks
		
		// unity callbacks
		
		// public methods
		
		// private methods
	}
}