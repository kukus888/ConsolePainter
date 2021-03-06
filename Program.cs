﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

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
				"Vývojářské možnosti",
				"Konec"
			};

			while(true){
				int HlMenu = fce.Menu ("ConsolePainter", HlMenuMoznosti);
				if (HlMenu == 0) {//Novy
					kreslit(null,null,null);
					Console.CursorVisible = false;
				}
				if (HlMenu == 1) {//nacist
					int volbanacteni = 0;
					bool nacteni = true;
					while (nacteni) {
						Console.Clear ();
						Console.SetCursorPosition (2, 1);
						Console.WriteLine ("Vyber soubor k načtení:");
						string[] cestanac = Directory.GetFiles (AppDomain.CurrentDomain.BaseDirectory);
						for (int i = 0; i <= cestanac.GetLength (0) - 1; i++) {
							Console.SetCursorPosition (2, i + 2);
							if (i == volbanacteni) {
								Console.Write ("> ");
							}
							Console.WriteLine (cestanac [i]);
						}
						Console.CursorVisible = false;
						ConsoleKeyInfo vstupnacteni = Console.ReadKey ();
						if (vstupnacteni.Key == ConsoleKey.Enter) {
							StreamReader mapa1 = new StreamReader(cestanac[volbanacteni]);
							int sirkamapy1 = Int32.Parse(mapa1.ReadLine ());
							int vyskamapy1 = Int32.Parse(mapa1.ReadLine ());
							string[,] platno = new string[vyskamapy1,sirkamapy1];
							ConsoleColor[,] BarvyBack = new ConsoleColor[vyskamapy1,sirkamapy1];
							ConsoleColor[,] BarvyFore = new ConsoleColor[vyskamapy1,sirkamapy1];
							for (int x = 0; x <= vyskamapy1-1; x++) {
								string Lajna = mapa1.ReadLine ();
								if (Lajna == null) {
									break;
								}
								string[] rozdelenalajna = Lajna.Split (',');
								for (int i = 0; i <= rozdelenalajna.Length-2; i++) {
									if (rozdelenalajna.ElementAt (i).ToString () == "null") {
										platno [x, i] = null;
									} else {
										platno [x, i] = rozdelenalajna.ElementAt (i).ToString ();
									}
								}
							}
							for (int x = 0; x <= vyskamapy1-1; x++) {
								string Lajna = mapa1.ReadLine ();
								if (Lajna == null) {
									break;
								}
								string[] rozdelenalajna = Lajna.Split (',');
								for (int i = 0; i <= rozdelenalajna.Length-2; i++) {
									BarvyBack[x,i] = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), rozdelenalajna.ElementAt (i).ToString ());
								}
							}
							for (int x = 0; x <= vyskamapy1-1; x++) {
								string Lajna = mapa1.ReadLine ();
								if (Lajna == null) {
									break;
								}
								string[] rozdelenalajna = Lajna.Split (',');
								for (int i = 0; i <= rozdelenalajna.Length-2; i++) {
									BarvyFore[x,i] = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), rozdelenalajna.ElementAt (i).ToString ());
								}

							}
							mapa1.Close ();
							Console.Clear ();
							kreslit (platno, BarvyBack, BarvyFore);
							nacteni = false;
						}
						if (vstupnacteni.Key == ConsoleKey.W) {
							volbanacteni--;
						}
						if (vstupnacteni.Key == ConsoleKey.S) {
							volbanacteni++;
						}
						if (volbanacteni >= cestanac.GetLength (0)) {
							volbanacteni = 0;
						}
						if (volbanacteni <= -1) {
							volbanacteni = cestanac.GetLength (0) - 1;
						}
						if (vstupnacteni.Key == ConsoleKey.Escape) {
							nacteni = false;
							break;
						}
					}
				}
				if (HlMenu == HlMenuMoznosti.GetLength(0)-1) {
					break;
				}
				if (HlMenu == 2) {//Vyvojarske moznosti
					Console.ResetColor ();
					Console.Clear ();
					ConsoleColor[] barvy = new ConsoleColor[]{
						ConsoleColor.Black, ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.Blue, ConsoleColor.DarkCyan, ConsoleColor.Cyan, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow, ConsoleColor.Yellow
					};
					for (int i = 0; i <= barvy.GetLength (0) - 1; i++) {
						Console.BackgroundColor = barvy [i];
						for (int z = 0; z <= barvy.GetLength (0) - 1; z++) {
							Console.ForegroundColor = barvy[z];
							Console.SetCursorPosition (z,i);
							Console.Write (" ");
						}
					}
					Console.ReadKey ();
					for (int i = 0; i <= barvy.GetLength (0) - 1; i++) {
						Console.BackgroundColor = barvy [i];
						for (int z = 0; z <= barvy.GetLength (0) - 1; z++) {
							Console.ForegroundColor = barvy[z];
							Console.SetCursorPosition (z,i);
							Console.Write ("░");
						}
					}
					Console.ReadKey ();
					for (int i = 0; i <= barvy.GetLength (0) - 1; i++) {
						Console.BackgroundColor = barvy [i];
						for (int z = 0; z <= barvy.GetLength (0) - 1; z++) {
							Console.ForegroundColor = barvy[z];
							Console.SetCursorPosition (z,i);
							Console.Write ("▒");
						}
					}
					Console.ReadKey ();
					for (int i = 0; i <= barvy.GetLength (0) - 1; i++) {
						Console.BackgroundColor = barvy [i];
						for (int z = 0; z <= barvy.GetLength (0) - 1; z++) {
							Console.ForegroundColor = barvy[z];
							Console.SetCursorPosition (z,i);
							Console.Write ("▓");
						}
					}
					Console.ReadKey ();
					//SINE WAVE
					for (int X = 0; X <= 666; X++) {
						Console.SetCursorPosition (1 + X, Int32.Parse (Math.Round(Math.Sin (X)*3).ToString ()) + 8);
						Console.WriteLine ("X");
						Thread.Sleep (500);
					}
					Console.ReadKey ();
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
				for (int x = 0; x <= platnoBarvyBack.GetLength(0)-1; x++) {
					for (int y = 0; y <= platnoBarvyBack.GetLength(1)-1; y++) {
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
							/*bool BufMenit = true;
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
							}*/

							Barva vylit = VybratBarvu();
							for (int i = 0; i <= platno.GetLength (0)-1; i++) {
								for (int x = 0; x <= platno.GetLength (1)-1; x++) {
									platno[i,x] = vylit.znak;
									platnoBarvyBack[i,x] = vylit.BackgroundColor;
									platnoBarvyFore[i,x] = vylit.ForegroundColor;
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
							string[] vysvetlivkyUlozeni = new string[]{"[Enter] - Přepsat soubor","[N] - Nový soubor"};
							int volbaUlo = 0;
							while (true) {
								soubory = Directory.GetFiles (cesta);
								Console.Clear ();
								Console.SetCursorPosition (2,1);
								Console.Write ("Zvolte soubor k uložení:");
								for (int i = 0; i <= soubory.GetLength (0) - 1; i++) {
									Console.SetCursorPosition (2,2+i);
									if (volbaUlo == i) {
										Console.Write ("> ");
									}
									Console.Write (soubory[i]);
								}
								for (int a = 0; a <= vysvetlivkyUlozeni.GetLength (0) - 1; a++) {
									Console.SetCursorPosition (1,a+soubory.GetLength(0)+3);
									Console.Write (vysvetlivkyUlozeni[a]);
								}
								ConsoleKeyInfo vstupUloz = Console.ReadKey ();
								if (vstupUloz.Key == ConsoleKey.N) {//New file...
									Console.Clear();
									Console.SetCursorPosition (1,1);
									Console.Write ("Nový soubor");
									Console.SetCursorPosition (1,2);
									Console.Write ("Název: ");
									string newFileName = Console.ReadLine ();
									string newFileNamePlusPath = cesta + newFileName;
									if (Directory.Exists (newFileNamePlusPath) || File.Exists (newFileNamePlusPath)) {//already exists
										Console.Clear();
										Console.SetCursorPosition (1,1);
										Console.Write ("Soubor již existuje!");
										Console.SetCursorPosition (1,2);
										Console.Write ("Chcete soubor přepsat? Y/n");
										while (true) {
											Console.SetCursorPosition (1, 3);
											ConsoleKeyInfo vstupUlozExist = Console.ReadKey ();
											if (vstupUlozExist.Key == ConsoleKey.Y) {//overwrite file
												File.Delete (newFileNamePlusPath);
												fce.UlozMapu (platno, newFileNamePlusPath, platnoBarvyBack, platnoBarvyFore);
												break;
											}
											if (vstupUlozExist.Key == ConsoleKey.N) {
												break;
											}
										}
									} else { //doesnt exist
										fce.UlozMapu (platno, newFileNamePlusPath, platnoBarvyBack, platnoBarvyFore);
									}
								}
								if (vstupUloz.Key == ConsoleKey.W) {
									volbaUlo--;
								}
								if (vstupUloz.Key == ConsoleKey.UpArrow) {
									volbaUlo--;
								}
								if (vstupUloz.Key == ConsoleKey.S) {
									volbaUlo++;
								}
								if (vstupUloz.Key == ConsoleKey.DownArrow) {
									volbaUlo++;
								}
								if (vstupUloz.Key == ConsoleKey.Enter) {
									File.Delete (soubory [volbaUlo]);
									fce.UlozMapu (platno, soubory [volbaUlo],platnoBarvyBack,platnoBarvyFore);
									break;
								}
								if (volbaUlo <= -1) {
									volbaUlo = soubory.GetLength (0)-1;
								}
								if (volbaUlo >= soubory.GetLength (0)) {
									volbaUlo = 0;
								}
							}
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
		public class Barva{
			public ConsoleColor BackgroundColor{ get; set;}
			public ConsoleColor ForegroundColor{ get; set;}
			public string znak{ get; set;}
		}
		static public Barva VybratBarvu(){
			Barva vraceciBarva = new Barva ();
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
					vraceciBarva.BackgroundColor = barvy [MenitX];
					vraceciBarva.ForegroundColor = ConsoleColor.White;
					vraceciBarva.znak = buf;
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
			return vraceciBarva;
		}
	}
}
