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
		/// из экземпляра класса <see cref="System.Drawing.Image"/>.
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
	}
}