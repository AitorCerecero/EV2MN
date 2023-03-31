
double x = 3, xAnterior, xMedia = 1; //Punto de partida de la busqueda (Tu Seleccionas donde iniciar)
double paso = 1, y1, y2, yMedia = 1, criterioCero = 0.0001;

y2 = y1 = (10.5859*Math.Log(x)+48.368-60); //evaluando la función en -4 EDITAR
                                // x = x + paso; //avanzo una unidad -4 -> -3
                                //y2 = 2*Math.Pow(x,2) - (5*x) + 1; //evalua la ecuación en -3

while (y1 * y2 >= 0)
{
    y1 = y2;
    x += paso;
    y2 = (10.5859 * Math.Log(x) + 48.368 - 60); //EDITAR
}

xAnterior = x - paso;

while (Math.Abs(yMedia) > criterioCero)
{
    xMedia = (xAnterior + x) / 2; 
    yMedia = (10.5859 * Math.Log(xMedia) + 48.368 - 60); 

    if (y1 * yMedia > 0)
    {
        y1 = yMedia;
        xAnterior = xMedia;
    }

    else if (y2 * yMedia > 0)
    {
        y2 = yMedia; 
        x = xMedia; 
    }
}

Console.Write("Mes en el que la estatura de anibal sera de 60: [" + xMedia + "]");