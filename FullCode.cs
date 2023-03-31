// PARTE 1, CONSTANTES MARIA
double[] tiempo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
double[] y = { 49, 57, 59, 61, 63, 65, 67, 69, 70, 71, 72, 74 };
int datos = y.Length, incognitas = 2;
int ren = incognitas, col = ren + 1;
double factor, pivote;

double[,] matrizJacobiana = new double[datos, incognitas];
double[,] matriz = new double[incognitas, incognitas + 1];

//MATRIZ JACO
for (int i = 0; i < datos; i++)
{
    matrizJacobiana[i, 0] = Math.Cos(tiempo[i] / 8); //MARIA
    matrizJacobiana[i, 1] = Math.Exp(tiempo[i] / 10); //MARIA
}

//MATRIZ CUADRADA GAUSS = JACOBIANA * JACOBIANA TRANSPUESTA 
for (int i = 0; i < incognitas; i++) //recorre renglones matriz Gauss
{
    for (int j = 0; j < incognitas; j++) //recorre columnas matriz Gauss
    {
        for (int k = 0; k < datos; k++) //recorre datos/renglones jacobiana
        {
            //la j se mueve y la i queda fijo
            matriz[i, j] += matrizJacobiana[k, j] * matrizJacobiana[k, i];
        }
    }
}

//COLUMNA EXTENDIDA: CADA COLUMNA DE LA JACOBIANA * VECTOR DE DATOS
for (int i = 0; i < incognitas; i++) //recorre columnas matriz Jacobiana
{
    for (int j = 0; j < datos; j++) //recorre renglones matriz Jacobiana
    {
        matriz[i, incognitas] += matrizJacobiana[j, i] * y[j];
    }
}

//GAUSS
// Recorrer matriz
for (int r = 0; r < ren; r++) //RECORRER RENGLONES r = 0 -> 1 -> 2
{
    pivote = matriz[r, r];
    for (int c = 0; c < col; c++) //RECORRER COLUMNAS C = 0 
    {
        //   if(matriz[r,c]==0)
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
Console.WriteLine("Constantes de la ecuacion de Maria: ");
//IMPRESION GAUSS INCOGNITAS
for (int r = 0; r < ren; r++)
{
    Console.WriteLine("x" + (r + 1) + "= " + matriz[r, col - 1]);
}
Console.WriteLine("Ecuacion De Maria: y(t)=x1cos(t/8)+x2e^t10" + "\n");





//_--------------------------------------------------///////////
//// PARTE 1.5, CONSTANTES ANIBEL
double[] tiempo2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

double[] y2 = { 50, 55, 60, 61, 65, 67, 69, 70, 72, 73, 74, 76 };
datos = y2.Length; incognitas = 2;
ren = incognitas; col = ren + 1;
double factor2, pivote2;

double[,] matrizJacobiana2 = new double[datos, incognitas];
double[,] matriz2 = new double[incognitas, incognitas + 1];

//MATRIZ JACO
for (int i = 0; i < datos; i++)
{
    matrizJacobiana2[i, 0] = Math.Log(tiempo2[i]);
    matrizJacobiana2[i, 1] = 1;
}

//MATRIZ CUADRADA GAUSS = JACOBIANA * JACOBIANA TRANSPUESTA 
for (int i = 0; i < incognitas; i++) //recorre renglones matriz Gauss
{
    for (int j = 0; j < incognitas; j++) //recorre columnas matriz Gauss
    {
        for (int k = 0; k < datos; k++) //recorre datos/renglones jacobiana
        {
            //la j se mueve y la i queda fijo
            matriz2[i, j] += matrizJacobiana2[k, j] * matrizJacobiana2[k, i];
        }
    }
}

//COLUMNA EXTENDIDA: CADA COLUMNA DE LA JACOBIANA * VECTOR DE DATOS
for (int i = 0; i < incognitas; i++) //recorre columnas matriz Jacobiana
{
    for (int j = 0; j < datos; j++) //recorre renglones matriz Jacobiana
    {
        matriz2[i, incognitas] += matrizJacobiana2[j, i] * y2[j];
    }
}

//GAUSS
// Recorrer matriz
for (int r = 0; r < ren; r++) //RECORRER RENGLONES r = 0 -> 1 -> 2
{
    pivote2 = matriz2[r, r];
    for (int c = 0; c < col; c++) //RECORRER COLUMNAS C = 0 
    {
        //   if(matriz[r,c]==0)
        matriz2[r, c] = matriz2[r, c] / pivote2;
        //  matriz[r,c] /= pivote;   
    }
    //VOLVER A RECORRER LA MATRIZ PARA HACER LAS CONVERSIONES A CERO
    for (int rCero = 0; rCero < ren; rCero++)
    {
        if (r != rCero) //BRINCAR EL RENGLON DEL PIVOTE
        {
            factor2 = matriz2[rCero, r];

            for (int cCero = 0; cCero < col; cCero++)
            {
                //(VALOR ORIGINAL ) – (RENGLON DEL PIVOTE,C)(FACTOR))\
                matriz2[rCero, cCero] = matriz2[rCero, cCero] - (factor2 * matriz2[r, cCero]);
                //matriz[rCero, cCero] -= (factor* matriz[r,cCero]);
            }
        }
    }
}
//IMPRESION GAUSS INCOGNITAS
Console.WriteLine("Constantes de la ecuacion de Anibal: ");
for (int r = 0; r < ren; r++)
{
    Console.WriteLine("x"+ (r + 1) + "= " + matriz2[r, col - 1]);
}
Console.WriteLine("Ecuacion De Anibal: y(t)=x1ln(t)+x2" + "\n\n");
//-----------------------------------------------------------------------//
//PARTE 2, MATRIZ JACOBIANA
double t = 2, yT = 57;
ren = 2; col = ren + 1;
matriz = new double[ren, col];
pivote = 0;
double criterioCero = 0.0001;
factor = 0;

matriz[0, 2] = 1;
matriz[1, 2] = 1;

while (Math.Abs(matriz[0, 2]) > criterioCero || Math.Abs(matriz[1, 2]) > criterioCero)
{
    //APLICAR MATRIZ JACOBIANA MANUALEMENTE EN CADA POSICION DE LA MATRIZ

    matriz[0, 0] = 10.5859 / t;
    matriz[0, 1] = -1;
    matriz[0, 2] = -(10.5859 * Math.Log(t) + 48.5681 - yT);

    matriz[1, 0] = -(30.4708 / 8) * Math.Sin(t / 8) + (22.4977 / 10) * Math.Exp(t / 10);
    matriz[1, 1] = -1;
    matriz[1, 2] = -(30.4702 * Math.Cos(t / 8) + 22.4977 * Math.Exp(t / 10) - yT);


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
    yT += matriz[1, 2];

}
Console.WriteLine("Los bebes tendran una estatura de "+t+" a los "+yT+"\n");

//-----------------------------------------------------------------------//

//RAIZ DE ANIBAL

double x = 1, xAnterior, xMedia = 0; //Punto de partida de la busqueda (Tu Seleccionas donde iniciar)
double paso = 1, y1, y22, yMedia = 1;

y22 = y1 = (10.5859 * Math.Log(x) + 48.368 - 60);  //evaluando la función en 
// x = x + paso; //avanzo una unidad   
while (y1 * y22 >= 0)
{
    y1 = y22;
    x += paso;
    y22 = (10.5859 * Math.Log(x) + 48.368 - 60);//EDITAR
}

xAnterior = x - paso;

//BISECCION (OBTENER PUNTOS INTERMEDIOS E IR CAMBIANDO LIMITES
while (Math.Abs(yMedia) > criterioCero)
{
    xMedia = (xAnterior + x) / 2; //PUNTO INTERMEDIO DE LAS X'S
    yMedia = (10.5859 * Math.Log(xMedia) + 48.368 - 60);   //EDITAR

    //VALIDAR SI TIENE EL MISMO SIGNO QUE Y1 
    if (y1 * yMedia > 0)//TIENEN EL MISMO SIGNO
    {
        y1 = yMedia;
        xAnterior = xMedia;
    }

    //VALIDAR SI TIENE EL MISMO SIGNO QUE Y2
    else if (y22 * yMedia > 0)//TIENEN EL MISMO SIGNO
    {
        y22 = yMedia; //adaptar las y's
        x = xMedia; //adaptar las x's
    }
}
Console.WriteLine("La estatua de Anibal será de 60cm a los: "+xMedia+" Meses");


//__-------------------------------------------------__----------------//
//30.4702 * Math.Cos(x/8) + 22.4977 * Math.Exp((x/10)) - 60; 

//RAIZ DE MARIA _______________
x = 0; xAnterior = 0; xMedia = 0; paso = 1; y1 = 1; y22 = 1; yMedia = 1;  //SOBREESCRIBIR VARIABLES
y22 = y1 = 30.4702 * Math.Cos(x / 8) + 22.4977 * Math.Exp((x / 10)) - 60; //evaluando la función en -4 EDITAR

while (y1 * y22 >= 0)
{
    y1 = y22;
    x += paso;
    y22 = 30.4702 * Math.Cos(x / 8) + 22.4977 * Math.Exp((x / 10)) - 60;  // EDITABLE, 
                                                                          // Es igual a: y = x^3 - x^2 + 4x - 2 
}

xAnterior = x - paso;

//BISECCION (OBTENER PUNTOS INTERMEDIOS E IR CAMBIANDO LIMITES
while (Math.Abs(yMedia) > criterioCero)
{

    xMedia = x - ((xAnterior - x) * y22) / (y1 - y22);

    yMedia = 30.4702 * Math.Cos(xMedia / 8) + 22.4977 * Math.Exp((xMedia / 10)) - 60;  //EDITAR

    //VALIDAR SI TIENE EL MISMO SIGNO QUE Y1 
    if (y1 * yMedia > 0)//TIENEN EL MISMO SIGNO
    {
        y1 = yMedia;
        xAnterior = xMedia;
    }


    //VALIDAR SI TIENE EL MISMO SIGNO QUE Y2
    else if (y22 * yMedia > 0)//TIENEN EL MISMO SIGNO
    {
        y22 = yMedia; //adaptar las y's
        x = xMedia; //adaptar las x's
    }
}
Console.WriteLine("La estatua de Maria será de 60cm a los: " + xMedia + " Meses");

