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

public class GamePlay
{
	public int PlayState;

	public World World;

	public GamePlay()
	{
		PlayState = 0;
		ResetWorld(null);
	}

	public virtual void Update()
	{
		if (PlayState == 0)
		{
			World.Update();
		}
	}
	
	public virtual void ResetWorld(object info)
	{
		World = new World(ResetWorld);
	}
	
	public virtual void Draw()
	{
		if (PlayState == 0)
		{
			World.Draw(Vector2.Zero);
		}
	}
}