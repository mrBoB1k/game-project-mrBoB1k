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

public class Hero : Unit
{
	private int _weapon = 1;

	public Hero(string path, Vector2 position, Vector2 dims, int ownerId) : base(path, position, dims, ownerId)
	{
		Speed = 2;
		Health = 5;
		HealthMax = Health;
	}

	public override void Update(Vector2 offset)
	{
		if (Globals.Keyboard.GetPress("A"))
		{
			Pos = new Vector2(Pos.X - Speed, Pos.Y);
		}

		if (Globals.Keyboard.GetPress("D"))
		{
			Pos = new Vector2(Pos.X + Speed, Pos.Y);
		}

		if (Globals.Keyboard.GetPress("W"))
		{
			Pos = new Vector2(Pos.X, Pos.Y - Speed);
		}

		if (Globals.Keyboard.GetPress("S"))
		{
			Pos = new Vector2(Pos.X, Pos.Y + Speed);
		}

		if (Globals.Keyboard.GetSinglePress("D1"))
		{
			_weapon = 1;
		}

		if (Globals.Keyboard.GetSinglePress("D2"))
		{
			_weapon = 2;
		}

		GameGlobals.CheckScroll(Pos);

		Rot = Globals.RotateTowards(Pos,
			new Vector2(Globals.Mouse.NewMousePos.X, Globals.Mouse.NewMousePos.Y) - offset);

		if (Globals.Mouse.LeftClick())
		{
			if (_weapon == 1)
				GameGlobals.PassProjectile(new Fireball(new Vector2(Pos.X, Pos.Y), this,
					new Vector2(Globals.Mouse.NewMousePos.X, Globals.Mouse.NewMousePos.Y) - offset));
			if (_weapon == 2)
				GameGlobals.PassProjectile(new Arrow(new Vector2(Pos.X, Pos.Y), this,
					new Vector2(Globals.Mouse.NewMousePos.X, Globals.Mouse.NewMousePos.Y) - offset));
		}

		base.Update(offset);
	}

	public override void Draw(Vector2 offset)
	{
		base.Draw(offset);
	}
}