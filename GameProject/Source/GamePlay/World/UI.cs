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
using MonoGame.Extended.Content;

#endregion

namespace GameProject;

public class UI
{
	public Basic2d PauseOverlay;

	public SpriteFont FontArial12;
	public SpriteFont FontCaveat36;

	public QuantityDisplayBar HealthBar;

	public UI()
	{
		PauseOverlay = new Basic2d("Pause", new Vector2(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2),
			new Vector2(300, 300));
		FontArial12 = Globals.Сontent.Load<SpriteFont>("Arial");
		FontCaveat36 = Globals.Сontent.Load<SpriteFont>("Caveat");
		HealthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
	}

	public void Update(World world)
	{
		HealthBar.Update(world.User.Hero.Health, world.User.Hero.HealthMax);
	}

	public void Draw(World world)
	{
		Globals.NormalFlatEffect.Parameters["xSize"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["ySize"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["xDraw"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["yDraw"].SetValue(1.0f);
		Globals.NormalFlatEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
		Globals.NormalFlatEffect.CurrentTechnique.Passes[0].Apply();

		var tempString = $"Score = {GameGlobals.Score}";
		Vector2 strDim = FontArial12.MeasureString(tempString);
		Globals.SpriteBatch.DrawString(FontArial12, tempString,
			new Vector2(Globals.ScreenWidth / 2 - strDim.X / 2, Globals.ScreenHeight - 40), Color.Black);

		if (world.User.Hero.Dead || world.User.Buildings.Count <= 0)
		{
			tempString = "Press Enter to Restart!";
			strDim = FontCaveat36.MeasureString(tempString);
			Globals.SpriteBatch.DrawString(FontCaveat36, tempString,
				new Vector2(Globals.ScreenWidth / 2 - strDim.X / 2, Globals.ScreenHeight / 2), Color.Black);
		}

		HealthBar.Draw(new Vector2(20, Globals.ScreenHeight - 20));

		if (GameGlobals.Paused)
		{
			PauseOverlay.Draw(Vector2.Zero);
		}
	}
}