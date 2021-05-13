using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            Task task1 = Task.Factory.StartNew(
                () =>

                {
                    for (int i = 0; i <= 30; i++)
                    {
                        Thread.Sleep(300);
                        label1.Text = i.ToString();
                    }
                });

            Task task2 = Task.Factory.StartNew(
              () =>

              {
                  for (int i = 0; i <= 30; i++)
                  {
                      Thread.Sleep(200);
                      label2.Text = i.ToString();
                  }
              });
        }


        int j, k, h;


        private void buttonStart2_Click(object sender, EventArgs e)
        {
            Task task1 = Task.Factory.StartNew(() =>

            {
                counter1();
            }
            );

            Task task2 = Task.Factory.StartNew(() =>

            {
                counter2();
                //task1.Wait(); // pause the task         

            }
           ).ContinueWith((task3) => // starts working after task 2 finishes
           {
               counter3();
               if (task3.IsCompleted == true)
               {
                   MessageBox.Show("Task completed");
               }
           });
            Task.Factory.StartNew(() => // chield task starts at the same time with parent task
            {
                
                    counter4();
                
            }, TaskCreationOptions.AttachedToParent); 


        }

        private void counter1()
        {
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(200);
                label3.Invoke(new counter1_delegate(new_counter1));

            }
        }

        private void counter2()
        {
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(300);
                label4.Invoke(new counter2_delegate(new_counter2));

            }
        }

        private void counter3()
        {
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(300);
                label4.Invoke(new counter3_delegate(new_counter3));

            }
        }

        private void counter4()
        {
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(100);
                label6.Invoke(new counter4_delegate(new_counter4));

            }
        }
        private delegate void counter1_delegate();

        private void new_counter1()
        {
            j++;
            label3.Text = j.ToString();
        }

        private delegate void counter2_delegate();

        private void new_counter2()
        {
            k++;
            label4.Text = k.ToString();
        }

        private delegate void counter3_delegate();

        private void new_counter3()
        {
            k++;
            label5.Text = k.ToString();
        }

        private delegate void counter4_delegate();

        private void new_counter4()
        {
            h++;
            label6.Text = h.ToString();
        }
    }
}
