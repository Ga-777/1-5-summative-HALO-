using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace private_1_5_summative_HALO
{

	public class Bullets
	{
		public Texture2D texture { get; set; }
		public Vector2 position { get; set; }
		public Vector2 velocity { get; set; }
		public bool isActive { get; set; }
		public Texture2D BulletTexture { get; }
		public Rectangle Rectangle { get; }

		public float speed = 10f;
		public Bullets(Texture2D texture, Vector2 position, Vector2 velocity)
		{
			texture = texture;
			position = position;
			velocity = velocity;
			isActive = true;

		}

		public Bullets(Texture2D bulletTexture, Rectangle rectangle)
		{
			BulletTexture = bulletTexture;
			Rectangle = rectangle;
		}

		public Bullets(Texture2D bulletTexture)
		{
			BulletTexture = bulletTexture;
		}

		public void Update()
		{
			position += velocity * speed;
			if (position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600)
			{
				isActive = false;
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}


	}
}
