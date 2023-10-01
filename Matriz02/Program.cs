var contador = 0;

int linhas = 0;
int colunas = 0;

int primeira_coluna = 0;
int _linha = 0;
string[] n = new string[6];
string[] arr_zeros = new string[7];
string[] arr_naozeros = new string[7];
int i = 0; int j = 0;

string[,] matriz = new string[7, 7] {

                /*0,   1,   2,   3,   4,   5,   6*/

                { "1", ">", ">", ">", "1", "3", "1" }, //0

                { "2", "!", "3", "5", "6", "1", "4" }, //1

                { "3", "!", "*", "*", "*", "*", "*" }, //2

                { "4", "!", "4", "5", "1", "!", "2" }, //3

                { ">", "!", "1", "5", "7", "!", "1" }, //4

                { ">", "3", "5", "6", "4", "!", "2" }, //5

                { ">", "1", ">", ">", ">", "!", "5" } //6

            };

CompararValoresHorizontal(matriz[linhas, colunas], matriz[linhas, colunas + 1]);

linhas = 0; colunas = 0;

CompararValoresVertical(matriz[linhas, colunas], matriz[linhas + 1, colunas]);

linhas = 0; colunas = 0;
BuscaPorValorZeroETroca(matriz[linhas, colunas]);

void CompararValoresHorizontal(string m1, string m2)
{
    //caso dois valores sejam iguais, ele deve chamar o método SubstituirValoresHorizontal
    //nos parâmetros são passados a posição do primeiro valor
    if (m1 == "*" || m1 == "!" || m1 == ">")
    {
        primeira_coluna = colunas;
        SubstituirValoresNaHorizontal(linhas, colunas);
    }

    //Se colunas igual a 5 ou 6, então foi percorrido todas as colunas da matriz.
    if (colunas == 6)
    {
        colunas = 0;
        linhas++;
    }
    else
        colunas++;


    //Se linhas igual a 7, então foi percorrido todas a linhas da matriz.
    if (linhas < 7)
        CompararValoresHorizontal(matriz[linhas, colunas], "");
}

void CompararValoresVertical(string m1, string m2)
{
    if (m1 == "*" || m1 == "!" || m1 == ">")
    {
        _linha = linhas;
        SubstituirValoresNaVertical(_linha, colunas);
        //BuscaPorValorNaoVazio(_linha, colunas);
    }
    //else if (m1 == " ")
    //{
    //    _linha = linhas;
    //    BuscaPorValorNaoVazio(_linha, colunas);
    //}

    //Se linhas igual a 5 ou 6, então foi percorrido todas as linhas da matriz.
    if (linhas == 6)
    {
        linhas = 0;
        colunas++;
    }
    else
        linhas++;


    //Se colunas igual a 7, então foi percorrido todas as colunas da matriz.
    if (colunas < 7)
        CompararValoresVertical(matriz[linhas, colunas], "");
}

void BuscaPorValorZeroETroca(string v1)
{
    if (v1 == "0" && linhas > 0)
    {
        arr_zeros[i] = v1;
        i++;
    }

    else if (v1 != "0")
    {
        arr_naozeros[j] = v1;
        j++;
    }


    if (linhas == 6)
    {
        if (arr_zeros.Length >= 3)
        {
            int cont_l = linhas;
            int x = j - 1;
            int y = i - 1;

            while (cont_l > 0)
            {
                while (x >= 0 && arr_naozeros[x] != null)
                {
                    matriz[cont_l, colunas] = arr_naozeros[x];
                    x--;
                    cont_l--;
                }

                while (y >= 0 && arr_zeros[y] != null)
                {
                    matriz[cont_l, colunas] = arr_zeros[y];
                    y--;
                    cont_l--;
                }

            }
            i = 0;
            j = 0;
        }

        linhas = 0;
        colunas++;
    }
    else
        linhas++;

    if (colunas < 7)
        BuscaPorValorZeroETroca(matriz[linhas, colunas]);

}

//void BuscaPorValorZeroETroca(int posicao, int aux_col)
//{
//    n = new string[6];
//    int aux_pos = posicao;
//    int t = 0;

//    if (matriz[posicao, aux_col] == " ")
//        matriz[posicao, aux_col] = "0";

//    while (posicao > 0)
//    {

//        if ((matriz[posicao - 1, aux_col]) != " ")
//        {
//            n[t] = matriz[posicao - 1, aux_col];

//            matriz[posicao - 1, aux_col] = "0";

//            t++;
//        }
//        posicao--;

//    }

//    AbaixarOsValores(aux_pos, aux_col);
//}

void SubstituirValoresNaHorizontal(int linha, int coluna)
{
    int aux_linha = linha;
    int aux_coluna = coluna;
    int aux_contador = 0;


    if (coluna < 6 && (matriz[aux_linha, aux_coluna] == matriz[aux_linha, aux_coluna + 1]) && contador < 4)
    {
        contador++;
        SubstituirValoresNaHorizontal(aux_linha, aux_coluna + 1);
    }
    else
    {
        aux_contador = contador;
        contador = 0;
        colunas = aux_coluna;
    }

    if (aux_contador == 4)
    {
        TrocaPorCaractereHorizontal(aux_linha, aux_coluna, "0", primeira_coluna);
    }

    if (aux_contador == 3)
    {
        TrocaPorCaractereHorizontal(aux_linha, aux_coluna, "0", primeira_coluna);
    }

    if (aux_contador == 2)
    {
        TrocaPorCaractereHorizontal(aux_linha, aux_coluna, "0", primeira_coluna);
    }
};

void SubstituirValoresNaVertical(int linha, int coluna)
{
    int aux_linha = linha;
    int aux_coluna = coluna;
    int aux_contador = 0;

    if (linha < 6 && (matriz[aux_linha, aux_coluna] == matriz[aux_linha + 1, aux_coluna]) && contador < 4)
    {
        contador++;
        SubstituirValoresNaVertical(aux_linha + 1, aux_coluna);
    }
    else
    {
        aux_contador = contador;
        contador = 0;
        linhas = aux_linha;
    }

    if (aux_contador == 4)
    {
        TrocaPorCaractereVertical(aux_linha, aux_coluna, "0", _linha);
    }

    if (aux_contador == 3)
    {
        TrocaPorCaractereVertical(aux_linha, aux_coluna, "0", _linha);
    }

    if (aux_contador == 2)
    {
        TrocaPorCaractereVertical(aux_linha, aux_coluna, "0", _linha);
    }
};

void TrocaPorCaractereHorizontal(int aux_l, int aux_col, string caractere, int primeira_posicao)
{
    while (aux_col >= primeira_posicao)
    {
        matriz[aux_l, aux_col] = caractere;

        //if (aux_l == 0)
        //    matriz[aux_l, aux_col] = "0";

        aux_col--;
    }
}

void TrocaPorCaractereVertical(int aux_l, int aux_col, string caractere, int primeira_posicao)
{
    while (aux_l >= primeira_posicao)
    {
        matriz[aux_l, aux_col] = caractere;
        aux_l--;
    }

}

//posicao = primeira posicap

void BuscarValor() { }



void AbaixarOsValores(int pos, int aux_col)
{

    int aux = 0;
    int i = pos;

    while (pos < 6 && matriz[pos + 1, aux_col] == " ")
    {
        pos++;
        i = pos;
    }

    while (aux < n.Length && n[aux] != null)
    {
        matriz[i, aux_col] = n[aux];
        aux++;
        i--;
    }

}

for (int li = 0; li <= 6; li++)
{
    for (int col = 0; col <= 6; col++)
    {
        Console.Write("{0} ", matriz[li, col]);
    }
    Console.WriteLine("\n");
}
