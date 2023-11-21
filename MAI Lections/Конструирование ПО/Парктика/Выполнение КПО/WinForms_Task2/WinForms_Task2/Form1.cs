namespace WinForms_Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int space = 0;
        bool makeLetterUpcase = false;

        // ������� ��� ���, ��� ������������ � ���� �������:
        /*
         * ��� Event ��� EventHandler (�������) �#'�. 
         * ��� ���� ����� ������������ ������� � ��������� �����������.
         * 
         * ������ ������, ���� �����-�� ��������, �����-�� �������, ��� �������� �������.
         * ��� ������� �� ����� ������ �� �������� ��������, ��� ��������� �� �������.
         * ��� �� �����, ��� � ���� �������, ��� �� �������, ������ ������ � ���, ��� ���������� �������.
         * � ������ � ����� ��, ��� �� ��� ������� ��������.
         * 
         * ��������� ��� ������� - ��� ��� ����� �����������.
         */

        private void textBox1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (sender is not TextBox textBox1)
                return;

            if (Char.IsLetter(e.KeyChar) || (e.KeyChar == ' ')) // ���� ������ ������ ������, ���� - ����� 
            {
                if (textBox1.SelectionStart == 0) // SelectionStart - ��� ��������� �������, ������� ��� ������������ ��� ����������� ��������� �� KeyUp
                                                  // Selection ���� �����, ����� ����� ����� ������ ����� �����, ������ ��� �����
                {
                    if (e.KeyChar == ' ') // �� � Selection, ��-���� ������� ��. ��������� �������� ������ ������ ������� ��
                        e.Handled = true; // ���������� ���� ������, ���� ������� �� ��
                    else // ���� ��� �� ��������,
                        e.KeyChar = Char.ToUpper(e.KeyChar);
                }
                else if (makeLetterUpcase)
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                    makeLetterUpcase = false; // ���� ����� ��������������� � �������... ���� ��� ���� ����� ������ �� ����������.
                }
                else if (e.KeyChar == ' ') // ������� ������ - ������
                {
                    if (space == 0) // ��� ������ ������
                        space++;
                    else
                        e.Handled = true; // ���������� ���� ������
                }
                else if (space > 0) // ��� ��� ������, � ������ ��������� ������� - ��������
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                    space++; // � ��������� ������ ���� �����, � ������ ���������� ������
                }
            }
            else if (e.KeyChar == '-')
            {
                makeLetterUpcase = true;
            }
            else
                e.Handled = true; // ���������� ���� ������
        }

        private void textBox1_KeyUp(object? sender, KeyEventArgs e)
        {
            if (sender is not TextBox textBox1)
                return;

            if (space == 2)
            {
                textBox1.AppendText(".");
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
            if (space == 3)
            {
                textBox1.AppendText(".");
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
                space = 0;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox used = new()
            {
                Width = 200,
                Height = 50,
                Location = new Point(100, 100)
            };
            Controls.Add(used);
            used.KeyPress += textBox1_KeyPress;
            used.KeyUp += textBox1_KeyUp;
        }
    }
}