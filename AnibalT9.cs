double[] tiempo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
double[] y = { 50, 55, 60, 61, 65, 67, 69, 70, 72, 73, 74, 76 };
double factor, pivote;
int datos = y.Length;
int inco = 2;

double[,] MJ = new double[datos, inco];
double[,] max = new double[inco, inco + 1];

int ren = inco;
int col = ren + 1;



for (int i = 0; i < datos; i++)
{
    MJ[i, 0] = Math.Log(tiempo[i]);//ADAPTAR
    MJ[i, 1] = 1;
}

for (int i = 0; i < inco; i++)
{
    for (int j = 0; j < inco; j++)
    {
        for (int e = 0; e < datos; e++)
        {
            max[i, j] += MJ[e, j] * MJ[e, i];
        }
    }
}

for (int i = 0; i < inco; i++)
{
    for (int j = 0; j < datos; j++)
    {
        max[i, inco] += MJ[j, i] * y[j];
    }
}


for (int r = 0; r < ren; r++) 
    pivote = max[r, r];
    for (int c = 0; c < col; c++) 
    {
        max[r, c] = max[r, c] / pivote;
    }
  
    for (int rCero = 0; rCero < ren; rCero++)
    {
        if (r != rCero) 
        {
            factor = max[rCero, r];

            for (int cCero = 0; cCero < col; cCero++)
            {
                max[rCero, cCero] = max[rCero, cCero] - (factor * max[r, cCero]);
            }
        }
    }
}
Console.WriteLine("Variables de Anibal ");
for (int r = 0; r < ren; r++)
{
    Console.WriteLine("Variable " + (r + 1) + ": " + max[r, col - 1]);
}