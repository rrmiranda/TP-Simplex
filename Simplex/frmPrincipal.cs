using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Simplex.svc_simplex;

namespace Simplex
{
    public partial class frmPrincipal : Form
    {
        int Restricoes;
        int Produtos;
        string FO;
        int x;
        int y = 1;
        int Linha = 0;
        int cont = 0;

        float[] VetProdutos;       //Receber valores do produto (30x1, 30x2, etc);
        string[] VetInequacao;   //Receber valores das inequações (>= ou <=) para criar variáveis auxiliares;
        //float[,] MatRestricoes;    //Receber valores das inequações respectivas aos produtos (R1 = ..., R2 = ...,);

        svc_simplex.SimplexClient SVC = new svc_simplex.SimplexClient();
                      
        public frmPrincipal()
        {
            InitializeComponent();
            
        }

        private void rbtmin_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbtmin.Checked == true)
            {
                FO = "min";
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {
           
            MessageBox.Show("1º Informe a quantidade de Produtos e Restrições", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (rbtmax.Checked)
            {
                FO = "max";
            }
            else
            {
                FO = "min";
            }

            txt_valorp.Enabled = false;
            txt_valorr.Enabled = false;
            txt_valorine.Enabled = false;
            txt_valorresultine.Enabled = false;

            btn_inserir.Enabled = false;
            btn_inserir2.Enabled = false;
            btn_inserir3.Enabled = false;
            btn_inserir4.Enabled = false;

        }
        private void button2_Click(object sender, EventArgs e) 
        {
            if (txtnum.Text!="" && int.Parse(txtnum.Text) > 0 && txtrest.Text!="" && int.Parse(txtrest.Text) > 0)
            {
                Produtos = int.Parse(txtnum.Text);    //Recebe numero de produtos a serem analisados (x1, x2, etc);
                Restricoes = int.Parse(txtrest.Text); //Recebe numero de restrições presentes no problema;

                txtnum.Enabled = false;
                txtrest.Enabled = false;

                btn_inserirPR.Enabled = false;
                VetProdutos = new float[Produtos];       //Receber valores do produto (30x1, 30x2, etc);
                VetInequacao = new string[Restricoes]; //Receber valores das inequações (>= ou <=) para criar variáveis auxiliares;

                SVC.SetarTamanhoMatRestricoes(Restricoes, (Produtos + 1));
                //MatRestricoes = new float[Restricoes, (Produtos + 1)]; //Receber valores das inequações respectivas aos produtos (R1 = ..., R2 = ...,);
                MessageBox.Show("Agora informe os valores dos produtos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_valorp.Enabled = true;
                btn_inserir.Enabled = true;

            }
            MessageBox.Show("Favor preencher os campos para proseguir ", "Atenção", MessageBoxButtons.OK);
            txtnum.Focus();

        }
        /// <summary>
        /// //Procedimento para receber dados de Produtos
        /// </summary>
        /// <param name="VetProdutos"> Vetor contendo o total de produtos (x1, x2, .., xn)</param>        
        private void btn_inserir_Click(object sender, EventArgs e)
        {
            #region Verificar


            if ((float.Parse(txt_valorp.Text) > 0))
            {
                VetProdutos[x] = float.Parse(txt_valorp.Text);

                MessageBox.Show("Você inseriu o " + (y) + " Valor.", "Atenção", MessageBoxButtons.OK);

                x++; //variavel auxiliar para guardar valores dos produtos no vetor.
                y++; //variavel usada para contabilizar os registros dos produtos inseridos
            }
            #endregion     //Testar variaveis informadas;
            else
            {

                MessageBox.Show(" VALOR(ES) INCORRETO(S)", "Atenção", MessageBoxButtons.OK);
            }
            txt_valorp.Text = null;
            txt_valorp.Focus();

            if (x >= VetProdutos.Length)
            {
                txt_valorp.Enabled = false;
                btn_inserir.Enabled = false;
                MessageBox.Show("Agora informe o valor das Restrições!");

                txt_valorr.Enabled = true;
                btn_inserir2.Enabled = true;

                txt_valorr.Focus();

            }
            
        }

        /// <summary>
        /// //Procedimento para receber as Restriçoes
        /// </summary>
        /// <param name="VetProdutos"> Vetor contendo o total de produtos (x1, x2, .., xn)</param>
        private void btn_inserir2_Click(object sender, EventArgs e)
        {
            SVC.SetarMatRestricoes(float.Parse(txt_valorr.Text),Linha,cont);

            float valor = SVC.RetornarValorMatRestricoes(Linha, cont);
            //MatRestricoes[Linha, cont] = float.Parse(txt_valorr.Text);
            #region Verificar
            if (SVC.RetornarValorMatRestricoes(Linha,cont)<0) // MatRestricoes[Linha, cont] < 0)
            {
              MessageBox.Show("VALOR INCORRETO");
            }
            #endregion

            MessageBox.Show("Você inseriu o valor do " + (cont + 1) + "º produto: ");

            cont++;
            txt_valorr.Clear();
            txt_valorr.Focus();

            if (cont>=Produtos)
            {
                
                cont = 0;
                MessageBox.Show("Informe a inequação ( '<=' ou '>=' ) dessa respectiva restrição: ");

                txt_valorine.Enabled = true;
                btn_inserir3.Enabled = true;

                txt_valorr.Enabled = false;
                btn_inserir2.Enabled = false;
                                
            }             
        }

        /// <summary>
        /// //Procedimento para receber os valores das inequaçoes
        /// </summary>
        private void btn_inserir3_Click(object sender, EventArgs e)
        {
            #region Verificar
            if ((txt_valorine.Text != "=>") && (txt_valorine.Text != ">=") && (txt_valorine.Text != "<=") && (txt_valorine.Text != "=<"))
            {
                MessageBox.Show("VALOR INCORRETO");
                txt_valorine.Clear();
                txt_valorine.Focus();
            }
            else
            {
                VetInequacao[Linha] = txt_valorine.Text;
                txt_valorine.Enabled = false;
                btn_inserir3.Enabled = false;
                txt_valorine.Clear();

                txt_valorresultine.Enabled = true;
                btn_inserir4.Enabled = true;

                MessageBox.Show("Informe valor resultante dessa respectiva inequação: ");
                txt_valorresultine.Focus();
            }
            #endregion

        }

        /// <summary>
        /// //Procedimento para receber os valores resultante das inequaçoes
        /// </summary>
        private void btn_inserir4_Click(object sender, EventArgs e)
        {
            SVC.SetarMatRestricoes(float.Parse(txt_valorresultine.Text), Linha, SVC.RetornarTamMatRestricoes());
            //MatRestricoes[Linha, MatRestricoes.GetLength(1) - 1] = float.Parse(txt_valorresultine.Text);

            #region Verificar
            if (SVC.RetornarValorMatRestricoes(Linha,SVC.RetornarTamMatRestricoes())<=0)  
          //if( MatRestricoes[Linha, MatRestricoes.GetLength(1) - 1] <= 0)
            {
                MessageBox.Show("VALOR INCORRETO");
            }
            #endregion
            Linha++; //passa para a proxima linha que armazena a os valores da proxima restriçao;
            if (Linha < Restricoes)
            {
                MessageBox.Show("Informe os valores da " + (Linha + 1) + "º Restrição: ");

                txt_valorresultine.Clear();
                txt_valorresultine.Enabled = false;
                btn_inserir4.Enabled = false;

                txt_valorr.Enabled = true;
                btn_inserir2.Enabled = true;
                txt_valorr.Focus();
            }
            else
            {
                txt_valorresultine.Clear();
                txt_valorresultine.Enabled = false;
                btn_inserir4.Enabled = false;
            }
        }

        /// <summary>
        /// //Procedimento para habilitar a ediçao dos valores de produtos e restriçoes;
        /// </summary>
        private void btn_editPR_Click(object sender, EventArgs e)
        {

            btn_inserirPR.Enabled = true;
            txtnum.Enabled = true;
            txtrest.Enabled = true;
        }

        /// <summary>
        /// //Procedimento para alterar o valor da variavel FO, min ou max
        /// </summary>
        private void rbtmax_CheckedChanged(object sender, EventArgs e) //Recebe variável respectiva a função;
        {
            if (rbtmax.Checked == true)
            {
                FO = "max";
            }
        }


        /// <summary>
        /// Procedimento para encerrar aplicação
        /// </summary>
        /// <summary>
        /// //Procedimento para executar o algoritmo simplex
        /// </summary>
        /// 
        private void btn_fechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente Encerrar aplicação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }

            

        }
        private void btn_calcular_Click(object sender, EventArgs e)
        {                       
             ParametroFase1 parametro = SVC.CalcularSimplex(FO, VetProdutos, VetInequacao);

            txtresultvalores.Text =parametro.resultvalores;
            txtresult.Text = parametro.result;


            //bool Error = false;

            //do
            //{
            // //float[,] Tabela = CriaTabela(FO, VetProdutos, VetInequacao, MatRestricoes);  //Função que cria tabela simplex das respectivas variáveis informadas;

            //     //Ao executar Algoritmo de Troca as variáveis mudam suas posições na tabela, ficando impossível no final determinar qual valor é de qual variavel, então criei um método para gravar os valores das variaveis x1, x2, x3, etc;
            //     int aux = 1;    //Variavel auxiliar para verificar os valores das variaveis básicas na tabela simplex;
            //     string[,] ValorVariaveis = new string[2, (Tabela.GetLength(0) - 1) + (Tabela.GetLength(1) - 1)];   //Matriz que recebe as variaveis e seus respectivos valores, retirando da Tabela SImplex;
            //     for (int cont = 0; cont < ValorVariaveis.GetLength(1); cont++)
            //     {
            //         ValorVariaveis[0, cont] = "X" + (cont + 1);                         //Adicionando as variaveis na matriz na linha1;
            //         if (cont < (Tabela.GetLength(1) - 1))
            //             ValorVariaveis[1, cont] = string.Concat(Tabela[0, cont + 1]);   //Adicionando na linha2 os valores respectivos as variaveis não-básicas;
            //         else
            //         {
            //             ValorVariaveis[1, cont] = string.Concat(Tabela[aux, 0]);        //Adicionando na linha2 os valores respectivos as variaveis básicas;
            //             aux++;
            //         }
            //     }
            //     AnaliseFase1(Tabela, ValorVariaveis);    //Chama primeiro procedimento de analise da tabela simplex;

            // } while (Error == true);    //Tratamento de erros, repetirá o procedimento Dados se erro for verdade;

        }

        /// <summary>
        /// //Função que cria uma Tabela simplex, recebendo os respectivos valores informados no procedimento Dados;
        /// </summary>
        /// <param name="VetProdutos"> Vetor contendo o total de produtos (x1, x2, .., xn)</param>
        /// <param name="VetInequacao"> Vetor que recebe o tipo de inequação de cada restrição (R1: maior/igual, R2: menor/igual, etc)</param>
        /// <param name="MatRestricoes"> Matriz que recebe valores de suas restrições</param>
        /// <returns> Retorna uma Tabela Simplex com os valores informados pelo usuario</returns>
        static float[,] CriaTabela(string FO, float[] VetProdutos, string[] VetInequacao, float[,] MatRestricoes)
        {
            float[,] Tabela = new float[VetInequacao.Length + 1, VetProdutos.Length + 1];  // +1 refere-se ao f(x) e Membro Livre respectivamente;

            if (FO == "max")   //Se função for Máxima, valores dos produtos não modificam, entretanto se for Mínimo os valores ficarão negativos;
            {
                for (int Coluna = 0; Coluna < Tabela.GetLength(1); Coluna++)               // Preencher f(x);
                {
                    if (Coluna == 0)
                        Tabela[0, 0] = 0;
                    else
                        Tabela[0, Coluna] = VetProdutos[Coluna - 1];
                }
            }
            else
            {
                for (int Coluna = 0; Coluna < Tabela.GetLength(1); Coluna++)      //FOR para preencher linha "f(x)" e valores dos produtos;
                {
                    if (Coluna == 0)
                        Tabela[0, 0] = 0;
                    else
                        Tabela[0, Coluna] = -(VetProdutos[Coluna - 1]);
                }
            }
            for (int Restricao = 0; Restricao < VetInequacao.Length; Restricao++)             // Preencher Variaveis basicas e não basicas; 
                if ((VetInequacao[Restricao] == "<=") || (VetInequacao[Restricao] == "=<"))   //Necessário realizar transformações dos valores das variaveis caso inequação seja menor ou igual;
                {
                    for (int cont = 0; cont < MatRestricoes.GetLength(1); cont++)
                    {
                        if (cont == 0)
                            Tabela[Restricao + 1, cont] = MatRestricoes[Restricao, MatRestricoes.GetLength(1) - 1];
                        else
                            Tabela[Restricao + 1, cont] = MatRestricoes[Restricao, cont - 1];
                    }
                }
                else
                {
                    for (int cont = 0; cont < MatRestricoes.GetLength(1); cont++)
                    {
                        if (cont == 0)
                            Tabela[Restricao + 1, cont] = -(MatRestricoes[Restricao, MatRestricoes.GetLength(1) - 1]);
                        else
                            Tabela[Restricao + 1, cont] = -(MatRestricoes[Restricao, cont - 1]);
                    }
                }
            return Tabela;     //Retorna Tabela Simplex;
        }

        /// <summary>
        /// Procedimento para a primeira analise da Tabela Simplex;
        /// </summary>
        /// <param name="Tabela"> Tabela Simplex gerada na função CriaTabela</param>
        /// <param name="ValorVariaveis"> Matriz que contém valores das respectivas variaveis (linha1: x1, x2, etc; linha2: 20, 30, etc)</param>
        private  void AnaliseFase1(float[,] Tabela, string[,] ValorVariaveis)
        {
            bool EstadoAtipico = false;    //Variavel que verifica se tabela vai gerar um estado diferente do 'caminho perfeito', ou seja, se recebera respostas diferentes da Solução Ótima; 
            int controle = 0, ControleLinha = 0, ControleColuna = 0;
            //Controle: Verificar estados da tabela (Seguir segunda etapa, Solução Impossível ou Algoritmo de troca);
            //ControleLinha: Verifica se existe valor negativo na Coluna "Menbro Livre";
            //ControleLinha(depois)/ControleColuna: Variaveis que contem valor da Linha Permissiva e Coluna Permissiva;
            float EP = 0, VerificaEP = (Tabela[0, 0] * Tabela[0, 0]);
            //EP: Elemento Permitido;
            //VerificaEP: Verifica qual é o valor permissivo na tabela, recebendo maior valor na tabela para a verificação mais a frente;
            if (VerificaEP < 0)      //Caso valor recebido de VerificaEP seja negativo, necessario coloca-lo positivo para verificação;
                VerificaEP = -(VerificaEP);
            if (VerificaEP == 0)      //Caso valor recebido de VerificaEP seja igual a zero, necessario colocar outro valor para verificação;
                VerificaEP = (Tabela[1, 0] * Tabela[1, 0]);
            float[] VetLinhaPermitida = new float[Tabela.GetLength(1)];    //Vetor com valores da Linha Permitida (Membro Livre, Variaveis Não Basicas);
            float[] VetColunaPermitida = new float[Tabela.GetLength(0)];   //Vetor com valores da Coluna Permitida (f(x), Variaveis Basicas);


            txtfase.Text="** 1ª FASE DO MÉTODO**";
                      
            MessageBox.Show("Pressione OK para processar a primeira fase do método !!!");
            
            for (int Linha = 1; Linha < Tabela.GetLength(0); Linha++)
                if (Tabela[Linha, 0] < 0)
                {
                    controle = 0;
                    ControleLinha = Linha;
                }
                else
                    controle = 1;
            if ((controle == 1) && (ControleLinha == 0))
            {
               txtresult2.Text="Não foi encontrado valores negativos na coluna de Membros Livres !!!";
               MessageBox.Show("Pressione uma tecla para prosseguir á próxima etapa.");
               AnaliseFase2(Tabela, ValorVariaveis);
            }
            else
            {
                controle = 0;
                for (int Produtos = 0; Produtos < Tabela.GetLength(1) - 1; Produtos++)  //FOR para verificar se Linha contem algum valor negativo para Variaveis Não Basicas;
                {
                    if (Tabela[ControleLinha, Produtos + 1] < 0)   //Se ouver valor negativo na Linha encontrada, armazenar a Coluna Permissiva;
                    {
                        controle = 0;                              //Verificar se solução é impossivel ou necessário chamar Algoritmo de Troca;
                        ControleColuna = (Produtos + 1);           //Adiciona valor da Coluna Permissiva;
                       for (int cont = 0; cont < VetColunaPermitida.Length; cont++)
                            VetColunaPermitida[cont] = Tabela[cont, Produtos + 1];   //Adiciona valores da Coluna Permissiva respectivas ao f(x) e Variaveis Basicas;
                    }
                    else
                        controle = controle + 2;
                }
                if (controle / (Tabela.GetLength(1) - 1) == 2) //Se Linha não conter nenhum valor negativo para Variaveis Não Basicas, não existe Solução Otima;
                {
                    EstadoAtipico = true; //Variavel verificadora de estado da Tabela Simplex é ativado;
                    txtresult.Text="SOLUÇÃO IMPOSSÍVEL (PERMISSIVA NÃO EXISTE)";
                    txtresult2.Text="Ao procurarmos algum elemento negativo na linha que corresponde à variável\ncom membro livre negativo encontrou-se elementos positivos ou iguais a 0 !!!";
                    MessageBox.Show("Pressione ok para continuar!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    Resultado(Tabela, ValorVariaveis, EstadoAtipico); //Chama procedimento para demonstrar Tabela Simplex obtida;
                }
                else
                {
                    for (int cont = 1; cont < Tabela.GetLength(0); cont++)  //Verificar a Linha Permitida e adicionar seus valores no vetor, além de encontrar o EP;
                    {
                        if (VerificaEP >= Tabela[cont, 0] / VetColunaPermitida[cont])
                        {
                            if ((Tabela[cont, 0] < 0) && (VetColunaPermitida[cont] < 0) || (Tabela[cont, 0] >= 0) && (VetColunaPermitida[cont] > 0))
                            {
                                VerificaEP = Tabela[cont, 0] / VetColunaPermitida[cont];
                                EP = VetColunaPermitida[cont];                  //Adiciona o EP (Elemento Permissivo);
                                ControleLinha = cont;                           //Adiciona valor da Linha Permissiva;
                                for (int cont2 = 0; cont2 < VetLinhaPermitida.Length; cont2++)
                                    VetLinhaPermitida[cont2] = Tabela[cont, cont2];  //Adiciona valores da Linha Permissiva respectivas ao Menbro Livre e Variaveis Não Basicas;
                            }
                        }
                    }
                    txtresult.Text="Algoritmo de Troca será executado.";
                    MessageBox.Show("Pressione ok para continuar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AlgoritmoTroca(Tabela, VetLinhaPermitida, VetColunaPermitida, ValorVariaveis, EP, ControleLinha, ControleColuna); //Chamar procedimento do Algoritmo de Troca da Tabela Simplex;
                    AnaliseFase1(Tabela, ValorVariaveis); //Necessário analisar a Nova Tabela antes de passar para 2ª fase;
                }
            }
       
        }
        /// <summary>
        /// Procedimento para a Segunda analise da Tabela Simplex;
        /// </summary>
        /// <param name="Tabela"> Tabela Simplex gerada na função CriaTabela</param>
        /// <param name="ValorVariaveis"> Matriz que contém valores das respectivas variaveis (linha1: x1, x2, etc; linha2: 20, 30, etc)</param>
        private  void AnaliseFase2(float[,] Tabela, string[,] ValorVariaveis)
        {
            bool EstadoAtipico = false;
            int controle = 0, ControleLinha = 0, ControleColuna = 0;
            //Controle: Verificar estados da tabela(Seguir segunda etapa, Solução Impossível ou Algoritmo de troca);
            //ControleLinha: Verifica se existe valor negativo na Coluna "Menbro Livre";
            //ControleLinha(depois)/ControleColuna: Variaveis que contem valor da Linha Permissiva e Coluna Permissiva;
            float EP = 0, VerificaEP = Tabela[0, 0];
            //EP: Elemento Permitido;
            //VerificaEP: Verifica qual é o valor permissivo na tabela, recebendo maior valor na tabela para a verificação mais a frente;
            if (VerificaEP < 0) //Caso valor recebido de VerificaEP seja negativo, necessario coloca-lo positivo para verificação;
                VerificaEP = -(VerificaEP); //Caso valor recebido de VerificaEP seja igual a zero, necessario colocar outro valor para verificação;
            float[] VetLinhaPermitida = new float[Tabela.GetLength(1)];
            float[] VetColunaPermitida = new float[Tabela.GetLength(0)];

            txtfase.Text="2ª FASE DO MÉTODO";
            MessageBox.Show("Pressione ok para processar a segunda fase do método !!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int Coluna = 1; Coluna < Tabela.GetLength(1); Coluna++)     //Necessário verificar estado da Tabela;
            {
                if ((Tabela[0, Coluna] > 0) && (controle != -1))         //Verificar se existe valores positivos na Linha f(x)
                {
                    controle = 0;
                    ControleColuna = Coluna;          //Necessário verificar Coluna que ouver valores negativos, além de armazenar o valor da Coluna Permissiva;
                }
                else if (Tabela[0, Coluna] == 0)      //Verificar se existe valores nulos na Linha f(x)
                    controle = -1;
                else if (controle != -1)              //Verificar se existe valores negativos na Linha f(x)
                    controle = 1;
            }
            if ((controle == 1) && (ControleColuna == 0))
            {
                txtresult.Text="SOLUÇÃO ÓTIMA OBTIDA";
                txtresult2.Text="Foi encontrado a tabela que corresponde á solução ótima !!!";

                MessageBox.Show("Pressione ok para para continuar  !!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Resultado(Tabela, ValorVariaveis, EstadoAtipico);
            }
            else if ((controle == -1) && (ControleColuna == 0))
            {
                EstadoAtipico = true; //Variavel verificadora de estado da Tabela Simplex é ativado;
                txtresult.Text ="MÚLTIPLAS SOLUÇÕES";
                txtresult2.Text = "Foi encontrado elemento zero (não consideramos o membro livre) na linha F(x) !!!";

                MessageBox.Show("Pressione ok para para continuar  !!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Resultado(Tabela, ValorVariaveis, EstadoAtipico); //Chama procedimento para demonstrar Tabela Simplex obtida;
            }
            else
            {
                controle = 0;
                for (int cont = 0; cont < VetColunaPermitida.Length; cont++)  //FOR para preencher vetor com valores da Coluna Permissiva;
                    VetColunaPermitida[cont] = Tabela[cont, ControleColuna];
                for (int cont = 1; cont < Tabela.GetLength(0); cont++)        //FOR para verificar se Coluna Permissiva contem algum valor negativo, além de encontrar o EP;
                {
                    if (VetColunaPermitida[cont] < 0)
                        controle = controle + 2;
                    else if ((Tabela[cont, 0] < 0) && (VetColunaPermitida[cont] < 0) || (Tabela[cont, 0] >= 0) && (VetColunaPermitida[cont] > 0))
                    {
                        controle = 0;
                        if (VerificaEP >= Tabela[cont, 0] / VetColunaPermitida[cont])
                        {
                            VerificaEP = Tabela[cont, 0] / VetColunaPermitida[cont];
                            EP = VetColunaPermitida[cont];                        //Adiciona o EP (Elemento Permissivo);
                            ControleLinha = cont;                                 //Adiciona valor da Linha Permissiva;
                            for (int cont2 = 0; cont2 < VetLinhaPermitida.Length; cont2++)
                                VetLinhaPermitida[cont2] = Tabela[cont, cont2];   //Adiciona valores da Linha Permissiva respectivas ao Menbro Livre e Variaveis Não Basicas;
                        }
                    }
                }
                if (controle / (Tabela.GetLength(0) - 1) == 2) //Se ouver valores positivos no Membro Livre então Solução é Ilimitada;
                {
                    EstadoAtipico = true; //Variavel verificadora de estado da Tabela Simplex é ativado;
                    txtresult.Text = "SOLUÇÃO ILIMITADA";


                    txtresult2.Text = "Na coluna permitida encontrada, todos os elementos correspondentes ás variáveis básicas são negativas !!!";
                    MessageBox.Show("Pressione ok para para continuar  !!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Resultado(Tabela, ValorVariaveis, EstadoAtipico); //Chama procedimento para demonstrar Tabela Simplex obtida;
                }
                else
                {

                   txtfase.Text="Algoritmo de Troca será executado.";

                    MessageBox.Show("Pressione ok para para continuar  !!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AlgoritmoTroca(Tabela, VetLinhaPermitida, VetColunaPermitida, ValorVariaveis, EP, ControleLinha, ControleColuna);  //Chamar procedimento do Algoritmo de Troca da Tabela Simplex;
                    AnaliseFase2(Tabela, ValorVariaveis);    //Necessário analisar a Nova Tabela para encontrar o resultado final da Tabela Simplex;
                }
            }
        }

        /// <summary>
        /// Algoritmo de Troca da Tabela Simplex;
        /// </summary>
        /// <param name="Tabela"> Tabela Simplex verificada nos procedimentos Fase1 e Fase2</param>
        /// <param name="VetLinhaPermitida"> Linha Permissiva obtida na tabela</param>
        /// <param name="VetColunaPermitida"> Coluna Permissiva obtida na tabela</param>
        /// <param name="ValorVariaveis"> Matriz com variaveis e respectivos valores</param>
        /// <param name="EP"> Elemento Permitido</param>
        /// <param name="ControleLinha"> Variavel que contem valor da Linha Permissiva</param>
        /// <param name="ControleColuna"> Variavel que contem valor da Coluna Permissiva</param>
        private void AlgoritmoTroca(float[,] Tabela, float[] VetLinhaPermitida, float[] VetColunaPermitida, string[,] ValorVariaveis, float EP, int ControleLinha, int ControleColuna)
        {
            float[] SubCelulasColuna = new float[VetColunaPermitida.Length];             //Vetor que contem os valores da sub-células Inferiores da Coluna Permitida;
            float[,] NovaTabela = new float[Tabela.GetLength(0), Tabela.GetLength(1)];   //Matriz que receberá os novos valores advindos dos cálculos da Tabela Simplex recebida;
            for (int L = 0; L < Tabela.GetLength(0); L++)      //FOR que preenche o vetor SubCelulaColuna e parte da Nova Tabela Simplex;
            {
                for (int C = 0; C < Tabela.GetLength(1); C++)  //Preenchimento da Linha Permitida e Coluna Permitida da Nova Tabela SImplex; 
                {
                    if ((Tabela[L, C] == VetLinhaPermitida[C]) && (ControleLinha == L))         //Multiplica-se toda a linha pelo EP Inverso;
                        NovaTabela[L, C] = VetLinhaPermitida[C] * (1 / EP);
                    if ((Tabela[L, C] == VetColunaPermitida[L]) && (ControleColuna == C))       //Multiplica-se toda a coluna pelo - (EP Inverso)
                    {
                        NovaTabela[L, C] = VetColunaPermitida[L] * -(1 / EP);
                        SubCelulasColuna[L] = NovaTabela[L, C];
                    }
                    if ((Tabela[L, C] == EP) && (ControleLinha == L) && (ControleColuna == C))  //Calcula-se o inverso do Elemento Permitido;
                    {
                        NovaTabela[L, C] = 1 / EP;
                        SubCelulasColuna[L] = NovaTabela[L, C];
                    }
                }
            }
            for (int L = 0; L < Tabela.GetLength(0); L++)      //FOR que termina de preencher a Nova Tabela Simplex utilizando dos valores da SubCelula;
            {
                for (int C = 0; C < Tabela.GetLength(1); C++)
                {
                    if ((C != ControleColuna) && (L != ControleLinha))   //IF que verifica se célula da Nova Tabela ja foi preenchida anteriormente, se estiver vazia então executa os procedimento;
                    {
                        NovaTabela[L, C] = SubCelulasColuna[L] * VetLinhaPermitida[C];  //Multiplica-se a (SCS) marcada em sua respectiva coluna com a (SCI) marcada de sua respectiva linha;
                        NovaTabela[L, C] = Tabela[L, C] + NovaTabela[L, C];             //Somam-se as (SCI) com as (SCS) das demais células restantes da tabela original;
                    }
                }
            }
            for (int L = 0; L < Tabela.GetLength(0); L++)      //FOR repassa novos valores obtidos para a Tabela Simplex original;
                for (int C = 0; C < Tabela.GetLength(1); C++)
                    Tabela[L, C] = NovaTabela[L, C];

            //Após executar procedimento de troca necessário trocar de posição a variável não básica com a variável básica, ambas definidas como “Permitidas na tabela anterior;
            int aux = 1;            //Variavel auxiliar para verificar os valores das variaveis básicas na tabela simplex;
            string variavel = "";   //Variavel auxiliar que receberá a variavel da Coluna Permitida que será trocada pela variavel da Linha Permitida;
            for (int cont = 0; cont < ValorVariaveis.GetLength(1); cont++)
            {
                if (cont < (Tabela.GetLength(1) - 1))
                    ValorVariaveis[1, cont] = string.Concat(Tabela[0, cont + 1]);   //Adicionando na linha2 os valores respectivos as variaveis não-básicas;
                else
                {
                    ValorVariaveis[1, cont] = string.Concat(Tabela[aux, 0]);        //Adicionando na linha2 os valores respectivos as variaveis básicas;
                    aux++;
                }
            }
            if (string.Concat(Tabela[0, ControleColuna]) == ValorVariaveis[1, ControleColuna - 1])   //Verifica valor da variavel não basica que será trocada;
            {
                aux = ControleColuna - 1;            //'-1' para eliminar a coluna "Membro Livre", aux recebe o valor da coluna que contem a variavel que será trocada;
                variavel = ValorVariaveis[0, aux];   //Variavel auxiliar recebe a variavel não basica que será trocada;
            }
            for (int cont = 0; cont < ValorVariaveis.GetLength(1); cont++)                          //Verifica valor da variavel basica que será trocada;
            {
                if ((string.Concat(Tabela[ControleLinha, 0]) == ValorVariaveis[1, cont]) && (cont >= (Tabela.GetLength(1) - 1)))
                {
                    ValorVariaveis[0, aux] = ValorVariaveis[0, cont];  //Troca da variavel nao basica pela basica;
                    aux = cont;                                        //aux recebe o valor da coluna que contem a variavel que será trocada;
                }
            }
            ValorVariaveis[0, aux] = variavel;   //Troca da variavel basica pela não basica;
            
            txtresult.Text="Impressão dos novos valores das variáveis!";
            txtresultvalores.Clear();
            for (int L = 0; L < ValorVariaveis.GetLength(0); L++)
            {
                if(L>0)
                {
                   txtresultvalores.Text= txtresultvalores.Text+ Environment.NewLine; 
                }
                
                for (int C = 0; C < ValorVariaveis.GetLength(1); C++)
                    txtresultvalores.Text= txtresultvalores.Text + " " +(ValorVariaveis[L, C] + "   ");
            }
            MessageBox.Show("Pressione ok para para continuar  !!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Procedimento que demonstra resultado obtido na Tabela;
        /// </summary>
        /// <param name="Tabela"> Tabela Simplex</param>
        /// <param name="ValorVariaveis"> Matriz que contém valores das respectivas variaveis</param>
        /// <param name="EstadoAtipico"> Variavel que verifica estado da Tabela Simplex (Solução Otima obtida ou não)</param>
        private void Resultado(float[,] Tabela, string[,] ValorVariaveis, bool EstadoAtipico)
        {
            if (EstadoAtipico == true) //Se nos procedimentos de analises foi encontrado algo átipico na Tabela Simplex demontrar a tabela sem resultados;
            {
                txtfase.Text="DEMONSTRAÇÃO TABELA";
                txtresult.Text="Estado atípico ocorrido !!!";
                txtresultvalores.Clear();
                for (int L = 0; L < Tabela.GetLength(0); L++)
                {
                    if (L > 0)
                    {
                        txtresultvalores.Text = txtresultvalores.Text + Environment.NewLine;
                    }

                    for (int C = 0; C < Tabela.GetLength(1); C++)
                    txtresultvalores.Text = txtresultvalores.Text+(Tabela[L, C].ToString("n2") + "     ");
                }                             
               
            }
            else
            {
                txtfase.Text = "DEMONSTRAÇÃO TABELA";
                txtresultvalores.Clear();
                for (int L = 0; L < Tabela.GetLength(0); L++)
                {
                    if (L > 0)
                    {
                        txtresultvalores.Text = txtresultvalores.Text + Environment.NewLine;
                    }
                    if (L > 0)
                   
                    for (int C = 0; C < Tabela.GetLength(1); C++)
                    txtresultvalores.Text = txtresultvalores.Text + Environment.NewLine + (Tabela[L, C].ToString("n2") + "     ");
                }

                txtresultvalores.Clear();
                if ((Tabela[0, 0]) < 0)
                    txtresult.Text= "RESPOSTAS:  Z = " + -(Tabela[0, 0]) +";";
                else
                    txtresult.Text = "RESPOSTAS:  Z = " +  (Tabela[0, 0]) + ";";

                for (int L = 0; L < ValorVariaveis.GetLength(0); L++)
                {
                    if (L > 0)
                    {
                        txtresultvalores.Text =  txtresultvalores.Text + Environment.NewLine;
                    }

                    for (int C = 0; C < ValorVariaveis.GetLength(1); C++)
                    {
                        if (L == 0)
                            txtresultvalores.Text = txtresultvalores.Text + (ValorVariaveis[L, C] + "    |    ");
                        if (L == 1)
                            if (float.Parse(ValorVariaveis[L, C]) < 0)
                                txtresultvalores.Text = txtresultvalores.Text + 0 + "       ";
                            else
                                txtresultvalores.Text = txtresultvalores.Text+ ValorVariaveis[L, C] + "      ";

                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
           
        }
    }
}
