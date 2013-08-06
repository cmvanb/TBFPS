/*
	Author	: Casper van Beuzekom
	Date	: 2013-08-06
	
	Copyright (c) Casper van Beuzekom
	All rights reserved.
	Do not distribute.
*/

using UnityEditor;
using Casper.Framework;

namespace Casper.TBFPS
{
	public class LevelDataAsset 
	{
		// public methods
		[MenuItem("Assets/Create/LevelData")]
		public static void CreateAsset()
		{
			ScriptableObjectUtil.CreateAsset<LevelData>();
		}
	}
}