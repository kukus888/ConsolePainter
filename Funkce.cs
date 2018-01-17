using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsolePainter
{
	public class Funkce
	{
		public Funkce ()
		{
		}
		public void VykresliPlatno(string[,] platno, ConsoleColor[,] platnoBarvyBack, ConsoleColor[,] platnoBarvyFore,int offSetX, int offSetY){
			for (int x = 0; x <= platno.GetLength (0) - 1; x++) {
				for (int y = 0; y <= platno.GetLength (1) - 1; y++) {
					Console.SetCursorPosition (x+offSetX,y+offSetY);
					if (platno [x, y] == null) {
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write ("X");
					} else {
						Console.BackgroundColor = platnoBarvyBack[x,y];
						Console.ForegroundColor = platnoBarvyFore[x,y];
						Console.Write (platno [x, y]);
					}
				}
			}
			Console.ResetColor ();
		}
		public int Menu(string titulek,string[] moznosti){
			int vracecihodnota;
			int volba = 0;
			while (true) {
				Console.Clear ();
				Console.SetCursorPosition (2,1);
				Console.Write (titulek);
				for (int i = 0; i <= moznosti.GetLength (0) - 1; i++) {
					Console.SetCursorPosition (2,2+i);
					if (volba == i) {
						Console.Write ("> ");
					}
					Console.Write (moznosti[i]);
				}
				ConsoleKeyInfo vstup = Console.ReadKey ();
				if (vstup.Key == ConsoleKey.W) {
					volba--;
				}
				if (vstup.Key == ConsoleKey.UpArrow) {
					volba--;
				}
				if (vstup.Key == ConsoleKey.S) {
					volba++;
				}
				if (vstup.Key == ConsoleKey.DownArrow) {
					volba++;
				}
				if (vstup.Key == ConsoleKey.Enter) {
					vracecihodnota = volba;
					break;
				}
				if (volba <= -1) {
					volba = moznosti.GetLength (0)-1;
				}
				if (volba >= moznosti.GetLength (0)) {
					volba = 0;
				}
			}
			return vracecihodnota;
		}
		public void UlozMapu(string[,] platno, string soubor, ConsoleColor[,] BarvyBack, ConsoleColor[,] BarvyFore) {
			if (File.Exists (soubor)) {
				File.Delete (soubor);
			}
			StreamWriter mapa0 = new StreamWriter(soubor);
			mapa0.WriteLine (platno.GetLength(1));
			mapa0.WriteLine (platno.GetLength(0));
			for(int a = 0;a<= platno.GetLength(0)-1;a++){
				for(int b = 0;b<= platno.GetLength(1)-1;b++){
					if (platno [a, b] == null) {
						mapa0.Write ("null");
					} else {
						mapa0.Write (platno [a, b]);
					}
					mapa0.Write (',');
				}
				mapa0.WriteLine ();
			}
			for(int a = 0;a<= platno.GetLength(0)-1;a++){
				for(int b = 0;b<= platno.GetLength(1)-1;b++){
					mapa0.Write ((BarvyBack [a, b]).ToString());
					mapa0.Write (',');
				}
				mapa0.WriteLine ();
			}
			for(int a = 0;a<= platno.GetLength(0)-1;a++){
				for(int b = 0;b<= platno.GetLength(1)-1;b++){
					mapa0.Write ((BarvyFore [a, b]).ToString());
					mapa0.Write (',');
				}
				mapa0.WriteLine ();
			}
			mapa0.Close ();
		}
	}
}

