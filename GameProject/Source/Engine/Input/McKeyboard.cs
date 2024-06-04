#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

#endregion

namespace GameProject;

public class McKeyboard
{
	public KeyboardState NewKeyboard, OldKeyboard;

	public List<McKey> PressedKeys = new List<McKey>(), PreviousPressedKeys = new List<McKey>();

	public McKeyboard()
	{
	}

	public virtual void Update()
	{
		NewKeyboard = Keyboard.GetState();

		GetPressedKeys();
	}

	public void UpdateOld()
	{
		OldKeyboard = NewKeyboard;

		PreviousPressedKeys = new List<McKey>();
		for (int i = 0; i < PressedKeys.Count; i++)
		{
			PreviousPressedKeys.Add(PressedKeys[i]);
		}
	}


	public bool GetPress(string key)
	{
		for (int i = 0; i < PressedKeys.Count; i++)
		{
			if (PressedKeys[i].Key == key)
			{
				return true;
			}
		}


		return false;
	}


	public virtual void GetPressedKeys()
	{
		bool found = false;

		PressedKeys.Clear();
		for (int i = 0; i < NewKeyboard.GetPressedKeys().Length; i++)
		{
			PressedKeys.Add(new McKey(NewKeyboard.GetPressedKeys()[i].ToString(), 1));
		}
	}

	public bool GetSinglePress(string key)
	{
		for (var i = 0; i < PressedKeys.Count; i++)
		{
			var isIn = false;

			for (var j = 0; j < PreviousPressedKeys.Count; j++)
			{
				if (PressedKeys[i].Key == PreviousPressedKeys[j].Key)
				{
					isIn = true;
					break;
				}
			}

			if (!isIn && (PressedKeys[i].Key == key || PressedKeys[i].Print == key))
			{
				return true;
			}
		}

		return false;
	}
}