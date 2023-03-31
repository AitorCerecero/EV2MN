double t = 4, y = 50;
int ren = 2, col = ren + 1;
double[,] matriz = new double[ren, col];
double factor, pivote, criterioCero = 0.0001;
matriz[0, 2] = 1;
matriz[1, 2] = 1;

while (Math.Abs(matriz[0, 2]) > criterioCero || Math.Abs(matriz[1, 2]) > criterioCero)
{
    //APLICAR MATRIZ JACOBIANA MANUALEMENTE EN CADA POSICION DE LA MATRIZ

    ///PRIMERA ECUACION
    matriz[0, 0] = 10.5859/ Math.Log(t);
    matriz[0, 1] = -1;
    matriz[0, 2] = -(10.5859 * Math.Log(t) + 48.5681-y);

    //SEGUNDA ECUACION
    matriz[1, 0] = -(30.4708 / 8) * Math.Sin(t / 8) + (22.4977 / 10) * Math.Exp(t / 10);
    matriz[1, 1] = -1;
    matriz[1, 2] = -(30.4702 * Math.Cos(t / 8) + 22.4977 * Math.Exp(t / 10) - y);


    /* APLICAR GAUSS

     Recorrer matriz para imprimir datos*/
    for (int r = 0; r < ren; r++) //RECORRER RENGLONES r = 0 -> 1 -> 2
    {
        pivote = matriz[r, r];
        for (int c = 0; c < col; c++) //RECORRER COLUMNAS C = 0 
        {
            matriz[r, c] = matriz[r, c] / pivote;
            //  matriz[r,c] /= pivote;   
        }
        //VOLVER A RECORRER LA MATRIZ PARA HACER LAS CONVERSIONES A CERO
        for (int rCero = 0; rCero < ren; rCero++)
        {
            if (r != rCero) //BRINCAR EL RENGLON DEL PIVOTE
            {
                factor = matriz[rCero, r];

                for (int cCero = 0; cCero < col; cCero++)
                {
                    //(VALOR ORIGINAL ) – (RENGLON DEL PIVOTE,C)(FACTOR))\
                    matriz[rCero, cCero] = matriz[rCero, cCero] - (factor * matriz[r, cCero]);
                    //matriz[rCero, cCero] -= (factor* matriz[r,cCero]);
                }
            }
        }
    }
    t += matriz[0, 2];
   y += matriz[1, 2];


}
Console.WriteLine(" t : " + t);
Console.WriteLine(" y : " + y);
