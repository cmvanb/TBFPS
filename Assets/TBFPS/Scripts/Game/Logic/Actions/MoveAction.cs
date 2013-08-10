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
	public class MoveAction : Action
	{
		// events
		
		// inspector vars
	
		// public vars
		
		// private vars
		
		// constructor
		
		// singleton callbacks
		
		// unity callbacks
		
		// public methods
		public override void Start()
		{
			DebugUtil.Log("Started move action");
		}
		
		public override void Update()
		{
		}
				
		public override void Finish()
		{
			DebugUtil.Log("Finished move action");
		}
		
		// private methods
	}
}