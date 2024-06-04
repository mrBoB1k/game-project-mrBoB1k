#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

#endregion

namespace GameProject;

public class User : Player
{
	public User(int id, XElement data) : base(id, data)
	{
		// Hero = new Hero("Player", new Vector2(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2),
		// 	new Vector2(64, 112), id);

		// Buildings.Add(new Tower(new Vector2(Hero.Pos.X, Hero.Pos.Y*1.9f), id));
	}

	public override void Update(Player enemy, Vector2 offset)
	{
		base.Update(enemy, offset);
	}
}