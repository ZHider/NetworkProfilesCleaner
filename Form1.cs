using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace NetworkProfilesCleaner
{
    public partial class Form1 : Form
    {
        // public RegistryView regView;
        public string systemBits;


        public Form1()
        {
            InitializeComponent();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            button_refresh.Enabled = false;

            // 打开注册表项
            var key = Registry.LocalMachine
                .OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkList\\Profiles");

            if (key == null)
            {
                MessageBox.Show("Error when opening key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBox_2clean.Items.Clear();
            listBox_2save.Items.Clear();

            // 同步读取注册表
            foreach (string subKeyName in key.GetSubKeyNames())
            {
                profile p = new profile(key.OpenSubKey(subKeyName));

                this.Invoke(new Action(() => {
                    listBox_2clean.Items.Add(p);
                }));
            }


            button_refresh.Enabled = true;
        }

        private void button_c2s_Click(object sender, EventArgs e)
        {
            if (listBox_2clean.SelectedItems.Count == 0) { return; }
            Utils.swapListBoxSelectedItems(listBox_2clean, listBox_2save);
        }

        private void button_s2c_Click(object sender, EventArgs e)
        {
            if (listBox_2save.SelectedItems.Count == 0) { return; }
            Utils.swapListBoxSelectedItems(listBox_2save, listBox_2clean);
        }

        private void button_swap_Click(object sender, EventArgs e)
        {
            Utils.swapListBoxItems(listBox_2clean, listBox_2save);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            if (listBox_2clean.Items.Count == 0
                || MessageBox.Show(
                    "Are you going to deleted all the network profiles in the Clear list?", 
                    "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                    ) != DialogResult.Yes)
                { return; }

            // 打开注册表项
            var rootKey = Registry.LocalMachine
                .OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkList\\Profiles", true);

            var exceptions = new List<Exception>();
            var profiles2clean = Utils.extractItems(listBox_2clean.Items).Cast<profile>();
            foreach (var p in profiles2clean)
            {
                try
                {
                    rootKey.DeleteSubKeyTree(p.GUID);
                    listBox_2clean.Items.Remove(p);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
                
            }

            if (exceptions.Count == 0)
            {
                MessageBox.Show("Cleaned all!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(exceptions[0].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_backup_Click(object sender, EventArgs e)
        {
            if (listBox_2clean.Items.Count == 0) { return; }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Registry File|*.reg";
            saveFileDialog1.Title = "Save profiles backup";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "") { return; }

            Utils.ExportRegistryKeyArray(
                listBox_2clean.Items.Cast<profile>().Select(
                    profile => "HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkList\\Profiles\\" + profile.GUID),
                saveFileDialog1.FileName
            );

            MessageBox.Show("Backuped all profiles in Clean list!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            Process.Start("reg.exe",
                @"ADD HKCU\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit /v LastKey /t REG_SZ /d "
                + "\""
                + @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles"
                + "\""
                + " /f /reg:" + systemBits).WaitForExit();
            Process.Start("C:\\Windows\\regedit", "-m");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            // 32位进程只能打开32位regedit.exe，32位和64位有些注册表是隔离的
            // button_open.Enabled = !(Environment.Is64BitOperatingSystem ^ Environment.Is64BitProcess);

            // 32Bits / 64Bits 注册表兼容
            if (IntPtr.Size == 8)
            {
                // regView = RegistryView.Registry64;
                systemBits = "64";
                this.Text += " x64";
            }
            else
            {
                // regView = RegistryView.Registry32;
                systemBits = "32";
                this.Text += " x32";
            }
        }

        private void checkBox_mutiline_CheckedChanged(object sender, EventArgs e)
        {
            listBox_2clean.MultiColumn = checkBox_mutiline.Checked;
            listBox_2save.MultiColumn = checkBox_mutiline.Checked;
        }
    }


    public static class Utils
    {
        public static object[] extractItems(ICollection items)
        {
            object[] temp = new object[items.Count];
            items.CopyTo(temp, 0);
            return temp;
        }

        /// <summary>
        /// 交换两个 ListBox 控件的表项
        /// </summary>
        public static void swapListBoxItems(ListBox from, ListBox to)
        {
            var temp = extractItems(from.Items);

            from.Items.Clear();
            from.Items.AddRange(to.Items);
            to.Items.Clear();
            to.Items.AddRange(temp);

        }

        /// <summary>
        /// 传送两个 ListBox 控件的已选中表项
        /// </summary>
        public static void swapListBoxSelectedItems(ListBox from, ListBox to)
        {
            var temp = extractItems(from.SelectedItems);

            foreach (var item in temp)
            {
                from.Items.Remove(item);
                to.Items.Add(item);
            }

        }

        /// <summary>
        /// 导出列表中的每一个注册表项，并合并为一个reg文件并导出
        /// </summary>
        /// <param name="registryKeys">注册表项的完整路径</param>
        /// <param name="outputFile">输出文件名</param>
        public static void ExportRegistryKeyArray(IEnumerable<string> registryKeys, string outputFile)
        {
            // 新建一个临时文件夹，把中间文件都放进去
            var TempDirPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            /// 用于获取在这个临时文件夹中的文件名
            string TempFilePath(string filename)
            {
                var _filename = filename + ".reg";
                return Path.Combine(TempDirPath, _filename);
            }

            /// 阻塞同步的使用 REG.EXE 导出注册表为 REG 文件
            Process ExportRegSync(string keysPath, string outFile, string systemBits)
            {
                var arg = $"EXPORT \"{keysPath}\" \"{outFile}\" /y /reg:{systemBits}";
                var startInfo = new ProcessStartInfo("reg.exe", arg)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                var process = new Process { StartInfo = startInfo };
                process.Start();
                process.WaitForExit();

                return process;
            }

            // 注册表路径数组化来获取长度
            var rKeys = registryKeys.ToArray();
            // 用来存放线程的标准错误输出
            string[] threadsStdError = new string[rKeys.Length];

            bool msgBoxRetry;

            // 如果重新开始，就从这里开始
            keyBackupStart:

            // 重试信息框值
            msgBoxRetry = false;

            try
            {
                // 创建临时文件夹
                Directory.CreateDirectory(TempDirPath);

                // 判断系统位数
                string systemBits;
                if (IntPtr.Size == 8) 
                { systemBits = "64"; }
                else { systemBits = "32"; }


                // 为每个注册表项创建一个临时.reg文件
                var tempFiles = 
                    Enumerable.Range(0, rKeys.Length)
                    .Select(i => TempFilePath(i.ToString("D4")))
                    .ToArray();
                
                
                var threads = rKeys.Select((keysPath, i) =>
                    new Thread(() =>
                    {
                        var process = ExportRegSync(keysPath, tempFiles[i], systemBits);

                        var stdErr = process.StandardError.ReadToEnd().Trim();
                        Console.WriteLine(process.StartInfo.Arguments + "\n"
                            + process.StandardOutput.ReadToEnd().Trim() + "|"
                            + stdErr
                        );

                        // 储存标准错误
                        threadsStdError[i] = stdErr;
                    }
                )).ToList();
                threads.ForEach( t => t.Start());

                // 等待所有线程执行完毕
                threads.ForEach((t) => t.Join());

                // 将所有临时.reg文件合并到新的.reg文件
                var tmpOutfile = TempFilePath("output");
                foreach (string tempFile in tempFiles)
                {
                    File.AppendAllText(tmpOutfile, File.ReadAllText(tempFile) + "\n");
                }
                // 移动文件为最终输出文件
                File.Copy(tmpOutfile, outputFile, true);
            }
            catch (FileNotFoundException ex)
            {
                var errOutputs = threadsStdError
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Select(s => s.Trim())
                    .ToArray();
                var msgBox = MessageBox.Show(
                    "Error when backup: " + ex.Message
                    + "\nWith Error output:\n"
                    + string.Join(Environment.NewLine, errOutputs),
                    "Backup Error",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error
                );
                msgBoxRetry = msgBox == DialogResult.Retry;
            }
            finally
            {
                // 删除临时文件夹
                Directory.Delete(TempDirPath, true);
            }

            // 如果重试就重新开始
            if (msgBoxRetry) { goto keyBackupStart; }

        }
    }

    internal struct profile
    {
        public object Name;
        public string GUID;
        public RegistryKey key;

        public profile(RegistryKey key)
        {
            this.key = key;
            this.Name = key.GetValue("ProfileName");
            this.GUID = Path.GetFileName(key.Name);
        }

        public override bool Equals(object obj)
        {
            return obj is profile other &&
                   GUID == other.GUID;
        }

        public override int GetHashCode()
        {
            int hashCode = EqualityComparer<string>.Default.GetHashCode(GUID);
            return hashCode;
        }

        public void Deconstruct(out object name, out string guid)
        {
            name = Name;
            guid = this.GUID;
        }

        public override string ToString()
        {
            return this.Name as string;
        }
    }
}
