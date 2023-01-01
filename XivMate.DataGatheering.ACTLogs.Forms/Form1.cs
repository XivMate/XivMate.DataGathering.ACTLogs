using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using XivMate.DataGatheering.ACTLogs.Forms.Properties;

namespace XivMate.DataGatheering.ACTLogs.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private DirectoryInfo ActLogFileDirectory => new(actLogLocationTextBox.Text);

    private DirectoryInfo XivMateDirectory =>
        new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "XivMate"));

    private void Form1_Load(object sender, EventArgs e)
    {
        var logLocation = Environment.ExpandEnvironmentVariables(Settings.Default.ACTLogLocation);
        actLogLocationTextBox.Text = logLocation;

        var outputLocation = Environment.ExpandEnvironmentVariables(Settings.Default.OutputDirectory);
        outputLogTxt.Text=outputLocation;
    }

    private void validateBtn_Click(object sender, EventArgs e)
    {
        var actDirectory = ActLogFileDirectory;
        if (!actDirectory.Exists)
        {
            MessageBox.Show("Could not find ACT Logs", $"Path: {actDirectory.FullName}", MessageBoxButtons.OK);
            return;
        }

        // Make our folder where we'll store our ACT stuff


        if (!XivMateDirectory.Exists)
            XivMateDirectory.Create();

        // Try to write a file in there
        //UpdateView(GetLogSettings(XivMateDirectory.FullName));
    }

    public ACTLogSettings GetLogSettings(string folder)
    {
        var logSettingsPath = GetLogSettingsPath(folder);
        if (!File.Exists(logSettingsPath))
            SaveLogSettings(folder, new ACTLogSettings());
        return JsonConvert.DeserializeObject<ACTLogSettings>(File.ReadAllText(logSettingsPath));
    }

    private void SaveLogSettings(string folder, ACTLogSettings actLogSettings)
    {
        var logSettingsPath = GetLogSettingsPath(folder);
        File.WriteAllText(logSettingsPath, JsonConvert.SerializeObject(actLogSettings));
    }

    private string GetLogSettingsPath(string folder)
    {
        return Path.Combine(folder, "ActScan.json");
    }

    private void findFilesBtn_Click(object sender, EventArgs e)
    {
        var actFolder = ActLogFileDirectory;
        var settings = GetLogSettings(XivMateDirectory.FullName);

        var logFiles = GetActLogFilesInFolder(actFolder, settings);

        SaveLogSettings(XivMateDirectory.FullName, settings);
        UpdateView(logFiles);
    }

    private static List<ACTLogFile> GetActLogFilesInFolder(DirectoryInfo actFolder, ACTLogSettings settings)
    {
        var logFiles = new List<ACTLogFile>();

        foreach (var enumerateFile in actFolder.EnumerateFiles("*.log"))
        {
            var matchingLog = settings.ActLogFiles.FirstOrDefault(p => p.FileName == enumerateFile.Name);
            // Case 1 - not seen before
            if (matchingLog == null)
            {
                var newLogFile = new ACTLogFile
                {
                    ActLogFileStatus = ACTLogFileStatus.Unchecked,
                    FileName = enumerateFile.Name,
                    FileLength = enumerateFile.Length
                };
                settings.ActLogFiles.Add(newLogFile);
                logFiles.Add(newLogFile);
                continue;
            }

            if (matchingLog.FileLength != enumerateFile.Length)
            {
                matchingLog.ActLogFileStatus = ACTLogFileStatus.Changed;
            }

            logFiles.Add(matchingLog);
        }

        return logFiles;
    }

    private void UpdateView(List<ACTLogFile> logFiles)
    {
        aCTLogFileBindingSource.DataSource = logFiles;
    }

    private void parseFileBtn_Click(object sender, EventArgs e)
    {
        DisableButtons();

        var settings = GetLogSettings(XivMateDirectory.FullName);
        var logs = GetActLogFilesInFolder(ActLogFileDirectory, settings);
        //Setup worker
        var worker = new LogFileBackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.ProgressChanged += (o, args) =>
        {
            parseFileProgBar.Value = args.ProgressPercentage;
            if (args.UserState != null)
            {
                if (args.UserState is string str)
                {
                    parseFileTitleLabel.Text = $"Parsing {str}";
                }
                else if (args.UserState is LogFileProcessResult result)
                {
                    var matchingLog = settings.ActLogFiles.First(x => x.FileName == result.LogFile);
                    matchingLog.ActLogFileStatus = result.HasRelevantLogs ? ACTLogFileStatus.Exported : ACTLogFileStatus.NoMatches;
                    //I'm too lazy
                    logs.RemoveAll(log => log.FileName == matchingLog.FileName);
                    logs.Add(matchingLog);
                    UpdateView(logs);
                    SaveLogSettings(XivMateDirectory.FullName, settings);
                    Console.WriteLine(result.HasRelevantLogs);
                }
            }
            else
            {
                parseFileTitleLabel.Text = "";
                EnableButtons();
            }
        };

        var files = logs
            .Where(p => p.ActLogFileStatus == ACTLogFileStatus.Changed ||
                        p.ActLogFileStatus == ACTLogFileStatus.Unchecked ||
                        p.ActLogFileStatus == ACTLogFileStatus.Matches).Select(p => p.FileName);

        var outputDir = Path.Combine(outputLogTxt.Text, "LogOutput");

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        worker.RunWorkerAsync(new LogFileProcessRequest
        {
            OutputDirectory = outputDir,
            ActLogFileDirectory = ActLogFileDirectory.FullName,
            ActLogFiles = files.ToList()
        });
    }

    private void EnableButtons()
    {
        findFilesBtn.Enabled = true;
        validateBtn.Enabled = true;
        parseFileBtn.Enabled = true;
    }

    private void DisableButtons()
    {
        findFilesBtn.Enabled = false;
        validateBtn.Enabled = false;
        parseFileBtn.Enabled = false;
    }
}