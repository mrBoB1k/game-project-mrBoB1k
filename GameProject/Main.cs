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

public class Main : Game
{
	private GraphicsDeviceManager _graphics;
	// private SpriteBatch _spriteBatch;

	private GamePlay _gamePlay;

	private Basic2d _cursor;

	public Main()
	{
		_graphics = new GraphicsDeviceManager(this);
		// _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
		// _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
		// _graphics.IsFullScreen = true;

		Content.RootDirectory = "Content";
	}

	protected override void Initialize()
	{
		// TODO: Add your initialization logic here
		// Globals.ScreenWidth = 1200;
		// Globals.ScreenHeight = 800;
		Globals.ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
		Globals.ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

		_graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
		_graphics.PreferredBackBufferHeight = Globals.ScreenHeight;

		_graphics.IsFullScreen = true;

		_graphics.ApplyChanges();

		base.Initialize();
	}

	protected override void LoadContent()
	{
		// TODO: use this.Content to load your game content here
		Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
		Globals.Сontent = this.Content;

		_cursor = new Basic2d("CursorArrow", new Vector2(0, 0), new Vector2(24, 24));

		Globals.NormalFlatEffect = Globals.Сontent.Load<Effect>("Effects\\NormalFlat");
		
		Globals.Keyboard = new McKeyboard();
		Globals.Mouse = new McMouseControl();

		_gamePlay = new GamePlay();
	}

	protected override void Update(GameTime gameTime)
	{
		// if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
		//     Keyboard.GetState().IsKeyDown(Keys.Escape))
		// 	Exit();
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
		   (Keyboard.GetState().IsKeyDown(Keys.Tab) && GameGlobals.Paused))
			Exit();
		
		Globals.GameTime = gameTime;
		Globals.Keyboard.Update();
		Globals.Mouse.Update();

		_gamePlay.Update();

		Globals.Keyboard.UpdateOld();
		Globals.Mouse.UpdateOld();

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);
		// TODO: Add your drawing code here

		Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

		_gamePlay.Draw();

		Globals.NormalFlatEffect.Parameters["xSize"].SetValue((float)_cursor.Model.Bounds.Width);
		Globals.NormalFlatEffect.Parameters["ySize"].SetValue((float)_cursor.Model.Bounds.Height);
		Globals.NormalFlatEffect.Parameters["xDraw"].SetValue((float)((int)_cursor.Dims.X));
		Globals.NormalFlatEffect.Parameters["yDraw"].SetValue((float)((int)_cursor.Dims.Y));
		Globals.NormalFlatEffect.Parameters["filterColor"].SetValue(Color.Red.ToVector4());
		Globals.NormalFlatEffect.CurrentTechnique.Passes[0].Apply();
		
		_cursor.Draw(new Vector2(Globals.Mouse.NewMousePos.X, Globals.Mouse.NewMousePos.Y), new Vector2(0, 0),
			Color.Red);

		Globals.SpriteBatch.End();

		base.Draw(gameTime);
	}
}