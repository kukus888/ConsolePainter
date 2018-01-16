using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsolePainter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.CursorVisible = false;

			Funkce fce = new Funkce ();
			string[] HlMenuMoznosti = new string[]{
				"Nový..",
				"Načíst..",
				"Konec"
			};

			while(true){
				int HlMenu = fce.Menu ("ConsolePainter", HlMenuMoznosti);
				if (HlMenu == 0) {//Novy
					kreslit(null,null,null);
					Console.CursorVisible = false;
				}
				if (HlMenu == 1) {//nacist
					Console.WriteLine("WIP");
				}
				if (HlMenu == HlMenuMoznosti.GetLength(0)-1) {
					break;
				}
			}
		}
		public static void kreslit(string[,] platno, ConsoleColor[,] platnoBarvyBack, ConsoleColor[,] platnoBarvyFore){
			Funkce fce = new Funkce ();
			if (platno == null) {//NullPointerException
				platno = new string[32,16];
			}
			if (platnoBarvyFore == null) {//NullPointerException
				platnoBarvyFore = new ConsoleColor[32,16];
			}
			if (platnoBarvyBack == null) {//NullPointerException
				platnoBarvyBack = new ConsoleColor[32,16];
				for (int x = 0; x <= 15; x++) {
					for (int y = 0; y <= 15; y++) {
						platnoBarvyBack [x, y] = ConsoleColor.White;
					}
				}
			}
			Console.Clear ();
			Console.CursorVisible = true;
			bool WhKresli = true;
			int PlatnoX = 0;
			int PlatnoY = 0;
			int OffsetX = 1;
			int OffsetY = 1;
			ConsoleColor[] BufKresliBack = new ConsoleColor[]{
				ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue
			};
			ConsoleColor[] BufKresliFore = new ConsoleColor[]{
				ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue
			};
			string[] BufKresli = new string[]{
				" "," "," "
			};
			int VybranaBarva = 0;
			while (WhKresli) {
				fce.VykresliPlatno (platno,platnoBarvyBack,platnoBarvyFore,1,1);
				for (int a = 0; a <= 3; a++) {
					Console.SetCursorPosition (platno.GetLength(0)+2,a+1);
					Console.BackgroundColor = BufKresliBack[0];
					Console.Write ("{0}{0}{0}{0}{0}{0}",BufKresli[0]);
				}
				Console.SetCursorPosition (platno.GetLength(0)+2,1);
				if (BufKresliBack [0] == ConsoleColor.White) {
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write ("[J]");
				} else {
					Console.Write ("[J]");
				}
				for (int a = 0; a <= 3; a++) {
					Console.SetCursorPosition (platno.GetLength(0)+2,a+6);
					Console.BackgroundColor = BufKresliBack[1];
					Console.Write ("{0}{0}{0}{0}{0}{0}",BufKresli[1]);
				}
				Console.SetCursorPosition (platno.GetLength(0)+2,6);
				if (BufKresliBack [1] == ConsoleColor.White) {
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write ("[K]");
				} else {
					Console.Write ("[K]");
				}
				for (int a = 0; a <= 3; a++) {
					Console.SetCursorPosition (platno.GetLength(0)+2,a+11);
					Console.BackgroundColor = BufKresliBack[2];
					Console.Write ("{0}{0}{0}{0}{0}{0}",BufKresli[2]);
				}
				Console.SetCursorPosition (platno.GetLength(0)+2,11);
				if (BufKresliBack [2] == ConsoleColor.White) {
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write ("[L]");
				} else {
					Console.Write ("[L]");
				}
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition (1, platno.GetLength(1)+2);
				Console.Write ("[E] - Změníš barvu");
				Console.SetCursorPosition (1, platno.GetLength(1)+3);
				Console.Write ("[WASD] - pohyb po plátně");
				Console.SetCursorPosition (1, platno.GetLength(1)+4);
				Console.Write ("[Q] - Nástroje");
				Console.SetCursorPosition (1, platno.GetLength(1)+5);
				Console.Write ("[ESC] - Menu");
				Console.BackgroundColor = ConsoleColor.Black;
				Console.SetCursorPosition (PlatnoX+OffsetX,PlatnoY+OffsetY);
				ConsoleKeyInfo vstup = Console.ReadKey ();
				if (vstup.Key == ConsoleKey.H) {//delete
					platno[PlatnoX,PlatnoY] = null;
					platnoBarvyBack [PlatnoX, PlatnoY] = ConsoleColor.Black;
					platnoBarvyFore [PlatnoX, PlatnoY] = ConsoleColor.White;
				}
				if (vstup.Key == ConsoleKey.J) {
					platno[PlatnoX,PlatnoY] = BufKresli[0];
					platnoBarvyBack [PlatnoX, PlatnoY] = BufKresliBack[0];
					platnoBarvyFore [PlatnoX, PlatnoY] = BufKresliFore[0];
				}
				if (vstup.Key == ConsoleKey.K) {
					platno[PlatnoX,PlatnoY] = BufKresli[1];
					platnoBarvyBack [PlatnoX, PlatnoY] = BufKresliBack[1];
					platnoBarvyFore [PlatnoX, PlatnoY] = BufKresliBack[1];
				}
				if (vstup.Key == ConsoleKey.L) {
					platno[PlatnoX,PlatnoY] = BufKresli[2];
					platnoBarvyBack [PlatnoX, PlatnoY] = BufKresliBack[2];
					platnoBarvyFore [PlatnoX, PlatnoY] = BufKresliFore[2];
				}
				if (vstup.Key == ConsoleKey.Q) {//MENU NÁSTROJŮ
					Console.Clear ();
					Console.CursorVisible = false;
					string[] NastrMoznosti = new string[]{
						"Vylít plátno...","Zpět"
					};
					while (true) {
						int NastrVolba = fce.Menu ("Nástroje", NastrMoznosti);
						if (NastrVolba == 0) {//Vylit platno
							bool BufMenit = true;
							ConsoleColor[] barvy = new ConsoleColor[]{
								ConsoleColor.Black, ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.Blue, ConsoleColor.DarkCyan, ConsoleColor.Cyan, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow, ConsoleColor.Yellow
							};
							int MenitX = 0;
							int MenitY = 0;
							while (BufMenit) {
								Console.BackgroundColor = ConsoleColor.Black;
								Console.Clear ();
								for(int i = 0;i<= barvy.GetLength(0)-1;i++){
									Console.BackgroundColor = barvy[i];
									Console.ForegroundColor = ConsoleColor.White;
									Console.SetCursorPosition (i+1,1);
									Console.Write(" ");
									Console.SetCursorPosition (i+1,2);
									Console.Write("░");
									Console.SetCursorPosition (i+1,3);
									Console.Write("▒");
									Console.SetCursorPosition (i+1,4);
									Console.Write("▓");
								}
								Console.BackgroundColor = ConsoleColor.Black;
								Console.ForegroundColor = ConsoleColor.White;
								Console.SetCursorPosition (barvy.GetLength(0)+2,1);
								Console.Write ("Barva:");
								Console.SetCursorPosition (1,6);
								Console.Write ("Potvrdíš [ENTER]");
								Console.BackgroundColor = barvy[MenitX];
								Console.ForegroundColor = ConsoleColor.White;
								for (int a = 0; a <= 3; a++) {
									Console.SetCursorPosition (barvy.GetLength(0)+2,a+2);
									if(MenitY == 0){Console.Write ("      ");}
									if(MenitY == 1){Console.Write ("░░░░░░");}
									if(MenitY == 2){Console.Write ("▒▒▒▒▒▒");}
									if(MenitY == 3){Console.Write ("▓▓▓▓▓▓");}
								}
								Console.SetCursorPosition (MenitX+1,MenitY+1);
								ConsoleKeyInfo BufMenitVstup = Console.ReadKey ();
								if (BufMenitVstup.Key == ConsoleKey.Enter) {
									string buf = " ";
									if(MenitY == 0){buf = " ";}
									if(MenitY == 1){buf = "░";}
									if(MenitY == 2){buf = "▒";}
									if(MenitY == 3){buf = "▓";}
									for (int i = 0; i <= platno.GetLength (0)-1; i++) {
										for (int x = 0; x <= platno.GetLength (1)-1; x++) {
											platno[i,x] = buf;
											platnoBarvyBack[i,x] = barvy[MenitX];
											platnoBarvyFore[i,x] = ConsoleColor.White;
										}
									}
									BufMenit = false;
								}
								if (BufMenitVstup.Key == ConsoleKey.Escape) {
									BufMenit = false;
								}
								if (BufMenitVstup.Key == ConsoleKey.W || BufMenitVstup.Key == ConsoleKey.UpArrow) {
									MenitY--;
								}
								if (BufMenitVstup.Key == ConsoleKey.A || BufMenitVstup.Key == ConsoleKey.LeftArrow) {
									MenitX--;
								}
								if (BufMenitVstup.Key == ConsoleKey.S || BufMenitVstup.Key == ConsoleKey.DownArrow) {
									MenitY++;
								}
								if (BufMenitVstup.Key == ConsoleKey.D || BufMenitVstup.Key == ConsoleKey.RightArrow) {
									MenitX++;
								}
								if (MenitX <= -1) {
									MenitX++;
								}
								if (MenitX >= barvy.GetLength (0)) {
									MenitX--;
								}
								if (MenitY >= 5) {
									MenitY--;
								}
								if (MenitY <= -1) {
									MenitY++;
								}
							}
							Console.BackgroundColor = ConsoleColor.Black;
						}
						if (NastrVolba == NastrMoznosti.GetLength (0) - 1) {
							break;
						}
					}
					Console.Clear ();
					Console.CursorVisible = true;
				}
				if (vstup.Key == ConsoleKey.E) {
					bool BufMenit = true;
					ConsoleColor[] barvy = new ConsoleColor[]{
						ConsoleColor.Black, ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.Blue, ConsoleColor.DarkCyan, ConsoleColor.Cyan, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow, ConsoleColor.Yellow
					};
					int MenitX = 0;
					int MenitY = 0;
					while (BufMenit) {
						Console.BackgroundColor = ConsoleColor.Black;
						Console.Clear ();
						for(int i = 0;i<= barvy.GetLength(0)-1;i++){
							Console.BackgroundColor = barvy[i];
							Console.ForegroundColor = ConsoleColor.White;
							Console.SetCursorPosition (i+1,1);
							Console.Write(" ");
							Console.SetCursorPosition (i+1,2);
							Console.Write("░");
							Console.SetCursorPosition (i+1,3);
							Console.Write("▒");
							Console.SetCursorPosition (i+1,4);
							Console.Write("▓");
						}
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.White;
						Console.SetCursorPosition (barvy.GetLength(0)+2,1);
						Console.Write ("Barva:");
						Console.SetCursorPosition (1,6);
						Console.Write ("Měníš: ");
						if (VybranaBarva == 0) {
							Console.Write ("[J]");
						}
						if (VybranaBarva == 1) {
							Console.Write ("[K]");
						}
						if (VybranaBarva == 2) {
							Console.Write ("[L]");
						}
						Console.SetCursorPosition (1,7);
						Console.Write ("Změníš [TAB]");
						Console.BackgroundColor = barvy[MenitX];
						Console.ForegroundColor = ConsoleColor.White;
						for (int a = 0; a <= 3; a++) {
							Console.SetCursorPosition (barvy.GetLength(0)+2,a+2);
							if(MenitY == 0){Console.Write ("      ");}
							if(MenitY == 1){Console.Write ("░░░░░░");}
							if(MenitY == 2){Console.Write ("▒▒▒▒▒▒");}
							if(MenitY == 3){Console.Write ("▓▓▓▓▓▓");}
						}
						Console.SetCursorPosition (MenitX+1,MenitY+1);
						ConsoleKeyInfo BufMenitVstup = Console.ReadKey ();
						if (BufMenitVstup.Key == ConsoleKey.Enter) {
							if(MenitY == 0){BufKresli[VybranaBarva] = " ";}
							if(MenitY == 1){BufKresli[VybranaBarva] = "░";}
							if(MenitY == 2){BufKresli[VybranaBarva] = "▒";}
							if(MenitY == 3){BufKresli[VybranaBarva] = "▓";}
							BufKresliBack[VybranaBarva] = barvy[MenitX];
							BufKresliFore[VybranaBarva] = ConsoleColor.White;
							BufMenit = false;
						}
						if (BufMenitVstup.Key == ConsoleKey.Escape) {
							BufMenit = false;
						}
						if (BufMenitVstup.Key == ConsoleKey.Tab) {
							VybranaBarva++;
						}
						if (VybranaBarva >= 3) {
							VybranaBarva = 0;
						}
						if (BufMenitVstup.Key == ConsoleKey.W || BufMenitVstup.Key == ConsoleKey.UpArrow) {
							MenitY--;
						}
						if (BufMenitVstup.Key == ConsoleKey.A || BufMenitVstup.Key == ConsoleKey.LeftArrow) {
							MenitX--;
						}
						if (BufMenitVstup.Key == ConsoleKey.S || BufMenitVstup.Key == ConsoleKey.DownArrow) {
							MenitY++;
						}
						if (BufMenitVstup.Key == ConsoleKey.D || BufMenitVstup.Key == ConsoleKey.RightArrow) {
							MenitX++;
						}
						if (MenitX <= -1) {
							MenitX++;
						}
						if (MenitX >= barvy.GetLength (0)) {
							MenitX--;
						}
						if (MenitY >= 5) {
							MenitY--;
						}
						if (MenitY <= -1) {
							MenitY++;
						}
					}
				}
				if (vstup.Key == ConsoleKey.Escape) {//Otevrit menu
					bool EscKresli = true;
					Console.CursorVisible = false;
					while(EscKresli){
						string[] EscMoznosti = new string[]{
							"Zpět","Uložit","Konec"
						};
						int EscMoz = fce.Menu ("Menu",EscMoznosti);
						if (EscMoz == 0) {//zpet
							Console.Clear();
							EscKresli = false;
						}
						if (EscMoz == 1) {//ulozit
							Console.Clear ();
							string cesta = AppDomain.CurrentDomain.BaseDirectory;
							string[] soubory = Directory.GetFiles (cesta);
							int ulo = fce.Menu ("Uložení", soubory);
							fce.UlozMapu (platno, soubory [ulo]);
						}
						if (EscMoz == EscMoznosti.GetLength(0)-1) {
							WhKresli = false;
							EscKresli = false;
						}
					}
					Console.CursorVisible = true;
				}
				if (vstup.Key == ConsoleKey.W || vstup.Key == ConsoleKey.UpArrow) {
					PlatnoY--;
				}
				if (vstup.Key == ConsoleKey.A || vstup.Key == ConsoleKey.LeftArrow) {
					PlatnoX--;
				}
				if (vstup.Key == ConsoleKey.S || vstup.Key == ConsoleKey.DownArrow) {
					PlatnoY++;
				}
				if (vstup.Key == ConsoleKey.D || vstup.Key == ConsoleKey.RightArrow) {
					PlatnoX++;
				}
				if (PlatnoX <= -1) {
					PlatnoX++;
				}
				if (PlatnoX >= platno.GetLength (0)) {
					PlatnoX--;
				}
				if (PlatnoY >= platno.GetLength (1)) {
					PlatnoY--;
				}
				if (PlatnoY <= -1) {
					PlatnoY++;
				}
			}
		}
	}
}
