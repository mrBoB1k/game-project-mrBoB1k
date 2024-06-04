#region Includes

using System;
using System.Collections.Generic;
using System.Globalization;
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

public delegate void PassObject(object i);

public delegate object PassObjectAndReturn(object i);

public class Globals
{
	public static int ScreenHeight, ScreenWidth;

	public static Random Rand = new Random();

	public static System.Globalization.CultureInfo Culture = new CultureInfo("ru-RU");
	
	public static ContentManager Сontent;
	public static SpriteBatch SpriteBatch;

	public static Effect NormalFlatEffect;
	
	public static McKeyboard Keyboard;
	public static McMouseControl Mouse;

	public static GameTime GameTime;

	public static float GetDistance(Vector2 position, Vector2 target)
	{
		return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
	}

	public static Vector2 RadialMovement(Vector2 focus, Vector2 pos, float speed)
	{
		float dist = Globals.GetDistance(pos, focus);

		if (dist <= speed)
		{
			return focus - pos;
		}
		else
		{
			return (focus - pos) * speed / dist;
		}
	}

	public static float RotateTowards(Vector2 position, Vector2 focus)
	{
		return (float)Math.Atan2(position.Y - focus.Y, position.X - focus.X) - MathHelper.PiOver2;
	}
}