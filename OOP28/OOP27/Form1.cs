using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace OOP27
{
    public partial class Form1 : Form
    {
        private Stack<Action> actionsStack = new Stack<Action>();
        // Константи для виклику функції SHFileOperation
        private const int FO_DELETE = 3;
        private const int FOF_ALLOWUNDO = 0x40;
        private const int FOF_NOCONFIRMATION = 0x0010;

        // Сигнатура функції SHFileOperation
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

        // Структура SHFILEOPSTRUCT, яка використовується для виклику SHFileOperation
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public int wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }
        private string currentDirectory;
        private List<string> copiedFiles = new List<string>();
        private List<string> selectedFiles = new List<string>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            listView1.MouseUp += listView1_MouseUp;
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode != null)
            {
                string selectedPath = selectedNode.FullPath;

                if (Directory.Exists(selectedPath))
                {
                    currentDirectory = selectedPath;
                    LoadDirectories(selectedPath, selectedNode);
                    LoadFiles(selectedPath);
                }
            }
            if (selectedNode != null)
            {
                string selectedPath = selectedNode.FullPath;
                textBox1.Text = selectedPath; // Оновлення значення textBox1 з вибраним шляхом
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string selectedFileName = selectedItem.Text;
                string selectedFilePath = Path.Combine(currentDirectory, selectedFileName);

                if (File.Exists(selectedFilePath))
                {
                    FileInfo fileInfo = new FileInfo(selectedFilePath);
                    ShowFileProperties(fileInfo);
                }
            }
        }

        private void LoadDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.ImageIndex = 0;

                treeView1.Nodes.Add(driveNode);
            }
        }

        private void LoadDirectories(string path, TreeNode parentNode)
        {
            try
            {
                if (!Directory.Exists(path))
                    return;

                DirectoryInfo directory = new DirectoryInfo(path);

                // Очищення попередніх підтек та файлів
                parentNode.Nodes.Clear();
                listView1.Items.Clear();
                imageList1.Images.Clear();

                // Додавання батьківської теки до ListView
                if (parentNode.Parent != null)
                {
                    ListViewItem parentItem = new ListViewItem("..");
                    parentItem.ImageIndex = 1; // Індекс іконки теки
                    listView1.Items.Add(parentItem);
                }

                int imageIndex = 2; // Початковий індекс для іконок файлів

                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    TreeNode directoryNode = new TreeNode(subDirectory.Name);
                    directoryNode.ImageIndex = 1; // Індекс іконки теки

                    parentNode.Nodes.Add(directoryNode);

                    // Додавання теки до ListView
                    ListViewItem item = new ListViewItem(subDirectory.Name);
                    item.ImageIndex = 1; // Індекс іконки теки у списку зображень

                    listView1.Items.Add(item);
                }

                foreach (FileInfo file in directory.GetFiles())
                {
                    Icon fileIcon = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(fileIcon);

                    // Додавання файлу до ListView з відповідною іконкою
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add(file.Length.ToString());
                    item.SubItems.Add(file.LastWriteTime.ToString());
                    item.ImageIndex = imageIndex; // Встановлення індексу зображення

                    listView1.Items.Add(item);

                    imageIndex++; // Інкремент індексу зображення для наступного файлу
                }
            }
            catch
            {
                return;
            }
        }

        private void LoadFiles(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                listView1.Items.Clear();
                imageList1.Images.Clear();

                int imageIndex = 0;

                foreach (FileInfo file in directory.GetFiles())
                {
                    Icon fileIcon = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(fileIcon);
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add(FormatSize(file.Length));
                    item.SubItems.Add(file.LastWriteTime.ToString());
                    item.ImageIndex = imageIndex; 

                    listView1.Items.Add(item);

                    imageIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading files: " + ex.Message);
            }
        }

        private void ShowFileProperties(FileInfo fileInfo)
        {
            label1.Text = fileInfo.Name;
            label2.Text = "Створено: " + fileInfo.CreationTime.ToString();
            label3.Text = "Оновлено: " + fileInfo.LastWriteTime.ToString();
            label4.Text = "Розмір: " + FormatSize(fileInfo.Length);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.AfterSelect += treeView1_AfterSelect;
            LoadDrives();

            listView1.LargeImageList = imageList1;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            if (Directory.Exists(path))
            {
                currentDirectory = path;
                LoadDirectories(path, null); 
                LoadFiles(path);
            }
            else
            {
                MessageBox.Show("Вказано недійсний шлях до папки.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox2.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                List<string> matchingFiles = SearchFiles(currentDirectory, searchTerm);

                if (matchingFiles.Count > 0)
                {
                    // Очищаємо ListView та imageList1
                    listView1.Items.Clear();
                    imageList1.Images.Clear();

                    foreach (string file in matchingFiles)
                    {
                        // Додаємо знайдений файл до ListView
                        ListViewItem item = new ListViewItem(file);
                        item.SubItems.Add(""); // Порожнє значення для додаткових стовпців (розмір, дата)

                        // Отримуємо іконку файлу
                        Icon fileIcon = Icon.ExtractAssociatedIcon(file);
                        imageList1.Images.Add(fileIcon);

                        // Встановлюємо індекс зображення для елементу
                        item.ImageIndex = imageList1.Images.Count - 1;

                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Файли зі словом \"" + searchTerm + "\" не знайдені.");
                }
            }
            else
            {
                MessageBox.Show("Введіть слово для пошуку.");
            }
        }
        private List<string> SearchFiles(string path, string searchTerm)
        {
            List<string> matchingFiles = new List<string>();

            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    if (file.Name.Contains(searchTerm))
                    {
                        matchingFiles.Add(file.FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час пошуку файлів: " + ex.Message);
            }

            return matchingFiles;
        }

        private string FormatSize(long size)
        {
            const long KB = 1024;
            const long MB = KB * 1024;
            const long GB = MB * 1024;

            string sizeText;

            if (size >= GB)
            {
                double sizeInGB = (double)size / GB;
                sizeText = string.Format("{0:0.00} ГБ", sizeInGB);
            }
            else if (size >= MB)
            {
                double sizeInMB = (double)size / MB;
                sizeText = string.Format("{0:0.00} МБ", sizeInMB);
            }
            else if (size >= KB)
            {
                double sizeInKB = (double)size / KB;
                sizeText = string.Format("{0:0.00} КБ", sizeInKB);
            }
            else
            {
                sizeText = size.ToString() + " байт";
            }

            return sizeText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null)
            {
                treeView1.SelectedNode = treeView1.SelectedNode.Parent;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Nodes.Count > 0)
            {
                treeView1.SelectedNode = treeView1.SelectedNode.Nodes[0];
            }
        }
        private void CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                LoadDirectories(currentDirectory, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка створення каталогу: " + ex.Message);
            }
        }
        private void Copy(string sourcePath, string destinationPath)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, destinationPath);
                }
                else if (Directory.Exists(sourcePath))
                {
                    CopyDirectory(sourcePath, destinationPath);
                }

                LoadDirectories(currentDirectory, null);
                LoadFiles(currentDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка копіювання: " + ex.Message);
            }
        }
        private void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(sourceDirectory);
            DirectoryInfo destinationDirectoryInfo = new DirectoryInfo(destinationDirectory);

            if (!destinationDirectoryInfo.Exists)
            {
                destinationDirectoryInfo.Create();
            }

            foreach (FileInfo file in sourceDirectoryInfo.GetFiles())
            {
                string destinationFilePath = Path.Combine(destinationDirectory, file.Name);
                file.CopyTo(destinationFilePath, true);
            }

            foreach (DirectoryInfo subDirectory in sourceDirectoryInfo.GetDirectories())
            {
                string destinationSubDirectoryPath = Path.Combine(destinationDirectory, subDirectory.Name);
                CopyDirectory(subDirectory.FullName, destinationSubDirectoryPath);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string selectedFileName = selectedItem.Text;
                string selectedFilePath = Path.Combine(currentDirectory, selectedFileName);

                if (File.Exists(selectedFilePath))
                {
                    // Відкриття файлу за допомогою застосунку за замовчуванням
                    try
                    {
                        System.Diagnostics.Process.Start(selectedFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка відкриття файлу: " + ex.Message);
                    }
                }
            }
        }

        private void копіюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedFiles.Clear();

            foreach (ListViewItem selectedItem in listView1.SelectedItems)
            {
                string selectedFileName = selectedItem.Text;
                string selectedFilePath = Path.Combine(currentDirectory, selectedFileName);

                if (File.Exists(selectedFilePath))
                {
                    selectedFiles.Add(selectedFilePath);
                }
            }
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Питання користувача для підтвердження видалення
                DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити вибрані файли?", "Підтвердження видалення", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach (ListViewItem selectedItem in listView1.SelectedItems)
                        {
                            string selectedFileName = selectedItem.Text;
                            string selectedFilePath = Path.Combine(currentDirectory, selectedFileName);

                            if (File.Exists(selectedFilePath))
                            {
                                // Виклик функції SHFileOperation для переміщення файлу у корзину
                                SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT();
                                fileOp.wFunc = FO_DELETE;
                                fileOp.pFrom = selectedFilePath + '\0'; // Додаємо символ '\0' для позначення кінця списку файлів
                                fileOp.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;

                                int operationResult = SHFileOperation(ref fileOp);

                                if (operationResult != 0)
                                {
                                    MessageBox.Show("Помилка видалення файлу: " + selectedFileName);
                                }
                            }
                        }

                        LoadFiles(currentDirectory);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка видалення файлу: " + ex.Message);
                    }
                }
            }
        }

        private void перейменуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedItem.BeginEdit();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть лише один елемент для перейменування.");
            }
        }

        private void архіваціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "ZIP Archive (*.zip)|*.zip";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string archivePath = dialog.FileName;
                        using (var archive = ZipFile.Open(archivePath, ZipArchiveMode.Create))
                        {
                            foreach (ListViewItem item in listView1.SelectedItems)
                            {
                                string filePath = item.Tag.ToString();
                                string fileName = Path.GetFileName(filePath);
                                archive.CreateEntryFromFile(filePath, fileName);
                                string path = textBox1.Text;

                                if (Directory.Exists(path))
                                {
                                    currentDirectory = path;
                                    LoadDirectories(path, null);
                                    LoadFiles(path);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void розпакуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string extractPath = dialog.SelectedPath;
                        foreach (ListViewItem item in listView1.SelectedItems)
                        {
                            string filePath = item.Tag.ToString();
                            using (var archive = ZipFile.OpenRead(filePath))
                            {
                                foreach (var entry in archive.Entries)
                                {
                                    string entryPath = Path.Combine(extractPath, entry.FullName);
                                    entry.ExtractToFile(entryPath, true);
                                    string path = textBox1.Text;

                                    if (Directory.Exists(path))
                                    {
                                        currentDirectory = path;
                                        LoadDirectories(path, null);
                                        LoadFiles(path);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem != null && listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count == 0)
            {
                contextMenuStrip2.Show(listView1, e.Location);
            }
        }

        private void вставитиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (string filePath in selectedFiles)
            {
                string selectedFileName = Path.GetFileName(filePath);
                string selectedFileExtension = Path.GetExtension(filePath);
                string destinationFileName = selectedFileName;

                int counter = 1;
                while (File.Exists(Path.Combine(currentDirectory, destinationFileName)))
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(selectedFileName);
                    string incrementedFileName = $"{fileNameWithoutExtension}({counter}){selectedFileExtension}";
                    destinationFileName = incrementedFileName;
                    counter++;
                }

                string destinationPath = Path.Combine(currentDirectory, destinationFileName);
                File.Copy(filePath, destinationPath);
            }

            listView1.Items.Clear();
            LoadFiles(currentDirectory);
        }

        private void відмінитиДіїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string filePath in copiedFiles)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            // Очищаємо списки
            selectedFiles.Clear();
            copiedFiles.Clear();

            listView1.Items.Clear();
            LoadFiles(currentDirectory);
        }

        private void створитиНовийФайлToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
                // Створення екземпляру SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Встановлення фільтру файлів
                saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*";

                // Відкриття діалогового вікна збереження файлу
                DialogResult result = saveFileDialog.ShowDialog();

                // Перевірка, чи користувач вибрав файл
                if (result == DialogResult.OK)
                {
                    // Отримання шляху до обраного файлу
                    string filePath = saveFileDialog.FileName;

                    // Створення нового файлу за допомогою FileStream
                    using (FileStream fs = File.Create(filePath))
                    {
                        // Можна виконати додаткові дії з файлом, які потрібні
                    }
                string path = textBox1.Text;

                if (Directory.Exists(path))
                {
                    currentDirectory = path;
                    LoadDirectories(path, null);
                    LoadFiles(path);
                }
                // Оповіщення користувача про успішне створення файлу
                MessageBox.Show("Файл створено успішно!");

            }
        }
    }
}