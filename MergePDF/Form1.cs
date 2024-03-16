using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace MergePDF
{
    public partial class MainForm : Form
    {
        private List<PDF_File> files;
        private ToolTip toolTip;

        public MainForm()
        {
            InitializeComponent();
            this.files = new List<PDF_File>();
            setDefaultImage();

            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000; // Задержка перед автоматическим закрытием
            toolTip.InitialDelay = 1000; // Задержка перед появлением подсказки
            toolTip.ReshowDelay = 500; // Задержка перед повторным появлением подсказки
            toolTip.ShowAlways = true; // Показывать подсказку даже когда форма не активна

            setBaseTooltips();
        }

        private void setBaseTooltips ()
        {
            toolTip.SetToolTip(DropImage,   "Перенесите сюда .pdf файлы для склеивания"     + Environment.NewLine + "Так же можно перенести папку с .pdf файлами");
            toolTip.SetToolTip(btnUp,       "Перенести .pdf файл вверх по очереди"          + Environment.NewLine + "P.S.: Можно выделить несколько .pdf файлов");
            toolTip.SetToolTip(btnDown,     "Перенести .pdf файл вниз по очереди"           + Environment.NewLine + "P.S.: Можно выделить несколько .pdf файлов");
            toolTip.SetToolTip(BtnDelete,   "Удалить .pdf файл из очереди на склеивание"    + Environment.NewLine + "P.S.: Можно выделить несколько .pdf файлов");
            toolTip.SetToolTip(BtnMerge,    "Склеить .pdf файлы в порядке очереди");
        }

        private void CreateFileItem (string _path)
        {
            string[] splitPath = _path.Split('\\');
            if (splitPath.Length == 0) return;

            string filename = splitPath[splitPath.Length - 1];
            string[] splitFilename = filename.Split('.');

            string extension = splitFilename[splitFilename.Length - 1];

            if (extension.ToLower() == "pdf")
            {
                this.files.Add(new PDF_File(this.files.Count + 1, _path, filename));
            }
        }

        private void FileListFill()
        {
            FileList.Items.Clear();
            FileList.FullRowSelect = true;
            FileList.ShowItemToolTips = true;
            FileListNumChecked();

            foreach (var file in this.files)
            {
                ListViewItem item = new ListViewItem(file.Num.ToString());
                item.SubItems.Add(file.FileName);
                item.BackColor = Color.White;
                item.ToolTipText = file.Path;

                FileList.Items.Add(item); 
            }
            this.Controls.Add(FileList);
        }

        private void FileListNumChecked()
        {
            for (int i = 0; i < this.files.Count; i++)
            {
                this.files[i].Num = i + 1;
            }
        }

        private void evDragPanelDrop(object sender, DragEventArgs e)
        {
            foreach (var obj in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(obj))
                {
                    string[] files = Directory.GetFiles(obj, "*.pdf", SearchOption.AllDirectories);
                    foreach (var file in files) CreateFileItem(file);
                }
                else
                {
                    CreateFileItem(obj);
                }
            }
            FileListFill();
            setDefaultImage();
        }

        private void evDragPanelEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void evDragPanelLeave(object sender, EventArgs e)
        {
            setDefaultImage();
        }

        private void evDragPanelOver(object sender, DragEventArgs e)
        {
            setHoverImage();
        }

        private void setHoverImage ()
        {
            try
            {
                Image image = Properties.Resources.plus_hover_state;
                DropImage.BackgroundImage = image;
                DropImage.BackgroundImageLayout = ImageLayout.Zoom;
                DropImage.BackColor = Color.Transparent;

                Color color = ColorTranslator.FromHtml("#12000000");
                DropPanel.BackColor = color;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
            }
        }

        private void setDefaultImage()
        {
            try
            {
                Image image = Properties.Resources.plus_default_state;
                DropImage.BackgroundImage = image;
                DropImage.BackgroundImageLayout = ImageLayout.Zoom;
                DropImage.BackColor = Color.Transparent;

                Color color = ColorTranslator.FromHtml("#00000000");
                DropPanel.BackColor = color;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (FileList.Items.Count > 0)
            {
                foreach (ListViewItem item in FileList.SelectedItems)
                {
                    files.RemoveAll(file => file.Num == Convert.ToInt32(item.SubItems[0].Text));
                }
                FileListFill();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (FileList.SelectedItems.Count == 0) return;

            int firstIndex = Convert.ToInt32(FileList.SelectedItems[0].Text) - 1;
            int len = FileList.SelectedItems.Count;

            if (firstIndex == 0) return;
        
            List<int> selectedIndexList = new List<int>();

            for (int currentIndex = firstIndex; currentIndex < firstIndex + len; currentIndex++)
            {
                PDF_File currentItem = files[currentIndex];
                files.RemoveAt(currentIndex);
                files.Insert(currentIndex - 1, currentItem);

                selectedIndexList.Add(currentIndex - 1);
            }
            FileListFill();

            foreach (int selectedIndex in selectedIndexList)
            {
                FileList.Items[selectedIndex].Selected = true;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (FileList.SelectedItems.Count == 0) return;

            int lastIndex = Convert.ToInt32(FileList.SelectedItems[FileList.SelectedItems.Count - 1].Text) - 1;
            int len = FileList.SelectedItems.Count;

            if (lastIndex == files.Count - 1) return;

            List<int> selectedIndexList = new List<int>();

            for (int currentIndex = lastIndex; currentIndex > lastIndex - len; currentIndex--)
            {
                PDF_File currentItem = files[currentIndex];
                files.RemoveAt(currentIndex);
                files.Insert(currentIndex + 1, currentItem);

                selectedIndexList.Add(currentIndex + 1);
            }
            FileListFill();

            foreach (int selectedIndex in selectedIndexList)
            {
                FileList.Items[selectedIndex].Selected = true;
            }
        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            if (FileList.Items.Count <= 1) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Сохранить объединенный PDF файл";
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                string outputPath = saveFileDialog.FileName;

                try
                {
                    PdfDocument outputDocument = new PdfDocument();

                    foreach (var pdfFile in this.files)
                    {
                        PdfDocument inputDocument = PdfReader.Open(pdfFile.Path, PdfDocumentOpenMode.Import);

                        foreach (PdfPage page in inputDocument.Pages)
                        {
                            outputDocument.AddPage(page);
                        }

                        inputDocument.Close();
                    }

                    outputDocument.Save(outputPath);

                    MessageBox.Show("PDF файлы успешно объединены и сохранены в " + outputPath, "Успешно :)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при объединении и сохранении PDF файлов: " + ex.Message, "Упс... что-то сломалось.");
                }
            }
        }
    }

    public class PDF_File
    {
        public int Num          { get; set; }
        public string Path      { get; set; }
        public string FileName  { get; set; }

        public PDF_File(int _num, string _path, string _filename)
        {
            this.Num = _num;
            this.Path = _path;
            this.FileName = _filename;
        }
    }
}
