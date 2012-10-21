using System;
using System.Drawing;

namespace ImageArray
{
	/// <summary>
	/// Класс, хранящий слои Y, U и V изображения в
	/// виде двумерных массивов.
	/// </summary>
	public class ImageYUV
	{
		double [,] _y;
		double [,] _u;
		double [,] _v;

		/// <summary>
		/// Яркостный канал изображения.
		/// </summary>
		/// <value>
		/// Канал Y.
		/// </value>
		public double[,] Y {
			get {
				return _y;
			}
		}

		/// <summary>
		/// Хроматический канал изображения (U).
		/// </summary>
		/// <value>
		/// Канал U.
		/// </value>
		public double[,] U {
			get {
				return _u;
			}
		}

		/// <summary>
		/// Хроматический канал изображения (V).
		/// </summary>
		/// <value>
		/// Канал V.
		/// </value>
		public double[,] V {
			get {
				return _v;
			}
		}

		/// <summary>
		/// Создаёт новый экземпляр класса <see cref="ImageArray.ImageYUV"/>
		/// из экземпляра класса <see cref="System.Drawing.Bitmap"/>.
		/// </summary>
		/// <param name='im'>
		/// Исходное изображение.
		/// </param>
		public ImageYUV (Bitmap im)
		{
			int height = im.Height;
			int width  = im.Width;

			_y = new double[height, width];
			_u = new double[height, width];
			_v = new double[height, width];

			Color p;

			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					p = im.GetPixel(i, j);
					//TODO Проверить нормализацию хроматических компонент
					_y[i, j] = ( 0.29900 * p.R + 0.58700 * p.G + 0.11400 * p.B) / 255.0;
					_u[i, j] = (-0.14713 * p.R - 0.28886 * p.G + 0.43600 * p.B) / 255.0;
					_v[i, j] = ( 0.61500 * p.R - 0.51499 * p.G - 0.10001 * p.B) / 255.0;
				}
			}
		}

		/// <summary>
		/// Возвращает ширину изображения.
		/// </summary>
		/// <value>
		/// Ширина.
		/// </value>
		public int Width {
			get {
				return _y.GetLength (1);
			}
		}

		/// <summary>
		/// Возвращает высоту изображения.
		/// </summary>
		/// <value>
		/// Высота.
		/// </value>
		public int Height {
			get {
				return _y.GetLength (0);
			}
		}

		/// <summary>
		/// Приведение к типу <see cref="System.Drawing.Bitmap"/>.
		/// </summary>
		/// <returns>
		/// Экземпляр класса <see cref="System.Drawing.Bitmap"/>.
		/// </returns>
		public Bitmap ToBitmap()
		{
			Bitmap im = new Bitmap(Width, Height);

			for (int i = 0; i < Height; i++) {
				for (int j = 0; j < Width; j++) {

					//TODO Проверить нормализацию хроматических компонент
					int R = (int)Math.Round ((Y[i, j]                     + 1.13983 * V[i, j]) * 255);
					int G = (int)Math.Round ((Y[i, j] - 0.39465 * U[i, j] - 0.58060 * V[i, j]) * 255);
					int B = (int)Math.Round ((Y[i, j] + 2.03211 * U[i, j]                    ) * 255);

					im.SetPixel(i, j, Color.FromArgb(R, G, B));
				}
			}

			return im;
		}
	}
}