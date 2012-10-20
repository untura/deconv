using System;
using System.Drawing;

namespace ImageArray
{
	/// <summary>
	/// Класс, хранящий слои Y, U и V изображения.
	/// </summary>
	public class ImageYUV
	{
		double [,] y;
		double [,] u;
		double [,] v;

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

			y = new double[height, width];
			u = new double[height, width];
			v = new double[height, width];

			Color p;

			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					p = im.GetPixel(i, j);
					y[i, j] = ( 0.29900 * p.R + 0.58700 * p.G + 0.11400 * p.B) / 255.0;
					u[i, j] = (-0.14713 * p.R - 0.28886 * p.G + 0.43600 * p.B) / 255.0;
					v[i, j] = ( 0.61500 * p.R - 0.51499 * p.G - 0.10001 * p.B) / 255.0;
				}
			}
		}

		/// <summary>
		/// Чтение и запись значений каналов для заданного пикселя.
		/// </summary>
		/// <param name='i'>
		/// Координата i пикселя.
		/// </param>
		/// <param name='j'>
		/// Координата j пикселя.
		/// </param>
		/// <param name='channel'>
		/// Канал (Y, U или V).
		/// </param>
		public double this [int i, int j, ChannelYUV channel] {
			get {
				// FIXME Проверять координаты пикселя
				switch(channel) {
				case ChannelYUV.Y:
					return y[i, j];
				case ChannelYUV.U:
					return u[i, j];
				case ChannelYUV.V:
					return v[i, j];
				default:
					return 0;	// FIXME Генерировать исключение
				}
			}
			set {
				switch(channel) {
				case ChannelYUV.Y:
					y[i, j] = value;
					break;
				case ChannelYUV.U:
					u[i, j] = value;
					break;
				case ChannelYUV.V:
					v[i, j] = value;
					break;
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
				return y.GetLength (1);
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
				return y.GetLength (0);
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
					var Y = this[i, j, ChannelYUV.Y];
					var U = this[i, j, ChannelYUV.U];
					var V = this[i, j, ChannelYUV.V];

					int R = (int)Math.Round ((Y + 1.13983 * V) * 255);
					int G = (int)Math.Round ((Y - 0.39465 * U - 0.58060 * V) * 255);
					int B = (int)Math.Round ((Y + 2.03211 * U) * 255);

					im.SetPixel(i, j, Color.FromArgb(R, G, B));
				}
			}

			return im;
		}
	}
}