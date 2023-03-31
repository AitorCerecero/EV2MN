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