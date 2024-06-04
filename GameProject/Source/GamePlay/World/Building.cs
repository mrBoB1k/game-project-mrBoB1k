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

public class Building : AttackableObject
{
	public Building(string path, Vector2 position, Vector2 dims, int ownerId) : base(path, position, dims, ownerId)
	{
	}

	public virtual void Update(Vector2 offset, Player enemy)
	{
		base.Update(offset);
	}

	public override void Draw(Vector2 offset)
	{
		Globals.NormalFlatEffect.Parameters["xSize"].SetValue((float)Model.Bounds.Width);
		Globals.NormalFlatEffect.Parameters["ySize"].SetValue((float)Model.Bounds.Height);
		Globals.NormalFlatEffect.Parameters["xDraw"].SetValue((float)((int)Dims.X));
		Globals.NormalFlatEffect.Parameters["yDraw"].SetValue((float)((int)Dims.Y));
		Globals.NormalFlatEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
		Globals.NormalFlatEffect.CurrentTechnique.Passes[0].Apply();
		
		base.Draw(offset);
	}
}