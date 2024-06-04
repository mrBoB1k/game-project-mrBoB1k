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

public class Basic2d
{
	public float Rot;

	public Vector2 Pos, Dims;
	public Texture2D Model;

	public Basic2d(string path, Vector2 position, Vector2 dims)
	{
		Pos = position;
		this.Dims = dims;

		Model = Globals.Сontent.Load<Texture2D>(path);
	}

	public virtual void Update(Vector2 offset)
	{
	}

	public virtual void Draw(Vector2 offset)
	{
		if (Model != null)
		{
			Globals.SpriteBatch.Draw(Model,
				new Rectangle((int)(Pos.X + offset.X), (int)(Pos.Y + offset.Y), (int)(Dims.X), (int)(Dims.Y)),
				null,
				Color.White,
				Rot,
				new Vector2(Model.Bounds.Width / 2, Model.Bounds.Height / 2),
				SpriteEffects.None,
				0);
		}
	}

	public virtual void Draw(Vector2 offset, Vector2 origin, Color color)
	{
		if (Model != null)
		{
			Globals.SpriteBatch.Draw(Model,
				new Rectangle((int)(Pos.X + offset.X), (int)(Pos.Y + offset.Y), (int)(Dims.X), (int)(Dims.Y)),
				null,
				color,
				Rot,
				new Vector2(origin.X, origin.Y),
				SpriteEffects.None,
				0);
		}
	}
}