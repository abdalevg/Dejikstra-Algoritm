using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Deiksta : Form
    {
       public static int Graph_Size = 0;

       public static int[,] Graph1 = null;

       public static int Point = 0;
       
       public static int StartPoint = 0;

       public static bool GraphIsSet = true;

       public Deiksta()
        {
            InitializeComponent();
        }

       private void Deiksta_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            dataGridView1.ColumnCount = 0;
           
            toolStripButton1.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            richTextBox1.ReadOnly = true;
            button3.Enabled = false;
            button4.Enabled = false;

            toolStripButton3.Enabled = false;
        }

       private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Graph_Size = int.Parse(toolStripTextBox2.Text);
            toolStripTextBox2.Enabled = false;
            dataGridView1.Enabled = true;
            toolStripButton4.Enabled = true;

            dataGridView1.ColumnCount = Graph_Size;
            dataGridView1.RowCount = Graph_Size;
                 
            for (int i = 0; i < Graph_Size; i++)
            {
                dataGridView1.Columns[i].Name = (i+1).ToString();
                         
                for (int j = 0; j < Graph_Size; j++)
                {
                    dataGridView1.Rows[i].Cells[j].ReadOnly = false;
                    if (i == j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0; ;
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
             }
        }

       private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
           
        }
      
       private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text == "")
            {
                toolStripButton1.Enabled = false;
            }
            else
            {
                toolStripButton1.Enabled = true;
                toolStripButton1.Select();
            }

        }

       private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

       private void toolStripButton4_Click(object sender, EventArgs e)
        {
              Graph1 = new int[Graph_Size, Graph_Size];
                      
              for (int i = 0; i < Graph_Size; i++)
                {
                    for (int j = 0; j < Graph_Size; j++)
                    {
                      Graph1[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }

               Methods1.CheckingGraph(ref Graph1, ref Graph_Size, ref GraphIsSet);

               if (GraphIsSet == true)
               {
                    for (int i = 0; i < Graph_Size; i++)
                {
                    for (int j = 0; j < Graph_Size; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
                   button1.Enabled = true;
                   button2.Enabled = true;
                   textBox1.Enabled = true;
                   textBox2.Enabled = true;

                   button1.Focus();

                   button3.Enabled = true;
                   button4.Enabled = true;

                   toolStripButton4.Enabled = false;
                   toolStripButton5.Enabled = true;
                   toolStripButton1.Enabled = false;

                   toolStripButton3.Enabled = true;//saving file
               }
       }

       private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string CellValue = dataGridView1.CurrentCell.Value.ToString();//check this
                string CellValue2 = "";

                if (CellValue != "")
                {
                    for (int i = 0; i < CellValue.Length; i++)
                    {
                        if ((CellValue[i] < '0' || CellValue[i] > '9') == false)
                        {
                            CellValue2 = CellValue2 + CellValue[i];
                        }

                    }
                    CellValue = CellValue2;
                }
                if (CellValue == "")
                {
                    this.dataGridView1.CurrentCell.Value = "0";
                    toolStripButton4.Select();
                }
                else
                {
                    this.dataGridView1.CurrentCell.Value = CellValue;
                    toolStripButton4.Select();
                }
            }
            catch (NullReferenceException)
            {
            }
                           
            }
       
       private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            dataGridView1.ColumnCount = 0;
            
            toolStripTextBox2.Enabled = true;
            toolStripTextBox2.ReadOnly = false;
            toolStripButton1.Enabled = true;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            GraphIsSet = false;
            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            toolStripButton3.Enabled = false;//saving file

            if (toolStripTextBox2.Text == "")
            {
                toolStripButton1.Enabled = false;
            }
            else
            {
                toolStripButton1.Enabled = true;
            }
        }

       private void toolStripTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if ((!Char.IsDigit(ch) && (ch != 8) && (ch != 32)))
            {
                e.Handled = true;
            }
        }

       private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int SP = int.Parse(textBox1.Text);

                if (SP != Point)
                {
                    StartPoint = int.Parse(textBox1.Text);
                    button2.Focus();
                    MessageBox.Show("StartPoint: " + StartPoint.ToString());
                }
                else
                {
                    MessageBox.Show("Start Point equals Point");
                }
             }
        }

       private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int SP = int.Parse(textBox2.Text);

                if (SP != StartPoint)
                {
                    Point = int.Parse(textBox2.Text);
                    button1.Focus();
                    MessageBox.Show("Point" + Point.ToString());
                }
                else
                {
                    MessageBox.Show("Point equals StartPoint");
                }
            }

        }

       private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (GraphIsSet == true)
            {
                int Row = dataGridView1.CurrentRow.Index;

                if (StartPoint == 0)
                {
                    button1.Focus();
                    textBox1.Text = (Row + 1).ToString();
                }
                if (Point == 0)
                {
                    textBox2.Text = (Row + 1).ToString();
                }

                if(StartPoint!=0 && Point==0)
                {
                    button2.Focus();
                }
            }
        }

       private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
       {
          
       }

       private void button3_Click(object sender, EventArgs e)
       {
           int[,] TempGraph1 = new int[Graph_Size, Graph_Size];
           int[,] Data = null;
           int[,] Ways = new int[Graph_Size-1,Graph_Size-1];
           int [] NamesofPoints=new int[Graph_Size-1];
           int[][] Points = new int[Graph_Size - 1][];
           string PrintTextBox1 = "";
           string PrintTextBox2 = ""; 

           Methods1.ChoiceOfElement(ref Graph1,ref Graph_Size,out TempGraph1,StartPoint);
           Methods1.AlteringGraphArray(ref TempGraph1, ref Graph_Size, out Data);
           Methods1.NamingPoints(ref Points, ref NamesofPoints, Graph_Size, StartPoint);
           Methods1.ShortestWays(ref Ways,ref Data,ref Points,ref NamesofPoints,ref TempGraph1,Graph_Size);
           Methods1.PrintResults(ref Ways, ref Points, ref NamesofPoints, Graph_Size, StartPoint, Point,ref PrintTextBox1,ref PrintTextBox2);
           richTextBox1.Text =PrintTextBox1+"\n"+PrintTextBox2;
       }

       private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
       {
           
                        
       }

       private void dataGridView1_EditModeChanged(object sender, EventArgs e)
       {
           /*string CellValue = dataGridView1.CurrentCell.Value.ToString();//check this
           string CellValue2 = "";

           if (CellValue != "")
           {
               for (int i = 0; i < CellValue.Length; i++)
               {
                   if ((CellValue[i] < '0' || CellValue[i] > '9') == false)
                   {
                       CellValue2 = CellValue2 + CellValue[i];
                   }

               }
               CellValue = CellValue2;
           }
           if (CellValue == "")
           {
               this.dataGridView1.CurrentCell.Value = "0";
               toolStripButton4.Select();
           }
           else
           {
               this.dataGridView1.CurrentCell.Value = CellValue;
               toolStripButton4.Select();
           }*/
                        
       }

       private void button4_Click(object sender, EventArgs e)
       {
           StartPoint = 0;
           Point = 0;
           textBox1.Text = StartPoint.ToString();
           textBox2.Text = Point.ToString();


       }

       private void toolStripButton3_Click(object sender, EventArgs e)
       {
           try
           {
               if (GraphIsSet == true)
               {
                   saveFileDialog1.ShowDialog();
                   BinaryWriter File = new BinaryWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create));
                   for (int i = 0; i < Graph_Size; i++)
                   {
                       for (int j = 0; j < Graph_Size; j++)
                       {
                           File.Write(Graph1[i, j]);
                       }
                   }
                   File.Close();
               }
               else
               {
                   MessageBox.Show("Graph has'nt been created yet");
               }
           }
           catch (Exception Except)
           {
               MessageBox.Show(" "+ Except.Message);
           }
       }

       private void toolStripButton2_Click(object sender, EventArgs e)
       {
           try
           {
               dataGridView1.Enabled = true;

               openFileDialog1.ShowDialog();
               FileStream f1 = new FileStream(openFileDialog1.FileName, FileMode.Open);
               BinaryReader file = new BinaryReader(f1);

               double Size1 =Math.Sqrt( f1.Length / 4);
               Graph_Size = Convert.ToInt32(Size1);
               toolStripTextBox2.Text = Graph_Size.ToString();


               int[] FileRead = new int[f1.Length / 4];
               
               Graph1 = new int[Graph_Size, Graph_Size];
               dataGridView1.RowCount = Graph_Size;
               dataGridView1.ColumnCount = Graph_Size;

               for (int i = 0; i < Graph_Size; i++)
               {
                   for (int j = 0; j < Graph_Size; j++)
                   {
                       Graph1[i, j] = file.ReadInt32();
                       dataGridView1.Rows[i].Cells[j].Value = Graph1[i, j];
                       //dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                   }
               }
               file.Close();
               f1.Close();
               toolStripButton1.Enabled = false;
               toolStripTextBox2.ReadOnly = true;
               toolStripButton4.Enabled = false;
               toolStripButton5.Enabled = true;
               GraphIsSet = true;
               MessageBox.Show("Graph is set");

               button1.Enabled = true;
               button2.Enabled = true;
               textBox1.Enabled = true;
               textBox2.Enabled = true;

               button1.Focus();

               button3.Enabled = true;
               button4.Enabled = true;

               toolStripButton3.Enabled = true;//saving file



           }
           catch(Exception except)
           {
               MessageBox.Show(except.Message);
           }
          
          
          
          
       }

   }
 

    public static class Methods1
 {
     /*public static void SettingGraph(out int[,] Graph, out int Size, out string[,] GraphPreview)
     {

         do
         {
             //Size = Dialog.Entersize("Введите кол-во вершин в графе");
         } while (Size < 0);

         Graph = new int[Size, Size];
         GraphPreview = new string[Size + 1, Size + 1];

         int StringSize = 2 * Size - 1;

         for (int a = 1; a < Size + 1; a++)
         {
             GraphPreview[0, a] = Convert.ToString(a);
             GraphPreview[a, 0] = Convert.ToString(a);
         }

         for (int i = 0; i < Size; i++)
         {
             try
             {
                 Console.WriteLine("Введите строку смежности для вершины №{0} через пробел", i + 1);
                 string Input = "";

                 Input = Console.ReadLine();

                 for (int t = 0; t < Input.Length; t++)
                 {
                     if (Input[t] == ' ' && Input[t - 1] == ' ')
                     {
                         Input = Input.Remove(t, 1);
                         t--;
                     }
                 }

                 string[] StringArray = Input.Split(' ');
                 if (StringArray.Length > Size)
                 {
                     Console.WriteLine("Неверный ввод");
                     i--;
                 }
                 else
                 {
                     for (int k = 0; k < Size; k++)
                     {
                         if (StringArray[k] != "б")
                         {
                             Graph[i, k] = Convert.ToInt32(StringArray[k]);
                             if (Graph[i, k] > 100)
                             {
                                 Graph[i, k] = 100;
                             }
                         }
                         else
                         {
                             Graph[i, k] = 1000;
                         }
                         if (Graph[i, k] >= 0)
                         {
                             GraphPreview[i + 1, k + 1] = StringArray[k];
                         }
                         else
                         {
                             int Temp = Graph[i, k];
                             Graph[i, k] = Temp * -1;
                             GraphPreview[i + 1, k + 1] = Convert.ToString(Graph[i, k]);
                         }
                     }
                 }


             }
             catch (FormatException)
             {
                 Console.WriteLine("Неверный ввод");
                 i--;
             }
             catch (OverflowException)
             {
                 Console.WriteLine("Неверный ввод");
                 i--;
             }
             catch (IndexOutOfRangeException)
             {
                 Console.WriteLine("Неверный ввод");
                 i--;
             }


         }

         Console.WriteLine("Граф:");
         for (int g = 0; g < Size + 1; g++)
         {
             for (int h = 0; h < Size + 1; h++)
             {
                 Console.Write(GraphPreview[g, h] + " ");
             }
             Console.WriteLine();
         }

     }*/

     public static void AlteringGraphArray(ref int[,] TempGraph, ref int Size, out int[,] Data)
     {
         int[,] TempArray1 = new int[Size - 1, Size];
         int[,] TempArray2 = new int[Size - 1, Size - 1];
         for (int i = 0; i < Size - 1; i++)
         {
             for (int j = 0; j < Size; j++)
             {
                 TempArray1[i, j] = TempGraph[i + 1, j];
             }
         }
         for (int k = 0; k < Size - 1; k++)
         {
             for (int l = 0; l < Size - 1; l++)
             {
                 TempArray1[k, l] = TempArray1[k, l + 1];
                 TempArray1[k, l + 1] = TempArray1[k, l];
             }
         }
         for (int x = 0; x < Size - 1; x++)
         {
             for (int y = 0; y < Size - 1; y++)
             {
                 TempArray2[x, y] = TempArray1[x, y];
             }

         }
         Data = TempArray2;
         //MessageBox.Show(Data.GetLength(0).ToString());
  

     }

     public static void CheckingGraph(ref int[,] Graph, ref int Size, ref bool Key)
     {
         Key = true;
         for (int i = 0; i < Size; i++)//Check if graph has been set correctly//
         {
             for (int j = 0; j < Size; j++)
             {
                 if (Graph[i, j] != Graph[j, i])
                 {
                     Key = false;
                 }
             }
         }
         if (Key == false)
         {
             MessageBox.Show("Graph is not valid");
         }
         else
         {
             MessageBox.Show("Graph is set");
         }
     }

     public static void ChoiceOfElement(ref int[,] Graph, ref int Size, out int[,] TempGraph, int Option)
     {
         TempGraph = new int[Size, Size];
         for (int i = 0; i < Size; i++)
         {
             for (int j = 0; j < Size; j++)
             {
                 TempGraph[i, j] = Graph[i, j];
             }
         }
         
         for (int k = Option - 1; k > 0; k--)
         {
             for (int l = 0; l < Size; l++)
             {
                 int Temp;
                 Temp = TempGraph[k, l];
                 TempGraph[k, l] = TempGraph[k - 1, l];
                 TempGraph[k - 1, l] = Temp;

             }

         }
         for (int x = 0; x < Size; x++)
         {
             for (int y = Option - 1; y > 0; y--)
             {
                 int Temp;
                 Temp = TempGraph[x, y];
                 TempGraph[x, y] = TempGraph[x, y - 1];
                 TempGraph[x, y - 1] = Temp;
             }
         }

     }

     public static void CheckingPoints(ref int[][] Points, int Size, int y, int PointNumber, ref int[] NamesOfPoints)
     {
         //Defining Ways//

         Points[y] = new int[Points[PointNumber].Length + 1];

         for (int t = 0; t < Points[y].Length; t++)
         {
             if (t < Points[PointNumber].Length)
             {
                 Points[y][t] = Points[PointNumber][t];
             }
             else
             {
                 Points[y][t] = NamesOfPoints[y];
             }
         }

     }

     public static void PrintResults(ref int[,] Ways, ref int[][] Points, ref int[] NamesOfPoints, int Size, int Option, int Option2,ref string Print2,ref string Print3)
     {
         string[] Results = new string[Size - 1];
         for (int j = 0; j < Size - 1; j++)
         {
             if (Ways[Size - 2, j] == 1000)
             {
                 Results[j] = "б";
             }
             else
             {
                 Results[j] = Convert.ToString(Ways[Size - 2, j]);
             }
         }
         
         for (int f = 0; f < Size - 1; f++)
         {
             if (NamesOfPoints[f] == Option2)
             {
                 //Console.WriteLine("Путь: ");
                 string[] PrintResultsArray = new string[Points[f].Length + 1];
                 PrintResultsArray[0] = Convert.ToString(Option);
                 for (int i = 0; i < Points[f].Length; i++)
                 {
                     PrintResultsArray[i + 1] = Convert.ToString(Points[f][i]);
                 }
                 string Print1 = "";
                 for (int j = 0; j < Points[f].Length + 1; j++)
                 {
                     Print1 = Print1 + PrintResultsArray[j] + "-";
                 }

                  Print2 ="Путь"+ Print1.Remove(Print1.Length-1,1);
                  Print3= "Расстояние: " + Results[f];
             }

             
         
    }
     }
    
     public static void ShortestWays(ref int[,] Ways, ref int[,] Data, ref int[][] Points, ref int[] NamesOfPoints, ref int[,] TempGraph, int Size)
     {
         bool[] CheckedPoints = new bool[Size - 1];
         int PointNumber = 0;

         for (int k = 0; k < Size - 1; k++)
         {
             Ways[0, k] = TempGraph[0, k + 1];

         }

         //Defining Initial Point//
         CheckedPoints[0] = true;
         for (int l = 0; l < Size - 1; l++)
         {
             if (Ways[0, l] < Ways[0, 0])
             {
                 PointNumber = l;
                 CheckedPoints[l] = true;
                 CheckedPoints[0] = false;
             }
         }


         for (int x = 1; x < Size - 1; x++)
         {
             for (int y = 0; y < Size - 1; y++)
             {
                 if (Data[PointNumber, y] + Ways[x - 1, PointNumber] < Ways[x - 1, y] && Data[PointNumber, y] != 0)
                 {
                    Ways[x, y] = Data[PointNumber, y] + Ways[x-1, PointNumber];
                    Methods1.CheckingPoints(ref Points, Size, y, PointNumber, ref NamesOfPoints);
                 }
                 else
                 {
                     Ways[x, y] = Ways[x - 1, y];
                 }

             }

             PointNumber = x;
             CheckedPoints[x] = true;
             for (int z = 0; z < Size - 1; z++)
             {
                 if (Ways[x, z] < Ways[x, PointNumber] && CheckedPoints[z] == false)
                 {
                     PointNumber = z;
                     CheckedPoints[z] = true;
                     CheckedPoints[x] = false;

                 }
             }

         }
     }

     public static void NamingPoints(ref int[][] Points, ref int[] NamesOfPoints, int Size, int Option)
     {
         int[] TempNames = new int[Size];
         for (int q = 0; q < Size; q++)
         {
             if (q != Option - 1)
             {
                 TempNames[q] = q + 1;
             }
         }
         for (int z = 0; z < Size; z++)
         {
             if (TempNames[z] == 0)
             {
                 for (int a = z; a < Size - 1; a++)
                 {
                     TempNames[a] = TempNames[a + 1];
                     TempNames[a + 1] = TempNames[a];
                 }
             }
         }
         for (int e = 0; e < Size - 1; e++)
         {
             NamesOfPoints[e] = TempNames[e];
         }

         for (int r = 0; r < Size - 1; r++)//Initial Ways//
         {
             Points[r] = new int[1];
             Points[r][0] = NamesOfPoints[r];
         }
     }
 }

}

     
