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

public class Projectile2d : Basic2d
{
	public bool Done;
	public float Speed;
	public Vector2 Direction;
	public AttackableObject Owner;
	public McTimer Timer;

	public Projectile2d(string path, Vector2 position, Vector2 dims, AttackableObject owner, Vector2 target) : base(path, position,
		dims)
	{
		Done = false;
		Speed = 5.0f;
		Owner = owner;
		Direction = target - owner.Pos;
		Direction.Normalize();
		Rot = Globals.RotateTowards(position, target);
		Timer = new McTimer(1500);
	}

	public virtual void Update(Vector2 offset, List<AttackableObject> units)
	{
		Pos += Direction * Speed;

		Timer.UpdateTimer();

		if (Timer.Test())
		{
			Done = true;
		}

		if (HitSomething(units))
		{
			Done = true;
		}
	}

	public virtual bool HitSomething(List<AttackableObject> units)
	{
		for (int i = 0; i < units.Count; i++)
		{
			if (Owner.OwnerId != units[i].OwnerId && Globals.GetDistance(Pos, units[i].Pos) < units[i].HitDist)
			{
				units[i].GetHit(1);
				return true;
			}
		}

		return false;
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