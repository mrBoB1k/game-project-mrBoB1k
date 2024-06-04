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

public class QuantityDisplayBar
{
	public int Border;
	public Basic2d Bar, BarBKG;
	public Color Color;

	public QuantityDisplayBar(Vector2 dims, int border, Color color)
	{
		Border = border;
		Color = color;

		Bar = new Basic2d("solid", new Vector2(0, 0), new Vector2(dims.X - Border * 2, dims.Y - Border * 2));
		BarBKG = new Basic2d("shade", new Vector2(0, 0), new Vector2(dims.X, dims.Y));
	}

	public virtual void Update(float current, float max)
	{
		Bar.Dims = new Vector2((BarBKG.Dims.X - Border * 2) * (current / max), Bar.Dims.Y);
	}

	public virtual void Draw(Vector2 offset)
	{
		Globals.NormalFlatEffect.Parameters["xSize"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["ySize"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["xDraw"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["yDraw"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["filterColor"].SetValue(Color.Black.ToVector4());
		Globals.NormalFlatEffect.CurrentTechnique.Passes[0].Apply();
		
		BarBKG.Draw(offset, new Vector2(0, 0), Color.Black);
		
		Globals.NormalFlatEffect.Parameters["filterColor"].SetValue(Color.ToVector4());
		Globals.NormalFlatEffect.CurrentTechnique.Passes[0].Apply();
		
		Bar.Draw(offset + new Vector2(Border, Border), new Vector2(0, 0), Color);
	}
}