using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Queens
{
	internal class Program
	{
		static void DrawBoard(List<string> positions)
		{
			int thisRowQueenPosition;
			int posNum;
			int column;

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"\n Total number of possible positions: {positions.Count}\n\n");
			Console.OutputEncoding = Encoding.Unicode;
			Console.CursorVisible = false;

			for (posNum = 0; posNum < positions.Count;)
			{
				Console.SetCursorPosition(0, 4);

				for (int row = 1; row <= 8; row++)
				{
					Console.ResetColor();
					Console.Write("       ");

					thisRowQueenPosition = positions[posNum].IndexOf($"{row}") + 1;

					for (column = 1; column <= thisRowQueenPosition - 1; column++)
					{
						Console.BackgroundColor = (column % 2 == row % 2) ? ConsoleColor.Gray : ConsoleColor.DarkGray;
						Console.Write("   ");
					}

					Console.BackgroundColor = (column % 2 == row % 2) ? ConsoleColor.Gray : ConsoleColor.DarkGray;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Write($" ♠ ");

					for (column = thisRowQueenPosition + 1; column <= 8; column++)
					{
						Console.BackgroundColor = (column % 2 == row % 2) ? ConsoleColor.Gray : ConsoleColor.DarkGray;
						Console.Write("   ");
					}

					Console.Write("\n");
				}

				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.Cyan;
				if (posNum != 0) Console.Write("\n\n   <"); else Console.Write("\n\n    ");
				Console.Write($"      position number ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write($"{posNum + 1}  ");
				if (posNum != positions.Count - 1)
				{
					if (posNum >= 9) Console.Write("> ");
					else Console.Write(" > ");
				}
				else
					Console.Write(" ");

				Console.ResetColor();
				Console.Write("\n         R: Reset, esc: Exit\n ");

				Console.SetCursorPosition(0, 16);

				var key = Console.ReadKey();

				if (key.Key == ConsoleKey.Escape)
					return;

				else if (key.Key == ConsoleKey.R)
				{
					posNum = 0;
					continue;
				}

				else if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && posNum != positions.Count - 1)
				{
					posNum++;
					continue;
				}

				else if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && posNum != 0)
				{
					posNum--;
					continue;
				}
			}
		}

		static void Main()
		{
			int[] column = new int[9]; column[0] = 10;
			bool isValid = true;
			bool key = true;
			List<string> finalPositions = new List<string>();
			string nums = "0123456789";
			string answer;
			int n = 1;

			foreach (char p1 in nums)
			{
				if (!key)
				{
					nums = nums.Remove(column[n], 1);
					nums = nums.Insert(column[n], column[n].ToString());
					key = true;
				}
				if (p1 == '0') continue;
				column[n] = p1 - 48;

				nums = nums.Replace(p1, '0');
				n++;
				foreach (char p2 in nums)
				{
					if (!key)
					{
						nums = nums.Remove(column[n], 1);
						nums = nums.Insert(column[n], column[n].ToString());
						key = true;
					}
					if (p2 == '0') continue;
					if (p2 == '9')
					{
						key = false;
						n--;
						break;
					}
					column[n] = p2 - 48;

					for (int m = 1; m < n; m++)
						if (column[n] - column[m] == n - m || column[n] - column[m] == m - n)
						{
							isValid = false;
							break;
						}
					if (!isValid)
					{
						isValid = true;
						foreach (char t in nums.Substring(column[n] + 1))
						{
							if (t != '0' && t != '9')
							{
								key = false;
								break;
							}
						}
						if (!key)
						{
							key = true;
							continue;
						}
						key = false;
						n--;
						break;
					}

					nums = nums.Replace(p2, '0');
					n++;
					foreach (char p3 in nums)
					{
						if (!key)
						{
							nums = nums.Remove(column[n], 1);
							nums = nums.Insert(column[n], column[n].ToString());
							key = true;
						}
						if (p3 == '0') continue;
						if (p3 == '9')
						{
							key = false;
							n--;
							break;
						}
						column[n] = p3 - 48;

						for (int m = 1; m < n; m++)
							if (column[n] - column[m] == n - m || column[n] - column[m] == m - n)
							{
								isValid = false;
								break;
							}
						if (!isValid)
						{
							isValid = true;
							foreach (char t in nums.Substring(column[n] + 1))
							{
								if (t != '0' && t != '9')
								{
									key = false;
									break;
								}
							}
							if (!key)
							{
								key = true;
								continue;
							}
							key = false;
							n--;
							break;
						}

						nums = nums.Replace(p3, '0');
						n++;
						foreach (char p4 in nums)
						{
							if (!key)
							{
								nums = nums.Remove(column[n], 1);
								nums = nums.Insert(column[n], column[n].ToString());
								key = true;
							}
							if (p4 == '0') continue;
							if (p4 == '9')
							{
								key = false;
								n--;
								break;
							}
							column[n] = p4 - 48;

							for (int m = 1; m < n; m++)
								if (column[n] - column[m] == n - m || column[n] - column[m] == m - n)
								{
									isValid = false;
									break;
								}
							if (!isValid)
							{
								isValid = true;
								foreach (char t in nums.Substring(column[n] + 1))
								{
									if (t != '0' && t != '9')
									{
										key = false;
										break;
									}
								}
								if (!key)
								{
									key = true;
									continue;
								}
								key = false;
								n--;
								break;
							}

							nums = nums.Replace(p4, '0');
							n++;
							foreach (char p5 in nums)
							{
								if (!key)
								{
									nums = nums.Remove(column[n], 1);
									nums = nums.Insert(column[n], column[n].ToString());
									key = true;
								}
								if (p5 == '0') continue;
								if (p5 == '9')
								{
									key = false;
									n--;
									break;
								}
								column[n] = p5 - 48;

								for (int m = 1; m < n; m++)
									if (column[n] - column[m] == n - m || column[n] - column[m] == m - n)
									{
										isValid = false;
										break;
									}
								if (!isValid)
								{
									isValid = true;
									foreach (char t in nums.Substring(column[n] + 1))
									{
										if (t != '0' && t != '9')
										{
											key = false;
											break;
										}
									}
									if (!key)
									{
										key = true;
										continue;
									}
									key = false;
									n--;
									break;
								}

								nums = nums.Replace(p5, '0');
								n++;
								foreach (char p6 in nums)
								{
									if (!key)
									{
										nums = nums.Remove(column[n], 1);
										nums = nums.Insert(column[n], column[n].ToString());
										key = true;
									}
									if (p6 == '0') continue;
									if (p6 == '9')
									{
										key = false;
										n--;
										break;
									}
									column[n] = p6 - 48;

									for (int m = 1; m < n; m++)
										if (column[n] - column[m] == n - m || column[n] - column[m] == m - n)
										{
											isValid = false;
											break;
										}
									if (!isValid)
									{
										isValid = true;
										foreach (char t in nums.Substring(column[n] + 1))
										{
											if (t != '0' && t != '9')
											{
												key = false;
												break;
											}
										}
										if (!key)
										{
											key = true;
											continue;
										}
										key = false;
										n--;
										break;
									}

									nums = nums.Replace(p6, '0');
									n++;
									foreach (char p7 in nums)
									{
										if (!key)
										{
											nums = nums.Remove(column[n], 1);
											nums = nums.Insert(column[n], column[n].ToString());
											key = true;
										}
										if (p7 == '0') continue;
										if (p7 == '9')
										{
											key = false;
											n--;
											break;
										}
										column[n] = p7 - 48;

										for (int m = 1; m < n; m++)
											if (column[n] - column[m] == n - m || column[n] - column[m] == m - n)
											{
												isValid = false;
												break;
											}
										if (!isValid)
										{
											isValid = true;
											foreach (char t in nums.Substring(column[n] + 1))
											{
												if (t != '0' && t != '9')
												{
													key = false;
													break;
												}
											}
											if (!key)
											{
												key = true;
												continue;
											}
											key = false;
											n--;
											break;
										}

										nums = nums.Replace(p7, '0');
										n++;
										foreach (char p8 in nums)
										{
											if (p8 == '0') continue;
											if (p8 == '9')
											{
												key = false;
												n--;
												break;
											}
											column[n] = p8 - 48;

											for (int m = 1; m < n; m++)
												if (column[n] - column[m] == n - m || column[n] - column[m] == m - n)
												{
													isValid = false;
													break;
												}
											if (!isValid)
											{
												key = false;
												n--;
												break;
											}
											answer = "";
											for (int i = 1; i <= 8; i++)
												answer += column[i];
											finalPositions.Add(answer);
										}
									}
								}
							}
						}
					}
				}
			}

			DrawBoard(finalPositions);
		}
	}
}