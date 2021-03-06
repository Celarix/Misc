﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SomeDungeonGame.Graphics;

namespace SomeDungeonGame.Entities
{
	public sealed class SolidTile : Tile
	{
		private StaticGraphicsObject graphics;

		public override int ID
		{
			get { return 1; }
		}

		public SolidTile(string graphicsPath)
		{
			this.GraphicsPath = graphicsPath;
		}

		public override void LoadContent()
		{
			this.graphics = new StaticGraphicsObject();
			this.graphics.Load(this.GraphicsPath);
		}

		public override void Update()
		{
		}

		public override void Draw()
		{
			this.graphics.Draw(this.Position, Color.White);
		}

		public override void UnloadContent()
		{
		}
	}
}
