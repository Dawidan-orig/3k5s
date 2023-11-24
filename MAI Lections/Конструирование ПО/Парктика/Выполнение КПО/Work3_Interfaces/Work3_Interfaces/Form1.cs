using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Work3_Interfaces
{
    public partial class Form1 : Form
    {
        MiniList<CheckBox> v;
        IEnumerator<CheckBox> ven;
        IEnumerator<CheckBox> vn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        class MiniList<T> : IEnumerable<T>
        {
            static int num = 0;
            public Node Top;
            public class Node
            {
                public T content;
                public Node Next = null;
            }
            public int Append(T s)
            {
                Node p = new Node();
                p.content = s;
                if (Top != null) p.Next = Top;
                Top = p;
                return num++;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new Numerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public class Numerator : IEnumerator<T>
            {
                bool active = false;
                MiniList<T> lst;
                MiniList<T>.Node current = null;
                public Numerator(MiniList<T> vl)
                {
                    lst = vl;
                }
                T IEnumerator<T>.Current
                {
                    get
                    {
                        if (current == null || !active) throw new InvalidOperationException();
                        else return current.content;
                    }
                }
                object IEnumerator.Current
                {
                    get
                    {
                        if (current == null || !active) throw new InvalidOperationException();
                        else return current.content;
                    }
                }
                public bool MoveNext()
                {
                    if (active)
                        if (current.Next == null) return false;
                        else current = current.Next;
                    else
                        if (lst.Top != null)
                    {
                        active = true;
                        current = lst.Top;
                    }
                    else throw new Exception("List is empty");
                    return true;
                }
                public void Reset()
                {
                    active = false;
                    current = lst.Top;
                }
                public void Dispose() { current = null; }
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            v = new MiniList<CheckBox>();
            toolStripStatusLabel1.Text = "Список создан.";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (v != null)
            {
                CheckBox vcb = new CheckBox();
                vcb.Appearance = Appearance.Button;
                vcb.FlatStyle = FlatStyle.Standard;
                vcb.Top = 50;
                vcb.Width = 30;
                vcb.Left = 40 * v.Append(vcb);
                vcb.Text = Convert.ToString(vcb.Left);
                this.panel1.Controls.Add(vcb);
                toolStripStatusLabel1.Text = "";
            }
            else toolStripStatusLabel1.Text = "Список не создан.";
        }

        private void CheckElements_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void создатьЭнумераторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ven = v.GetEnumerator();
            toolStripStatusLabel1.Text = "Энумератор создан.";
        }

        private void moveNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ven != null)
                    if (ven.MoveNext())
                    {
                        ven.Current.CheckState = CheckState.Checked;
                        toolStripStatusLabel1.Text = "O.K.";
                    }
                    else toolStripStatusLabel1.Text = "Конец списка!";
                else toolStripStatusLabel1.Text = "Энумератор не создан!";
            }
            catch (Exception) { toolStripStatusLabel1.Text = "Список пуст!"; }
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ven != null)
                    if (ven.Current.Checked)
                        ven.Current.CheckState = CheckState.Unchecked;
                    else ven.Current.CheckState = CheckState.Checked;
                else toolStripStatusLabel1.Text = "Энумератор не создан!";
            }
            catch (InvalidOperationException) { toolStripStatusLabel1.Text = "Перебор не начат!"; }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            if (ven != null) { ven.Reset(); toolStripStatusLabel1.Text = "Энумератор обновлён!"; }
            else toolStripStatusLabel1.Text = "Энумератор не создан!";
        }

        private void toolStripStatusLabel1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            vn = v.GetEnumerator();
            toolStripStatusLabel1.Text = "Энумератор создан.";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                if (vn != null)
                    if (vn.MoveNext())
                    {
                        (vn.Current as CheckBox).CheckState = CheckState.Checked;
                        toolStripStatusLabel1.Text = "O.K.";
                    }
                    else toolStripStatusLabel1.Text = "Конец списка!";
                else toolStripStatusLabel1.Text = "Энумератор объектов не создан!";
            }
            catch (Exception) { toolStripStatusLabel1.Text = "Список пуст!"; }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                if (vn != null)
                    if ((vn.Current as CheckBox).Checked)
                        (vn.Current as CheckBox).CheckState = CheckState.Unchecked;
                    else (vn.Current as CheckBox).CheckState = CheckState.Checked;
                else toolStripStatusLabel1.Text = "Энумератор объектов не создан!";
            }
            catch (InvalidOperationException)
            {
                toolStripStatusLabel1.Text = "Перебор не начат!";
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            if (vn != null) { vn.Reset(); toolStripStatusLabel1.Text = "Энумератор объектов обновлён!"; }
            else toolStripStatusLabel1.Text = "Энумератор объектов не создан!";
        }
    }
}
