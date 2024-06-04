﻿#region Includes

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

public class GameGlobals
{
	public static bool Paused = false;
	
	public static int Score = 0;

	public static PassObject PassProjectile, PassMob, PassSpawner, CheckScroll;
}