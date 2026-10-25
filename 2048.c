#include <stdio.h>
#include <conio.h>
#include <time.h>
#include <Windows.h>

#define LEFT 75
#define RIGHT 77
#define UP 72
#define DOWN 80

int score;
int board[4][4] =
{
    { 0, 0, 0, 0 },
    { 0, 0, 0, 0 },
    { 0, 0, 0, 0 },
    { 0, 0, 0, 0 }
};

void Draw();
void NewNumber();
void check_game_over();

int main(int argc, char** argv)
{
    int i;
	int j;
	int r;
    int key;
    int act;
    
    NewNumber();
    NewNumber();
    Draw();
    
    while (1)
	{
        key = getch();
        
        if(key == 0xE0 || key == 0)
		{
            key = getch();
            
            switch (key)
			{
                case LEFT:
	                for (i = 0, act = 0; i < 4; i++)
					{
	                    for (j = 1; j <= 3; j++)
						{
	                        for (r = j; r > 0; r--)
							{
	                            if (board[i][r] == 0 || board[i][r] > 10000)
								{
									break;
								}
	                            if (board[i][r - 1] != 0 && board[i][r - 1] != board[i][r])
								{
									break;
								}
								
	                            if (board[i][r - 1] == 0)
								{
									board[i][r - 1] = board[i][r];
								}
	                            else if (board[i][r] == board[i][r - 1])
								{
	                                board[i][r - 1] *= 2;
	                                board[i][r - 1] += 10000;
	                                score += 2 *(board[i][r]);
	                            }
	                            
	                            board[i][r] = 0;
	                            act++;
	                        }
	                    }
	                }
	                
	                break;
                case RIGHT:
	                for (i = 0, act = 0; i < 4; i++)
					{
	                    for (j = 2; j >= 0; j--)
						{
	                        for (r = j; r < 3; r++)
							{
	                            if (board[i][r] == 0 || board[i][r] > 10000)
								{
									break;
								}
								
	                            if (board[i][r + 1] != 0 && board[i][r + 1] != board[i][r])
								{
									break;
								}
	                            
	                            if (board[i][r + 1] == 0)
								{
									board[i][r + 1] = board[i][r];
								}
	                            else if (board[i][r] == board[i][r + 1])
								{
	                                board[i][r+1] *= 2;
	                                board[i][r+1] += 10000;
	                                score += 2 * (board[i][r]);
	                            }
	                            
	                            board[i][r] = 0;
	                            act++;
	                        }
	                    }
	                }
	                
	                break;
                case UP:
	                for (j = 0, act = 0; j < 4; j++)
					{
	                    for (i = 1; i <= 3; i++)
						{
	                        for (r = i; r > 0; r--)
							{
	                            if (board[r][j] == 0 || board[r][j] > 10000)
								{
									break;
								}
								
	                            if (board[r - 1][j] != 0 && board[r - 1][j] != board[r][j])
								{
									break;
								}
	                            
	                            if (board[r - 1][j] == 0)
								{
									board[r - 1][j] = board[r][j];
								}
	                            else if (board[r][j] == board[r - 1][j])
								{
	                                board[r - 1][j] *= 2;
	                                board[r - 1][j] += 10000;
	                                score += 2 * (board[r][j]);
	                            }
	                            
	                            board[r][j] = 0;
	                            act++;
	                        }
	                    }
	                }
	                
                	break;
                case DOWN:
	                for(j = 0, act = 0; j < 4; j++)
					{
	                    for(i = 2; i >= 0; i--)
						{
	                        for(r = i; r < 3; r++)
							{
	                            if (board[r][j] == 0 || board[r][j] > 10000)
								{
									break;
								}
								
	                            if (board[r + 1][j] != 0 && board[r + 1][j] != board[r][j])
								{
									break;
								}
								
	                            if (board[r + 1][j] == 0)
								{
									board[r + 1][j] = board[r][j];
								}
	                            else if (board[r][j] == board[r + 1][j])
								{
	                                board[r + 1][j] *= 2;
	                                board[r + 1][j] += 10000;
	                                score += 2 * (board[r][j]);
	                            }
	                            
	                            board[r][j] = 0;
	                            act++;
	                        }
	                    }
	                }
	                
                	break;
            }
        }
        
        for (i = 0; i < 4; i++)
		{
            for (j = 0; j < 4; j++)
			{
                if(board[i][j] > 10000)
                {
                    board[i][j] -= 10000;
                }
            }
        }
        
        if (act > 0)
		{
            NewNumber();
            Draw();
            check_game_over();
        }
    }
}

void Draw()
{
    int i;
	int j;
    
    system("cls");
 
    for (i = 0; i < 4; i++)
	{
        for (j = 0; j < 4; j++)
		{
            if (board[i][j] == 0)
			{
				printf("    .");
			}
            else
			{
				printf("%5d", board[i][j]);
			}
        }
        
        printf("\n");    
    }
    
    printf("\n");
    printf("Score : %d \n", score);
}

void NewNumber()
{
    int i;
	int j;
    int cnt;
    int* p0[16] =
	{
		0
	};
    
    for (i = 0, cnt = 0; i < 4; i++)
	{
        for (j = 0; j < 4; j++)
        {
            if (board[i][j] == 0)
			{
                p0[cnt] = &board[i][j];
                cnt++;
            }
        }
    }
    
    *p0[rand()%(cnt)]=(rand()%100<80)?2:4;
}

void check_game_over()
{
    int i;
	int j;
    
    for (i = 0; i < 4; i++)
	{
		for (j = 0; j < 4; j++)
		{
			if (board[i][j] == 0)
			{
				return;
			}
		}
	}
	
    for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			if(board[i][j] == board[i + 1][j] || board[i][j] == board[i][j + 1])
			{
				return;
			}
		}
	}
	
    for (i = 0; i < 3; i++)
	{
		if (board[i][3] == board[i + 1][3])
		{
			return;
		}
	}
	
    for (j = 0; j < 3; j++)
	{
		if (board[3][j] == board[3][j + 1])
		{
			return;
		}
	}
    
    printf("Game Over..");
    exit(0);
}
