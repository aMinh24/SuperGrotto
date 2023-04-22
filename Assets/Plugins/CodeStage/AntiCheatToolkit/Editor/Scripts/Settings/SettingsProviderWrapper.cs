﻿#region copyright
// ---------------------------------------------------------------
//  Copyright (C) Dmitriy Yukhanov - focus [https://codestage.net]
// ---------------------------------------------------------------
#endregion

namespace CodeStage.AntiCheat.EditorCode
{
	using System.Collections.Generic;
	using UnityEditor;

	internal static class SettingsProviderWrapper
	{
		[SettingsProvider]
		public static SettingsProvider CreateMyCustomSettingsProvider()
		{
			var provider = new SettingsProvider(ACTkEditorConstants.SettingsProviderPath, SettingsScope.Project)
			{
				label = "Anti-Cheat Toolkit",
				guiHandler = searchContext =>
				{
					SettingsGUI.OnGUI();
				},

				keywords = new HashSet<string>(new[] {"focus", "codestage", "Anti", "Cheat", "Toolkit", "Injection", "Hash", "Wall", "Hack", "ACTk" })
			};

			return provider;
		}
	}
}