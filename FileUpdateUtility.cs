using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace CSVFileUpdater
{
    public partial class FileUpdateUtility
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public FileUpdateUtility()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            InitializeComponent();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string FName = "./IDStore.csv";
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        private bool ReadError = false;
        private bool FileLoading = false;
        private string SLOpenFName = "";
        private string tablename = "Export";
        private DataSet DataSet1;
        private Point HomeLoc = new Point(10, 60);
        private Size BasicSize = new Size(1400, 900);

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet1 = new DataSet();
            // Me.Location = HomeLoc
            // Me.Size = BasicSize
            // Me.Show()
            // Me.Refresh()
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SaveDataGrid();
            Close();
        }

        private void SaveDataGrid()
        {
            var textstr = new System.Text.StringBuilder();
            for (int x = 0, loopTo = DataGridView1.Rows.Count - 1; x <= loopTo; x++)
            {
                if (Information.IsNothing(DataGridView1.Rows[x].Cells[0].Value) == false)
                {
                    for (int v = 0, loopTo1 = DataGridView1.Columns.Count - 1; v <= loopTo1; v++)
                    {
                        // extracting cell value from 0 to 9 and add it on list
                        if (v > 0)
                        {
                            textstr.Append(",");
                        }

                        string tempstr = DataGridView1.Rows[x].Cells[v].Value.ToString();
                        tempstr = tempstr.Replace(",", ""); // remove any commas input into any field so csv file is not corrupted
                        textstr.Append(tempstr);
                    }
                }
                // adding new line to text
                textstr.AppendLine();
            }

            System.IO.File.WriteAllText(FName, textstr.ToString());
            return;
        }

        private void btnExitNoSave_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void btnOpenCSV_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader myStream = null;
            var openFileDialog1 = new OpenFileDialog();
            if ((DataSet1.DataSetName ?? "") == (tablename ?? ""))
            {
                DataSet1.Dispose();
                DataSet1 = new DataSet();
                DataGridView1.DataSource = Constants.vbNull;
            }

            DataSet1.Tables.Add(tablename);
            DataSet1.DataSetName = tablename;
            DataGridView1.DataSource = DataSet1;
            openFileDialog1.InitialDirectory = "./";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
            openFileDialog1.Title = "Open CSV Text File";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    return;
                }

                ReadError = false;
                FileLoading = true;
                int ReadNum = 0;
                try
                {
                    myStream = new System.IO.StreamReader(openFileDialog1.FileName);
                    if (myStream is object)
                    {
                        SLOpenFName = openFileDialog1.FileName;
                        lblOpenFN.Visible = true;
                        txtOpenFN.Visible = true;
                        txtOpenFN.Text = SLOpenFName;
                        string allData = myStream.ReadToEnd();
                        var rows = allData.Split(Conversions.ToChar(Constants.vbCrLf)); // ("\r".ToCharArray())
                        int incr1 = 0;
                        foreach (string r in rows)
                        {
                            string r1;
                            r1 = r.Trim(Conversions.ToChar(Constants.vbLf)).Trim();
                            if (ReadNum == 0)
                            {
                                r1 = r.Trim(Conversions.ToChar(Constants.vbLf)).Trim();
                                var items = r1.Split(',');
                                for (int ctr = 0, loopTo = Information.UBound(items); ctr <= loopTo; ctr++)
                                    DataSet1.Tables[tablename].Columns.Add(items[ctr]);
                            }
                            else
                            {
                                r1 = r.Trim(Conversions.ToChar(Constants.vbLf)).Trim();
                                var items1 = r1.Split(',');
                                if (!string.IsNullOrEmpty(items1[0]) & items1[0] != default)
                                {
                                    DataSet1.Tables[tablename].Rows.Add(items1);
                                }
                            }

                            ReadNum += 1;
                            incr1 += 1;
                        }

                        myStream.Close();
                        btnSaveFile.Visible = true;
                        btnExit.Visible = true;
                    }

                    myStream.Dispose();
                    DataGridView1.DataSource = DataSet1.Tables[0].DefaultView;
                    DataGridView1.Refresh();
                    FileLoading = false;
                    Refresh();
                }
                catch (Exception Ex)
                {
                    ErrorMsgBox("Cannot read file from disk. Original error: " + Ex.Message);
                }
                finally
                {
                    // Check this again, since we need to make sure we didn't throw an exception on open.
                    if (myStream is object)
                    {
                        myStream.Close();
                    }
                }
            }
            else
            {
                btnSaveFile.Visible = false;
                btnExit.Visible = false;
            }
        }

        private void ErrorMsgBox(string ErrMsg)
        {
            MessageBox.Show(ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            return;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveDataGrid();
            return;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnInfoForm_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.CSVUpdaterInfo.Show();
            return;
        }
    }
}