using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;


public class Efeitos	{


	public Bitmap gride(Bitmap tempBm){

		Bitmap bm = new Bitmap(tempBm);


		Color c = new Color();
		c = Color.FromArgb(0,0,0);


		for (int i = 0; i < bm.Width; i+=4){

			for (int j = 0; j < bm.Height; j+=4){

				bm.SetPixel(i,j,c);
			}

		}			

		return bm;


	}

	public Bitmap vermelho(Bitmap tempBm){

		Bitmap bm = new Bitmap(tempBm);
		Color colorPx ;

		for (int i = 0; i < bm.Width; i++){

			for (int j = 0; j < bm.Height; j++){
				
				colorPx = bm.GetPixel(i,j);
				int pixelR = 0;
				int pixelG = 0;
				int pixelB = 0;

				pixelR = colorPx.R;
				pixelG = colorPx.G - 255;
				pixelB = colorPx.B - 255;

				pixelR = Math.Max(pixelR, 0);
				pixelR = Math.Min(255, pixelR);


		
				pixelG = Math.Max(pixelG, 0);
				pixelG = Math.Min(255, pixelG);

			
				pixelB = Math.Max(pixelB, 0);
				pixelB = Math.Min(255, pixelB);			


				bm.SetPixel(i,j,Color.FromArgb((byte)pixelR, (byte)pixelG, (byte)pixelB));
			}

		}			

		return bm;

	}

	public Bitmap verde(Bitmap tempBm){

		Bitmap bm = new Bitmap(tempBm);
		Color colorPx ;

		for (int i = 0; i < bm.Width; i++){

			for (int j = 0; j < bm.Height; j++){

				colorPx = bm.GetPixel(i,j);
				int pixelR = 0;
				int pixelG = 0;
				int pixelB = 0;

				pixelR = colorPx.R - 255;
				pixelG = colorPx.G ;
				pixelB = colorPx.B - 255;

				pixelR = Math.Max(pixelR, 0);
				pixelR = Math.Min(255, pixelR);


				pixelG = Math.Max(pixelG, 0);
				pixelG = Math.Min(255, pixelG);

				pixelB = Math.Max(pixelB, 0);
				pixelB = Math.Min(255, pixelB);					

				bm.SetPixel(i,j,Color.FromArgb((byte)pixelR, (byte)pixelG, (byte)pixelB));
			}

		}			

		return bm;


	}

	public Bitmap azul(Bitmap tempBm){

		Bitmap bm = new Bitmap(tempBm);
		Color colorPx ;

		for (int i = 0; i < bm.Width; i++){

			for (int j = 0; j < bm.Height; j++){

				colorPx = bm.GetPixel(i,j);
				int pixelR = 0;
				int pixelG = 0;
				int pixelB = 0;

				pixelR = colorPx.R - 255;
				pixelG = colorPx.G - 255;
				pixelB = colorPx.B;

				pixelR = Math.Max(pixelR, 0);
				pixelR = Math.Min(255, pixelR);

				pixelG = Math.Max(pixelG, 0);
				pixelG = Math.Min(255, pixelG);

				pixelB = Math.Max(pixelB, 0);
				pixelB = Math.Min(255, pixelB);					

				bm.SetPixel(i,j,Color.FromArgb((byte)pixelR, (byte)pixelG, (byte)pixelB));
			}

		}			

		return bm;


	}



public Bitmap escalaDeCinza(Bitmap tempBm){

		Bitmap bm = new Bitmap(tempBm);

		for (int x = 0; x < bm.Width; x++)
        {
            for (int y = 0; y < bm.Height; y++)
            {
                // Obtém o pixel na posição (x, y)
                Color pixel = bm.GetPixel(x, y);

                // Calcula o valor médio dos componentes de cor (vermelho, verde, azul)
                int average = (pixel.R + pixel.G + pixel.B) / 3;

                // Define a cor do pixel na nova imagem como tons de cinza usando o valor médio calculado
                Color grayScalePixel = Color.FromArgb(average, average, average);
                bm.SetPixel(x, y, grayScalePixel);
            }
        }

        return bm;


	}



public Bitmap pretoOuBranco(Bitmap tempBm, int threshold){

		Bitmap bm = new Bitmap(tempBm);
		

		for (int x = 0; x < bm.Width; x++)
        {
            for (int y = 0; y < bm.Height; y++)
            {
                // Obtém o pixel na posição (x, y)
                Color pixel = bm.GetPixel(x, y);

                // Calcula o valor médio dos componentes de cor (vermelho, verde, azul)
                int average = (pixel.R + pixel.G + pixel.B) / 3;

                // Define a cor do pixel na nova imagem como tons de cinza usando o valor médio calculado
                Color binaryPixel;
                if (average < threshold)
                {
                    binaryPixel = Color.Black;
                }
                else
                {
                    binaryPixel = Color.White;
                }

                bm.SetPixel(x, y, binaryPixel);
            }
        }

        return bm;


	}

    public Bitmap apenasRosa(Bitmap tempBm, int threshold)
    {
        Bitmap bm = new Bitmap(tempBm);

        Color hotPinkColor = Color.FromArgb(255, 0, 255); // Define a cor rosa choque

        for (int x = 0; x < bm.Width; x++)
        {
            for (int y = 0; y < bm.Height; y++)
            {
                Color pixel = bm.GetPixel(x, y);
                int average = (pixel.R + pixel.G + pixel.B) / 3;

                if (average < threshold)
                {
                    bm.SetPixel(x, y, hotPinkColor);
                }
            }
        }

        return bm;
    }

    public Bitmap pintarFocinho(Bitmap tempBm){

        Bitmap bm = new Bitmap(tempBm);

        // Definir o tamanho do quadrante (largura e altura)
        int quadrantWidth = bm.Width / 4;
        int quadrantHeight = bm.Height / 4;

        int targetQuadrantRow = 2; // Linha 2 (índice 1)
        int targetQuadrantCol = 2; // Coluna 3 (índice 2)

        int minX = targetQuadrantCol * quadrantWidth;
        int minY = targetQuadrantRow * quadrantHeight;
        int maxX = minX + quadrantWidth;
        int maxY = minY + quadrantHeight;

        Bitmap quadrant = new Bitmap(quadrantWidth, quadrantHeight);
        for (int x = minX; x < maxX; x++)
        {
            for (int y = minY; y < maxY; y++)
            {
                Color pixel = bm.GetPixel(x, y);
                quadrant.SetPixel(x - minX, y - minY, pixel);
            }
        }

        // Aplicar a função pretoOuBranco ao quadrante 12
        Bitmap modifiedQuadrant = apenasRosa(quadrant,3);

        // Copiar o quadrante modificado de volta para a imagem original
        for (int x = minX; x < maxX; x++)
        {
            for (int y = minY; y < maxY; y++)
            {
                Color pixel = modifiedQuadrant.GetPixel(x - minX, y - minY);
                bm.SetPixel(x, y, pixel);
            }
        }
        return bm;

    }
}



